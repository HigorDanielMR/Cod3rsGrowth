sap.ui.define(["sap/ui/core/mvc/Controller"], function(Controller) {
    "use strict";
    return Controller.extend("ui5.carro.view.App", {
        onInit: function() {
            var that = this;
            window.setTimeout(function() {
                that.byId("botao").setVisible(true);
            }, Math.random() * 10000);
       },

    onPress: function() {
            this.byId("botao").setText("Alguém clicou aqui");
    }

    });
}, true);