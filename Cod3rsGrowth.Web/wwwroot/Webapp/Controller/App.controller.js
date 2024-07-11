sap.ui.define(["sap/ui/core/mvc/Controller"], function(Controller) {
    "use strict";
    return Controller.extend("ui5.walkthrough.view.App", {
        onInit: function() {
            var that = this;
            window.setTimeout(function() {
                that.byId("pressMeButton").setVisible(true);
            }, Math.random() * 10000);
       },

    onPress: function() {
            this.byId("pressMeButton").setText("Alguém clicou aqui");
    }

    });
}, true);