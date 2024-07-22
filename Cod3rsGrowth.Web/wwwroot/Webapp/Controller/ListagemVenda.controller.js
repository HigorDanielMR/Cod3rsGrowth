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

        coletarNome() {
            const nome = this.oView.byId("FiltroNome").getValue();
            return nome;
        },

        coletarCpf() {
            const cpf = this.oView.byId("FiltroCpf").getValue();
            return cpf;
        },

        coletarTelefone() {
            const telefone = this.oView.byId("FiltroTelefone").getValue();
            return telefone;
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
        },

        aoAlterarFiltrar() {
            const nome = this.coletarNome();
            const cpf = this.coletarCpf();
            const telefone = this.coletarTelefone();
            const dataInicial = this.coletarDataInicial();
            const dataFinal = this.coletarDataFinal();

            let url = "http://localhost:5071/api/Vendas?";

            if (nome) {
                url += `Nome=${nome}&`
            }

            if (cpf) {
                url += `Cpf=${cpf}&`
            }

            if (telefone) {
                url += `Telefone=${telefone}&`
            }

            if (dataInicial && dataFinal) {
                url += `DataDeCompraInicial=${dataInicial}&DataDeCompraFinal=${dataFinal}`;
            }

            else if (dataInicial) {
                url += `DataDeCompraInicial=${dataInicial}`;
            }

            else if (dataFinal) {
                url += `DataDeCompraFinal=${dataFinal}`;
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