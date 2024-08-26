sap.ui.define([
    'sap/ui/test/Opa5',
    'sap/ui/test/matchers/PropertyStrictEquals',
    "sap/ui/test/actions/Press",
    "sap/ui/test/actions/EnterText"

], function (Opa5, PropertyStrictEquals, Press, EnterText) {
    'use strict';

    const contextoVendas = "Vendas";
    const idDaTabela = "TabelaVendas";
    const idBotaoRemover = "botaoRemover";
    const idDaTagTextNome = "nomeDetalhes";
    const viewDetalhes = "vendas.Detalhes";
    const viewListagem = "vendas.ListagemVenda";

    Opa5.createPageObjects({
        naTelaDeDetalhesRemover: {
            arrangements: {
                euInicioMeuApp() {
                    return this.iStartMyUIComponent("../index.html");
                }
            },

            actions: {
                euClicoNaVendaSelecionada() {
                    const propriedadeDesejada = "text";
                    const nomeDesejado = "Teste Remover";
                    return this.waitFor({
                        controlType: "sap.m.Text",
                        viewName: viewListagem,
                        matchers: [
                            new PropertyStrictEquals({
                                name: propriedadeDesejada,
                                value: nomeDesejado
                            })
                        ],
                        actions: new Press(),
                        errorMessage: "Item com o nome desejado não encontrado"
                    });
                },
                euClicoNoBotaoRemover() {
                    return this.waitFor({
                        viewName: viewDetalhes,
                        id: idBotaoRemover,
                        actions: new Press(),
                        errorMessage: "Botão não encontrado."
                    })
                },
                euClicoNoBotaoSimDaMessageBox(){
                    const botaoSimMessageBox = "Sim";
                    return this.waitFor({
                        viewName: viewDetalhes,
                        searchOpenDialogs: true, 
                        controlType: "sap.m.Button", 
                        success(aButtons) {
                            return aButtons.filter(function (oButton) {
                                if(oButton.getText() == botaoSimMessageBox) {
                                    oButton.firePress();
                                }
                            });
                        },
                        actions: new Press(),
                        errorMessage: "MessageBox não encontrada."
                    })
                },
                euClicoNoBotaoNaoDaMessageBox(){
                    const botaoNaoMessageBox = "Não";
                    return this.waitFor({
                        viewName: viewDetalhes,
                        searchOpenDialogs: true, 
                        controlType: "sap.m.Button", 
                        success(aButtons) {
                            return aButtons.filter(function (oButton) {
                                if(oButton.getText() == botaoNaoMessageBox) {
                                    oButton.firePress();
                                }
                            });
                        },
                        actions: new Press(),
                        errorMessage: "MessageBox não encontrada."
                    })
                }
            },
            assertions: {
                euVerificoSeNomeEstaComoOEsperado() {
                    var nomeEsperado = "Teste Remover"
                    return this.waitFor({
                        id: idDaTagTextNome,
                        viewName: viewDetalhes,
                        controlType: "sap.m.Text",
                        success: function (texto) {
                            var nomePreenchido = texto.getText();

                            Opa5.assert.strictEqual(nomePreenchido, nomeEsperado, "O nome está como o esperado.");
                        },
                        errorMessage: "O nome não como o esperado."
                    });
                },
                euVerificoSeAVendaFoiRemovidaComSucesso(){
                    const nomeDesejado = 'Teste Remover';
                    const propriedadeDesejada = "nome";
                    return this.waitFor({
                        viewName: viewListagem,
                        id: idDaTabela,
                        success: function (oTable) {
                            var items = oTable.getItems();
                            var verificarItems = items.some((item, indice, lista) => {
                                var itemDesejado = lista[indice].getBindingContext(contextoVendas).getProperty(propriedadeDesejada);

                                return itemDesejado === nomeDesejado;
                            });
                            if(!verificarItems) Opa5.assert.ok(true, `Venda removida com sucesso.`);
                        },
                        errorMessage: "Venda não foi removida."
                    });
                }
            }            
        }
    });
});
