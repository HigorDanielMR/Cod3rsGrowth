sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/EnterText",
    "sap/ui/test/actions/Press",
    "sap/ui/test/matchers/PropertyStrictEquals",
    "sap/ui/test/matchers/Properties",
    "sap/ui/test/matchers/Ancestor"


], (Opa5, EnterText, Press, PropertyStrictEquals, Properties, Ancestor) => {
    "use strict";

    const valorDesejado = "814950";
    const indexDaCorDesejada = "4";
    const indexDaMarcaDesejada = "2";
    const idDoSwitchFlex = "InputFlex"
    const idDoInputValor = "InputValor";
    const idDoSelectCor = "SelecionarCor";
    const idDoInputModelo = "InputModelo";
    const modeloDesejado = "M3 Competition";
    const idDoSelectMarca = "SelecionarMarca";
    const idDoBotaoAdicionarCarro = "adicionarCarro";
    const viewAdicionarCarro = "carros.AdicionarCarro";
    const idDoMessageStripSucessoAoCriarCarro = "sucessoAoCriarCarro";

    Opa5.createPageObjects({
        naTelaDeAdicionarCarro: {
            arrangements: {
                euInicioMeuApp() {
                    return this.iStartMyUIComponent("../index.html");
                }
            },

            actions: {
                euPreenchoOInputDoModelo() {
                    return this.waitFor({
                        id: idDoInputModelo,
                        viewName: viewAdicionarCarro,
                        actions: new EnterText({
                            text: modeloDesejado
                        }),
                        errorMessage: "Input não encontrado."
                    });
                },

                euPreenchoOInputDoValor() {
                    return this.waitFor({
                        id: idDoInputValor,
                        viewName: viewAdicionarCarro,
                        actions: new EnterText({
                            text: valorDesejado
                        }),
                        errorMessage: "Input não encontrado."
                    })
                },

                euClicoNoSelectESelecionoACorDesejada() {
                    return this.waitFor({
                        id: idDoSelectCor,
                        viewName: viewAdicionarCarro,
                        actions: new Press(),
                        success(oSelect) {
                            this.waitFor({
                                controlType: "sap.ui.core.Item",
                                matchers: [
                                    new Ancestor(oSelect),
                                    new Properties({ key: indexDaCorDesejada })
                                ],
                                actions: new Press(),
                                errorMessage: "Cor não encontrada."
                            });
                        },
                        errorMessage: "Select não encontrado."
                    });
                },

                euCliCoNoSelectESelecionoAMarcaDesejada() {
                    return this.waitFor({
                        id: idDoSelectMarca,
                        viewName: viewAdicionarCarro,
                        actions: new Press(),
                        success(oSelect) {
                            this.waitFor({
                                controlType: "sap.ui.core.Item",
                                matchers: [
                                    new Ancestor(oSelect),
                                    new Properties({ key: indexDaMarcaDesejada })
                                ],
                                actions: new Press(),
                                errorMessage: "Marca não encontrada."
                            });
                        },
                        errorMessage: "Select não encontrado."
                    });
                },

                euClicoNoSeletESelecionoOTipoFlexDesejado() {
                    return this.waitFor({
                        id: idDoSwitchFlex,
                        viewName: viewAdicionarCarro,
                        actions: new Press(),
                        errorMessage: "Switch não encontrado."
                    });
                },

                euClicoNoBotaoAdicionarCarro() {
                    return this.waitFor({
                        id: idDoBotaoAdicionarCarro,
                        viewName: viewAdicionarCarro,
                        actions: new Press(),
                        errorMessage: "Botão não encontrado."
                    })
                }
            },

            assertions: {
                euVerificoSeAMessageStripDeCarroCriadoComSucessoFoiExibida() {
                    const propriedadeDesejada = "visible";
                    const valorDesejado = true;
                    return this.waitFor({
                        viewName: viewAdicionarCarro,
                        id: idDoMessageStripSucessoAoCriarCarro,
                        matchers: new PropertyStrictEquals({
                            name: propriedadeDesejada,
                            value: valorDesejado
                        }),
                        success() {
                            Opa5.assert.ok(true, `Message strip aberta com sucesso.`)
                        },
                        errorMessage: `Message strip não foi aberta.`
                    })
                }
            }
        }
    });
});
