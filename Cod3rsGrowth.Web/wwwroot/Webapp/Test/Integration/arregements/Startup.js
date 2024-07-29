sap.ui.define([
	"sap/ui/test/Opa5"
], function (Opa5) {
	"use strict";

	const nameSpace = "ui5.carro";

	return Opa5.extend("ui5.carro.test.integration.arregements.Startup", {
		/**
		 * Initializes mock server, then starts the app component
		 * @param {object} oOptionsParameter An object that contains the configuration for starting up the app
		 * @param {int} oOptionsParameter.delay A custom delay to start the app with
		 * @param {string} [oOptionsParameter.hash] The in app hash can also be passed separately for better readability in tests
		 * @param {boolean} [oOptionsParameter.autoWait=true] Automatically wait for pending requests while the application is starting up.
		 */

		iStartMyApp (oOptionsParameter) {
			var oOptions = oOptionsParameter || {};

			oOptions.delay = oOptions.delay || 1;
			this.iStartMyUIComponent({
				componentConfig: {
					name: nameSpace,
					async: true
				},
				hash: oOptions.hash,
				autoWait: oOptions.autoWait
			});
		}
	})
})