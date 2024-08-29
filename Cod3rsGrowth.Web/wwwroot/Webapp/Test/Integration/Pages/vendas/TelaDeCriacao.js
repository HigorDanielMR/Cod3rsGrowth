sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/EnterText",
    "sap/ui/test/actions/Press",
    "sap/ui/test/matchers/PropertyStrictEquals"

], function (Opa5, EnterText, Press, PropertyStrictEquals) {
    "use strict";

    const VIEW_CRIACAO = "vendas.AdicionarVenda";
    const CPF_PARA_INSERIR_CRIACAO = "12345678911";
    const ID_INPUT_CPF_TELA_DE_CRIACAO = "InputCpf";
    const ID_INPUT_PAGO_TELA_DE_CRIACAO = "InputPago";
    const ID_INPUT_NOME_TELA_DE_CRIACAO = "InputNome";
    const NOME_PARA_INSERIR_CRIACAO = "Teste Remover";
    const ID_INPUT_EMAIL_TELA_DE_CRIACAO = "InputEmail";
    const TELEFONE_PARA_INSERIR_CRIACAO = "62992810844";
    const EMAIL_PARA_INSERIR_CRIACAO = "teste@gmail.com";
    const ID_DA_TABELA_CARROS = "TabelaCarrosDisponiveis";
    const ID_INPUT_TELEFONE_TELA_DE_CRIACAO = "InputTelefone";
    const ID_DO_MESSAGE_STRIP_ERRO_AO_CRIAR_VENDA = "erroCriarVenda";
    const MENSAGEM_ERRO_INPUT_NAO_ENCONTRADO = "Input não encontrado.";
    const MENSAGEM_ERRO_BOTAO_NAO_ENCONTRADO = "Botão não encontrado.";
    const ID_DO_BOTAO_ADICIONAR_VENDA_CRIACAO = "AdicionarVendaCriacao";
    const MENSAGEM_ERRO_TABELA_NAO_ENCONTRADA = "Tabela não contém carros.";
    const ID_DO_MESSAGE_STRIP_SUCESSO_AO_CRIAR_CARRO = "sucessoAoCriarVenda";
    const MENSAGEM_ERRO_O_CARRO_NAO_FOI_SELECIONADO = "Carro não selecionado";
    
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
                        id: ID_INPUT_NOME_TELA_DE_CRIACAO,
                        viewName: VIEW_CRIACAO,
                        actions: new EnterText({
                            text: NOME_PARA_INSERIR_CRIACAO
                        }),
                        errorMessage: MENSAGEM_ERRO_INPUT_NAO_ENCONTRADO
                    })
                },

                euInsiroOCpfNoInputCpf() {
                    return this.waitFor({
                        id: ID_INPUT_CPF_TELA_DE_CRIACAO,
                        viewName: VIEW_CRIACAO,
                        actions: new EnterText({
                            text: CPF_PARA_INSERIR_CRIACAO
                        }),
                        errorMessage: MENSAGEM_ERRO_INPUT_NAO_ENCONTRADO
                    })
                },

                euInsiroOEmailNoInputEmail() {
                    return this.waitFor({
                        id: ID_INPUT_EMAIL_TELA_DE_CRIACAO,
                        viewName: VIEW_CRIACAO,
                        actions: new EnterText({
                            text: EMAIL_PARA_INSERIR_CRIACAO
                        }),
                        errorMessage: MENSAGEM_ERRO_INPUT_NAO_ENCONTRADO
                    })
                },

                euInsiroOTelefoneNoInputTelefone() {
                    return this.waitFor({
                        id: ID_INPUT_TELEFONE_TELA_DE_CRIACAO,
                        viewName: VIEW_CRIACAO,
                        actions: new EnterText({
                            text: TELEFONE_PARA_INSERIR_CRIACAO
                        }),
                        errorMessage: MENSAGEM_ERRO_INPUT_NAO_ENCONTRADO
                    })
                },

                euClicoNoInputPago() {
                    return this.waitFor({
                        id: ID_INPUT_PAGO_TELA_DE_CRIACAO,
                        viewName: VIEW_CRIACAO,
                        actions: new Press(),
                        errorMessage: MENSAGEM_ERRO_INPUT_NAO_ENCONTRADO
                    })
                },
                euSelecionoOItemNaTabela() {
                    const propriedadeDesejada = "text";
                    const MODELO_DESEJADO = "Teste";
                    return this.waitFor({
                        controlType: "sap.m.Text",
                        matchers: new PropertyStrictEquals({
                            name: propriedadeDesejada,
                            value: MODELO_DESEJADO
                        }),
                        actions: new Press(),
                        errorMessage: MENSAGEM_ERRO_TABELA_NAO_ENCONTRADA
                    })
                },

                euClicoNoBotaoAdicionarDaTelaDeCriacao() {
                    return this.waitFor({
                        id: ID_DO_BOTAO_ADICIONAR_VENDA_CRIACAO,
                        viewName: VIEW_CRIACAO,
                        actions: new Press(),
                        errorMessage: MENSAGEM_ERRO_BOTAO_NAO_ENCONTRADO
                    })
                }
            },

            assertions: {

                euVerificoSeAMessageStripDeErroAoCriarVendaFoiExibida(){
                    const propriedadeDesejada = "visible";
                    const VALOR_DESEJADO = true;
                    return this.waitFor({
                        viewName: VIEW_CRIACAO,
                        id: ID_DO_MESSAGE_STRIP_ERRO_AO_CRIAR_VENDA,
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

                euVerificoSeOcarroFoiSelecionado() {
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
                        errorMessage: MENSAGEM_ERRO_O_CARRO_NAO_FOI_SELECIONADO
                    })
                },

                euVerificoSeAMessageStripDeSucessoAoCriarVendaFoiExibida(){
                    const propriedadeDesejada = "visible";
                    const VALOR_DESEJADO = true;
                    return this.waitFor({
                        viewName: VIEW_CRIACAO,
                        id: ID_DO_MESSAGE_STRIP_SUCESSO_AO_CRIAR_CARRO,
                        matchers: new PropertyStrictEquals({
                            name: propriedadeDesejada,
                            value: VALOR_DESEJADO
                        }),
                        success() {
                            Opa5.assert.ok(true, `Message strip aberta com sucesso.`)
                        },
                        errorMessage: `Message strip não foi aberta.`
                    })
                }
            }
        }
    });
});
