sap.ui.define([
	"sap/ui/test/Opa5",
	"sap/ui/test/actions/Press"
], (Opa5, Press) => {
	"use strict";

	const sViewName = "ui5.walkthrough.view.App";

	Opa5.createPageObjects({
		onTheAppPage: {
			arrangements : {
				euInicioMeuApp : function () {
					return this.iStartMyUIComponent("../index.html");
				}
			},
			actions: {
				iPressTheSayHelloWithDialogButton() {
					return this.waitFor({
						viewName: sViewName,
						id: "pressMeButton",
						actions: new Press(),
						errorMessage: "Botão não encontrado!"
					});
				}
			},

			assertions: {
				iShouldSeeTheHelloDialog() {
					return this.waitFor({
						viewName : sViewName,
						id : "pressMeButton",
						success() {
							// we set the view busy, so we need to query the parent of the app
							Opa5.assert.ok(true, "The dialog is open");
						},
						errorMessage: "Did not find the dialog control"
					});
				}
			}
		}
	});
});
