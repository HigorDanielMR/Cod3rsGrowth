sap.ui.define([
	"sap/ui/test/opaQunit",
	"./TelaDeEdicao",
	"./TelaDeListagem"

], (opaTest) => {

	QUnit.module("Vendas Edicao");

	opaTest("Deve preencher o valor do input nome", function (Given, When, Then) {
		Given.iStartMyUIComponent({
			componentConfig: {
				name: "ui5/carro"
			},
			hash: "EditarVenda/3"
		});

		When.naTelaDeEdicao.euInsiroONomeNoInputNome();
		Then.naTelaDeEdicao.euVerificoSeOTextoFoiInseridoNoInputNome();
	});
	

	opaTest("Deve selecionar um carro na tabela", function (Given, When, Then) {
		When.naTelaDeEdicao.euSelecionoOItemNaTabela();
		Then.naTelaDeEdicao.euVereificoSeATabelaFoiPressionada();
	});

	opaTest("Deve clicar no botao adicionar ", function (Given, When, Then) {
		When.naTelaDeEdicao.euClicoNoBotaoAdicionarDaTelaDeEditar();
		Then.naTelaDeEdicao.euVerificoSeOBotaoAdicionarFoiClicado();
	});

	opaTest("Deve clicar no botao voltar para a tela de listagem", function (Given, When, Then) {
		When.naTelaDeEdicao.euClicoNoBotaoVoltarParaTelaListagem();
		Then.naTelaDeEdicao.euVerificoSeOBotaoVoltarParaATelaDeDetalhesFoiClicado();
		Then.naTelaDeEdicao.euVerificoSeAVendaFoiEditada();
	}),

	opaTest("Deve clicar na venda desejada e abrir a tela de detalhes", function (Given, When, Then) {
		When.naTelaDeEdicao.euClicoNaVendaDoIdNomeDesejado();
		Then.naTelaDeEdicao.euVerificoSeNomeEstaComoOEsperado();
	}),

	opaTest("Deve clicar no botao editar em detalhes e verificar se a view foi aberta", function (Given, When, Then) {
		When.naTelaDeEdicao.euClicoNoBotaoEditarNaTelaDeDetalhes();
		Then.naTelaDeEdicao.euVerificoSeAViewFoiCarregada();
		Then.iTeardownMyApp();
	})
});