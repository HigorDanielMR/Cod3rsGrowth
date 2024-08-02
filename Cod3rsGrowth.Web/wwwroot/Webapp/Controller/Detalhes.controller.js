sap.ui.define([
    "ui5/carro/controller/BaseController",
    "ui5/carro/model/formatter",
    "sap/ui/core/routing/History",
    "sap/ui/model/json/JSONModel"

], function (BaseController, Formatter, History, JSONModel) {
    "use strict";

    const voltarUmaPagina = -1;
    const ID = "id"

    const modeloVenda = "Venda"
    const rotaDetalhe = "appDetalhes"
    const urlObterPorId = "http://localhost:5071/api/Vendas/"

    return BaseController.extend("ui5.carro.controller.Detalhes", {
        formatter: Formatter,

        onInit: function () {
            this.aoCoincidirRota();
        },

        aoCoincidirRota: function () {
            this.processarEvento(() => {
                const oRouter = this.getOwnerComponent().getRouter();
                oRouter.getRoute(rotaDetalhe).attachMatched(this._obterPorId,this);
            });
        },

        _obterPorId: function (oEvent) {
            let id = oEvent.getParameter("arguments").id;
            let query = urlObterPorId + id;
            fetch(query)
                .then(resp => resp.json())
                .then(venda => this.getView().setModel(new JSONModel(venda), modeloVenda));
        },

        aoClicarVoltarParaTelaDeListagem() {
            this.processarEvento(() => {
                var history, previousHash;

                history = History.getInstance();
                previousHash = history.getPreviousHash();

                if (previousHash !== undefined) {
                    window.history.go(voltarUmaPagina);
                } else {
                    this.getRouter().navTo("appListagem", {}, true);
                }
            })
        },

        aoClicarNoBotaoEditarDeveAbrirATelaDeModificarVenda(oEvent){
            this.processarEvento(() => {
                const oItem = oEvent.getSource();
                const oRouter = this.getOwnerComponent().getRouter();
                oRouter.navTo("appEditarVenda", {
                    id: window.encodeURIComponent(oItem.getBindingContext(modeloVenda).getProperty(ID))
                });
            })
        }
    });
}, true);