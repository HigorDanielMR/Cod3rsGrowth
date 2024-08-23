sap.ui.define([
	"sap/ui/test/opaQunit",
	"./TelaCriacao"

], (opaTest) => {

	QUnit.module("Carro Criacao");

	opaTest("Deve editar o carro desejado e verificar se a message strip foi aberta.", function (Given, When, Then) {
		Given.iStartMyUIComponent({
			componentConfig: {
				name: "ui5/carro"
			},
			hash: "AdicionarCarro"
		});
		When.naTelaDeAdicionarCarro.euPreenchoOInputDoModelo();
		When.naTelaDeAdicionarCarro.euPreenchoOInputDoValor();
		When.naTelaDeAdicionarCarro.euClicoNoSelectESelecionoACorDesejada();
		When.naTelaDeAdicionarCarro.euCliCoNoSelectESelecionoAMarcaDesejada();
		When.naTelaDeAdicionarCarro.euClicoNoSeletESelecionoOTipoFlexDesejado();
		When.naTelaDeAdicionarCarro.euClicoNoBotaoAdicionarCarro();
		Then.naTelaDeAdicionarCarro.euVerificoSeAMessageStripDeCarroCriadoComSucessoFoiExibida();
		Then.iTeardownMyApp();

	});
});