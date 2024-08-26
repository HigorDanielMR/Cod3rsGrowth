sap.ui.define([
    'sap/ui/test/Opa5',
    'sap/ui/test/matchers/PropertyStrictEquals',
    "sap/ui/test/actions/Press",
    "sap/ui/test/actions/EnterText"

], function (Opa5, PropertyStrictEquals, Press, EnterText) {
    'use strict';

    const contextoCarros = "Carros";
    const idDaTabela = "TabelaCarros";
    const idDaTagTextModelo = "idModelo";
    const idBotaoRemover = "botaoRemoverCarro";
    const viewDetalhes = "carros.DetalhesCarro";
    const viewListagem = "carros.ListagemCarro";

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
                    const modeloDesejado = "M3 Competition";
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
                        errorMessage: "Carro com o modelo desejado não encontrado"
                    });
                },
                euClicoNoBotaoRemover() {
                    return this.waitFor({
                        viewName: viewDetalhes,
                        id: idBotaoRemover,
                        actions: new Press(),
                        errorMessage: "Botão não encontrado."
                    })
                },
                euClicoNoBotaoSimDaMessageBox(){
                    const botaoSimMessageBox = "Sim";
                    return this.waitFor({
                        viewName: viewDetalhes,
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
                        viewName: viewDetalhes,
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
                        id: idDaTagTextModelo,
                        viewName: viewDetalhes,
                        controlType: "sap.m.Text",
                        success: function (texto) {
                            var modeloPreenchido = texto.getText();

                            Opa5.assert.strictEqual(modeloPreenchido, modeloEsperado, "O modelo está como o esperado.");
                        },
                        errorMessage: "O modelo não como o esperado."
                    });
                },
                euVerificoSeOCarroFoiRemovidoComSucesso(){
                    const modeloDesejado = 'M3 Competition';
                    const propriedadeDesejada = "modelo";
                    return this.waitFor({
                        viewName: viewListagem,
                        id: idDaTabela,
                        success: function (oTable) {
                            var items = oTable.getItems();
                            var verificarItems = items.some((item, indice, lista) => {
                                var itemDesejado = lista[indice].getBindingContext(contextoCarros).getProperty(propriedadeDesejada);

                                return itemDesejado === modeloDesejado;
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
