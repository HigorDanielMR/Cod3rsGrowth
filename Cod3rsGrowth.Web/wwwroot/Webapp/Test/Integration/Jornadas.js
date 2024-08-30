sap.ui.define([
    "sap/ui/test/Opa5",
    "./arregements/Startup",
    "./pages/vendas/JornadaTelaDeListagem",
    "./pages/vendas/JornadaTelaDeDetalhes",
    "./pages/vendas/JornadaTelaDeCriacao",
    "./pages/vendas/JornadaTelaDeEdicao",
    "./pages/vendas/JornadaRemover",
    "./pages/carros/JornadaTelaListagem",
    "./pages/carros/JornadaTelaDeDetalhes",
    "./pages/carros/JornadaTelaCriacao",
    "./pages/carros/JornadaTelaDeEdicao",
    './pages/carros/JornadaRemover'
    
], function (Opa5, Startup) {
    "use Strict";

    const view = "ui5.carro.app";
    Opa5.extendConfig({
        arrangements: new Startup(),
        viewNamespace: view,
        autoWait: true
    })
})