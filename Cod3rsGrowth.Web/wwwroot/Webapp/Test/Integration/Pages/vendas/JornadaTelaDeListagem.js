sap.ui.define([
	"sap/ui/test/opaQunit",
	"./TelaDeListagem"

], (opaTest) => {

	QUnit.module("Vendas Listagem");

	opaTest("Deve filtrar pelo nome e atualizar lista filtrada", function (Given, When, Then) {
		Given.iStartMyApp();
		When.naTelaDeListagem.euPreenchoOInputDoFiltroNome();
		Then.naTelaDeListagem.euVerificoSeATabelaFoiFiltradaComoOEsperadoNome();
		Then.iTeardownMyApp();
	});

	opaTest("Deve filtrar pelo cpf e atualizar lista filtrada", function (Given, When, Then) {
		Given.iStartMyApp();
		When.naTelaDeListagem.euPreenchoOInputDoFiltroCpf();
		Then.naTelaDeListagem.euVerificoSeATabelaFoiFiltradaComoOEsperadoCpf();
		Then.iTeardownMyApp();
	});

	opaTest("Deve filtrar pelo telefone e atualizar lista filtrada", function (Given, When, Then) {
		Given.iStartMyApp();
		When.naTelaDeListagem.euPreenchoOInputDoFiltroTelefone();
		Then.naTelaDeListagem.euVerificoSeATabelaFoiFiltradaComoOEsperadoTelefone();
		Then.iTeardownMyApp();
	});

	opaTest("Deve filtrar pela data inicial e atualizar lista filtrada", function (Given, When, Then) {
		Given.iStartMyApp();
		When.naTelaDeListagem.euClicoNoIconeDoDateRangeSelection();
		Then.naTelaDeListagem.euVerificoSeATabelaFoiFiltradaComoOEsperadoDataInicialEDataFinal();
		Then.iTeardownMyApp();
	});
});