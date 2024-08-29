sap.ui.define([
    'sap/ui/test/Opa5',
    'sap/ui/test/matchers/PropertyStrictEquals',
    "sap/ui/test/actions/Press"

], function (Opa5, PropertyStrictEquals, Press) {
    'use strict';

    const ID_DA_TAG_TEXT_ID = "idCarro";
    const ID_DA_TAG_TEXT_MODELO = "idModelo";
    const VIEW_DETALHES = "carros.DetalhesCarro";
    const VIEW_LISTAGEM = "carros.ListagemCarro";
    const ID_BOTAO_VOLTAR_PARA_TELA_DE_LISTAGEM = "voltarParaAListagem";

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
                        id: ID_BOTAO_VOLTAR_PARA_TELA_DE_LISTAGEM,
                        viewName: VIEW_DETALHES,
                        actions: new Press(),
                        errorMessage: "Botão não encontrado"
                    })
                },

                euClicoNoCarroDesejado() {
                    const propriedadeDesejada = "text";
                    const MODELO_DESEJADO = "Supra";
                    return this.waitFor({
                        controlType: "sap.m.Text",
                        viewName: VIEW_LISTAGEM,
                        matchers: [
                            new PropertyStrictEquals({
                                name: propriedadeDesejada,
                                value: MODELO_DESEJADO
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
                euVerificoSeModeloEstaComoOEsperado() {
                    var modeloEsperado = "Skyline"
                    return this.waitFor({
                        id: ID_DA_TAG_TEXT_MODELO,
                        viewName: VIEW_DETALHES,
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
                euVerificoSeModeloDoSegundoItemDaListaEstaComoOEsperado() {
                    var modeloEsperado = "Supra"
                    return this.waitFor({
                        id: ID_DA_TAG_TEXT_MODELO,
                        viewName: VIEW_DETALHES,
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
