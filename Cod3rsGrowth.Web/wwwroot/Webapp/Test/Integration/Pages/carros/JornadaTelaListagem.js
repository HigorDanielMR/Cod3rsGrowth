sap.ui.define([
	"sap/ui/test/opaQunit",
	"./TelaListagem"

], (opaTest) => {

	QUnit.module("Carro Listagem");

	opaTest("Deve preencher o filtro modelo como desejado e verificar se foi filtrado com sucesso", function (Given, When, Then) {
		Given.iStartMyUIComponent({
			componentConfig: {
				name: "ui5/carro"
			},
			hash: "ListagemCarro"
		});
		When.naTelaDeDetalhesListagemCarro.euPreenchoOInputDoFiltroModelo();
		Then.naTelaDeDetalhesListagemCarro.euVerificoSeATabelaFoiFiltradaComoOEsperadoModelo();
		Then.iTeardownMyApp();
	});

	opaTest("Deve clicar no select de cor selecionar uma cor e verificar se a tabela foi filtrada como o desejado", function (Given, When, Then) {
		Given.iStartMyUIComponent({
			componentConfig: {
				name: "ui5/carro"
			},
			hash: "ListagemCarro"
		});
		When.naTelaDeDetalhesListagemCarro.euClicoNoSelectESelecionoACorDesejada();
		Then.naTelaDeDetalhesListagemCarro.euVerificoSeATabelaFoiFiltradaComACorEsperada();
		Then.iTeardownMyApp();
	});

	opaTest("Deve clicar no select de marca selecionar a marca e verificar se a tabela foi filtrada como o desejado", function (Given, When, Then) {
		Given.iStartMyUIComponent({
			componentConfig: {
				name: "ui5/carro"
			},
			hash: "ListagemCarro"
		});
		When.naTelaDeDetalhesListagemCarro.euCliCoNoSelectESelecionoAMarcaDesejada();
		Then.naTelaDeDetalhesListagemCarro.euVerificoSeATabelaFoiFiltradaComAMarcaEsperada();
		Then.iTeardownMyApp();
	});
	opaTest("Deve clicar no select de flex selecionar o tipo flex desejado e verificar se a tabela foi filtrada como o desejado", function (Given, When, Then) {
		Given.iStartMyUIComponent({
			componentConfig: {
				name: "ui5/carro"
			},
			hash: "ListagemCarro"
		});
		When.naTelaDeDetalhesListagemCarro.euClicoNoSeletESelecionoOTipoFlexDesejado();
		Then.naTelaDeDetalhesListagemCarro.euVerificoSeATabelaFoiFiltradaComOTipoFlexEsperado();
		Then.iTeardownMyApp();
	});
});