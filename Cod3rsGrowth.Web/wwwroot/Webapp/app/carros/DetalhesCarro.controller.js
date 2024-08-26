sap.ui.define([
    "ui5/carro/app/common/BaseController",
    "ui5/carro/model/formatter",
    "sap/ui/core/routing/History",
    "sap/ui/model/json/JSONModel",
    "sap/m/MessageBox"

], function (BaseController, Formatter, History, JSONModel) {
    "use strict";

    const modeloCarro = "Carro";
    const rotaDetalhe = "appDetalhesCarro";
    const parametroArgumento = "arguments";
    const rotaEditarCarro = "appEditarCarro";
    const rotaListagemCarros = "appListagemCarro";
    const urlCarro = "http://localhost:5071/api/Carros/";

    return BaseController.extend("ui5.carro.app.carros.DetalhesCarro", {
        formatter: Formatter,

        onInit() {
            this.aoCoincidirRota();
        },

        aoCoincidirRota() {
            this.processarEvento(() => {
                const rota = this.getOwnerComponent().getRouter();
                rota.getRoute(rotaDetalhe).attachMatched(this._carregarCarro, this);
            });
        },

        _carregarEventos(oEvent) {
            this._carregarCarro(oEvent);
        },

        _carregarCarro(oEvent) {
            let idDesejado = oEvent.getParameter(parametroArgumento).id;
            let query = urlCarro + idDesejado;
            let sucesso = true;
            fetch(query)
                .then((res) => {
                    if (!res.ok)
                        sucesso = false;
                    return res.json()
                })
                .then((carro) => {
                    if (sucesso) {
                        const jsonModel = new JSONModel(carro)
                        this.getView().setModel(jsonModel, modeloCarro);
                    }
                    else this._erroNaRequisicaoDaApi(carro);
                });

        },

        aoClicarVoltarParaTelaDeListagem() {
            this.processarEvento(() => {
                var history;
                history = History.getInstance();
                this.getRouter().navTo(rotaListagemCarros, {}, true);
            })
        },
        
        aoClicarNoBotaoEditar(oEvent){
            this.processarEvento(() =>{
                const oItem = oEvent.getSource();
                const oRouter = this.getOwnerComponent().getRouter();
                oRouter.navTo(rotaEditarCarro, {
                    id: oItem._getPropertiesToPropagate().oModels.Carro.oData.id
                });
            })
        }
    });
}, true);