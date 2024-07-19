sap.ui.define([
	"sap/ui/test/opaQunit",
	"./pages/App"
], (opaTest) => {

	QUnit.module("Navigation");

	opaTest("Should open the Hello dialog", function (Given, When, Then) {
		// Arrangements
		Given.iStartMyUIComponent({
			componentConfig: {
				name: "ui5.carro"
			}
		});

		//Actions
		When.onTheAppPage.euClicoNaSearchFildDoFiltroNome();
		When.onTheAppPage.euClicoNaSearchFildDoFiltroCpf();
		When.onTheAppPage.euClicoNaSearchFildDoFiltroTelefone();

		// Assertions
		Then.onTheAppPage.euVerificoSeATabelaFoiFiltradaComoOEsperadoNome();
		Then.onTheAppPage.euVerificoSeATabelaFoiFiltradaComoOEsperadoCpf();
		Then.onTheAppPage.euVerificoSeATabelaFoiFiltradaComoOEsperadoTelefone();
	});
});
