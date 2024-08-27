sap.ui.define([
	"sap/ui/test/opaQunit",
	"./TelaDeEdicao"

], (opaTest) => {

	QUnit.module("Carros Edicao");

	opaTest("Deve limpar o input modelo e verificar se a message strip foi aberta.", function (Given, When, Then) {
		Given.iStartMyUIComponent({
			componentConfig: {
				name: "ui5/carro"
			},
			hash: "EditarCarro/6"
		});
		When.naTelaDeEdicaoCarro.euLimpoModeloDoInput();
		When.naTelaDeEdicaoCarro.euClicoNoBotaoAdicionarDaTelaDeEditar();
		Then.naTelaDeEdicaoCarro.euVerificoSeAMessageStripDeErroAoEditarCarroFoiExibida();
	});

	opaTest("Deve preencher o valor dos inputs e verificar se a message strip foi aberta.", function(Given, When, Then){
		When.naTelaDeEdicaoCarro.euInsiroOModeloNoInput();
		When.naTelaDeEdicaoCarro.euSelecionoAMarcaDesejada();
		When.naTelaDeEdicaoCarro.euClicoNoBotaoAdicionarDaTelaDeEditar();
		Then.naTelaDeEdicaoCarro.euVerificoSeOMessageStripDeSUcessoFoiExibido();
		Then.iTeardownMyApp();
	})
});