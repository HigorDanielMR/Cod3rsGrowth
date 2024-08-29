sap.ui.define([
    "ui5/carro/app/common/BaseController",
    "sap/ui/model/json/JSONModel",
    "ui5/carro/model/formatter"

], function (BaseController, JSONModel, Formatter) {
    "use strict";

    const ID = "id";
    const MODELO_VENDA = "Vendas";
    const ROTA_LISTAGEM = "appListagem";
    const ROTA_DETALHES = "appDetalhes";
    const ID_DO_FILTRO_CPF = "FiltroCpf";
    const ID_DO_FILTRO_NOME = "FiltroNome";
    const ID_DO_FILTRO_TELEFONE = "FiltroTelefone";
    const ROTA_LISTAGEM_CARROS = "appListagemCarro";
    const ROTA_ADICIONAR_VENDA = "appAdicionarVenda";
    const URL_API = "http://localhost:5071/api/Vendas";    

    return BaseController.extend("ui5.carro.app.vendas.ListagemVenda", {
        formatter: Formatter,

        onInit() {
            this.aoCoincidirRota();
        },

        _carregarListaDeVendas() {
            fetch(URL_API)
                .then((res) => {
                    return res.json()
                })
                .then((data) => {
                    const jsonModel = new JSONModel(data)

                    !data.Detail ? this.getView().setModel(jsonModel, MODELO_VENDA)
                        : this._erroNaRequisicaoDaApi(data);
                })
        },

        aoCoincidirRota() {
            this.processarEvento(() => {
                var rota = this.getRouter();
                rota.getRoute(ROTA_LISTAGEM).attachMatched(this._carregarListaDeVendas, this);
            });
        },
        
        obterNome() {
            return this.oView.byId(ID_DO_FILTRO_NOME).getValue();
        },

        obterCpf() {
            const quantidadeDeCaracteresDoCpf = 14;
            const cpf = this.oView.byId(ID_DO_FILTRO_CPF).getValue();
            return cpf.length < quantidadeDeCaracteresDoCpf ? '' : cpf;
        },

        obterTelefone() {
            const quantidadeDeCaracteresDoTelefone = 15;
            const telefone = this.oView.byId(ID_DO_FILTRO_TELEFONE).getValue();
            return telefone.length < quantidadeDeCaracteresDoTelefone ? '' : telefone;
        },

        obterDataInicial(oEvent) {
            const parametroDataInicial = "from";
            let dataInicial = oEvent.getParameter(parametroDataInicial);            
             return Formatter.formatarData(dataInicial);
        },

        obterDataFinal(oEvent) {
            const parametroDataFinal = "to";
            let dataFinal = oEvent.getParameter(parametroDataFinal);
            return Formatter.formatarData(dataFinal);
        },

        aoFiltrar(oEvent) {
            this.processarEvento(() => {
                let urlDoFiltro = URL_API + "?";
                const cpf = this.obterCpf();
                const nome = this.obterNome();
                const telefone = this.obterTelefone();
                const dataInicial = this.obterDataInicial(oEvent);
                const dataFinal = this.obterDataFinal(oEvent);

                if (nome) {
                    urlDoFiltro += "Nome=" + nome + "&";
                }

                if (cpf) {
                    urlDoFiltro += "Cpf=" + cpf + "&";
                }

                if (telefone) {
                    urlDoFiltro += "Telefone=" + telefone + "&";
                }

                if (dataInicial && dataFinal) {
                    urlDoFiltro += "DataDeCompraInicial=" + dataInicial + "&" + "DataDeCompraFInal=" + dataFinal;
                }

                else if (dataInicial) {
                    urlDoFiltro += "DataDeCompraInicial=" + dataInicial;
                }

                else if (dataFinal) {
                    urlDoFiltro += "DataDeCompraFinal=" + dataFinal;
                }

                fetch(urlDoFiltro)
                    .then((res) => {
                        return res.json()
                    })
                    .then((vendas) => {
                        const jsonModel = new JSONModel(vendas)
                        !vendas.Detail ? this.getView().setModel(jsonModel, MODELO_VENDA)
                            : this._erroNaRequisicaoDaApi(vendas);
                    })
            })
        },

        adicionarVenda() {
            this.processarEvento(() => {
                this.getRouter().navTo(ROTA_ADICIONAR_VENDA, {}, true);  
            })
        },

        aoClicarDeveIParaAListagemCarro(){
            this.processarEvento(() => {
                this.getRouter().navTo(ROTA_LISTAGEM_CARROS, {}, true);  
            })
        },

        aoPressionar(oEvent) {
            const oItem = oEvent.getSource();
            const oRouter = this.getOwnerComponent().getRouter();
            oRouter.navTo(ROTA_DETALHES, {
                id: window.encodeURIComponent(oItem.getBindingContext(MODELO_VENDA).getProperty(ID))
            });
        }
    });
});