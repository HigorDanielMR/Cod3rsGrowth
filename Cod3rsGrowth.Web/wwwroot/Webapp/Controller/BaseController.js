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

		aoClicarNoBotaoVoltarDeveRetornarATelaDeListagem() {
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
			try {
				var promise = action();

				if (promise && typeof promise.catch === 'function') {
					promise.catch(error => MessageBox.error(error.message));
				}
			} catch (error) {
				MessageBox.error(error.message);
			}
		},

		formatarData(data) {
			var novaData = new Date(data);

			var dia = novaData.getDate().toString().padStart(2, '0');
			var mes = (novaData.getMonth() + 1).toString().padStart(2, '0');
			var ano = novaData.getFullYear();

			return `${ano}-${mes}-${dia}`;
		}
	});

});
