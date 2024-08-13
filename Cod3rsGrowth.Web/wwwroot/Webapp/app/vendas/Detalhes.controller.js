sap.ui.define([
    "ui5/carro/app/common/BaseController",
    "ui5/carro/model/formatter",
    "sap/ui/core/routing/History",
    "sap/ui/model/json/JSONModel"

], function (BaseController, Formatter, History, JSONModel) {
    "use strict";

    const id = "id"
    const modeloVenda = "Venda"
    const rotaDetalhe = "appDetalhes"
    const rotaListagem = "appListagem";
    const parametroArgumento = "arguments";
    const rotaEditarVenda = "appEditarVenda";
    const urlObterPorId = "http://localhost:5071/api/Vendas/"

    return BaseController.extend("ui5.carro.app.vendas.Detalhes", {
        formatter: Formatter,

        onInit: function () {
            this.aoCoincidirRota();
        },

        aoCoincidirRota: function () {
            this.processarEvento(() => {
                const rota = this.getOwnerComponent().getRouter();
                rota.getRoute(rotaDetalhe).attachMatched(this._obterPorId,this);
            });
        },

        _obterPorId: function (oEvent) {
            let id = oEvent.getParameter(parametroArgumento).id;
            let query = urlObterPorId + id;
            let sucesso = true;
            fetch(query)
                .then((res) => {
                    if (!res.ok)
                        sucesso = false;
                    return res.json()
                })
                .then((venda) => {
                    const jsonModel = new JSONModel(venda)
                    sucesso ? this.getView().setModel(jsonModel, modeloVenda)
                        : this._erroNaRequisicaoDaApi(venda);
                });
        },

        aoClicarVoltarParaTelaDeListagem() {
            this.processarEvento(() => {
                var history;

                history = History.getInstance();
                this.getRouter().navTo(rotaListagem, {}, true);
            })
        },

        aoClicarNoBotaoEditarDeveAbrirATelaDeModificarVenda(oEvent){
            this.processarEvento(() => {
                const oItem = oEvent.getSource();
                const oRouter = this.getOwnerComponent().getRouter();
                oRouter.navTo(rotaEditarVenda, {
                    id: window.encodeURIComponent(oItem.getBindingContext(modeloVenda).getProperty(id))
                });
            })
        }
    });
}, true);