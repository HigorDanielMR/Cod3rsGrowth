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
        FiltrarData() {
            const dataInicial = this.oView.byId("FiltroDataInicial").getValue();
            const dataFinal = this.oView.byId("FiltroDataFinal").getValue();

            var oDateFormat = DateFormat.getDateInstance({
                pattern: "dd/MM/YYYY"
            });

            let url = `http://localhost:5071/api/Vendas`;

            if (dataInicial && dataFinal) {
                const formatandoDataInicial = oDateFormat.format(new Date(dataInicial)).toString();
                const formatandoDataFinal = oDateFormat.format(new Date(dataFinal)).toString();
                url += `?DataDeCompraInicial=${formatandoDataInicial}&DataDeCompraFinal=${formatandoDataFinal}`;
            } else if (dataInicial) {
                const formatandoDataInicial = oDateFormat.format(new Date(dataInicial)).toString();
                url += `?DataDeCompraInicial=${formatandoDataInicial}`;
            } else if (dataFinal) {
                const formatandoDataFinal = oDateFormat.format(new Date(dataFinal)).toString();
                url += `?DataDeCompraFinal=${formatandoDataFinal}`;
            }

            fetch(url)
                .then((res) => res.json())
                .then((data) => {
                    const jsonModel = new JSONModel(data);
                    this.getView().setModel(jsonModel, NomeDaAPI);
                })
                .catch((err) => console.error(err));
        }

    });
});