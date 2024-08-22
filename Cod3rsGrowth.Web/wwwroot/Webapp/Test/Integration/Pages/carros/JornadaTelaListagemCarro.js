sap.ui.define([
	"sap/ui/test/opaQunit",
	"./TelaListagemCarro"

], (opaTest) => {

	QUnit.module("Carros Listagem");

	opaTest("Deve filtrar e verificar se a tabela foi filtrada como o desejado", function (Given, When, Then) {
		Given.iStartMyUIComponent({
			componentConfig: {
				name: "ui5/carro"
			},
			hash: "ListagemCarro"
		});
		When.naTelaDeDetalhesListagemCarro.euPreenchoOInputDoFiltroModelo();
		Then.naTelaDeDetalhesListagemCarro.euVerificoSeATabelaFoiFiltradaComoOEsperadoModelo();
	});
});