sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/EnterText",
    "sap/ui/test/matchers/AggregationLengthEquals",
    "sap/ui/test/actions/Press"

], (Opa5, EnterText, AggregationLengthEquals, Press) => {
    "use strict";

    var tagDasLinhas = "items";
    var idDaTabela = "TabelaVendas"
    var nomeParaInserir = "Adriana";
    var idDoFiltroCpf = "FiltroCpf";
    var idDoFiltroNome = "FiltroNome";
    var cpfParaInserir = "54651651651";
    var dataFinalParaInserir = "04072024";
    var telefoneParaInserir = "65165161651";
    var dataInicialParaInserir = "18072024";
    var idDoFiltroTelefone = "FiltroTelefone";
    var idDoFiltroDataFinal = "FiltroDataFinal";
    var idDoFiltroDataInicial = "FiltroDataInicial";
    const viewListagem = "ui5.carro.view.ListagemVenda";
    var idDoBotaoAdicionarVenda = "botaoAdicionarVenda";

    Opa5.createPageObjects({
        naTelaDeListagem: {
            arrangements: {
                euInicioMeuApp() {
                    return this.iStartMyUIComponent("../index.html");
                }
            },
            actions: {
                euPreenchoOInputDoFiltroNome() {
                    return this.waitFor({
                        id: idDoFiltroNome,
                        viewName: viewListagem,
                        actions: new EnterText({
                            text: nomeParaInserir
                        }),
                        errorMessage: "Input não encontrado."
                    });
                },

                euPreenchoOInputDoFiltroCpf() {
                    return this.waitFor({
                        id: idDoFiltroCpf,
                        viewName: viewListagem,
                        actions: new EnterText({
                            text: cpfParaInserir
                        }),
                        errorMessage: "Input não encontrado."
                    });
                },

                euPreenchoOInputDoFiltroTelefone() {
                    return this.waitFor({
                        id: idDoFiltroTelefone,
                        viewName: viewListagem,
                        actions: new EnterText({
                            text: telefoneParaInserir
                        }),
                        errorMessage: "Input não encontrado."
                    });
                },

                euPreenchoOInputDoFiltroDataInicial() {
                    return this.waitFor({
                        id: idDoFiltroDataInicial,
                        viewName: viewListagem,
                        actions: new EnterText({
                            text: dataInicialParaInserir
                        }),
                        errorMessage: "Input não encontrado."
                    });
                },

                euPreenchoOInputDoFiltroDataFinal() {
                    return this.waitFor({
                        id: idDoFiltroDataFinal,
                        viewName: viewListagem,
                        actions: new EnterText({
                            text: dataFinalParaInserir
                        }),
                        errorMessage: "Input não encontrado."
                    });
                },

                euClicoNoBotaoAdicionar() {
                    return this.waitFor({
                        id: idDoBotaoAdicionarVenda,
                        viewName: viewListagem,
                        actions: new Press(),
                        errorMessage: "Botão não encontrado."
                    })
                }
            },

            assertions: {
                euVerificoSeATabelaFoiFiltradaComoOEsperadoNome() {
                    const tamanhoEsperado = 1
                    return this.waitFor({
                        viewName: viewListagem,
                        id: idDaTabela,
                        matchers: new AggregationLengthEquals({
                            name: tagDasLinhas,
                            length: tamanhoEsperado
                        }),
                        success: function (oTable) {
                            var items = oTable.getItems();
                            var verificarItems = items.every((item, indice, lista) => {
                                var itemDesejado = lista[indice].getBindingContext("Vendas").getProperty("nome");

                                return itemDesejado === 'Adriana';
                            });
                            Opa5.assert.ok(verificarItems, `A pagina contem os items esperados`);
                        },
                        errorMessage: "A pagina não contem o numero de items esperados"
                    });
                },

                euVerificoSeATabelaFoiFiltradaComoOEsperadoCpf() {
                    const tamanhoEsperado = 1

                    return this.waitFor({
                        viewName: viewListagem,
                        id: idDaTabela,
                        matchers: new AggregationLengthEquals({
                            name: tagDasLinhas,
                            length: tamanhoEsperado
                        }),
                        success: function (oTable) {
                            var items = oTable.getItems();
                            var verificarItems = items.every((item, indice, lista) => {
                                var itemDesejado = lista[indice].getBindingContext("Vendas").getProperty("cpf");

                                return itemDesejado === '546.516.516-51';
                            });
                            Opa5.assert.ok(verificarItems, `A pagina contem os items esperados`);
                        },
                        errorMessage: "A pagina não contem o numero de items esperados"
                    });
                },

                euVerificoSeATabelaFoiFiltradaComoOEsperadoTelefone() {
                    const tamanhoEsperado = 1
                    return this.waitFor({
                        viewName: viewListagem,
                        id: idDaTabela,
                        matchers: new AggregationLengthEquals({
                            name: tagDasLinhas,
                            length: tamanhoEsperado
                        }),
                        success: function (oTable) {
                            var items = oTable.getItems();
                            var verificarItems = items.every((item, indice, lista) => {
                                var itemDesejado = lista[indice].getBindingContext("Vendas").getProperty("telefone");

                                return itemDesejado === '(65) 16516-1651';
                            });
                            Opa5.assert.ok(verificarItems, `A pagina contem os items esperados`);
                        },
                        errorMessage: "A pagina não contem o numero de items esperados"
                    });
                },

                euVerificoSeATabelaFoiFiltradaComoOEsperadoDataInicial() {
                    const tamanhoEsperado = 5

                    return this.waitFor({
                        viewName: viewListagem,
                        id: idDaTabela,
                        matchers: new AggregationLengthEquals({
                            name: tagDasLinhas,
                            length: tamanhoEsperado
                        }),
                        success: function (oTable) {
                            var items = oTable.getItems();
                            var verificarItems = items.every((item, indice, lista) => {
                                var itemDesejado = lista[indice].getBindingContext("Vendas").getProperty("dataDeCompra");
                                return itemDesejado >= '2024-07-18';
                            });
                            Opa5.assert.ok(verificarItems, `A pagina contem os items esperados`);
                        },
                        errorMessage: "A pagina não contem o numero de items esperados"
                    });
                },

                euVerificoSeATabelaFoiFiltradaComoOEsperadoDataFinal() {
                    const tamanhoEsperado = 2

                    return this.waitFor({
                        viewName: viewListagem,
                        id: idDaTabela,
                        matchers: new AggregationLengthEquals({
                            name: tagDasLinhas,
                            length: tamanhoEsperado
                        }),
                        success: function (oTable) {
                            var items = oTable.getItems();
                            var verificarItems = items.every((item, indice, lista) => {
                                var itemDesejado = lista[indice].getBindingContext("Vendas").getProperty("dataDeCompra").split("T");
                                var dataFormatada = itemDesejado[0];
                                return dataFormatada <= '2024-07-04';
                            });
                            Opa5.assert.ok(verificarItems, `A pagina contem os items esperados`);
                        },
                        errorMessage: "A pagina não contem o numero de items esperados"
                    });
                },

                euVerificoSeOBotaoFoiClicado() {
                    return this.waitFor({
                        success() {
                            Opa5.assert.ok(true, `O botão foi clicado`);
                        },
                        errorMessage: "O botão não foi clicado"
                    });
                }
            }
        }
    });
});
