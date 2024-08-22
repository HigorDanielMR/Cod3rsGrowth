sap.ui.define([
	"sap/ui/test/opaQunit",
	"./TelaCriacao"

], (opaTest) => {

	QUnit.module("Carro Criacao");

	opaTest("Deve clicar na venda desejada e entrar na view de detalhes", function (Given, When, Then) {
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
	});
});