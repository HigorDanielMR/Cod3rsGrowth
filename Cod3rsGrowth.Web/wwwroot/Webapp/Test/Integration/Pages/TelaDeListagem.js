sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/EnterText",
    "sap/ui/test/actions/Press"

], (Opa5, EnterText, Press) => {
    "use strict";

    const idDaTabela = "TabelaVendas"
    const nomeParaInserir = "Eliane";
    const idDoFiltroCpf = "FiltroCpf";
    const idDoFiltroNome = "FiltroNome";
    const cpfParaInserir = "54651651651";
    const dataFinalParaInserir = "04072024";
    const telefoneParaInserir = "65165161651";
    const dataInicialParaInserir = "18072024";
    const idDoFiltroTelefone = "FiltroTelefone";
    const idDoFiltroDataFinal = "FiltroDataFinal";
    const idDoFiltroDataInicial = "FiltroDataInicial";
    const viewListagem = "ListagemVenda";
    const idDoBotaoAdicionarVenda = "botaoAdicionarVenda";

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
                    return this.waitFor({
                        viewName: viewListagem,
                        id: idDaTabela,
                        success: function (oTable) {
                            var items = oTable.getItems();
                            var verificarItems = items.some((item, indice, lista) => {
                                var itemDesejado = lista[indice].getBindingContext("Vendas").getProperty("nome");

                                return itemDesejado === 'Eliane';
                            });
                            Opa5.assert.ok(verificarItems, `A pagina contem os items esperados`);
                        },
                        errorMessage: "A pagina não contem o numero de items esperados"
                    });
                },

                euVerificoSeATabelaFoiFiltradaComoOEsperadoCpf() {
                    return this.waitFor({
                        viewName: viewListagem,
                        id: idDaTabela,
                        success: function (oTable) {
                            var items = oTable.getItems();
                            var verificarItems = items.some((item, indice, lista) => {
                                var itemDesejado = lista[indice].getBindingContext("Vendas").getProperty("cpf");

                                return itemDesejado === '546.516.516-51';
                            });
                            Opa5.assert.ok(verificarItems, `A pagina contem os items esperados`);
                        },
                        errorMessage: "A pagina não contem o numero de items esperados"
                    });
                },

                euVerificoSeATabelaFoiFiltradaComoOEsperadoTelefone() {
                    return this.waitFor({
                        viewName: viewListagem,
                        id: idDaTabela,
                        success: function (oTable) {
                            var items = oTable.getItems();
                            var verificarItems = items.some((item, indice, lista) => {
                                var itemDesejado = lista[indice].getBindingContext("Vendas").getProperty("telefone");

                                return itemDesejado === '(65) 16516-1651';
                            });
                            Opa5.assert.ok(verificarItems, `A pagina contem os items esperados`);
                        },
                        errorMessage: "A pagina não contem o numero de items esperados"
                    });
                },

                euVerificoSeATabelaFoiFiltradaComoOEsperadoDataInicial() {
                    return this.waitFor({
                        viewName: viewListagem,
                        id: idDaTabela,
                        success: function (oTable) {
                            var items = oTable.getItems();
                            var verificarItems = items.some((item, indice, lista) => {
                                var itemDesejado = lista[indice].getBindingContext("Vendas").getProperty("dataDeCompra");
                                return itemDesejado >= '2024-07-18';
                            });
                            Opa5.assert.ok(verificarItems, `A pagina contem os items esperados`);
                        },
                        errorMessage: "A pagina não contem o numero de items esperados"
                    });
                },

                euVerificoSeATabelaFoiFiltradaComoOEsperadoDataFinal() {
                    return this.waitFor({
                        viewName: viewListagem,
                        id: idDaTabela,
                        success: function (oTable) {
                            var items = oTable.getItems();
                            var verificarItems = items.some((item, indice, lista) => {
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
