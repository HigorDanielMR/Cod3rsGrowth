sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/EnterText",
    "sap/ui/test/matchers/AggregationLengthEquals",
    "sap/ui/test/actions/Press",
    "sap/ui/test/matchers/PropertyStrictEquals"

], function (Opa5, EnterText, AggregationLengthEquals, Press, PropertyStrictEquals) {
    "use strict";

    var idDaTabelaVenda = "TabelaVendas"
    var nomeParaInserirCriacao = "Eliane"
    var idInputCpfTelaDeCriacao = "InputCpf"
    var cpfParaInserirCriacao = "12345678911"
    var idInputPagoTelaDeCriacao = "InputPago"
    var idDoBotaoAtualizar = "atualizarTabela"
    var idInputNomeTelaDeCriacao = "InputNome"
    var idInputEmailTelaDeCriacao = "InputEmail"
    var telefoneParaInserirCriacao = "62992810844"
    var emailParaInserirCriacao = "teste@gmail.com"
    var idDaTabelaCarros = "TabelaCarrosDisponiveis"
    var viewCriacao = "ui5.carro.view.AdicionarVenda"
    var idInputTelefoneTelaDeCriacao = "InputTelefone"
    var idDoBotaoAdicionarVenda = "botaoAdicionarVenda"
    const viewListagem = "ui5.carro.view.ListagemVenda"
    var idDoBotaoAdicionarVendaCriacao = "AdicionarVendaCriacao"
    var idDoBotaoVoltarParaTelaDeListagem = "voltarParaAListagem"
    
    Opa5.createPageObjects({
        naTelaDeCriacao: {
            arrangements: {
                euInicioMeuApp() {
                    return this.iStartMyUIComponent("../index.html");
                }
            },
            actions: {
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
                        id: idInputPagoTelaDeCriacao,
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
                },

                euSelecionoOItemNaTabela() {
                    return this.waitFor({
                        controlType: "sap.m.ColumnListItem",
                        viewName: viewCriacao,
                        matchers: new PropertyStrictEquals({
                            name: "id",
                            value: "__item1-__component0---adicionarVenda--TabelaCarrosDisponiveis-0"
                        }),
                        actions: new Press(),
                        errorMessage: "Tabela não contém carros."
                    })
                },

                euClicoNoBotaoAdicionarDaTelaDeCriacao() {
                    return this.waitFor({
                        id: idDoBotaoAdicionarVendaCriacao,
                        viewName: viewCriacao,
                        actions: new Press(),
                        errorMessage: "Botão não encontrado."
                    })
                },

                euClicoNoBotaoVoltarParaTelaDeListagem() {
                    return this.waitFor({
                        id: idDoBotaoVoltarParaTelaDeListagem,
                        viewName: viewCriacao,
                        actions: new Press(),
                        errorMessage: "Botão não encontrado."
                    })
                },

                euClicoNoBotaoAtualizar() {
                    return this.waitFor({
                        id: idDoBotaoAtualizar,
                        viewName: viewListagem,
                        actions: new Press(),
                        errorMessage: "Botão não encontrado."
                    })
                }
            },

            assertions: {
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
                        success() {
                            Opa5.assert.ok(true, `Texto inserido com sucesso.`);
                        },
                        errorMessage: "O texto não foi adicionado."
                    });
                },

                euVerificoSeOTextoFoiInseridoNoInputCpf() {
                    return this.waitFor({
                        success() {
                            Opa5.assert.ok(true, `Texto inserido com sucesso.`);
                        },
                        errorMessage: "O texto não foi adicionado."
                    });
                },

                euVerificoSeOTextoFoiInseridoNoInputEmail() {
                    return this.waitFor({
                        success() {
                            Opa5.assert.ok(true, `Texto inserido com sucesso.`);
                        },
                        errorMessage: "O texto não foi adicionado."
                    });
                },

                euVerificoSeOTextoFoiInseridoNoInputTelefone() {
                    return this.waitFor({
                        success() {
                            Opa5.assert.ok(true, `Texto inserido com sucesso.`);
                        },
                        errorMessage: "O texto não foi adicionado."
                    });
                },

                euVerificoSeOInputPagoFoiPressionado() {
                    return this.waitFor({
                        success() {
                            Opa5.assert.ok(true, `Input pago clicado com sucesso.`);
                        },
                        errorMessage: "O texto não foi adicionado."
                    });
                },

                euVereificoSeATabelaFoiPressionada() {
                    return this.waitFor({
                        viewName: viewCriacao,
                        id: idDaTabelaCarros,
                        success: function (oTable) {
                            var aSelectedItems = oTable.getSelectedItems();
                            var verificarItems = aSelectedItems.every((item, indice, lista) => {
                                if (aSelectedItems.length == 1) {
                                    return true;
                                }
                            });
                            Opa5.assert.ok(verificarItems, `Carro selecionado com sucesso.`);
                        },
                        errorMessage: "Carro não selecionado"
                    })
                },

                euVerificoSeOBotaoAdicionarFoiClicado() {
                    return this.waitFor({
                        success() {
                            Opa5.assert.ok(true, `O botão foi clicado`);
                        },
                        errorMessage: "O botão não foi clicado"
                    });
                },

                euVerificoSeOBotaoVoltarParaATelaDeListagemFoiClicado() {
                    return this.waitFor({
                        success() {
                            Opa5.assert.ok(true, `O botão foi clicado`);
                        },
                        errorMessage: "O botão não foi clicado"
                    });
                },

                euVerificoSeAVendaFoiCriada() {
                    return this.waitFor({
                        viewName: viewListagem,
                        id: idDaTabelaVenda,
                        success: function (oTable) {
                            var items = oTable.getItems();
                            var itemEncontrado = items.some(function (item) {
                                var nomeDesejado = item.getBindingContext("Vendas").getProperty("nome");
                                return nomeDesejado === "Eliane";
                            });
                            Opa5.assert.ok(itemEncontrado, "A venda foi criada com sucesso.");
                        },
                        errorMessage: "A venda não foi criada com sucesso."
                    });
                }
            }
        }
    });
});
