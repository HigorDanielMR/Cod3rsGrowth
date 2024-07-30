sap.ui.define([
	"sap/ui/test/opaQunit",
	"./pages/TelaDeListagem",
	"./pages/TelaDeDetalhes"

], (opaTest) => {

	QUnit.module("Nvegation");

	opaTest("Deve clicar no botao adicionar", function (Given, When, Then) {
		Given.iStartMyApp();

	});
});