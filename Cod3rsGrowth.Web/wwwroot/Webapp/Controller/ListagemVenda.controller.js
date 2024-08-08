sap.ui.define([
    "ui5/carro/controller/BaseController",
    "sap/ui/model/json/JSONModel",
    "ui5/carro/model/formatter",
    "sap/m/MessageBox"

], function (BaseController, JSONModel, Formatter, MessageBox) {
    "use strict";

    const ID = "id"
    const modeloVenda = "Vendas"
    const idDoFiltroCpf = "FiltroCpf"
    const RotaListagem = "appListagem"
    const idDoFiltroNome = "FiltroNome"
    const quantidadeDeCaracteresDoCpf = 14
    const quantidadeDeCaracteresDoTelefone = 15
    const idDoFiltroTelefone = "FiltroTelefone"
    let url = "http://localhost:5071/api/Vendas"    
    const idDoFiltroData = "FiltroData"

    return BaseController.extend("ui5.carro.controller.ListagemVenda", {
        formatter: Formatter,

        onInit() {
            this.aoCoincidirRota();
        },


        _carregarListaDeVendas() {
            let sucesso = true;
            fetch(url)
                .then((res) => {
                    if (!res.ok)
                        sucesso = false;
                    return res.json()
                })
                .then((data) => {
                    const jsonModel = new JSONModel(data)
                    sucesso ? this.getView().setModel(jsonModel, modeloVenda)
                        : this._erroNaRequisicaoDaApi(data);
                })
                .catch((err) => console.error(err));
        },

        aoCoincidirRota() {
            this.processarEvento(() => {
                var rota = sap.ui.core.UIComponent.getRouterFor(this);
                rota.getRoute(RotaListagem).attachMatched(this._carregarListaDeVendas, this);
            });
        },

        abrirDatePicker: function (oEvent) {
            this.getView().byId("FiltroData").openBy(oEvent.getSource().getDomRef());
        },

        limparFiltroData() {
            const dataInicial = oEvent.getSource().setDateValue(null);
            const dataFinal = oEvent.getSource().setSecondDateValue(null);

        },

        aoColetarNome() {
            const nome = this.oView.byId(idDoFiltroNome).getValue();
            return nome;
        },

        aoColetarCpf() {
            const cpf = this.oView.byId(idDoFiltroCpf).getValue();
            if (cpf.length < quantidadeDeCaracteresDoCpf) return '';
            return cpf;
        },

        aoColetarTelefone() {
            const telefone = this.oView.byId(idDoFiltroTelefone).getValue();
            if (telefone.length < quantidadeDeCaracteresDoTelefone) return '';
            return telefone;
        },

        aoColetarDataInicial(oEvent) {
            let dataInicial = oEvent.getParameter("from");;
            let dataInicialFormatada = Formatter.formatarData(dataInicial);

            if (dataInicialFormatada === '31/12/1970') {
                dataInicialFormatada = undefined;
            }
             return dataInicialFormatada;
        },

        aoColetarDataFinal(oEvent) {
            let dataFinal = oEvent.getParameter("to");
            let dataFinalFormatada = Formatter.formatarData(dataFinal);

            if (dataFinalFormatada === '31/12/1970') {
                dataFinalFormatada = undefined;
            }
            return dataFinalFormatada;
        },

        aoFiltrar(oEvent) {
            this.processarEvento(() => {
                let sucesso = true;
                let urlDoFiltro = url + "?";
                const cpf = this.aoColetarCpf();
                const nome = this.aoColetarNome();
                const telefone = this.aoColetarTelefone();
                const dataInicial = this.aoColetarDataInicial(oEvent);
                const dataFinal = this.aoColetarDataFinal(oEvent);

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
                        if (!res.ok)
                            sucesso = false;
                        return res.json()
                    })
                    .then((vendas) => {
                        const jsonModel = new JSONModel(vendas)
                        sucesso ? this.getView().setModel(jsonModel, modeloVenda)
                            : this._erroNaRequisicaoDaApi(vendas);
                    })
                    .catch((err) => console.error(err));
            })
        },

        adicionarVenda() {
            this.processarEvento(() => {
                this.getRouter().navTo("appAdicionarVenda", {}, true);  
            })
        },

        aoPressionar(oEvent) {
            const oItem = oEvent.getSource();
            const oRouter = this.getOwnerComponent().getRouter();
            oRouter.navTo("appDetalhes", {
                id: window.encodeURIComponent(oItem.getBindingContext(modeloVenda).getProperty(ID))
            });
        }
    });
});