sap.ui.define([
    "sap/ui/test/Opa5",
    "./arregements/Startup",
    "./JornadaTelaDeListagem",
    "./JornadaTelaDeDetalhes",
    "./JornadaTelaDeCriacao"
], function (Opa5, Startup) {
    "use Strict";

    const view = "ui5.carro.view";
    Opa5.extendConfig({
        arrangements: new Startup(),
        viewNamespace: view,
        autoWait: true
    })
})