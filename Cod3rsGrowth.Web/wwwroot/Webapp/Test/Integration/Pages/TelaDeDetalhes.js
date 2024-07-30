sap.ui.define([
    'sap/ui/test/Opa5',
    'sap/ui/test/matchers/PropertyStrictEquals',
    'sap/ui/test/matchers/Interaction',
    'sap/ui/test/matchers/BindingPath',
    'sap/ui/test/matchers/AggregationContainingPropertyStrictEquals'
], function (Opa5, PropertyStrictEquals, Interaction, BindingPath, AggregationContainingPropertyStrictEquals) {
    'use strict';

    const viewListagem = "ListagemVenda"
    const viewDetalhes = "Detalhes"

    Opa5.createPageObjects({
        naTelaDeDetalhes: {
            arrangements: {
                euInicioMeuApp() {
                    return this.iStartMyUIComponent("../index.html");
                }
            },
            actions: {
            },
            assertions: {
            }            
        }
    });
});
