sap.ui.define([
    "ui5/carro/controller/BaseController"

], function (BaseController, ResourceModel) {
    "use strict";

    return BaseController.extend("ui5.carro.controller.Home", {
        onInit: function () {
            var that = this;
            window.setTimeout(function() {
                that.byId("botao");
            }, Math.random() * 10000);
       },

       onPress: function() {
        this.byId("botao").setText("Alguém clicou aqui");
        }
    });
 });