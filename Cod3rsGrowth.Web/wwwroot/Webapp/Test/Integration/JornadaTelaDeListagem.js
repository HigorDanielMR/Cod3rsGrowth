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
		When.naTelaDeListagem.euPreenchoOInputDoFiltroNome();
		Then.naTelaDeListagem.euVerificoSeATabelaFoiFiltradaComoOEsperadoNome();
		Then.iTeardownMyApp();
	});

	opaTest("Deve filtrar pelo cpf e atualizar lista filtrada", function (Given, When, Then) {
		Given.iStartMyUIComponent({
			componentConfig: {
				name: "ui5.carro"
			}
		});
		When.naTelaDeListagem.euPreenchoOInputDoFiltroCpf();
		Then.naTelaDeListagem.euVerificoSeATabelaFoiFiltradaComoOEsperadoCpf();
		Then.iTeardownMyApp();
	});

	opaTest("Deve filtrar pelo telefone e atualizar lista filtrada", function (Given, When, Then) {
		Given.iStartMyUIComponent({
			componentConfig: {
				name: "ui5.carro"
			}
		});
		When.naTelaDeListagem.euPreenchoOInputDoFiltroTelefone();
		Then.naTelaDeListagem.euVerificoSeATabelaFoiFiltradaComoOEsperadoTelefone();
		Then.iTeardownMyApp();
	});

	opaTest("Deve filtrar pela data inicial e atualizar lista filtrada", function (Given, When, Then) {
		Given.iStartMyUIComponent({
			componentConfig: {
				name: "ui5.carro"
			}
		});
		When.naTelaDeListagem.euPreenchoOInputDoFiltroDataInicial();
		Then.naTelaDeListagem.euVerificoSeATabelaFoiFiltradaComoOEsperadoDataInicial();
		Then.iTeardownMyApp();
	});
	opaTest("Deve filtrar pela data final e atualizar lista filtrada", function (Given, When, Then) {
		Given.iStartMyUIComponent({
			componentConfig: {
				name: "ui5.carro"
			}
		});
		When.naTelaDeListagem.euPreenchoOInputDoFiltroDataFinal();
		Then.naTelaDeListagem.euVerificoSeATabelaFoiFiltradaComoOEsperadoDataFinal();
		Then.iTeardownMyApp();

	});

	opaTest("Deve clicar no botão adicionar", function (Given, When, Then) {
		Given.iStartMyUIComponent({
			componentConfig: {
				name: "ui5.carro"
			}
		});
		When.naTelaDeListagem.euClicoNoBotaoAdicionar();
		Then.naTelaDeListagem.euVerificoSeOBotaoFoiClicado();
		Then.iTeardownMyApp();
	});
});