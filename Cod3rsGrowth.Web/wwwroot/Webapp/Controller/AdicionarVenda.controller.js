sap.ui.define([
    "ui5/carro/controller/BaseController",
    "sap/ui/core/routing/History",
    "sap/ui/model/json/JSONModel",
    "ui5/carro/model/formatter"

], function (BaseController, History, JSONModel, Formatter) {
    "use strict";

    var url = "http://localhost:5071/api/Carros"    
    var NomeDaAPI = "Carros"

    return BaseController.extend("ui5.carro.controller.AdicionarVenda", {
        formatter: Formatter,

        onInit() {
            fetch(url)
                .then((res) => res.json())
                .then((data) => {
                    const jsonModel = new JSONModel(data)

                    this.getView().setModel(jsonModel, NomeDaAPI);
                })
                .catch((err) => console.error(err));
        },

        handleLoadItems: function (oControlEvent) {
            oControlEvent.getSource().getBinding("items").resume();
        },

        cancelar() {
            var history, previousHash;

            history = History.getInstance();
            previousHash = history.getPreviousHash();

            if (previousHash !== undefined) {
                window.history.go(voltarUmaPagina);
            } else {
                this.getRouter().navTo("appListagem", {}, true /*no history*/);
            }
        }
    });
}, true);