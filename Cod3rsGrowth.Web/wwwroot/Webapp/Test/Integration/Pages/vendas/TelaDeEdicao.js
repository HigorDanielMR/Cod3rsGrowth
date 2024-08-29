sap.ui.define([
    'sap/ui/test/Opa5',
    'sap/ui/test/matchers/PropertyStrictEquals',
    "sap/ui/test/actions/Press",
    "sap/ui/test/actions/EnterText"

], function (Opa5, PropertyStrictEquals, Press, EnterText) {
    'use strict';

    const NOME_PROPRIEDADE_TEXT = "text";
    const VIEW_CRIACAO = "vendas.AdicionarVenda";
    const NOME_PARA_INSERIR_EDITAR = "Vitor Godoi";
    const ID_INPUT_NOME_TELA_DE_EDITAR = "InputNome";
    const ID_DA_TABELA_CARROS = "TabelaCarrosDisponiveis";
    const ID_DO_MESSAGE_STRIP_ERRO_AO_EDITAR_VENDA = "erroEditarVenda";
    const ID_DO_BOTAO_ADICIONAR_VENDA_CRIACAO = "AdicionarVendaCriacao";
    const ID_DO_MESSAGE_STRIP_SUCESSO_AO_EDITAR_VENDA = "sucessoAoEditarVenda";
    
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
                        id: ID_INPUT_NOME_TELA_DE_EDITAR,
                        viewName: VIEW_CRIACAO,
                        actions: new EnterText({
                            text: nomeVazio
                        }),
                        errorMessage: "Input não encontrado."
                    })
                },
                euInsiroONomeNoInputNome() {
                    return this.waitFor({
                        id: ID_INPUT_NOME_TELA_DE_EDITAR,
                        viewName: VIEW_CRIACAO,
                        actions: new EnterText({
                            text: NOME_PARA_INSERIR_EDITAR
                        }),
                        errorMessage: "Input não encontrado."
                    })
                },
                euSelecionoOItemNaTabela() {
                    const nomeDoCarroDesejado = "Corolla";
                    return this.waitFor({
                        controlType: "sap.m.Text",
                        matchers: new PropertyStrictEquals({
                            name: NOME_PROPRIEDADE_TEXT,
                            value: nomeDoCarroDesejado
                        }),
                        actions: new Press(),
                        errorMessage: "Tabela não contém carros."
                    })
                },

                euClicoNoBotaoAdicionarDaTelaDeEditar() {
                    return this.waitFor({
                        id: ID_DO_BOTAO_ADICIONAR_VENDA_CRIACAO,
                        viewName: VIEW_CRIACAO,
                        actions: new Press(),
                        errorMessage: "Botão não encontrado."
                    })
                }
            },

            assertions: {
                euVerificoSeAMessageStripDeErroAoEditarVendaFoiExibida(){
                    const propriedadeDesejada = "visible";
                    const VALOR_DESEJADO = true;
                    return this.waitFor({
                        viewName: VIEW_CRIACAO,
                        id: ID_DO_MESSAGE_STRIP_ERRO_AO_EDITAR_VENDA,
                        matchers: new PropertyStrictEquals({
                            name: propriedadeDesejada,
                            value: VALOR_DESEJADO
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
                        viewName: VIEW_CRIACAO,
                        id: ID_DA_TABELA_CARROS,
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
                    const VALOR_DESEJADO = true;
                    return this.waitFor({
                        viewName: VIEW_CRIACAO,
                        id: ID_DO_MESSAGE_STRIP_SUCESSO_AO_EDITAR_VENDA,
                        matchers: new PropertyStrictEquals({
                            name: propriedadeDesejada,
                            value: VALOR_DESEJADO
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
