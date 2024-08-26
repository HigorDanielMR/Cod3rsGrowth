sap.ui.define([
	"sap/ui/test/opaQunit",
	"./TelaDeCriacao",
	"./TelaDeListagem"

], (opaTest) => {

	QUnit.module("Vendas Criacao");
	
	opaTest("Deve clicar no botao adicionar e verificar se message strip de erro foi aberta.", function (Given, When, Then) {
		Given.iStartMyUIComponent({
			componentConfig: {
				name: "ui5/carro"
			},
			hash: "AdicionarVenda"
		});
		When.naTelaDeCriacao.euClicoNoBotaoAdicionarDaTelaDeCriacao();
		Then.naTelaDeCriacao.euVerificoSeAMessageStripDeErroAoCriarVendaFoiExibida();
	});

	opaTest("Deve preencher os dados da venda e verificar se a messge strip de sucesso foi aberta.", function(Given, When, Then){
		When.naTelaDeCriacao.euInsiroONomeNoInputNome();
		When.naTelaDeCriacao.euInsiroOCpfNoInputCpf();
		When.naTelaDeCriacao.euInsiroOEmailNoInputEmail();		
		When.naTelaDeCriacao.euInsiroOTelefoneNoInputTelefone();
		When.naTelaDeCriacao.euClicoNoInputPago();
		When.naTelaDeCriacao.euSelecionoOItemNaTabela();
		When.naTelaDeCriacao.euClicoNoBotaoAdicionarDaTelaDeCriacao();
		Then.naTelaDeCriacao.euVerificoSeAMessageStripDeSucessoAoCriarVendaFoiExibida();
		Then.iTeardownMyApp();
	})
});