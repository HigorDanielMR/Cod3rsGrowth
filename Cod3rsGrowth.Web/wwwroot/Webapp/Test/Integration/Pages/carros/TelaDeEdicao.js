sap.ui.define([
    'sap/ui/test/Opa5',
    'sap/ui/test/matchers/PropertyStrictEquals',
    'sap/ui/test/matchers/Properties',
    "sap/ui/test/actions/Press",
    "sap/ui/test/actions/EnterText",
    "sap/ui/test/matchers/Ancestor"


], function (Opa5, PropertyStrictEquals, Properties, Press, EnterText, Ancestor) {
    'use strict';
    
    const indexDaMarcaDesejada = "0";
    const modeloParaInserirEditar = "A3";
    const idDoSelectMarca = "SelecionarMarca";
    const viewEdicao = "carros.AdicionarCarro";
    const idInputModeloTelaDeEditar = "InputModelo";
    const idDoBotaoAdicionarCarro = "adicionarCarro";
    const idDoMessageStripSucessoEditar = "sucessoAoEditarCarro";
    const idDoMessageStripErroAoEditarCarro = "erroAoEditarCarro"
    
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
                        id: idInputModeloTelaDeEditar,
                        viewName: viewEdicao,
                        actions: new EnterText({
                            text: modeloVazio
                        }),
                        errorMessage: "Input não encontrado."
                    })
                },
                euInsiroOModeloNoInput() {
                    return this.waitFor({
                        id: idInputModeloTelaDeEditar,
                        viewName: viewEdicao,
                        actions: new EnterText({
                            text: modeloParaInserirEditar
                        }),
                        errorMessage: "Input não encontrado."
                    })
                },
                euSelecionoAMarcaDesejada() {
                    return this.waitFor({
                        id: idDoSelectMarca,
                        viewName: viewEdicao,
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

                euClicoNoBotaoAdicionarDaTelaDeEditar() {
                    return this.waitFor({
                        id: idDoBotaoAdicionarCarro,
                        viewName: viewEdicao,
                        actions: new Press(),
                        errorMessage: "Botão não encontrado."
                    })
                },
            },
            assertions: {
                euVerificoSeAMessageStripDeErroAoEditarCarroFoiExibida(){
                    const propriedadeDesejada = "visible";
                    const valorDesejado = true;
                    return this.waitFor({
                        viewName: viewEdicao,
                        id: idDoMessageStripErroAoEditarCarro,
                        matchers: new PropertyStrictEquals({
                            name: propriedadeDesejada,
                            value: valorDesejado
                        }),
                        success() {
                            Opa5.assert.ok(true, `Message strip aberta com sucesso.`)
                        },
                        errorMessage: `Message strip não foi aberta.`
                    })
                },
                euVerificoSeOMessageStripDeSUcessoFoiExibido() {
                    const propriedadeDesejada = "visible";
                    const valorDesejado = true;
                    return this.waitFor({
                        viewName: viewEdicao,
                        id: idDoMessageStripSucessoEditar,
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
