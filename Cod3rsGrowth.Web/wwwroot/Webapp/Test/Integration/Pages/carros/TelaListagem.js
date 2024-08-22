sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/EnterText",
    "sap/ui/test/actions/Press",
    "sap/ui/test/matchers/PropertyStrictEquals",
    "sap/ui/test/matchers/Properties",
    "sap/ui/test/matchers/Ancestor"


], (Opa5, EnterText, Press, PropertyStrictEquals, Properties, Ancestor) => {
    "use strict";

    const contextoCarros = "Carros";
    const idDaTabela = "TabelaCarros";
    const idDoFiltroModelo = "FiltroModelo";
    const viewListagemCarro = "carros.ListagemCarro";
    const modeloDesejado = "Supra";
    const idDoSelectFiltroCores = "FiltroCores";
    const indexCorDeseada = "2";
    const idDoSelectFiltroMarca = "FiltroMarcas";
    const indexDaMarcaDesejada = "1";
    const idDoSelectFiltroFlex = "FiltroFlex";
    const valorFlexDesejado = "true";

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
                        id: idDoFiltroModelo,
                        viewName: viewListagemCarro,
                        actions: new EnterText({
                            text: modeloDesejado
                        }),
                        errorMessage: "Input não encontrado."
                    });
                },

                euClicoNoSelectESelecionoACorDesejada() {
                    return this.waitFor({
                        id: idDoSelectFiltroCores,
                        viewName: viewListagemCarro,
                        actions: new Press(),
                        success(oSelect) {
                            this.waitFor({
                                controlType: "sap.ui.core.Item",
                                matchers: [
                                    new Ancestor(oSelect),
                                    new Properties({ key: indexCorDeseada })
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
                        id: idDoSelectFiltroMarca,
                        viewName: viewListagemCarro,
                        actions: new Press(),
                        success(oSelect) {
                            this.waitFor({
                                controlType: "sap.ui.core.Item",
                                matchers: [
                                    new Ancestor(oSelect),
                                    new Properties({ key: indexDaMarcaDesejada })
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
                        id: idDoSelectFiltroFlex,
                        viewName: viewListagemCarro,
                        actions: new Press(),
                        success(oSelect) {
                            this.waitFor({
                                controlType: "sap.ui.core.Item",
                                matchers: [
                                    new Ancestor(oSelect),
                                    new Properties({ key: valorFlexDesejado })
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
                    const modeloDesejado = 'Supra';
                    const propriedadeDesejada = "modelo";
                    return this.waitFor({
                        viewName: viewListagemCarro,
                        id: idDaTabela,
                        success(oTable) {
                            var items = oTable.getItems();
                            var verificarItems = items.some((item, indice, lista) => {
                                var itemDesejado = lista[indice].getBindingContext(contextoCarros).getProperty(propriedadeDesejada);

                                return itemDesejado === modeloDesejado;
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
                        viewName: viewListagemCarro,
                        id: idDaTabela,
                        success(oTable) {
                            var items = oTable.getItems();
                            var verificarItems = items.some((item, indice, lista) => {
                                var itemDesejado = lista[indice].getBindingContext(contextoCarros).getProperty(propriedadeDesejada);

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
                        viewName: viewListagemCarro,
                        id: idDaTabela,
                        success(oTable) {
                            var items = oTable.getItems();
                            var verificarItems = items.some((item, indice, lista) => {
                                var itemDesejado = lista[indice].getBindingContext(contextoCarros).getProperty(propriedadeDesejada);

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
                        viewName: viewListagemCarro,
                        id: idDaTabela,
                        success(oTable) {
                            var items = oTable.getItems();
                            var verificarItems = items.some((item, indice, lista) => {
                                var itemDesejado = lista[indice].getBindingContext(contextoCarros).getProperty(propriedadeDesejada);

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
