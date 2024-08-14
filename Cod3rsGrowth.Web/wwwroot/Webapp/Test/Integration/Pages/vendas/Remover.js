sap.ui.define([
    'sap/ui/test/Opa5',
    'sap/ui/test/matchers/PropertyStrictEquals',
    "sap/ui/test/actions/Press",
    "sap/ui/test/actions/EnterText"

], function (Opa5, PropertyStrictEquals, Press, EnterText) {
    'use strict';

    const viewDetalhes = "Detalhes";
    const idDaTagTextID = "idDetalhes";
    const viewListagem = "ListagemVenda";
    const idDaTagTextNome = "nomeDetalhes";
    const idBotaoVoltarParaTelaDeListagem = "voltarParaAListagem";

    Opa5.createPageObjects({
        naTelaDeDetalhesRemover: {
            arrangements: {
                euInicioMeuApp() {
                    return this.iStartMyUIComponent("../index.html");
                }
            },

            actions: {
                euClicoNaVendaSelecionada() {
                    return this.waitFor({
                        controlType: "sap.m.Text",
                        viewName: viewListagem,
                        matchers: [
                            new PropertyStrictEquals({
                                name: "text",
                                value: "Teste Remover"
                            })
                        ],
                        actions: new Press(),
                        errorMessage: "Item com o nome desejado não encontrado"
                    });
                },
                euClicoNoBotaoRemover() {
                    return this.waitFor({
                        viewName: viewDetalhes,
                        id: "botaoRemover",
                        actions: new Press(),
                        errorMessage: "Botão não encontrado."
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
                euVerificoSeAMessageBoxDeConfirmarRemoverVendaFoiAberta() {
                    this.waitFor({
                        controlType: "sap.m.MessageBox",
                        success() {
                            Opa5.assert.ok(true, "A MessageBox foi aberta!");
                        },
                        errorMessage: "Não foi possível encontrar a MessageBox"
                    });

                }
            }            
        }
    });
});
