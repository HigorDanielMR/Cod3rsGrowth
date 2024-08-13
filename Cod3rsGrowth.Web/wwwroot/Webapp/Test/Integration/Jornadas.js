sap.ui.define([
    "sap/ui/test/Opa5",
    "./arregements/Startup",
    "./pages/vendas/JornadaTelaDeListagem",
    "./pages/vendas/JornadaTelaDeDetalhes",
    "./pages/vendas/JornadaTelaDeCriacao",
    "./pages/vendas/JornadaTelaDeEdicao"
], function (Opa5, Startup) {
    "use Strict";

    const view = "ui5.carro.app.vendas";
    Opa5.extendConfig({
        arrangements: new Startup(),
        viewNamespace: view,
        autoWait: true
    })
})