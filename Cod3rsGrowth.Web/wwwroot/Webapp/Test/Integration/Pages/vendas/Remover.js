sap.ui.define([
    'sap/ui/test/Opa5',
    'sap/ui/test/matchers/PropertyStrictEquals',
    "sap/ui/test/actions/Press"

], function (Opa5, PropertyStrictEquals, Press) {
    'use strict';

    const CONTEXTO_VENDAS = "Vendas";
    const ID_DA_TABELA = "TabelaVendas";
    const VIEW_DETALHES = "vendas.Detalhes";
    const ID_BOTAO_REMOVER = "botaoRemover";
    const ID_DA_TAG_TEXT_NOME = "nomeDetalhes";
    const VIEW_LISTAGEM = "vendas.ListagemVenda";

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
                        viewName: VIEW_LISTAGEM,
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
                        viewName: VIEW_DETALHES,
                        id: ID_BOTAO_REMOVER,
                        actions: new Press(),
                        errorMessage: "Botão não encontrado."
                    })
                },
                euClicoNoBotaoSimDaMessageBox(){
                    const botaoSimMessageBox = "Sim";
                    return this.waitFor({
                        viewName: VIEW_DETALHES,
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
                euClicoNoBotaoOkDaMessageBox(){
                    const botaoNaoMessageBox = "Ok";
                    return this.waitFor({
                        viewName: VIEW_DETALHES,
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
                        id: ID_DA_TAG_TEXT_NOME,
                        viewName: VIEW_DETALHES,
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
                        viewName: VIEW_LISTAGEM,
                        id: ID_DA_TABELA,
                        success: function (oTable) {
                            var items = oTable.getItems();
                            var verificarItems = items.some((item, indice, lista) => {
                                var itemDesejado = lista[indice].getBindingContext(CONTEXTO_VENDAS).getProperty(propriedadeDesejada);

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
