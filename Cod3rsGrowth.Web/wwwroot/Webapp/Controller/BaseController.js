sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/core/routing/History",
	"sap/ui/core/UIComponent"
], function(Controller, History, UIComponent) {
	"use strict";

	var voltarUmaPagina = -1;

	return Controller.extend("ui5.carro.controller.BaseController", {
		getRouter : function () {
			return UIComponent.getRouterFor(this);
		},

		onNavBack: function () {
			var history, previousHash;

			history = History.getInstance();
			previousHash = history.getPreviousHash();

			if (previousHash !== undefined) {
				window.history.go(voltarUmaPagina);
			} else {
				this.getRouter().navTo("appListagem", {}, true);
			}
		}

	});

});
