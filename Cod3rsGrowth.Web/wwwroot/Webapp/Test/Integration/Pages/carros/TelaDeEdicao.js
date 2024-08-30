sap.ui.define([
    'sap/ui/test/Opa5',
    'sap/ui/test/matchers/PropertyStrictEquals',
    'sap/ui/test/matchers/Properties',
    "sap/ui/test/actions/Press",
    "sap/ui/test/actions/EnterText",
    "sap/ui/test/matchers/Ancestor"


], function (Opa5, PropertyStrictEquals, Properties, Press, EnterText, Ancestor) {
    'use strict';
    
    const INDEX_DA_MARCA_DESEJADA = "0";
    const MODELO_PARA_INSERIR_EDITAR = "A3";
    const VIEW_EDICAO = "carros.AdicionarCarro";
    const ID_DO_SELECT_MARCA = "SelecionarMarca";
    const ID_INPUT_MODELO_TELA_DE_EDITAR = "InputModelo";
    const ID_DO_BOTAO_ADICIONAR_CARRO = "adicionarCarro";
    const ID_DO_MESSAGE_STRIP_SUCESSO_EDITAR = "sucessoAoEditarCarro";
    const ID_DO_MESSAGE_STRIP_ERRO_AO_EDITAR_CARRO = "erroAoEditarCarro";
    
    Opa5.createPageObjects({
        naTelaDeEdicaoCarro: {
            arrangements: {
                euInicioMeuApp() {
                    return this.iStartMyUIComponent("../index.html");
                }
            },

            actions: {
                euLimpoModeloDoInput(){
                    const modeloVazio = "";
                    return this.waitFor({
                        id: ID_INPUT_MODELO_TELA_DE_EDITAR,
                        viewName: VIEW_EDICAO,
                        actions: new EnterText({
                            text: modeloVazio
                        }),
                        errorMessage: "Input não encontrado."
                    })
                },
                euInsiroOModeloNoInput() {
                    return this.waitFor({
                        id: ID_INPUT_MODELO_TELA_DE_EDITAR,
                        viewName: VIEW_EDICAO,
                        actions: new EnterText({
                            text: MODELO_PARA_INSERIR_EDITAR
                        }),
                        errorMessage: "Input não encontrado."
                    })
                },
                euSelecionoAMarcaDesejada() {
                    return this.waitFor({
                        id: ID_DO_SELECT_MARCA,
                        viewName: VIEW_EDICAO,
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

                euClicoNoBotaoAdicionarDaTelaDeEditar() {
                    return this.waitFor({
                        id: ID_DO_BOTAO_ADICIONAR_CARRO,
                        viewName: VIEW_EDICAO,
                        actions: new Press(),
                        errorMessage: "Botão não encontrado."
                    })
                },
            },
            assertions: {
                euVerificoSeAMessageStripDeErroAoEditarCarroFoiExibida(){
                    const propriedadeDesejada = "visible";
                    const VALOR_DESEJADO = true;
                    return this.waitFor({
                        viewName: VIEW_EDICAO,
                        id: ID_DO_MESSAGE_STRIP_ERRO_AO_EDITAR_CARRO,
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
                euVerificoSeOMessageStripDeSUcessoFoiExibido() {
                    const propriedadeDesejada = "visible";
                    const VALOR_DESEJADO = true;
                    return this.waitFor({
                        viewName: VIEW_EDICAO,
                        id: ID_DO_MESSAGE_STRIP_SUCESSO_EDITAR,
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
