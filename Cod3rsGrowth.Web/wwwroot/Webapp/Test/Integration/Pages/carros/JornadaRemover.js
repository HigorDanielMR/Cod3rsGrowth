sap.ui.define([
	"sap/ui/test/opaQunit",
	"./Remover"

], (opaTest) => {

	QUnit.module("Carros Remover");

	opaTest("Deve clicar no carro desejado e entrar na tela de detalhes", function (Given, When, Then) {
		Given.iStartMyUIComponent({
			componentConfig: {
				name: "ui5/carro"
			},
			hash: "ListagemCarro"
		});
		When.naTelaDetalhesRemoverCarro.euClicoNoCarroDesejado();
		Then.naTelaDetalhesRemoverCarro.euVerificoSeModeloEstaComoOEsperado();
	});

	opaTest("Deve clicar no botao remover clicar no botao sim para remover e verificar se a venda foi removida com sucesso", function (Given, When, Then) {
		When.naTelaDetalhesRemoverCarro.euClicoNoBotaoRemover();
		When.naTelaDetalhesRemoverCarro.euClicoNoBotaoSimDaMessageBox();
		When.naTelaDetalhesRemoverCarro.euClicoNoBotaoOkDaMessageBoxSucesso();
		Then.naTelaDetalhesRemoverCarro.euVerificoSeOCarroFoiRemovidoComSucesso();
		Then.iTeardownMyApp();
	});
});