sap.ui.define([
	"sap/ui/test/opaQunit",
	"./pages/App"
], (opaTest) => {

	QUnit.module("Navigation");

	opaTest("Should open the Hello dialog", function (Given, When, Then) {
		Given.iStartMyUIComponent({
			componentConfig: {
				name: "ui5.carro"
			}
		});
		When.onTheAppPage.euPreenchoOInputDoFiltroNome();
		Then.onTheAppPage.euVerificoSeATabelaFoiFiltradaComoOEsperadoNome();
		Then.iTeardownMyApp();

		Given.iStartMyUIComponent({
			componentConfig: {
				name: "ui5.carro"
			}
		});
		When.onTheAppPage.euPreenchoOInputDoFiltroCpf();
		Then.onTheAppPage.euVerificoSeATabelaFoiFiltradaComoOEsperadoCpf();
		Then.iTeardownMyApp();

		Given.iStartMyUIComponent({
			componentConfig: {
				name: "ui5.carro"
			}
		});
		When.onTheAppPage.euPreenchoOInputDoFiltroTelefone();
		Then.onTheAppPage.euVerificoSeATabelaFoiFiltradaComoOEsperadoTelefone();
		Then.iTeardownMyApp();

		Given.iStartMyUIComponent({
			componentConfig: {
				name: "ui5.carro"
			}
		});
		When.onTheAppPage.euPreenchoOInputDoFiltroDataInicial();
		Then.onTheAppPage.euVerificoSeATabelaFoiFiltradaComoOEsperadoDataInicial();
		Then.iTeardownMyApp();

		Given.iStartMyUIComponent({
			componentConfig: {
				name: "ui5.carro"
			}
		});
		When.onTheAppPage.euPreenchoOInputDoFiltroDataFinal();
		Then.onTheAppPage.euVerificoSeATabelaFoiFiltradaComoOEsperadoDataFinal();
		Then.iTeardownMyApp();
	});
	opaTest()
});
