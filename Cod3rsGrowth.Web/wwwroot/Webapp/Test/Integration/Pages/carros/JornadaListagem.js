sap.ui.define([
	"sap/ui/test/opaQunit",
	"./Listagem"

], (opaTest) => {

	QUnit.module("Carros Listagem");

	opaTest("Deve verificar se os detalhes estao com os dados esperados e verifica se o carro esta com os dados esperados", function (Given, When, Then) {
		Given.iStartMyUIComponent({
			componentConfig: {
				name: "ui5/carro"
			},
			hash: "detalhes/1"
		});
		Then.naTelaDeDetalhesListagemCarro.euVerificoSeOIdEstaComoOEsperado();
		Then.naTelaDeDetalhesListagemCarro.euVerificoSeNomeEstaComoOEsperado();
		Then.naTelaDeDetalhesListagemCarro.euVerificoSeOIdDoCarroEstaComoOEsperado();
		Then.naTelaDeDetalhesListagemCarro.euVerificoSeNomeDoSegundoCarroEstaComoOEsperado();
	});

    opaTest("Deve voltar para a tela de listagem clicar na venda desejada entrar na tela de detalhes verificar se os dados estao como o esperado e verifica se o carro esta com os dados esperados", function (Given, When, Then) {
		When.naTelaDeDetalhesListagemCarro.euClicoNoBotaoVoltarParaATelaDeListagem();
		When.naTelaDeDetalhesListagemCarro.euClicoNaVendaSelecionada();
        Then.naTelaDeDetalhesListagemCarro.euVerificoSeOIdDoSegundoItemDaListaEstaComoOEsperado();
		Then.naTelaDeDetalhesListagemCarro.euVerificoSeNomeDoSegundoItemDaListaEstaComoOEsperado();
		Then.naTelaDeDetalhesListagemCarro.euVerificoSeOIdDoSegundoCarroEstaComoOEsperado();
		Then.naTelaDeDetalhesListagemCarro.euVerificoSeONomeDoSegundoCarroEstaComoOEsperado();
	});
});