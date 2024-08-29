sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/EnterText",
    "sap/ui/test/actions/Press",
    "sap/ui/test/matchers/PropertyStrictEquals"


], (Opa5, EnterText, Press, PropertyStrictEquals) => {
    "use strict";

    const CONTEXTO_VENDAS = "Vendas";
    const NOME_PARA_INSERIR = "Adriana";
    const ID_DA_TABELA = "TabelaVendas";
    const ID_DO_FILTRO_CPF = "FiltroCpf";
    const ID_DO_FILTRO_DATA = "FiltroData";
    const ID_DO_FILTRO_NOME = "FiltroNome";
    const CPF_PARA_INSERIR = "54651651651";
    const TELEFONE_PARA_INSERIR = "65165161651";
    const VIEW_LISTAGEM = "vendas.ListagemVenda";
    const ID_DO_FILTRO_TELEFONE = "FiltroTelefone";
    const DATA_PARA_INSERIR = "04/07/2024-18/07/2024";

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
                        id: ID_DO_FILTRO_NOME,
                        viewName: VIEW_LISTAGEM,
                        actions: new EnterText({
                            text: NOME_PARA_INSERIR
                        }),
                        errorMessage: "Input não encontrado."
                    });
                },

                euPreenchoOInputDoFiltroCpf() {
                    return this.waitFor({
                        id: ID_DO_FILTRO_CPF,
                        viewName: VIEW_LISTAGEM,
                        actions: new EnterText({
                            text: CPF_PARA_INSERIR
                        }),
                        errorMessage: "Input não encontrado."
                    });
                },

                euPreenchoOInputDoFiltroTelefone() {
                    return this.waitFor({
                        id: ID_DO_FILTRO_TELEFONE,
                        viewName: VIEW_LISTAGEM,
                        actions: new EnterText({
                            text: TELEFONE_PARA_INSERIR
                        }),
                        errorMessage: "Input não encontrado."
                    });
                },

                euClicoNoIconeDoDateRangeSelection() {
                    return this.waitFor({
                        viewName: VIEW_LISTAGEM,
                        id: ID_DO_FILTRO_DATA,
                        actions: new EnterText({
                            text: DATA_PARA_INSERIR
                        }),
                        errorMessage: "Input não encontrado."
                    });
                }
            },

            assertions: {
                euVerificoSeATabelaFoiFiltradaComoOEsperadoNome() {
                    const nomeDesejado = 'Adriana';
                    const propriedadeDesejada = "nome";
                    return this.waitFor({
                        viewName: VIEW_LISTAGEM,
                        id: ID_DA_TABELA,
                        success: function (oTable) {
                            var items = oTable.getItems();
                            var verificarItems = items.some((item, indice, lista) => {
                                var itemDesejado = lista[indice].getBindingContext(CONTEXTO_VENDAS).getProperty(propriedadeDesejada);

                                return itemDesejado === nomeDesejado;
                            });
                            Opa5.assert.ok(verificarItems, `A pagina contem os items esperados`);
                        },
                        errorMessage: "A pagina não contem o numero de items esperados"
                    });
                },

                euVerificoSeATabelaFoiFiltradaComoOEsperadoCpf() {
                    const propiedadeDesejada = "cpf";
                    const cpfDesejado = '546.516.516-51';
                    return this.waitFor({
                        viewName: VIEW_LISTAGEM,
                        id: ID_DA_TABELA,
                        success: function (oTable) {
                            var items = oTable.getItems();
                            var verificarItems = items.some((item, indice, lista) => {
                                var itemDesejado = lista[indice].getBindingContext(CONTEXTO_VENDAS).getProperty(propiedadeDesejada);

                                return itemDesejado === cpfDesejado;
                            });
                            Opa5.assert.ok(verificarItems, `A pagina contem os items esperados`);
                        },
                        errorMessage: "A pagina não contem o numero de items esperados"
                    });
                },

                euVerificoSeATabelaFoiFiltradaComoOEsperadoTelefone() {
                    const propriedadeDesejada = "telefone";
                    const telefoneDesejado = '(65) 16516-1651';

                    return this.waitFor({
                        viewName: VIEW_LISTAGEM,
                        id: ID_DA_TABELA,
                        success: function (oTable) {
                            var items = oTable.getItems();
                            var verificarItems = items.some((item, indice, lista) => {
                                var itemDesejado = lista[indice].getBindingContext(CONTEXTO_VENDAS).getProperty(propriedadeDesejada);

                                return itemDesejado === telefoneDesejado;
                            });
                            Opa5.assert.ok(verificarItems, `A pagina contem os items esperados`);
                        },
                        errorMessage: "A pagina não contem o numero de items esperados"
                    });
                },

                euVerificoSeATabelaFoiFiltradaComoOEsperadoDataInicialEDataFinal() {
                    const dataDesejada = '2024-07-18';
                    const propriedadeDesejada = "dataDeCompra";
                    return this.waitFor({
                        viewName: VIEW_LISTAGEM,
                        id: ID_DA_TABELA,
                        success: function (oTable) {
                            var items = oTable.getItems();
                            var verificarItems = items.some((item, indice, lista) => {
                                var itemDesejado = lista[indice].getBindingContext(CONTEXTO_VENDAS).getProperty(propriedadeDesejada);
                                return itemDesejado <= dataDesejada;
                            });
                            Opa5.assert.ok(verificarItems, `A pagina contem os items esperados`);
                        },
                        errorMessage: "A pagina não contem o numero de items esperados"
                    });
                }
            }
        }
    });
});
