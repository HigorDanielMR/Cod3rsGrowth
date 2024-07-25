sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/EnterText",
    "sap/ui/test/matchers/AggregationLengthEquals",
    "sap/ui/test/actions/Press"

], (Opa5, EnterText, AggregationLengthEquals, Press) => {
    "use strict";

    const viewListagem = "ui5.carro.view.ListagemVenda";
    var idDaTabela = "TabelaVendas"
    var idDoFiltroNome = "FiltroNome";
    var nomeParaInserir = "Adriana";
    var idDoFiltroCpf = "FiltroCpf";
    var cpfParaInserir = "54651651651";
    var idDoFiltroTelefone = "FiltroTelefone";
    var telefoneParaInserir = "65165161651";
    var idDoFiltroDataInicial = "FiltroDataInicial";
    var dataInicialParaInserir = "18072024";
    var idDoFiltroDataFinal = "FiltroDataFinal";
    var dataFinalParaInserir = "04072024";
    var tagDasLinhas = "items";

    var viewCriacao = "ui5.carro.view.AdicionarVenda"
    var idDoBotaoAdicionarVenda = "botaoAdicionarVenda";
    var idInputNomeTelaDeCriacao = "InputNome";
    var idInputCpfTelaDeCriacao = "InputCpf";
    var idInputEmailTelaDeCriacao = "InputEmail";
    var idInputTelefoneTelaDeCriacao = "InputTelefone";
    var idInputPagoTelaDeCriacao = "InputPago";
    var nomeParaInserirCriacao = "Julio Rodrigues";
    var cpfParaInserirCriacao = "12345678911";
    var emailParaInserirCriacao = "julio@gmail.com";
    var telefoneParaInserirCriacao = "62992810844"
    var idDaTabelaCarros = "TabelaCarrosDisponiveis";

    Opa5.createPageObjects({
        onTheAppPage: {
            arrangements: {
                euInicioMeuApp() {
                    return this.iStartMyUIComponent("../index.html");
                }
            },
            actions: {
                euPreenchoOInputDoFiltroNome: function () {
                    return this.waitFor({
                        id: idDoFiltroNome,
                        viewName: viewListagem,
                        actions: new EnterText({
                            text: nomeParaInserir
                        }),
                        errorMessage: "Input não encontrado."
                    });
                },
                euPreenchoOInputDoFiltroCpf: function () {
                    return this.waitFor({
                        id: idDoFiltroCpf,
                        viewName: viewListagem,
                        actions: new EnterText({
                            text: cpfParaInserir
                        }),
                        errorMessage: "Input não encontrado."
                    });
                },
                euPreenchoOInputDoFiltroTelefone: function () {
                    return this.waitFor({
                        id: idDoFiltroTelefone,
                        viewName: viewListagem,
                        actions: new EnterText({
                            text: telefoneParaInserir
                        }),
                        errorMessage: "Input não encontrado."
                    });
                },
                euPreenchoOInputDoFiltroDataInicial: function () {
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
                },

                euInsiroONomeNoInputNome() {
                    return this.waitFor({
                        id: idInputNomeTelaDeCriacao,
                        viewName: viewCriacao,
                        actions: new EnterText({
                            text: nomeParaInserirCriacao
                        }),
                        errorMessage: "Input não encontrado."
                    })
                },
                euInsiroOCpfNoInputCpf() {
                    return this.waitFor({
                        id: idInputCpfTelaDeCriacao,
                        viewName: viewCriacao,
                        actions: new EnterText({
                            text: cpfParaInserirCriacao
                        }),
                        errorMessage: "Input não encontrado."
                    })
                },
                euInsiroOEmailNoInputEmail() {
                    return this.waitFor({
                        id: idInputEmailTelaDeCriacao,
                        viewName: viewCriacao,
                        actions: new EnterText({
                            text: emailParaInserirCriacao
                        }),
                        errorMessage: "Input não encontrado."
                    })
                },
                euInsiroOTelefoneNoInputTelefone() {
                    return this.waitFor({
                        id: idInputTelefoneTelaDeCriacao,
                        viewName: viewCriacao,
                        actions: new EnterText({
                            text: telefoneParaInserirCriacao
                        }),
                        errorMessage: "Input não encontrado."
                    })
                },
                euClicoNoInputPago() {
                    return this.waitFor({
                        id: idInputEmailTelaDeCriacao,
                        viewName: viewCriacao,
                        actions: new Press(),
                        errorMessage: "Input não encontrado."
                    })
                },
                euClicoNaTabelaCarro() {
                    return this.waitFor({
                        id: idDaTabelaCarros,
                        viewName: viewCriacao,
                        actions: new Press(),
                        errorMessage: "Tabela não encontrada."
                    })
                }
            },

            assertions: {
                euVerificoSeATabelaFoiFiltradaComoOEsperadoNome: function () {
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
                euVerificoSeATabelaFoiFiltradaComoOEsperadoCpf: function () {
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
                euVerificoSeATabelaFoiFiltradaComoOEsperadoTelefone: function () {
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
                euVerificoSeATabelaFoiFiltradaComoOEsperadoDataInicial: function () {
                    const tamanhoEsperado = 3

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
                                item = lista[indice].getBindingContext("Vendas").getProperty("dataDeCompra");
                                return item <= '18/07/2024';
                            });
                            Opa5.assert.ok(verificarItems, `A pagina contem os items esperados`);
                        },
                        errorMessage: "A pagina não contem o numero de items esperados"
                    });
                },
                euVerificoSeATabelaFoiFiltradaComoOEsperadoDataFinal: function () {
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
                                return dataFormatada >= '04/07/2024';
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
                },
                euVerificoSeOTextoFoiInseridoNoInputNome() {
                    return this.waitFor({
                        sucess() {
                            Opa5.assert.ok(true, `Texto inserido com sucesso.`);
                        },
                        errorMessage: "O texto não foi adicionado."
                    });
                },
                euVerificoSeOTextoFoiInseridoNoInputCpf() {
                    return this.waitFor({
                        sucess() {
                            Opa5.assert.ok(true, `Texto inserido com sucesso.`);
                        },
                        errorMessage: "O texto não foi adicionado."
                    });
                },

                euVerificoSeOTextoFoiInseridoNoInputEmail() {
                    return this.waitFor({
                        sucess() {
                            Opa5.assert.ok(true, `Texto inserido com sucesso.`);
                        },
                        errorMessage: "O texto não foi adicionado."
                    });
                },
                euVerificoSeOTextoFoiInseridoNoInputTelefone() {
                    return this.waitFor({
                        sucess() {
                            Opa5.assert.ok(true, `Texto inserido com sucesso.`);
                        },
                        errorMessage: "O texto não foi adicionado."
                    });
                },
                euVerificoSeOInputPagoFoiPressionado() {
                    return this.waitFor({
                        sucess() {
                            Opa5.assert.ok(true, `Input pago clicado com sucesso.`);
                        },
                        errorMessage: "O texto não foi adicionado."
                    });
                },
                euVereificoSeATabelaFoiPressionada() {
                    return this.waitFor({
                        viewName: viewCriacao,
                        id: idDaTabelaCarros,
                        matchers: new AggregationLengthEquals({
                            name: tagDasLinhas,
                        }),
                        success: function (oTable) {

                            var oTable = this.getView().byId("TabelaCarrosDisponiveis");
                            var aSelectedItems = oTable.getSelectedItems();

                            if (aSelectedItems.length === 0) {
                                this.getView().byId("erroSelecionarCarro").setVisible(true);
                            }
                            else {
                                this.getView().byId("erroSelecionarCarro").setVisible(false);
                            }

                            var oSelectedItem = aSelectedItems[0];
                            var oBindingContext = oSelectedItem.getBindingContext("Carros");
                            var oSelectedCar = oBindingContext.getObject();

                            var items = oTable.getItems();
                            var verificarItems = items.every((item, indice, lista) => {
                                var itemDesejado = lista[indice].getBindingContext("Vendas").getProperty("dataDeCompra").split("T");
                                var dataFormatada = itemDesejado[0];
                                return dataFormatada >= '04/07/2024';
                            });
                            Opa5.assert.ok(verificarItems, `A pagina contem os items esperados`);
                        },
                        errorMessage: "A pagina não contem o numero de items esperados"
                    })
                }
            }
        }
    });
});
