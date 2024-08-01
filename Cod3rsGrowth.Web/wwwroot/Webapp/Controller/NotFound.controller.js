﻿sap.ui.define([
    "ui5/carro/controller/BaseController",
    "sap/ui/core/routing/History"
], function (BaseController, History) {
    "use strict";

    const voltarUmaPagina = -1;

    return BaseController.extend("ui5.carro.Controller.NotFound", {
        onInit: function () {
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
        }
    });
});