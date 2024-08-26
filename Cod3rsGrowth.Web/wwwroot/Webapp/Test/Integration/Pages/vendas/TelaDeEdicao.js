sap.ui.define([
    'sap/ui/test/Opa5',
    'sap/ui/test/matchers/PropertyStrictEquals',
    "sap/ui/test/actions/Press",
    "sap/ui/test/actions/EnterText"

], function (Opa5, PropertyStrictEquals, Press, EnterText) {
    'use strict';

    const nomePropriedadeText = "text";
    const viewCriacao = "vendas.AdicionarVenda";
    const nomeParaInserirEditar = "Vitor Godoi";
    const idInputNomeTelaDeEditar = "InputNome";
    const idDaTabelaCarros = "TabelaCarrosDisponiveis";
    const idDoMessageStripErroAoEditarVenda = "erroEditarVenda";
    const idDoBotaoAdicionarVendaCriacao = "AdicionarVendaCriacao";
    const idDoMessageStripSucessoAoEditarVenda = "sucessoAoEditarVenda";
    
    Opa5.createPageObjects({
        naTelaDeEdicao: {
            arrangements: {
                euInicioMeuApp() {
                    return this.iStartMyUIComponent("../index.html");
                }
            },

            actions: {
                euLimpoOInputNome(){
                    const nomeVazio = "";
                    return this.waitFor({
                        id: idInputNomeTelaDeEditar,
                        viewName: viewCriacao,
                        actions: new EnterText({
                            text: nomeVazio
                        }),
                        errorMessage: "Input não encontrado."
                    })
                },
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
                }
            },

            assertions: {
                euVerificoSeAMessageStripDeErroAoEditarVendaFoiExibida(){
                    const propriedadeDesejada = "visible";
                    const valorDesejado = true;
                    return this.waitFor({
                        viewName: viewCriacao,
                        id: idDoMessageStripErroAoEditarVenda,
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
                euVerificoSeAMessageStripDeSucessoAoEditarVendaFoiExibida(){
                    const propriedadeDesejada = "visible";
                    const valorDesejado = true;
                    return this.waitFor({
                        viewName: viewCriacao,
                        id: idDoMessageStripSucessoAoEditarVenda,
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
            }
        }
    });
});
