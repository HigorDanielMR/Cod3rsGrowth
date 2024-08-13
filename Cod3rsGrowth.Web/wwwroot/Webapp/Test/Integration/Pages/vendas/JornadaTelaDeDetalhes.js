sap.ui.define([
	"sap/ui/test/opaQunit",
	"./TelaDeListagem",
	"./TelaDeDetalhes"

], (opaTest) => {

	QUnit.module("Detalhes");

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
		Then.iTeardownMyApp();
	});
});