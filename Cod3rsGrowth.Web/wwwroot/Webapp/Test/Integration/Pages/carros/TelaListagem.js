sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/EnterText",
    "sap/ui/test/actions/Press",
    "sap/ui/test/matchers/Properties",
    "sap/ui/test/matchers/Ancestor"


], (Opa5, EnterText, Press, Properties, Ancestor) => {
    "use strict";

    const INDEX_COR_DESEJADA = "2";
    const MODELO_DESEJADO = "Supra";
    const CONTEXTO_CARROS = "Carros";
    const VALOR_FLEX_DESEJADO = "true";
    const INDEX_DA_MARCA_DESEJADA = "1";
    const ID_DA_TABELA = "TabelaCarros";
    const ID_DO_FILTRO_MODELO = "FiltroModelo";
    const ID_DO_SELECT_FILTRO_FLEX = "FiltroFlex";
    const ID_DO_SELECT_FILTRO_CORES = "FiltroCores";
    const ID_DO_SELECT_FILTRO_MARCA = "FiltroMarcas";
    const VIEW_LISTAGEM_CARRO = "carros.ListagemCarro";

    Opa5.createPageObjects({
        naTelaDeDetalhesListagemCarro: {
            arrangements: {
                euInicioMeuApp() {
                    return this.iStartMyUIComponent("../index.html");
                }
            },

            actions: {
                euPreenchoOInputDoFiltroModelo() {
                    return this.waitFor({
                        id: ID_DO_FILTRO_MODELO,
                        viewName: VIEW_LISTAGEM_CARRO,
                        actions: new EnterText({
                            text: MODELO_DESEJADO
                        }),
                        errorMessage: "Input não encontrado."
                    });
                },

                euClicoNoSelectESelecionoACorDesejada() {
                    return this.waitFor({
                        id: ID_DO_SELECT_FILTRO_CORES,
                        viewName: VIEW_LISTAGEM_CARRO,
                        actions: new Press(),
                        success(oSelect) {
                            this.waitFor({
                                controlType: "sap.ui.core.Item",
                                matchers: [
                                    new Ancestor(oSelect),
                                    new Properties({ key: INDEX_COR_DESEJADA })
                                ],
                                actions: new Press(),
                                errorMessage: "Cor não encontrada."
                            });
                        },
                        errorMessage: "Select não encontrado."
                    });
                },

                euCliCoNoSelectESelecionoAMarcaDesejada() {
                    return this.waitFor({
                        id: ID_DO_SELECT_FILTRO_MARCA,
                        viewName: VIEW_LISTAGEM_CARRO,
                        actions: new Press(),
                        success(oSelect) {
                            this.waitFor({
                                controlType: "sap.ui.core.Item",
                                matchers: [
                                    new Ancestor(oSelect),
                                    new Properties({ key: INDEX_DA_MARCA_DESEJADA })
                                ],
                                actions: new Press(),
                                errorMessage: "Marca não encontrada."
                            });
                        },
                        errorMessage: "Select não encontrado."
                    });
                },

                euClicoNoSeletESelecionoOTipoFlexDesejado() {
                    return this.waitFor({
                        id: ID_DO_SELECT_FILTRO_FLEX,
                        viewName: VIEW_LISTAGEM_CARRO,
                        actions: new Press(),
                        success(oSelect) {
                            this.waitFor({
                                controlType: "sap.ui.core.Item",
                                matchers: [
                                    new Ancestor(oSelect),
                                    new Properties({ key: VALOR_FLEX_DESEJADO })
                                ],
                                actions: new Press(),
                                errorMessage: "Flex sim não encontrada."
                            });
                        },
                        errorMessage: "Select não encontrado."
                    });
                }
            },

            assertions: {
                euVerificoSeATabelaFoiFiltradaComoOEsperadoModelo() {
                    const MODELO_DESEJADO = 'Supra';
                    const propriedadeDesejada = "modelo";
                    return this.waitFor({
                        viewName: VIEW_LISTAGEM_CARRO,
                        id: ID_DA_TABELA,
                        success(oTable) {
                            var items = oTable.getItems();
                            var verificarItems = items.some((item, indice, lista) => {
                                var itemDesejado = lista[indice].getBindingContext(CONTEXTO_CARROS).getProperty(propriedadeDesejada);

                                return itemDesejado === MODELO_DESEJADO;
                            });
                            Opa5.assert.ok(verificarItems, `A pagina contem os items esperados`);
                        },
                        errorMessage: "A pagina não contem o numero de items esperados"
                    });
                },

                euVerificoSeATabelaFoiFiltradaComACorEsperada() {
                    const corDesejada = 2;
                    const propriedadeDesejada = "cor";
                    return this.waitFor({
                        viewName: VIEW_LISTAGEM_CARRO,
                        id: ID_DA_TABELA,
                        success(oTable) {
                            var items = oTable.getItems();
                            var verificarItems = items.some((item, indice, lista) => {
                                var itemDesejado = lista[indice].getBindingContext(CONTEXTO_CARROS).getProperty(propriedadeDesejada);

                                return itemDesejado === corDesejada;
                            });
                            Opa5.assert.ok(verificarItems, `A pagina contem os items esperados`);
                        },
                        errorMessage: "A pagina não contem o numero de items esperados"
                    });
                },

                euVerificoSeATabelaFoiFiltradaComAMarcaEsperada() {
                    const marcaDesejada = 1;
                    const propriedadeDesejada = "marca";
                    return this.waitFor({
                        viewName: VIEW_LISTAGEM_CARRO,
                        id: ID_DA_TABELA,
                        success(oTable) {
                            var items = oTable.getItems();
                            var verificarItems = items.some((item, indice, lista) => {
                                var itemDesejado = lista[indice].getBindingContext(CONTEXTO_CARROS).getProperty(propriedadeDesejada);

                                return itemDesejado === marcaDesejada;
                            });
                            Opa5.assert.ok(verificarItems, `A pagina contem os items esperados`);
                        },
                        errorMessage: "A pagina não contem o numero de items esperados"
                    });
                },

                euVerificoSeATabelaFoiFiltradaComOTipoFlexEsperado() {
                    const flexDesejado = true;
                    const propriedadeDesejada = "flex";
                    return this.waitFor({
                        viewName: VIEW_LISTAGEM_CARRO,
                        id: ID_DA_TABELA,
                        success(oTable) {
                            var items = oTable.getItems();
                            var verificarItems = items.some((item, indice, lista) => {
                                var itemDesejado = lista[indice].getBindingContext(CONTEXTO_CARROS).getProperty(propriedadeDesejada);

                                return itemDesejado === flexDesejado;
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
