sap.ui.define([
    "ui5/carro/app/common/BaseController",
    "sap/ui/model/json/JSONModel",
    "ui5/carro/model/formatter",
    "sap/m/MessageBox"

], function (BaseController, JSONModel, Formatter, MessageBox) {
    "use strict";

    const id = "id";
    const modeloVenda = "Vendas";
    const idDoFiltroCpf = "FiltroCpf";
    const rotaListagem = "appListagem";
    const rotaDetalhes = "appDetalhes";
    const idDoFiltroNome = "FiltroNome";
    const quantidadeDeCaracteresDoCpf = 14;
    const quantidadeDeCaracteresDoTelefone = 15;
    const idDoFiltroTelefone = "FiltroTelefone";
    const rotaListagemCarros = "appListagemCarro";
    const rotaAdicionarVenda = "appAdicionarVenda";
    const urlApi = "http://localhost:5071/api/Vendas";    

    return BaseController.extend("ui5.carro.app.vendas.ListagemVenda", {
        formatter: Formatter,

        onInit() {
            this.aoCoincidirRota();
        },

        _carregarListaDeVendas() {
            fetch(urlApi)
                .then((res) => {
                    return res.json()
                })
                .then((data) => {
                    const jsonModel = new JSONModel(data)

                    !data.Detail ? this.getView().setModel(jsonModel, modeloVenda)
                        : this._erroNaRequisicaoDaApi(data);
                })
        },

        aoCoincidirRota() {
            this.processarEvento(() => {
                var rota = this.getRouter();
                rota.getRoute(rotaListagem).attachMatched(this._carregarListaDeVendas, this);
            });
        },
        
        obterNome() {
            return this.oView.byId(idDoFiltroNome).getValue();
        },

        obterCpf() {
            const cpf = this.oView.byId(idDoFiltroCpf).getValue();
            return cpf.length < quantidadeDeCaracteresDoCpf ? '' : cpf;
        },

        obterTelefone() {
            const telefone = this.oView.byId(idDoFiltroTelefone).getValue();
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
                let urlDoFiltro = urlApi + "?";
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
                        !vendas.Detail ? this.getView().setModel(jsonModel, modeloVenda)
                            : this._erroNaRequisicaoDaApi(vendas);
                    })
            })
        },

        adicionarVenda() {
            this.processarEvento(() => {
                this.getRouter().navTo(rotaAdicionarVenda, {}, true);  
            })
        },

        aoClicarDeveIParaAListagemCarro(){
            this.processarEvento(() => {
                this.getRouter().navTo(rotaListagemCarros, {}, true);  
            })
        },

        aoPressionar(oEvent) {
            const oItem = oEvent.getSource();
            const oRouter = this.getOwnerComponent().getRouter();
            oRouter.navTo(rotaDetalhes, {
                id: window.encodeURIComponent(oItem.getBindingContext(modeloVenda).getProperty(id))
            });
        }
    });
});