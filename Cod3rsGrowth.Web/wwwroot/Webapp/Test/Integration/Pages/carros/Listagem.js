sap.ui.define([
    'sap/ui/test/Opa5',
    'sap/ui/test/matchers/PropertyStrictEquals',
    "sap/ui/test/actions/Press",
    "sap/ui/test/actions/EnterText",
    "sap/ui/test/matchers/AggregationLengthEquals"

], function (Opa5, PropertyStrictEquals, Press, EnterText, AggregationLengthEquals) {
    'use strict';

    const viewDetalhes = "Detalhes";
    const idDaTabela = "TabelaVendas";
    const viewListagem = "ListagemVenda";
    const contextoVendas = "Vendas";
    const idBotaoRemover = "botaoRemover";
    const idDaTagTextNome = "nomeDetalhes";
    const idTagNomeDetalhesCarro = "tagNomeDetalhesCarro"
    const idDaTabelaCarros = "TabelaCarros";
    const idTagIdDetalhesCarro = "tagIdDetalhesCarro";
    const tagDasLinhas = "items";
    const idDaTagTextID = "idDetalhes";
    const idBotaoVoltarParaTelaDeListagem = "voltarParaAListagem";

    Opa5.createPageObjects({
        naTelaDeDetalhesListagemCarro: {
            arrangements: {
                euInicioMeuApp() {
                    return this.iStartMyUIComponent("../index.html");
                }
            },

            actions: {
                euClicoNoBotaoVoltarParaATelaDeListagem() {
                    return this.waitFor({
                        id: idBotaoVoltarParaTelaDeListagem,
                        viewName: viewDetalhes,
                        actions: new Press(),
                        errorMessage: "Botão não encontrado"
                    })
                },

                euClicoNaVendaSelecionada() {
                    const propriedadeDesejada = "text";
                    const nomeDesejado = "Higor";
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
                euVerificoSeOIdDoCarroEstaComoOEsperado() {
                    var idEsperado = "1"
                    return this.waitFor({
                        id: idTagIdDetalhesCarro,
                        viewName: viewDetalhes,
                        controlType: "sap.m.Text",
                        success(texto) {
                            var idColetado = texto.getText();

                            Opa5.assert.strictEqual(idColetado, idEsperado, "O id está como esperado.")
                        },
                        errorMessage: "O id está como o esperado."
                    });
                },

                euVerificoSeNomeDoSegundoCarroEstaComoOEsperado() {
                    var nomeEsperado = "Skyline"
                    return this.waitFor({
                        id: idTagNomeDetalhesCarro,
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
                    var idEsperado = "2"
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
                euVerificoSeNomeDoSegundoItemDaListaEstaComoOEsperado() {
                    var nomeEsperado = "Higor"
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
                euVerificoSeOIdDoSegundoCarroEstaComoOEsperado() {
                    var idEsperado = "2"
                    return this.waitFor({
                        id: idTagIdDetalhesCarro,
                        viewName: viewDetalhes,
                        controlType: "sap.m.Text",
                        success(texto) {
                            var idColetado = texto.getText();

                            Opa5.assert.strictEqual(idColetado, idEsperado, "O id está como esperado.")
                        },
                        errorMessage: "O id está como o esperado."
                    });
                },

                euVerificoSeONomeDoSegundoCarroEstaComoOEsperado() {
                    var nomeEsperado = "Supra"
                    return this.waitFor({
                        id: idTagNomeDetalhesCarro,
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
