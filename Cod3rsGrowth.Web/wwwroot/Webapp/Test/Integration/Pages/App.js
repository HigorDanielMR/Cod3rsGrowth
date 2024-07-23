sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/EnterText",
    "sap/ui/test/matchers/AggregationLengthEquals"

], (Opa5, EnterText, AggregationLengthEquals) => {
    "use strict";

    const sViewName = "ui5.carro.view.ListagemVenda";

    Opa5.createPageObjects({
        onTheAppPage: {
            arrangements: {
                euInicioMeuApp() {
                    return this.iStartMyUIComponent("../index.html");
                }
            },
            actions: {
                euPreenchoOInputDoFiltroNome: function () {
                    return this.waitFor({
                        id: "FiltroNome",
                        viewName: sViewName,
                        actions: new EnterText({
                            text: "Adriana"
                        }),
                        errorMessage: "Input não encontrado."
                    });
                },
                euPreenchoOInputDoFiltroCpf: function () {
                    return this.waitFor({
                        id: "FiltroCpf",
                        viewName: sViewName,
                        actions: new EnterText({
                            text: "54651651651"
                        }),
                        errorMessage: "Input não encontrado."
                    });
                },
                euPreenchoOInputDoFiltroTelefone: function () {
                    return this.waitFor({
                        id: "FiltroTelefone",
                        viewName: sViewName,
                        actions: new EnterText({
                            text: "65165161651"
                        }),
                        errorMessage: "Input não encontrado."
                    });
                },
                euPreenchoOInputDoFiltroDataInicial: function () {
                    return this.waitFor({
                        id: "FiltroDataInicial",
                        viewName: sViewName,
                        actions: new EnterText({
                            text: "18072024"
                        }),
                        errorMessage: "Input não encontrado."
                    });
                },
                euPreenchoOInputDoFiltroDataFinal: function () {
                    return this.waitFor({
                        id: "FiltroDataFinal",
                        viewName: sViewName,
                        actions: new EnterText({
                            text: "04072024"
                        }),
                        errorMessage: "Input não encontrado."
                    });
                }
            },

            assertions: {
                euVerificoSeATabelaFoiFiltradaComoOEsperadoNome: function () {
                    const tamanhoEsperado = 1
                    return this.waitFor({
                        viewName: sViewName,
                        id: "TabelaVendas",
                        matchers: new AggregationLengthEquals({
                            name: "items",
                            length: tamanhoEsperado
                        }),
                        success: function () {
                            Opa5.assert.ok(true, `A pagina contem ${tamanhoEsperado} items esperados`);
                        },
                        errorMessage: "A pagina não contem o numero de items esperados"
                    });
                },
                euVerificoSeATabelaFoiFiltradaComoOEsperadoCpf: function () {
                    const tamanhoEsperado = 1

                    return this.waitFor({
                        viewName: sViewName,
                        id: "TabelaVendas",
                        matchers: new AggregationLengthEquals({
                            name: "items",
                            length: tamanhoEsperado
                        }),
                        success: function () {
                            Opa5.assert.ok(true, `A pagina contem ${tamanhoEsperado} items esperados`);
                        },
                        errorMessage: "A pagina não contem o numero de items esperados"
                    });
                },
                euVerificoSeATabelaFoiFiltradaComoOEsperadoTelefone: function () {
                    const tamanhoEsperado = 1
                    return this.waitFor({
                        viewName: sViewName,
                        id: "TabelaVendas",
                        matchers: new AggregationLengthEquals({
                            name: "items",
                            length: tamanhoEsperado
                        }),
                        success: function () {
                            Opa5.assert.ok(true, `A pagina contem ${tamanhoEsperado} items esperados`);
                        },
                        errorMessage: "A pagina não contem o numero de items esperados"
                    });
                },
                euVerificoSeATabelaFoiFiltradaComoOEsperadoDataInicial: function () {
                    const tamanhoEsperado = 2

                    return this.waitFor({
                        viewName: sViewName,
                        id: "TabelaVendas",
                        matchers: new AggregationLengthEquals({
                            name: "items",
                            length: tamanhoEsperado
                        }),
                        success: function () {
                            Opa5.assert.ok(true, `A pagina contem ${tamanhoEsperado} items esperados`);
                        },
                        errorMessage: "A pagina não contem o numero de items esperados"
                    });
                },
                euVerificoSeATabelaFoiFiltradaComoOEsperadoDataFinal: function () {
                    const tamanhoEsperado = 2

                    return this.waitFor({
                        viewName: sViewName,
                        id: "TabelaVendas",
                        matchers: new AggregationLengthEquals({
                            name: "items",
                            length: tamanhoEsperado
                        }),
                        success: function () {
                            Opa5.assert.ok(true, `A pagina contem ${tamanhoEsperado} items esperados`);
                        },
                        errorMessage: "A pagina não contem o numero de items esperados"
                    });
                }
            }
        }
    });
});
