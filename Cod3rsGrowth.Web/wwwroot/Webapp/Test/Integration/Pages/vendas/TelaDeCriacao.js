sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/EnterText",
    "sap/ui/test/actions/Press",
    "sap/ui/test/matchers/PropertyStrictEquals"

], function (Opa5, EnterText, Press, PropertyStrictEquals) {
    "use strict";

    const propriedadeNome = "nome";
    const contextoVendas = "Vendas";
    const idDaTabelaVenda = "TabelaVendas";
    const idInputCpfTelaDeCriacao = "InputCpf";
    const viewCriacao = "vendas.AdicionarVenda";
    const viewListagem = "vendas.ListagemVenda";
    const cpfParaInserirCriacao = "12345678911";
    const idInputPagoTelaDeCriacao = "InputPago";
    const idInputNomeTelaDeCriacao = "InputNome";
    const nomeParaInserirCriacao = "Teste Remover";
    const idInputEmailTelaDeCriacao = "InputEmail";
    const telefoneParaInserirCriacao = "62992810844";
    const emailParaInserirCriacao = "teste@gmail.com";
    const idDaTabelaCarros = "TabelaCarrosDisponiveis";
    const idInputTelefoneTelaDeCriacao = "InputTelefone";
    const idDoBotaoAdicionarVenda = "botaoAdicionarVenda";
    const idDoBotaoAdicionarVendaCriacao = "AdicionarVendaCriacao";
    const idDoBotaoVoltarParaTelaDeListagem = "voltarParaAListagem";
    const menssagemErroInputNaoEncontrado = "Input não encontrado.";
    const menssagemDeErroBotaoNaoEncontrado = "Botão não encontrado.";
    const menssagemDeErroOBotaoNaoFoiClicado = "O botão não foi clicado";
    const menssagemDeErroTabelaNaoEncontrada = "Tabela não contém carros.";
    const menssagemDeErroOCarroNaoFoiSelecionado = "Carro não selecionado";
    const menssagemDeErroOTextoNaoFoiAdicionado = "O texto não foi adicionado.";
    const menssagemDeErroAVendaNaoFoiCriadaComSucesso = "A venda não foi criada com sucesso.";
    
    Opa5.createPageObjects({
        naTelaDeCriacao: {
            arrangements: {
                euInicioMeuApp() {
                    return this.iStartMyUIComponent("../index.html");
                }
            },

            actions: {
                euInsiroONomeNoInputNome() {
                    return this.waitFor({
                        id: idInputNomeTelaDeCriacao,
                        viewName: viewCriacao,
                        actions: new EnterText({
                            text: nomeParaInserirCriacao
                        }),
                        errorMessage: menssagemErroInputNaoEncontrado
                    })
                },

                euInsiroOCpfNoInputCpf() {
                    return this.waitFor({
                        id: idInputCpfTelaDeCriacao,
                        viewName: viewCriacao,
                        actions: new EnterText({
                            text: cpfParaInserirCriacao
                        }),
                        errorMessage: menssagemErroInputNaoEncontrado
                    })
                },

                euInsiroOEmailNoInputEmail() {
                    return this.waitFor({
                        id: idInputEmailTelaDeCriacao,
                        viewName: viewCriacao,
                        actions: new EnterText({
                            text: emailParaInserirCriacao
                        }),
                        errorMessage: menssagemErroInputNaoEncontrado
                    })
                },

                euInsiroOTelefoneNoInputTelefone() {
                    return this.waitFor({
                        id: idInputTelefoneTelaDeCriacao,
                        viewName: viewCriacao,
                        actions: new EnterText({
                            text: telefoneParaInserirCriacao
                        }),
                        errorMessage: menssagemErroInputNaoEncontrado
                    })
                },

                euClicoNoInputPago() {
                    return this.waitFor({
                        id: idInputPagoTelaDeCriacao,
                        viewName: viewCriacao,
                        actions: new Press(),
                        errorMessage: menssagemErroInputNaoEncontrado
                    })
                },
                euSelecionoOItemNaTabela() {
                    const propriedadeDesejada = "text";
                    const modeloDesejado = "Teste";
                    return this.waitFor({
                        controlType: "sap.m.Text",
                        matchers: new PropertyStrictEquals({
                            name: propriedadeDesejada,
                            value: modeloDesejado
                        }),
                        actions: new Press(),
                        errorMessage: menssagemDeErroTabelaNaoEncontrada
                    })
                },

                euClicoNoBotaoAdicionarDaTelaDeCriacao() {
                    return this.waitFor({
                        id: idDoBotaoAdicionarVendaCriacao,
                        viewName: viewCriacao,
                        actions: new Press(),
                        errorMessage: menssagemDeErroBotaoNaoEncontrado
                    })
                },

                euClicoNoBotaoVoltarParaTelaDeListagem() {
                    return this.waitFor({
                        id: idDoBotaoVoltarParaTelaDeListagem,
                        viewName: viewCriacao,
                        actions: new Press(),
                        errorMessage: menssagemDeErroBotaoNaoEncontrado
                    })
                },
                euClicoNoBotaoAdicionarVenda() {
                    return this.waitFor({
                        id: idDoBotaoAdicionarVenda,
                        viewName: viewListagem,
                        actions: new Press(),
                        errorMessage: menssagemDeErroBotaoNaoEncontrado
                    })
                }
            },

            assertions: {
                euVerificoSeOTextoFoiInseridoNoInputNome() {
                    return this.waitFor({
                        success() {
                            Opa5.assert.ok(true, `Texto inserido com sucesso.`);
                        },
                        errorMessage: menssagemDeErroOTextoNaoFoiAdicionado
                    });
                },

                euVerificoSeOTextoFoiInseridoNoInputCpf() {
                    return this.waitFor({
                        success() {
                            Opa5.assert.ok(true, `Texto inserido com sucesso.`);
                        },
                        errorMessage: menssagemDeErroOTextoNaoFoiAdicionado
                    });
                },

                euVerificoSeOTextoFoiInseridoNoInputEmail() {
                    return this.waitFor({
                        success() {
                            Opa5.assert.ok(true, `Texto inserido com sucesso.`);
                        },
                        errorMessage: menssagemDeErroOTextoNaoFoiAdicionado
                    });
                },

                euVerificoSeOTextoFoiInseridoNoInputTelefone() {
                    return this.waitFor({
                        success() {
                            Opa5.assert.ok(true, `Texto inserido com sucesso.`);
                        },
                        errorMessage: menssagemDeErroOTextoNaoFoiAdicionado
                    });
                },

                euVerificoSeOInputPagoFoiPressionado() {
                    return this.waitFor({
                        success() {
                            Opa5.assert.ok(true, `Input pago clicado com sucesso.`);
                        },
                        errorMessage: menssagemErroInputNaoEncontrado
                    });
                },

                euVereificoSeATabelaFoiPressionada() {
                    const tiveUmItem = 1;
                    return this.waitFor({
                        viewName: viewCriacao,
                        id: idDaTabelaCarros,
                        success(tabela) {
                            var itemsSelecionados = tabela.getSelectedItems();
                            var verificarItems = itemsSelecionados.every(() => {
                                if (itemsSelecionados.length === tiveUmItem) {
                                    return true;
                                }
                            });
                            Opa5.assert.ok(verificarItems, `Carro selecionado com sucesso.`);
                        },
                        errorMessage: menssagemDeErroOCarroNaoFoiSelecionado
                    })
                },

                euVerificoSeOBotaoAdicionarFoiClicado() {
                    return this.waitFor({
                        success() {
                            Opa5.assert.ok(true, `O botão foi clicado`);
                        },
                        errorMessage: menssagemDeErroOBotaoNaoFoiClicado
                    });
                },

                euVerificoSeOBotaoVoltarParaATelaDeListagemFoiClicado() {
                    return this.waitFor({
                        success() {
                            Opa5.assert.ok(true, `O botão foi clicado`);
                        },
                        errorMessage: menssagemDeErroOBotaoNaoFoiClicado
                    });
                },

                euVerificoSeAVendaFoiCriada() {
                    return this.waitFor({
                        viewName: viewListagem,
                        id: idDaTabelaVenda,
                        success: function (oTable) {
                            var items = oTable.getItems();
                            var itemEncontrado = items.some(function (item) {
                                var nomeDesejado = item.getBindingContext(contextoVendas).getProperty(propriedadeNome);
                                return nomeDesejado === nomeParaInserirCriacao;
                            });
                            Opa5.assert.ok(itemEncontrado, "A venda foi criada com sucesso.");
                        },
                        errorMessage: menssagemDeErroAVendaNaoFoiCriadaComSucesso
                    });
                },
                euVerificoSeOBotaoAdicionarVendaFoiClicado() {
                    return this.waitFor({
                        success() {
                            Opa5.assert.ok(true, `O botão foi clicado`);
                        },
                        errorMessage: menssagemDeErroOBotaoNaoFoiClicado
                    });
                }
            }
        }
    });
});
