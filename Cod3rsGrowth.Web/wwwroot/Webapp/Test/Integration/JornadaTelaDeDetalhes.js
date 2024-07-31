sap.ui.define([
	"sap/ui/test/opaQunit",
	"./pages/TelaDeListagem",
	"./pages/TelaDeDetalhes"

], (opaTest) => {

	QUnit.module("Teste tela de detalhes");

	opaTest("Deve clicar no primeiro item da lista e verificar os dados dos detalhes", function (Given, When, Then) {
		Given.iStartMyApp();
		When.naTelaDeDetalhes.euClicoNaTabelaVenda();
		When.naTelaDeDetalhes.euClicoNaVendaSelecionada();
		Then.naTelaDeDetalhes.euVerificoSeOIdEstaComoOEsperado();
		Then.naTelaDeDetalhes.euVerificoSeNomeEstaComoOEsperado();

	});
});