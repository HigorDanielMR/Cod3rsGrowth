sap.ui.define([
	"sap/ui/test/opaQunit",
	"./TelaDeDetalhes"

], (opaTest) => {

	QUnit.module("Carros Detalhes");

	opaTest("Deve iniciar no primeiro item da lista e verificar os dados dos detalhes", function (Given, When, Then) {
		Given.iStartMyUIComponent({
			componentConfig: {
				name: "ui5/carro"
			},
			hash: "DetalhesCarro/1"
		});
		Then.naTelaDeDetalhesCarro.euVerificoSeOIdEstaComoOEsperado();
		Then.naTelaDeDetalhesCarro.euVerificoSeModeloEstaComoOEsperado();
	});

	opaTest("Deve voltar para a tela de listagem dos carros clicar no carro desejado e verificar os dados da tela de detalhes", function(Given, When, Then){
		When.naTelaDeDetalhesCarro.euClicoNoBotaoVoltarParaATelaDeListagem();
		When.naTelaDeDetalhesCarro.euClicoNoCarroDesejado();
		Then.naTelaDeDetalhesCarro.euVerificoSeOIdDoSegundoItemDaListaEstaComoOEsperado();
		Then.naTelaDeDetalhesCarro.euVerificoSeModeloDoSegundoItemDaListaEstaComoOEsperado();
		Then.iTeardownMyApp();
	})
});