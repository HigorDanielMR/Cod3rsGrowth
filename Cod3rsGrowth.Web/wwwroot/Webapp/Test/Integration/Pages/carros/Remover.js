sap.ui.define([
    'sap/ui/test/Opa5',
    'sap/ui/test/matchers/PropertyStrictEquals',
    "sap/ui/test/actions/Press"

], function (Opa5, PropertyStrictEquals, Press) {
    'use strict';

    const CONTEXTO_CARROS = "Carros";
    const ID_DA_TABELA = "TabelaCarros";
    const ID_DA_TAG_TEXT_MODELO = "idModelo";
    const ID_BOTAO_REMOVER = "botaoRemoverCarro";
    const VIEW_DETALHES = "carros.DetalhesCarro";
    const VIEW_LISTAGEM = "carros.ListagemCarro";

    Opa5.createPageObjects({
        naTelaDetalhesRemoverCarro: {
            arrangements: {
                euInicioMeuApp() {
                    return this.iStartMyUIComponent("../index.html");
                }
            },

            actions: {
                euClicoNoCarroDesejado() {
                    const propriedadeDesejada = "text";
                    const MODELO_DESEJADO = "M3 Competition";
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
                        errorMessage: "Carro com o modelo desejado não encontrado"
                    });
                },
                euClicoNoBotaoRemover() {
                    return this.waitFor({
                        viewName: VIEW_DETALHES,
                        id: ID_BOTAO_REMOVER,
                        actions: new Press(),
                        errorMessage: "Botão não encontrado."
                    })
                },
                euClicoNoBotaoSimDaMessageBox(){
                    const botaoSimMessageBox = "Sim";
                    return this.waitFor({
                        viewName: VIEW_DETALHES,
                        searchOpenDialogs: true, 
                        controlType: "sap.m.Button", 
                        success(aButtons) {
                            return aButtons.filter(function (oButton) {
                                if(oButton.getText() == botaoSimMessageBox) {
                                    oButton.firePress();
                                }
                            });
                        },
                        actions: new Press(),
                        errorMessage: "MessageBox não encontrada."
                    })
                },

                euClicoNoBotaoOkDaMessageBoxSucesso(){
                    const botaoSimMessageBox = "Ok";
                    return this.waitFor({
                        viewName: VIEW_DETALHES,
                        searchOpenDialogs: true, 
                        controlType: "sap.m.Button", 
                        success(aButtons) {
                            return aButtons.filter(function (oButton) {
                                if(oButton.getText() == botaoSimMessageBox) {
                                    oButton.firePress();
                                }
                            });
                        },
                        actions: new Press(),
                        errorMessage: "MessageBox não encontrada."
                    })
                }
            },
            assertions: {
                euVerificoSeModeloEstaComoOEsperado() {
                    var modeloEsperado = "M3 Competition"
                    return this.waitFor({
                        id: ID_DA_TAG_TEXT_MODELO,
                        viewName: VIEW_DETALHES,
                        controlType: "sap.m.Text",
                        success: function (texto) {
                            var modeloPreenchido = texto.getText();

                            Opa5.assert.strictEqual(modeloPreenchido, modeloEsperado, "O modelo está como o esperado.");
                        },
                        errorMessage: "O modelo não como o esperado."
                    });
                },
                euVerificoSeOCarroFoiRemovidoComSucesso(){
                    const MODELO_DESEJADO = 'M3 Competition';
                    const propriedadeDesejada = "modelo";
                    return this.waitFor({
                        viewName: VIEW_LISTAGEM,
                        id: ID_DA_TABELA,
                        success: function (oTable) {
                            var items = oTable.getItems();
                            var verificarItems = items.some((item, indice, lista) => {
                                var itemDesejado = lista[indice].getBindingContext(CONTEXTO_CARROS).getProperty(propriedadeDesejada);

                                return itemDesejado === MODELO_DESEJADO;
                            });
                            if(!verificarItems) Opa5.assert.ok(true, `Venda removida com sucesso.`);
                        },
                        errorMessage: "Venda não foi removida."
                    });
                }
            }            
        }
    });
});
