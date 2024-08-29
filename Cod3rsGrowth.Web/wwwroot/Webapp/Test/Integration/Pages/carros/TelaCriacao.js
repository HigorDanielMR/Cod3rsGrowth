sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/EnterText",
    "sap/ui/test/actions/Press",
    "sap/ui/test/matchers/PropertyStrictEquals",
    "sap/ui/test/matchers/Properties",
    "sap/ui/test/matchers/Ancestor"


], (Opa5, EnterText, Press, PropertyStrictEquals, Properties, Ancestor) => {
    "use strict";

    const VALOR_DESEJADO = "814950";
    const INDEX_DA_COR_DESEJADA = "4";
    const INDEX_DA_MARCA_DESEJADA = "2";
    const ID_DO_SWITCH_FLEX = "InputFlex"
    const ID_DO_INPUT_VALOR = "InputValor";
    const ID_DO_SELECT_COR = "SelecionarCor";
    const ID_DO_INPUT_MODELO = "InputModelo";
    const MODELO_DESEJADO = "M3 Competition";
    const ID_DO_SELECT_MARCA = "SelecionarMarca";
    const ID_DO_BOTAO_ADICIONAR_CARRO = "adicionarCarro";
    const VIEW_ADICIONAR_CARRO = "carros.AdicionarCarro";
    const ID_DO_MESSAGE_STRIP_ERRO_CRIAR_CARRO= "erroAoCriarCarro";
    const ID_DO_MESSAGE_STRIP_SUCESSO_AO_CRIAR_CARRO = "sucessoAoCriarCarro";

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
                        id: ID_DO_INPUT_MODELO,
                        viewName: VIEW_ADICIONAR_CARRO,
                        actions: new EnterText({
                            text: MODELO_DESEJADO
                        }),
                        errorMessage: "Input não encontrado."
                    });
                },

                euPreenchoOInputDoValor() {
                    return this.waitFor({
                        id: ID_DO_INPUT_VALOR,
                        viewName: VIEW_ADICIONAR_CARRO,
                        actions: new EnterText({
                            text: VALOR_DESEJADO
                        }),
                        errorMessage: "Input não encontrado."
                    })
                },

                euClicoNoSelectESelecionoACorDesejada() {
                    return this.waitFor({
                        id: ID_DO_SELECT_COR,
                        viewName: VIEW_ADICIONAR_CARRO,
                        actions: new Press(),
                        success(oSelect) {
                            this.waitFor({
                                controlType: "sap.ui.core.Item",
                                matchers: [
                                    new Ancestor(oSelect),
                                    new Properties({ key: INDEX_DA_COR_DESEJADA })
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
                        id: ID_DO_SELECT_MARCA,
                        viewName: VIEW_ADICIONAR_CARRO,
                        actions: new Press(),
                        success(oSelect) {
                            this.waitFor({
                                controlType: "sap.ui.core.Item",
                                matchers: [
                                    new Ancestor(oSelect),
                                    new Properties({ key: INDEX_DA_MARCA_DESEJADA })
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
                        id: ID_DO_SWITCH_FLEX,
                        viewName: VIEW_ADICIONAR_CARRO,
                        actions: new Press(),
                        errorMessage: "Switch não encontrado."
                    });
                },

                euClicoNoBotaoAdicionarCarro() {
                    return this.waitFor({
                        id: ID_DO_BOTAO_ADICIONAR_CARRO,
                        viewName: VIEW_ADICIONAR_CARRO,
                        actions: new Press(),
                        errorMessage: "Botão não encontrado."
                    })
                }
            },

            assertions: {
                euVerificoSeAMessageStripDeErroAoCriarCarroFoiExibida(){
                    const propriedadeDesejada = "visible";
                    const VALOR_DESEJADO = true;
                    return this.waitFor({
                        viewName: VIEW_ADICIONAR_CARRO,
                        id: ID_DO_MESSAGE_STRIP_ERRO_CRIAR_CARRO,
                        matchers: new PropertyStrictEquals({
                            name: propriedadeDesejada,
                            value: VALOR_DESEJADO
                        }),
                        success() {
                            Opa5.assert.ok(true, `Message strip aberta com sucesso.`)
                        },
                        errorMessage: `Message strip não foi aberta.`
                    })
                },
                euVerificoSeAMessageStripDeCarroCriadoComSucessoFoiExibida() {
                    const propriedadeDesejada = "visible";
                    const VALOR_DESEJADO = true;
                    return this.waitFor({
                        viewName: VIEW_ADICIONAR_CARRO,
                        id: ID_DO_MESSAGE_STRIP_SUCESSO_AO_CRIAR_CARRO,
                        matchers: new PropertyStrictEquals({
                            name: propriedadeDesejada,
                            value: VALOR_DESEJADO
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
