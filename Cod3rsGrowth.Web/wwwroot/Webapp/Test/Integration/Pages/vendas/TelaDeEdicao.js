sap.ui.define([
    'sap/ui/test/Opa5',
    'sap/ui/test/matchers/PropertyStrictEquals',
    "sap/ui/test/actions/Press",
    "sap/ui/test/actions/EnterText"

], function (Opa5, PropertyStrictEquals, Press, EnterText) {
    'use strict';

    const propriedadeNome = "nome";
    const contextoVendas = "Vendas";
    const viewCriacao = "AdicionarVenda";
    const viewListagem = "ListagemVenda";
    const idDaTabelaVenda = "TabelaVendas";
    const nomeParaInserirCriacao = "Eliane";
    const idInputCpfTelaDeCriacao = "InputCpf";
    const cpfParaInserirCriacao = "12345678911";
    const idInputPagoTelaDeCriacao = "InputPago";
    const idInputNomeTelaDeCriacao = "InputNome";
    const idInputEmailTelaDeCriacao = "InputEmail";
    const telefoneParaInserirCriacao = "62992810844";
    const emailParaInserirCriacao = "teste@gmail.com";
    const idDaTabelaCarros = "TabelaCarrosDisponiveis";
    const idInputTelefoneTelaDeCriacao = "InputTelefone";
    const idDoBotaoAdicionarVenda = "botaoAdicionarVenda";
    const idDoBotaoAdicionarVendaCriacao = "AdicionarVendaCriacao";
    const idDoBotaoVoltarParaTelaDeListagem = "voltarParaAListagem";

    Opa5.createPageObjects({
        naTelaDeDetalhes: {
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
                euSelecionoOItemNaTabela() {
                    return this.waitFor({
                        controlType: "sap.m.Text",
                        matchers: new PropertyStrictEquals({
                            name: "text",
                            value: "Creta"
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
                euClicoNoBotaoAdicionarVenda() {
                    return this.waitFor({
                        id: idDoBotaoAdicionarVenda,
                        viewName: viewListagem,
                        actions: new Press(),
                        errorMessage: "Botão não encontrado."
                    })
                }
            },
            assertions: {
                euVerificoSeATelaDeCriacaoFoiCarregada() {
                    return this.waitFor({
                        id: "Title1",
                        matchers: new PropertyStrictEquals({
                            name: "text",
                            value: "Adicionar Venda"
                        }),
                        success() {
                            Opa5.assert.ok(true, "Tela de criacao carregada com sucesso");
                        }
                    })
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
                        errorMessage: "Input não encontrado."
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
            }
        }
    });
});
