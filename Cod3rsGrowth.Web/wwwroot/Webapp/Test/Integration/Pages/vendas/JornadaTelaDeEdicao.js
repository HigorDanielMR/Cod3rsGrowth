sap.ui.define([
	"sap/ui/test/opaQunit",
	"./TelaDeEdicao",
	"./TelaDeListagem"

], (opaTest) => {

	QUnit.module("Teste tela de edicao");

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

	opaTest("Deve preencher o valor do input cpf", function (Given, When, Then) {
		When.naTelaDeEdicao.euInsiroOCpfNoInputCpf();
		Then.naTelaDeEdicao.euVerificoSeOTextoFoiInseridoNoInputCpf();
	});

	opaTest("Deve preencher o valor do input email", function (Given, When, Then) {
		When.naTelaDeEdicao.euInsiroOEmailNoInputEmail();
		Then.naTelaDeEdicao.euVerificoSeOTextoFoiInseridoNoInputEmail();
	});

	opaTest("Deve preencher o valor do input telefone", function (Given, When, Then) {

		When.naTelaDeEdicao.euInsiroOTelefoneNoInputTelefone();
		Then.naTelaDeEdicao.euVerificoSeOTextoFoiInseridoNoInputTelefone();
	});

	opaTest("Deve clicar no checkbox pago", function (Given, When, Then) {

		When.naTelaDeEdicao.euClicoNoInputPago();
		Then.naTelaDeEdicao.euVerificoSeOInputPagoFoiPressionado();
	});

	opaTest("Deve selecionar um carro na tabela", function (Given, When, Then) {
		When.naTelaDeEdicao.euSelecionoOItemNaTabela();
		Then.naTelaDeEdicao.euVereificoSeATabelaFoiPressionada();
	});

	opaTest("Deve clicar no botao adicionar e verificar se venda foi criada com sucesso", function (Given, When, Then) {
		When.naTelaDeEdicao.euClicoNoBotaoAdicionarDaTelaDeCriacao();
		When.naTelaDeEdicao.euClicoNoBotaoVoltarParaTelaDeListagem();
		Then.naTelaDeEdicao.euVerificoSeOBotaoAdicionarFoiClicado();
		Then.naTelaDeEdicao.euVerificoSeOBotaoVoltarParaATelaDeListagemFoiClicado();
		Then.naTelaDeEdicao.euVerificoSeAVendaFoiCriada();
	});

	opaTest("Deve clicar no botao adicionar venda na tela de listagem", function (Given, When, Then) {
		When.naTelaDeEdicao.euClicoNoBotaoAdicionarVenda();
		Then.naTelaDeEdicao.euVerificoSeOBotaoAdicionarVendaFoiClicado();
	});

	
});