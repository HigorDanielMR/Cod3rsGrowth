sap.ui.define([
    'sap/ui/test/Opa5',
    'sap/ui/test/matchers/PropertyStrictEquals',
    "sap/ui/test/actions/Press",
    "sap/ui/test/actions/EnterText"

], function (Opa5, PropertyStrictEquals, Press, EnterText) {
    'use strict';

    const viewDetalhes = "Detalhes"
    const idDaTagTextID = "idDetalhes"
    const viewListagem = "ListagemVenda"
    const idTabelaVendas = "TabelaVendas"
    const idDaTagTextNome = "nomeDetalhes"
    const idDaVendaSelecionadaTabelaVenda = "__item0-__component0---listagem--TabelaVendas-0"

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
                        id: "voltarParaAListagem",
                        viewName: viewDetalhes,
                        actions: new Press(),
                        errorMessage: "Botão não encontrado"
                    })
                },

                euClicoNaVendaSelecionada() {
                    return this.waitFor({
                        controlType: "sap.m.Text",
                        viewName: viewListagem,
                        matchers: [
                            new PropertyStrictEquals({
                                name: "text",
                                value: "Higor Daniel"
                            })
                        ],
                        actions: new Press(),
                        errorMessage: "Item com o nome desejado não encontrado"
                    });
                }
            },
            assertions: {
                euVerificoSeOIdEstaComoOEsperado() {
                    var idEsperado = "1"
                    return this.waitFor({
                        id: idDaTagTextID,
                        viewName: viewDetalhes,
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
                euVerificoSeOIdDoSegundoItemDaListaEstaComoOEsperado() {
                    var idEsperado = "3"
                    return this.waitFor({
                        id: idDaTagTextID,
                        viewName: viewDetalhes,
                        controlType: "sap.m.Text",
                        success(texto) {
                            var idColetado = texto.getText();

                            Opa5.assert.strictEqual(idColetado, idEsperado, "O id está como esperado.")
                        },
                        errorMessage: "O id está como o esperado."
                    });
                },
                euVerificoSeNomeDopSegundoItemDaListaEstaComoOEsperado() {
                    var nomeEsperado = "Higor Daniel"
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
                }
            }            
        }
    });
});
