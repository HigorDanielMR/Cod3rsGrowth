sap.ui.define([
	"sap/ui/test/opaQunit",
	"./pages/TelaDeCriacao",
	"./pages/TelaDeListagem"

], (opaTest) => {

	QUnit.module("Posts");

	opaTest("Deve clicar no botao adicionar", function (Given, When, Then) {
		Given.iStartMyUIComponent({
			componentConfig: {
				name: "ui5.carro"
			}
		});
		When.naTelaDeListagem.euClicoNoBotaoAdicionar();
		Then.naTelaDeListagem.euVerificoSeOBotaoFoiClicado();
		
	});
	opaTest("Deve preencher o valor do input nome", function (Given, When, Then) {
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
		When.naTelaDeCriacao.euClicoNaTabelaCarro();
		When.naTelaDeCriacao.euSelecionoOItemNaTabela();
		Then.naTelaDeCriacao.euVereificoSeATabelaFoiPressionada();
	});

	opaTest("Deve clicar no botao adicionar e verificar se venda foi criada com sucesso", function (Given, When, Then) {
		When.naTelaDeCriacao.euClicoNoBotaoAdicionarDaTelaDeCriacao();
		When.naTelaDeCriacao.euClicoNoBotaoVoltarParaTelaDeListagem();
		When.naTelaDeCriacao.euClicoNoBotaoAtualizar();
		Then.naTelaDeCriacao.euVerificoSeOBotaoAdicionarFoiClicado();
		Then.naTelaDeCriacao.euVerificoSeOBotaoVoltarParaATelaDeListagemFoiClicado();
		Then.naTelaDeCriacao.euVerificoSeAVendaFoiCriada();

	});
});