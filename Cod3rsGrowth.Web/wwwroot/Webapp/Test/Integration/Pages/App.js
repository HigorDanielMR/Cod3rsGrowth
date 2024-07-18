sap.ui.define([
	"sap/ui/test/Opa5",
	"sap/ui/test/actions/Press",
	"sap/ui/test/matchers/PropertyStrictEquals"
], (Opa5, Press, PropertyStrictEquals) => {
	"use strict";

	const sViewName = "ui5.carro.view.ListagemVenda";
	const idDoInput = "FiltroNome"

	Opa5.createPageObjects({
		onTheAppPage: {
			arrangements : {
				euInicioMeuApp() {
					return this.iStartMyUIComponent("../index.html");
				}
			},
			actions: {
				euPressionooInput()
				{
					return this.waitFor({
						viewName : sViewName,
            			id : idDoBotao,
            			actions : new Press(),
            			errorMessage : "O input não foi encontrado!"
					});
				}
			},

			assertions: {
				euVerificoSeOTextoFoiAlterado() {
					return this.waitFor({
						viewName : sViewName,
						id : idDoBotao,
						matchers : new PropertyStrictEquals({
							name : "text",
							value : "Alguém clicou aqui"
						}),
						success : function (oButton) {
							Opa5.assert.ok(true, "O texto do botão foi alterado para: " + oButton.getText());
						},
						errorMessage : "O texto do botão não foi alterado!"
					});
				}
			}
		}
	});
});
