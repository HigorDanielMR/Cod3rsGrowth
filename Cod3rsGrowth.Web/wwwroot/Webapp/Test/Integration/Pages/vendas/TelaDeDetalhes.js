sap.ui.define([
    'sap/ui/test/Opa5',
    'sap/ui/test/matchers/PropertyStrictEquals',
    "sap/ui/test/actions/Press"

], function (Opa5, PropertyStrictEquals, Press) {
    'use strict';

    const ID_DA_TAG_TEXT_ID = "idDetalhes";
    const VIEW_DETALHES = "vendas.Detalhes";
    const ID_DA_TAG_TEXT_NOME = "nomeDetalhes";
    const VIEW_LISTAGEM = "vendas.ListagemVenda";
    const ID_BOTAO_VOLTAR_PARA_TELA_DE_LISTAGEM = "voltarParaAListagem";

    Opa5.createPageObjects({
        naTelaDeDetalhes: {
            arrangements: {
                euInicioMeuApp() {
                    return this.iStartMyUIComponent("../index.html");
                }
            },

            actions: {
                euClicoNoBotaoVoltarParaATelaDeListagem() {
                    return this.waitFor({
                        id: ID_BOTAO_VOLTAR_PARA_TELA_DE_LISTAGEM,
                        viewName: VIEW_DETALHES,
                        actions: new Press(),
                        errorMessage: "Botão não encontrado"
                    })
                },

                euClicoNaVendaSelecionada() {
                    const propriedadeDesejada = "text";
                    const nomeDesejado = "Higor";
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
                }
            },
            assertions: {
                euVerificoSeOIdEstaComoOEsperado() {
                    var idEsperado = "91"
                    return this.waitFor({
                        id: ID_DA_TAG_TEXT_ID,
                        viewName: VIEW_DETALHES,
                        controlType: "sap.m.Text",
                        success(texto) {
                            var idColetado = texto.getText();

                            Opa5.assert.strictEqual(idColetado, idEsperado, "O id está como esperado.")
                        },
                        errorMessage: "O id está como o esperado."
                    });
                },
                euVerificoSeNomeEstaComoOEsperado() {
                    var nomeEsperado = "Adriana"
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
                euVerificoSeOIdDoSegundoItemDaListaEstaComoOEsperado() {
                    var idEsperado = "2"
                    return this.waitFor({
                        id: ID_DA_TAG_TEXT_ID,
                        viewName: VIEW_DETALHES,
                        controlType: "sap.m.Text",
                        success(texto) {
                            var idColetado = texto.getText();

                            Opa5.assert.strictEqual(idColetado, idEsperado, "O id está como esperado.")
                        },
                        errorMessage: "O id está como o esperado."
                    });
                },
                euVerificoSeNomeDopSegundoItemDaListaEstaComoOEsperado() {
                    var nomeEsperado = "Higor"
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
                }
            }            
        }
    });
});
