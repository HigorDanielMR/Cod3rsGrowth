sap.ui.define([
	"sap/ui/test/opaQunit",
	"./pages/TelaDeListagem",
	"./pages/TelaDeDetalhes"

], (opaTest) => {

	QUnit.module("Teste tela de detalhes");

	opaTest("Deve clicar no primeiro item da lista e verificar os dados dos detalhes", function (Given, When, Then) {
		Given.iStartMyUIComponent({
			componentConfig: {
				name: "ui5/carro"
			},
			hash: "detalhes/1"
		});
		Then.naTelaDeDetalhes.euVerificoSeOIdEstaComoOEsperado();
		Then.naTelaDeDetalhes.euVerificoSeNomeEstaComoOEsperado();
		When.naTelaDeDetalhes.euClicoNoBotaoVoltarParaATelaDeListagem();
		When.naTelaDeDetalhes.euClicoNaVendaSelecionada();
		Then.naTelaDeDetalhes.euVerificoSeOIdDoSegundoItemDaListaEstaComoOEsperado();
		Then.naTelaDeDetalhes.euVerificoSeNomeDopSegundoItemDaListaEstaComoOEsperado();

	});
});