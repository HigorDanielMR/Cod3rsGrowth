sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/EnterText",
    "sap/ui/test/actions/Press",
    "sap/ui/test/matchers/PropertyStrictEquals"


], (Opa5, EnterText, Press, PropertyStrictEquals) => {
    "use strict";

    const contextoCarros = "Carros";
    const idDaTabela = "TabelaCarros";
    const idDoFiltroModelo = "FiltroModelo";
    const viewListagemCarro = "ListagemCarro";

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
                            text: "M3"
                        }),
                        errorMessage: "Input não encontrado."
                    });
                }
            },

            assertions: {
                euVerificoSeATabelaFoiFiltradaComoOEsperadoModelo() {
                    const modeloDesejado = 'M3';
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
                }
            }
        }
    });
});
