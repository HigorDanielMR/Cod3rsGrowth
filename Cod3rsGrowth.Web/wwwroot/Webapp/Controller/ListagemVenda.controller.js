sap.ui.define([
    "ui5/carro/controller/BaseController",
    "sap/ui/model/json/JSONModel",
    "ui5/carro/model/formatter"
], function (BaseController, JSONModel, Formatter) {
    "use strict";

    var NomeDaAPI = "Vendas"

    return BaseController.extend("ui5.carro.controller.ListagemVenda", {
        formatter: Formatter,

        onInit() {
                fetch("http://localhost:5071/api/Vendas")
                .then((res) => res.json())
                .then((data) => {
                    const jsonModel = new JSONModel(data)

                    this.getView().setModel(jsonModel, NomeDaAPI);
                })
                .catch((err) => console.error(err));
        },
        filtroNome() {
            fetch(`http://localhost:5071/api/Vendas?Nome=${this.oView.byId("FiltroNome").getValue()}`)
                .then((res) => res.json())
                .then((data) => {
                    const jsonModel = new JSONModel(data)

                    this.getView().setModel(jsonModel, NomeDaAPI);
                })
                .catch((err) => console.error(err));
        },
        filtroCpf() {
            fetch(`http://localhost:5071/api/Vendas?Cpf=${this.oView.byId("FiltroCpf").getValue()}`)
                .then((res) => res.json())
                .then((data) => {
                    const jsonModel = new JSONModel(data)

                    this.getView().setModel(jsonModel, NomeDaAPI);
                })
                .catch((err) => console.error(err));
        },
        filtroTelefone() {
            fetch(`http://localhost:5071/api/Vendas?Telefone=${this.oView.byId("FiltroTelefone").getValue()}`)
                .then((res) => res.json())
                .then((data) => {
                    const jsonModel = new JSONModel(data)

                    this.getView().setModel(jsonModel, NomeDaAPI);
                })
                .catch((err) => console.error(err));
        },
        filtroDataInicial() {
            fetch(`http://localhost:5071/api/Vendas?DataDeCompraInicial=${this.oView.byId("FiltroDataInicial").getValue()}`)
                .then((res) => res.json())
                .then((data) => {
                    const jsonModel = new JSONModel(data)

                    this.getView().setModel(jsonModel, NomeDaAPI);
                })
                .catch((err) => console.error(err));
        },
        filtroDatFinal() {
            fetch(`http://localhost:5071/api/Vendas?DataDeCompraFinal=${this.oView.byId("FiltroDataFial").getValue()}`)
                .then((res) => res.json())
                .then((data) => {
                    const jsonModel = new JSONModel(data)

                    this.getView().setModel(jsonModel, NomeDaAPI);
                })
                .catch((err) => console.error(err));
        }

    });
});