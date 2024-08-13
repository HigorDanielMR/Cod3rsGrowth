sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/EnterText",
    "sap/ui/test/actions/Press",
    "sap/ui/test/matchers/PropertyStrictEquals"


], (Opa5, EnterText, Press, PropertyStrictEquals) => {
    "use strict";

    const propriedadeCpf = "cpf";
    const propriedadeNome = "nome";
    const contextoVendas = "Vendas";
    const nomeParaInserir = "Adriana";
    const idDaTabela = "TabelaVendas";
    const idDoFiltroCpf = "FiltroCpf";
    const idDoFiltroNome = "FiltroNome";
    const cpfParaInserir = "54651651651";
    const viewListagem = "ListagemVenda";
    const propriedadeTelefone = "telefone";
    const telefoneParaInserir = "65165161651";
    const dataParaInserir = "04/07/2024-18/07/2024";
    const idDoFiltroTelefone = "FiltroTelefone";
    const idDoFiltroData = "FiltroData";
    const propriedadeDataDeCompra = "dataDeCompra";
    const idDoFiltroDataInicial = "FiltroDataInicial";
    const idDoBotaoAdicionarVenda = "botaoAdicionarVenda";

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
                        id: idDoFiltroNome,
                        viewName: viewListagem,
                        actions: new EnterText({
                            text: nomeParaInserir
                        }),
                        errorMessage: "Input não encontrado."
                    });
                },

                euPreenchoOInputDoFiltroCpf() {
                    return this.waitFor({
                        id: idDoFiltroCpf,
                        viewName: viewListagem,
                        actions: new EnterText({
                            text: cpfParaInserir
                        }),
                        errorMessage: "Input não encontrado."
                    });
                },

                euPreenchoOInputDoFiltroTelefone() {
                    return this.waitFor({
                        id: idDoFiltroTelefone,
                        viewName: viewListagem,
                        actions: new EnterText({
                            text: telefoneParaInserir
                        }),
                        errorMessage: "Input não encontrado."
                    });
                },

                euClicoNoIconeDoDateRangeSelection() {
                    return this.waitFor({
                        viewName: viewListagem,
                        id: idDoFiltroData,
                        actions: new EnterText({
                            text: dataParaInserir
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
                        viewName: viewListagem,
                        id: idDaTabela,
                        success: function (oTable) {
                            var items = oTable.getItems();
                            var verificarItems = items.some((item, indice, lista) => {
                                var itemDesejado = lista[indice].getBindingContext(contextoVendas).getProperty(propriedadeDesejada);

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
                        viewName: viewListagem,
                        id: idDaTabela,
                        success: function (oTable) {
                            var items = oTable.getItems();
                            var verificarItems = items.some((item, indice, lista) => {
                                var itemDesejado = lista[indice].getBindingContext(contextoVendas).getProperty(propiedadeDesejada);

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
                        viewName: viewListagem,
                        id: idDaTabela,
                        success: function (oTable) {
                            var items = oTable.getItems();
                            var verificarItems = items.some((item, indice, lista) => {
                                var itemDesejado = lista[indice].getBindingContext(contextoVendas).getProperty(propriedadeDesejada);

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
                        viewName: viewListagem,
                        id: idDaTabela,
                        success: function (oTable) {
                            var items = oTable.getItems();
                            var verificarItems = items.some((item, indice, lista) => {
                                var itemDesejado = lista[indice].getBindingContext(contextoVendas).getProperty(propriedadeDesejada);
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
