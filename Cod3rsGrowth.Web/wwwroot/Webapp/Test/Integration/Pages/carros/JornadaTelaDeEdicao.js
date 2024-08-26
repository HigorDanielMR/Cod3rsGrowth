sap.ui.define([
	"sap/ui/test/opaQunit",
	"./TelaDeEdicao"

], (opaTest) => {

	QUnit.module("Carros Edicao");

	opaTest("Deve preencher o valor dos inputs e verificar se a message strip foi aberta.", function (Given, When, Then) {
		Given.iStartMyUIComponent({
			componentConfig: {
				name: "ui5/carro"
			},
			hash: "EditarCarro/7"
		});

		When.naTelaDeEdicaoCarro.euInsiroOModeloNoInput();
		When.naTelaDeEdicaoCarro.euSelecionoAMarcaDesejada();
		When.naTelaDeEdicaoCarro.euClicoNoBotaoAdicionarDaTelaDeEditar();
		Then.naTelaDeEdicaoCarro.euVerificoSeOMessageStripDeSUcessoFoiExibido();
		Then.iTeardownMyApp();
	});
});