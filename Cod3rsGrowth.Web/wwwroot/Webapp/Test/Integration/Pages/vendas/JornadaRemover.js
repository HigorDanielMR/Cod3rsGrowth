sap.ui.define([
	"sap/ui/test/opaQunit",
	"./Remover"

], (opaTest) => {

	QUnit.module("Vendas Remover");

	opaTest("Deve clicar na venda desejada e entrar na view de detalhes", function (Given, When, Then) {
		Given.iStartMyApp();
		When.naTelaDeDetalhesRemover.euClicoNaVendaSelecionada();
		Then.naTelaDeDetalhesRemover.euVerificoSeNomeEstaComoOEsperado();
	});

	opaTest("Deve clicar no botao remover clicar no botao sim para remover venda e botao nao para remover carro e verificar se a venda foi removida com sucesso", function (Given, When, Then) {
		When.naTelaDeDetalhesRemover.euClicoNoBotaoRemover();
		When.naTelaDeDetalhesRemover.euClicoNoBotaoSimDaMessageBox();
		When.naTelaDeDetalhesRemover.euClicoNoBotaoOkDaMessageBox();
		Then.naTelaDeDetalhesRemover.euVerificoSeAVendaFoiRemovidaComSucesso();
		Then.iTeardownMyApp();
	});
});