sap.ui.define([
    "ui5/carro/controller/BaseController",
    "sap/ui/model/resource/ResourceModel"

], function (BaseController, ResourceModel) {
    "use strict";

    return BaseController.extend("ui5.carro.controller.Home", {
        onInit: function () {
            const modeloI18n = new ResourceModel({
                bundleName: "ui5.carro.i18n.i18n"
            });
            this.getView().setModel(modeloI18n, "i18n");

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