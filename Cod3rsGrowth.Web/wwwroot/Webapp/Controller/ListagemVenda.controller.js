sap.ui.define([
    "ui5/carro/controller/BaseController",
    "sap/ui/core/format/DateFormat",
    "sap/ui/model/json/JSONModel",
    "ui5/carro/model/formatter"
], function (BaseController, DateFormat, JSONModel, Formatter) {
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

        filtrarDatas() {
            const dataInicial = this.coletarDataInicial();
            const dataFinal = this.coletarDataFinal();

            let url = `http://localhost:5071/api/Vendas`;

            if (dataInicial && dataFinal) {
                url += `?DataDeCompraInicial=${dataInicial}&DataDeCompraFinal=${dataFinal}`;
            } else if (dataInicial) {
                url += `?DataDeCompraInicial=${dataInicial}`;
            } else if (dataFinal) {
                url += `?DataDeCompraFinal=${dataFinal}`;
            }

            fetch(url)
                .then((res) => res.json())
                .then((data) => {
                    const jsonModel = new JSONModel(data);
                    this.getView().setModel(jsonModel, NomeDaAPI);
                })
                .catch((err) => console.error(err));
        },

        coletarDataInicial() {
            const dataInicial = this.oView.byId("FiltroDataInicial").getValue();
            if (!dataInicial) return '';
            return dataInicial;
        },

        coletarDataFinal() {
            const dataFinal = this.oView.byId("FiltroDataFinal").getValue();
            if (!dataFinal) return '';
            return dataFinal;
        }
    });
});