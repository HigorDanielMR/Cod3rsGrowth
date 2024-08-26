sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/EnterText",
    "sap/ui/test/actions/Press",
    "sap/ui/test/matchers/PropertyStrictEquals"

], function (Opa5, EnterText, Press, PropertyStrictEquals) {
    "use strict";

    const idInputCpfTelaDeCriacao = "InputCpf";
    const viewCriacao = "vendas.AdicionarVenda";
    const cpfParaInserirCriacao = "12345678911";
    const idInputPagoTelaDeCriacao = "InputPago";
    const idInputNomeTelaDeCriacao = "InputNome";
    const nomeParaInserirCriacao = "Teste Remover";
    const idInputEmailTelaDeCriacao = "InputEmail";
    const telefoneParaInserirCriacao = "62992810844";
    const emailParaInserirCriacao = "teste@gmail.com";
    const idDaTabelaCarros = "TabelaCarrosDisponiveis";
    const idInputTelefoneTelaDeCriacao = "InputTelefone";
    const idDoMessageStripErroAoCriarVenda = "erroCriarVenda";
    const idDoBotaoAdicionarVendaCriacao = "AdicionarVendaCriacao";
    const menssagemErroInputNaoEncontrado = "Input não encontrado.";
    const menssagemDeErroBotaoNaoEncontrado = "Botão não encontrado.";
    const menssagemDeErroTabelaNaoEncontrada = "Tabela não contém carros.";
    const menssagemDeErroOCarroNaoFoiSelecionado = "Carro não selecionado";
    const idDoMessageStripSucessoAoCriarCarro = "sucessoAoCriarVenda";
    
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
                }
            },

            assertions: {

                euVerificoSeAMessageStripDeErroAoCriarVendaFoiExibida(){
                    const propriedadeDesejada = "visible";
                    const valorDesejado = true;
                    return this.waitFor({
                        viewName: viewCriacao,
                        id: idDoMessageStripErroAoCriarVenda,
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

                euVerificoSeOcarroFoiSelecionado() {
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

                euVerificoSeAMessageStripDeSucessoAoCriarVendaFoiExibida(){
                    const propriedadeDesejada = "visible";
                    const valorDesejado = true;
                    return this.waitFor({
                        viewName: viewCriacao,
                        id: idDoMessageStripSucessoAoCriarCarro,
                        matchers: new PropertyStrictEquals({
                            name: propriedadeDesejada,
                            value: valorDesejado
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
