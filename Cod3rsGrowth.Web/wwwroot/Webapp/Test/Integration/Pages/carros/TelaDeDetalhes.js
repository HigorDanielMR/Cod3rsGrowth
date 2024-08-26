sap.ui.define([
    'sap/ui/test/Opa5',
    'sap/ui/test/matchers/PropertyStrictEquals',
    "sap/ui/test/actions/Press"

], function (Opa5, PropertyStrictEquals, Press) {
    'use strict';

    const idDaTagTextID = "idCarro";
    const idDaTagTextModelo = "idModelo";
    const viewDetalhes = "carros.DetalhesCarro";
    const viewListagem = "carros.ListagemCarro";
    const idBotaoVoltarParaTelaDeListagem = "voltarParaAListagem";

    Opa5.createPageObjects({
        naTelaDeDetalhesCarro: {
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

                euClicoNoCarroDesejado() {
                    const propriedadeDesejada = "text";
                    const modeloDesejado = "Supra";
                    return this.waitFor({
                        controlType: "sap.m.Text",
                        viewName: viewListagem,
                        matchers: [
                            new PropertyStrictEquals({
                                name: propriedadeDesejada,
                                value: modeloDesejado
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
                euVerificoSeModeloEstaComoOEsperado() {
                    var modeloEsperado = "Skyline"
                    return this.waitFor({
                        id: idDaTagTextModelo,
                        viewName: viewDetalhes,
                        controlType: "sap.m.Text",
                        success: function (texto) {
                            var modeloPreenchido = texto.getText();

                            Opa5.assert.strictEqual(modeloPreenchido, modeloEsperado, "O nome está como o esperado.");
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
                euVerificoSeModeloDoSegundoItemDaListaEstaComoOEsperado() {
                    var modeloEsperado = "Supra"
                    return this.waitFor({
                        id: idDaTagTextModelo,
                        viewName: viewDetalhes,
                        controlType: "sap.m.Text",
                        success: function (texto) {
                            var modeloPreenchido = texto.getText();

                            Opa5.assert.strictEqual(modeloPreenchido, modeloEsperado, "O nome está como o esperado.");
                        },
                        errorMessage: "O nome não como o esperado."
                    });
                }
            }            
        }
    });
});
