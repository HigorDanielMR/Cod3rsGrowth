sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/EnterText",
    "sap/ui/test/matchers/AggregationLengthEquals"

], (Opa5, EnterText, AggregationLengthEquals) => {
    "use strict";

    const sViewName = "ui5.carro.view.ListagemVenda";
    var idDaTabela = "TabelaVendas"
    var idDoFiltroNome = "FiltroNome";
    var nomeParaInserir = "Adriana";
    var idDoFiltroCpf = "FiltroCpf";
    var cpfParaInserir = "54651651651";
    var idDoFiltroTelefone = "FiltroTelefone";
    var telefoneParaInserir = "65165161651";
    var idDoFiltroDataInicial = "FiltroDataInicial";
    var dataInicialParaInserir = "18072024";
    var idDoFiltroDataFinal = "FiltroDataFinal";
    var dataFinalParaInserir = "04072024";
    var tagDasLinhas = "items";

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
                        id: idDoFiltroNome,
                        viewName: sViewName,
                        actions: new EnterText({
                            text: nomeParaInserir
                        }),
                        errorMessage: "Input não encontrado."
                    });
                },
                euPreenchoOInputDoFiltroCpf: function () {
                    return this.waitFor({
                        id: idDoFiltroCpf,
                        viewName: sViewName,
                        actions: new EnterText({
                            text: cpfParaInserir
                        }),
                        errorMessage: "Input não encontrado."
                    });
                },
                euPreenchoOInputDoFiltroTelefone: function () {
                    return this.waitFor({
                        id: idDoFiltroTelefone,
                        viewName: sViewName,
                        actions: new EnterText({
                            text: telefoneParaInserir
                        }),
                        errorMessage: "Input não encontrado."
                    });
                },
                euPreenchoOInputDoFiltroDataInicial: function () {
                    return this.waitFor({
                        id: idDoFiltroDataInicial,
                        viewName: sViewName,
                        actions: new EnterText({
                            text: dataInicialParaInserir
                        }),
                        errorMessage: "Input não encontrado."
                    });
                },
                euPreenchoOInputDoFiltroDataFinal: function () {
                    return this.waitFor({
                        id: idDoFiltroDataFinal,
                        viewName: sViewName,
                        actions: new EnterText({
                            text: dataFinalParaInserir
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
                        id: idDaTabela,
                        matchers: new AggregationLengthEquals({
                            name: tagDasLinhas,
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
                        id: idDaTabela,
                        matchers: new AggregationLengthEquals({
                            name: tagDasLinhas,
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
                        id: idDaTabela,
                        matchers: new AggregationLengthEquals({
                            name: tagDasLinhas,
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
                        id: idDaTabela,
                        matchers: new AggregationLengthEquals({
                            name: tagDasLinhas,
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
                        id: idDaTabela,
                        matchers: new AggregationLengthEquals({
                            name: tagDasLinhas,
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
