sap.ui.define([
	"sap/ui/test/opaQunit",
	"./vendas/TelaDeEdicao",
	"./vendas/TelaDeListagem"

], (opaTest) => {

	QUnit.module("Teste tela de edicao");

	opaTest("Deve preencher o valor do input nome", function (Given, When, Then) {
		Given.iStartMyUIComponent({
			componentConfig: {
				name: "ui5/carro"
			},
			hash: "EditarVenda/3"
		});

		When.naTelaDeCriacao.euInsiroONomeNoInputNome();
		Then.naTelaDeCriacao.euVerificoSeOTextoFoiInseridoNoInputNome();
	});

	opaTest("Deve preencher o valor do input cpf", function (Given, When, Then) {
		When.naTelaDeCriacao.euInsiroOCpfNoInputCpf();
		Then.naTelaDeCriacao.euVerificoSeOTextoFoiInseridoNoInputCpf();
	});

	opaTest("Deve preencher o valor do input email", function (Given, When, Then) {
		When.naTelaDeCriacao.euInsiroOEmailNoInputEmail();
		Then.naTelaDeCriacao.euVerificoSeOTextoFoiInseridoNoInputEmail();
	});

	opaTest("Deve preencher o valor do input telefone", function (Given, When, Then) {

		When.naTelaDeCriacao.euInsiroOTelefoneNoInputTelefone();
		Then.naTelaDeCriacao.euVerificoSeOTextoFoiInseridoNoInputTelefone();
	});

	opaTest("Deve clicar no checkbox pago", function (Given, When, Then) {

		When.naTelaDeCriacao.euClicoNoInputPago();
		Then.naTelaDeCriacao.euVerificoSeOInputPagoFoiPressionado();
	});

	opaTest("Deve selecionar um carro na tabela", function (Given, When, Then) {
		When.naTelaDeCriacao.euSelecionoOItemNaTabela();
		Then.naTelaDeCriacao.euVereificoSeATabelaFoiPressionada();
	});

	opaTest("Deve clicar no botao adicionar e verificar se venda foi criada com sucesso", function (Given, When, Then) {
		When.naTelaDeCriacao.euClicoNoBotaoAdicionarDaTelaDeCriacao();
		When.naTelaDeCriacao.euClicoNoBotaoVoltarParaTelaDeListagem();
		Then.naTelaDeCriacao.euVerificoSeOBotaoAdicionarFoiClicado();
		Then.naTelaDeCriacao.euVerificoSeOBotaoVoltarParaATelaDeListagemFoiClicado();
		Then.naTelaDeCriacao.euVerificoSeAVendaFoiCriada();
	});

	opaTest("Deve clicar no botao adicionar venda na tela de listagem", function (Given, When, Then) {
		When.naTelaDeListagem.euClicoNoBotaoAdicionarVenda();
		Then.naTelaDeCriacao.euVerificoSeOBotaoAdicionarVendaFoiClicado();
	});
});