sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/Press",
    "sap/ui/test/matchers/PropertyStrictEquals",
    "sap/ui/test/actions/EnterText",
    'sap/ui/test/matchers/AggregationLengthEquals'
], (Opa5, Press, PropertyStrictEquals, EnterText, AggregationLengthEquals) => {
    "use strict";

    const sViewName = "ui5.carro.view.ListagemVenda";
    const idDoInput = "FiltroNome"

    Opa5.createPageObjects({
        onTheAppPage: {
            arrangements: {
                euInicioMeuApp() {
                    return this.iStartMyUIComponent("../index.html");
                }
            },
            actions: {
                euClicoNaSearchFildDoFiltroNome: function () {
                    return this.waitFor({
                        id: "FiltroNome",
                        viewName: sViewName,
                        actions: new EnterText({
                            text: "Adriana"
                        }),
                        errorMessage: "SearchField não encontrado."
                    });
                },
                euClicoNaSearchFildDoFiltroCpf: function () {
                    return this.waitFor({
                        id: "FiltroCpf",
                        viewName: sViewName,
                        actions: new EnterText({
                            text: "546.516.516-51"
                        }),
                        errorMessage: "SearchField não encontrado."
                    });
                },
                euClicoNaSearchFildDoFiltroTelefone: function () {
                    return this.waitFor({
                        id: "FiltroTelefone",
                        viewName: sViewName,
                        actions: new EnterText({
                            text: "(65) 16516-1651"
                        }),
                        errorMessage: "SearchField não encontrado."
                    });
                }
            },

            assertions: {
                euVerificoSeATabelaFoiFiltradaComoOEsperadoNome: function () {
                    return this.waitFor({
                        viewName: sViewName,
                        id: "TabelaVendas",
                        matchers: function (oTable) {
                            var aCells = oTable.getItems()[0].getCells();

                            let result = aCells.map((cell) => {
                                return cell.getText().includes("Adriana");
                            })

                            if (result)
                                return true;
                            return false;
                        },
                        success: function () {
                            Opa5.assert.ok(true, "A tabela foi filtrada apenas com o nome desejado.");
                        },
                        errorMessage: "A tabela não contem os valores esperados"
                    });
                },
                euVerificoSeATabelaFoiFiltradaComoOEsperadoCpf: function () {
                    return this.waitFor({
                        viewName: sViewName,
                        id: "TabelaVendas",
                        matchers: function (oTable) {
                            var aCells = oTable.getItems()[0].getCells();

                            let result = aCells.map((cell) => {
                                return cell.getText().includes("546.516.516-51");
                            })

                            if (result)
                                return true;
                            return false;
                        },
                        success: function () {
                            Opa5.assert.ok(true, "A tabela foi filtrada apenas com o cpf desejado.");
                        },
                        errorMessage: "A tabela não contem os valores esperados"
                    });
                },
                euVerificoSeATabelaFoiFiltradaComoOEsperadoTelefone: function () {
                    return this.waitFor({
                        viewName: sViewName,
                        id: "TabelaVendas",
                        matchers: function (oTable) {
                            var aCells = oTable.getItems()[0].getCells();

                            let result = aCells.map((cell) => {
                                return cell.getText().includes("(65) 16516-1651");
                            })

                            if (result)
                                return true;
                            return false;
                        },
                        success: function () {
                            Opa5.assert.ok(true, "A tabela foi filtrada apenas com o telefone desejado.");
                        },
                        errorMessage: "A tabela não contem os valores esperados"
                    });
                }
            }
        }
    });
});
