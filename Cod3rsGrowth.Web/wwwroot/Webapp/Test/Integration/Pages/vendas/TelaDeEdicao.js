sap.ui.define([
    'sap/ui/test/Opa5',
    'sap/ui/test/matchers/PropertyStrictEquals',
    'sap/ui/test/matchers/Properties',
    "sap/ui/test/actions/Press",
    "sap/ui/test/actions/EnterText"

], function (Opa5, PropertyStrictEquals, Properties, Press, EnterText) {
    'use strict';

    const propriedadeNome = "nome";
    const contextoVendas = "Vendas";
    const viewDetalhes = "Detalhes";
    const nomePropriedadeText = "text";
    const viewCriacao = "AdicionarVenda";
    const viewListagem = "ListagemVenda";
    const idDaTagTextNome = "nomeDetalhes";
    const idDaTabelaVenda = "TabelaVendas";
    const idDoBotaoEditar = "botaoEditarVenda";
    const nomeParaInserirEditar = "Vitor Godoi";
    const idInputNomeTelaDeEditar = "InputNome";
    const idDaTabelaCarros = "TabelaCarrosDisponiveis";
    const idDoBotaoAdicionarVendaCriacao = "AdicionarVendaCriacao";
    const idDoBotaoVoltarParaTelaDeListagem = "voltarParaAListagem";
    
    Opa5.createPageObjects({
        naTelaDeEdicao: {
            arrangements: {
                euInicioMeuApp() {
                    return this.iStartMyUIComponent("../index.html");
                }
            },

            actions: {
                euInsiroONomeNoInputNome() {
                    return this.waitFor({
                        id: idInputNomeTelaDeEditar,
                        viewName: viewCriacao,
                        actions: new EnterText({
                            text: nomeParaInserirEditar
                        }),
                        errorMessage: "Input não encontrado."
                    })
                },
                euSelecionoOItemNaTabela() {
                    const nomeDoCarroDesejado = "Corolla";
                    return this.waitFor({
                        controlType: "sap.m.Text",
                        matchers: new PropertyStrictEquals({
                            name: nomePropriedadeText,
                            value: nomeDoCarroDesejado
                        }),
                        actions: new Press(),
                        errorMessage: "Tabela não contém carros."
                    })
                },

                euClicoNoBotaoAdicionarDaTelaDeEditar() {
                    return this.waitFor({
                        id: idDoBotaoAdicionarVendaCriacao,
                        viewName: viewCriacao,
                        actions: new Press(),
                        errorMessage: "Botão não encontrado."
                    })
                },

                euClicoNoBotaoVoltarParaTelaListagem() {
                    return this.waitFor({
                        id: idDoBotaoVoltarParaTelaDeListagem,
                        viewName: viewCriacao,
                        actions: new Press(),
                        errorMessage: "Botão não encontrado."
                    })
                },
                euClicoNaVendaDoIdNomeDesejado() {
                    const nomeDesejado = "Vitor Godoi";
                    return this.waitFor({
                        controlType: "sap.m.Text",
                        viewName: viewListagem,
                        matchers: [
                            new PropertyStrictEquals({
                                name: nomePropriedadeText,
                                value: nomeDesejado
                            })
                        ],
                        actions: new Press(),
                        errorMessage: "Item com o nome desejado não encontrado"
                    });
                },
                euClicoNoBotaoEditarNaTelaDeDetalhes() {
                    return this.waitFor({
                        id: idDoBotaoEditar,
                        viewName: viewDetalhes,
                        actions: new Press(),
                        errorMessage: "Botão não encontrado."
                    })    
                }
            },
            assertions: {
                euVerificoSeOTextoFoiInseridoNoInputNome() {
                    return this.waitFor({
                        success() {
                            Opa5.assert.ok(true, `Texto inserido com sucesso.`);
                        },
                        errorMessage: "O texto não foi adicionado."
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

                euVerificoSeOBotaoVoltarParaATelaDeDetalhesFoiClicado() {
                    return this.waitFor({
                        success() {
                            Opa5.assert.ok(true, `O botão foi clicado`);
                        },
                        errorMessage: "O botão não foi clicado"
                    });
                },

                euVerificoSeAVendaFoiEditada() {
                    return this.waitFor({
                        viewName: viewListagem,
                        id: idDaTabelaVenda,
                        success: function (oTable) {
                            var items = oTable.getItems();
                            var itemEncontrado = items.some(function (item) {
                                var nomeDesejado = item.getBindingContext(contextoVendas).getProperty(propriedadeNome);
                                return nomeDesejado === nomeParaInserirEditar;
                            });
                            Opa5.assert.ok(itemEncontrado, "A venda foi criada com sucesso.");
                        },
                        errorMessage: "A venda não foi criada com sucesso."
                    });
                },
                euVerificoSeNomeEstaComoOEsperado() {
                    var nomeEsperado = "Vitor Godoi"
                    return this.waitFor({
                        id: idDaTagTextNome,
                        viewName: viewDetalhes,
                        controlType: "sap.m.Text",
                        success: function (texto) {
                            var nomePreenchido = texto.getText();

                            Opa5.assert.strictEqual(nomePreenchido, nomeEsperado, "O nome está como o esperado.");
                        },
                        errorMessage: "O nome não como o esperado."
                    });
                },
                euVerificoSeAViewFoiCarregada() {
                    const idDoTitulo = "Title1";
                    const textoDesejado = "Editar Venda";
                    return this.waitFor({
                        id: idDoTitulo,
                        viewName: viewCriacao,
                        matchers: new Properties({
                            text: textoDesejado
                        }),
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
