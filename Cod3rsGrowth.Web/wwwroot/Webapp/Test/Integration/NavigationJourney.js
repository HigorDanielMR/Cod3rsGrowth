sap.ui.define([
	"sap/ui/test/opaQunit",
	"./pages/App"
], (opaTest) => {

	QUnit.module("Posts");

	opaTest("Deve filtrar pelo nome e atualizar lista filtrada", function (Given, When, Then) {
		Given.iStartMyUIComponent({
			componentConfig: {
				name: "ui5.carro"
			}
		});
		When.onTheAppPage.euPreenchoOInputDoFiltroNome();
		Then.onTheAppPage.euVerificoSeATabelaFoiFiltradaComoOEsperadoNome();
		Then.iTeardownMyApp();
	});

	opaTest("Deve filtrar pelo cpf e atualizar lista filtrada", function (Given, When, Then) {
		Given.iStartMyUIComponent({
			componentConfig: {
				name: "ui5.carro"
			}
		});
		When.onTheAppPage.euPreenchoOInputDoFiltroCpf();
		Then.onTheAppPage.euVerificoSeATabelaFoiFiltradaComoOEsperadoCpf();
		Then.iTeardownMyApp();
	});

	opaTest("Deve filtrar pelo telefone e atualizar lista filtrada", function (Given, When, Then) {
		Given.iStartMyUIComponent({
			componentConfig: {
				name: "ui5.carro"
			}
		});
		When.onTheAppPage.euPreenchoOInputDoFiltroTelefone();
		Then.onTheAppPage.euVerificoSeATabelaFoiFiltradaComoOEsperadoTelefone();
		Then.iTeardownMyApp();
	});

	opaTest("Deve filtrar pela data inicial e atualizar lista filtrada", function (Given, When, Then) {
		Given.iStartMyUIComponent({
			componentConfig: {
				name: "ui5.carro"
			}
		});
		When.onTheAppPage.euPreenchoOInputDoFiltroDataInicial();
		Then.onTheAppPage.euVerificoSeATabelaFoiFiltradaComoOEsperadoDataInicial();
		Then.iTeardownMyApp();
	});
	opaTest("Deve filtrar pela data final e atualizar lista filtrada", function (Given, When, Then) {
		Given.iStartMyUIComponent({
			componentConfig: {
				name: "ui5.carro"
			}
		});
		When.onTheAppPage.euPreenchoOInputDoFiltroDataFinal();
		Then.onTheAppPage.euVerificoSeATabelaFoiFiltradaComoOEsperadoDataFinal();
		Then.iTeardownMyApp();
	});
});
