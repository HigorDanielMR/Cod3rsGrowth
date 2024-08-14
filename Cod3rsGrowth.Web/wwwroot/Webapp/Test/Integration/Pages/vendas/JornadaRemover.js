sap.ui.define([
	"sap/ui/test/opaQunit",
	"./Remover"

], (opaTest) => {

	QUnit.module("Remover");

	opaTest("Deve clicar na venda desejada e entrar na view de detalhes", function (Given, When, Then) {
		Given.iStartMyApp();
		When.naTelaDeDetalhesRemover.euClicoNaVendaSelecionada();
		Then.naTelaDeDetalhesRemover.euVerificoSeNomeEstaComoOEsperado();
	});

	opaTest("Deve clicar no botao remover e verificar se a messageBox foi aberta conforme o esperado", function (Given, When, Then) {
		When.naTelaDeDetalhesRemover.euClicoNoBotaoRemover();
		Then.naTelaDeDetalhesRemover.euVerificoSeAMessageBoxDeConfirmarRemoverVendaFoiAberta();
	})
});