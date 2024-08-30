sap.ui.define([
	"sap/ui/test/opaQunit",
	"./TelaDeEdicao",
	"./TelaDeListagem"

], (opaTest) => {

	QUnit.module("Vendas Edicao");

	opaTest("Deve limpar input nome e verificar se message strip de erro foi aberta.", function(Given, When, Then){
		Given.iStartMyUIComponent({
			componentConfig: {
				name: "ui5/carro"
			},
			hash: "EditarVenda/3"
		});
		When.naTelaDeEdicao.euLimpoOInputNome();
		When.naTelaDeEdicao.euClicoNoBotaoAdicionarDaTelaDeEditar();
		Then.naTelaDeEdicao.euVerificoSeAMessageStripDeErroAoEditarVendaFoiExibida();
	})

	opaTest("Deve preencher os dados desejados e verificar se a message strip de sucesso foi aberta.", function (Given, When, Then) {
		When.naTelaDeEdicao.euInsiroONomeNoInputNome();
		When.naTelaDeEdicao.euSelecionoOItemNaTabela();
		When.naTelaDeEdicao.euClicoNoBotaoAdicionarDaTelaDeEditar();
		Then.naTelaDeEdicao.euVereificoSeATabelaFoiPressionada();
		Then.naTelaDeEdicao.euVerificoSeAMessageStripDeSucessoAoEditarVendaFoiExibida();
		Then.iTeardownMyApp();
	})
});