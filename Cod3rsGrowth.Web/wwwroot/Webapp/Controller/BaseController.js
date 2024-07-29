sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/core/routing/History",
	"sap/ui/core/UIComponent",
	"sap/m/MessageBox"
], function (Controller, History, UIComponent, MessageBox) {
	"use strict";

	var voltarUmaPagina = -1;

	return Controller.extend("ui5.carro.controller.BaseController", {
		getRouter() {
			return UIComponent.getRouterFor(this);
		},

		onNavBack() {
			var history, previousHash;

			history = History.getInstance();
			previousHash = history.getPreviousHash();

			if (previousHash !== undefined) {
				window.history.go(voltarUmaPagina);
			} else {
				this.getRouter().navTo("appListagem", {}, true);
			}
		},
		processarEvento(action) {
			const tipoDaPromise = "catch",
				tipoBuscado = "function";
			try {
				var promise = action();
				if (promise && typeof (promise[tipoDaPromise]) == tipoBuscado) {
					promise.catch(error => MessageBox.error(error.message));
				}
			} catch (error) {
				MessageBox.error(error.message);
			}
		},

		formatarData(data) {
			const novaData = new Date(data);

			const dia = novaData.getDate().toString().padStart(2, '0');
			const mes = (novaData.getMonth() + 1).toString().padStart(2, '0');
			const ano = novaData.getFullYear();

			return `${ano}-${mes}-${dia}`;
		}
	});

});
