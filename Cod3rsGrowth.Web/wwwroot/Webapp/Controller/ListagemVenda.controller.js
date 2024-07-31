sap.ui.define([
    "ui5/carro/controller/BaseController",
    "sap/ui/model/json/JSONModel",
    "ui5/carro/model/formatter"

], function (BaseController, JSONModel, Formatter) {
    "use strict";

    const ID = "id"
    const modeloVenda = "Vendas"
    const idDoFiltroCpf = "FiltroCpf"
    const RotaListagem = "appListagem"
    const idDoFiltroNome = "FiltroNome"
    const quantidadeDeCaracteresDoCpf = 14
    const quantidadeDeCaracteresDoTelefone = 15
    const idDoFiltroTelefone = "FiltroTelefone"
    let url = "http://localhost:5071/api/Vendas"    
    const idDOFiltroDataFinal = "FiltroDataFinal"
    const idDoFiltroDataInicial = "FiltroDataInicial"

    return BaseController.extend("ui5.carro.controller.ListagemVenda", {
        formatter: Formatter,

        onInit() {
            this.aoCoincidirRota();
        },

        _carregarListaDeVendas() {
            fetch(url)
                .then((res) => res.json())
                .then((data) => {
                    const jsonModel = new JSONModel(data)

                    this.getView().setModel(jsonModel, modeloVenda);
                })
                .catch((err) => console.error(err));
        },

        aoCoincidirRota() {
            this.processarEvento(() => {
                var rota = sap.ui.core.UIComponent.getRouterFor(this);
                rota.getRoute(RotaListagem).attachMatched(this._carregarListaDeVendas, this);
            });
        },
        
        aoColetarNome() {
            const nome = this.oView.byId(idDoFiltroNome).getValue();
            return nome;
        },

        aoColetarCpf() {
            const cpf = this.oView.byId(idDoFiltroCpf).getValue();
            if (cpf.length < quantidadeDeCaracteresDoCpf) return '';
            return cpf;
        },

        aoColetarTelefone() {
            const telefone = this.oView.byId(idDoFiltroTelefone).getValue();
            if (telefone.length < quantidadeDeCaracteresDoTelefone) return '';
            return telefone;
        },

        aoColetarDataInicial() {
            const dataInicial = this.oView.byId(idDoFiltroDataInicial).getValue();
            if (!dataInicial) return '';
            return dataInicial;
        },

        aoColetarDataFinal() {
            const dataFinal = this.oView.byId(idDOFiltroDataFinal).getValue();
            if (!dataFinal) return '';
            return dataFinal;
        },

        aoFiltrar() {
            this.processarEvento(() => {
                let urlDoFiltro = url + "?";
                const cpf = this.aoColetarCpf();
                const nome = this.aoColetarNome();
                const telefone = this.aoColetarTelefone();
                const dataFinal = this.aoColetarDataFinal();
                const dataInicial = this.aoColetarDataInicial();

                if (nome) {
                    urlDoFiltro += "Nome=" + nome + "&";
                }

                if (cpf) {
                    urlDoFiltro += "Cpf=" + cpf + "&";
                }

                if (telefone) {
                    urlDoFiltro += "Telefone=" + telefone + "&";
                }

                if (dataInicial && dataFinal) {
                    urlDoFiltro += "DataDeCompraInicial=" + dataInicial + "&" + "DataDeCompraFInal=" + dataFinal;
                }

                else if (dataInicial) {
                    urlDoFiltro += "DataDeCompraInicial=" + dataInicial;
                }

                else if (dataFinal) {
                    urlDoFiltro += "DataDeCompraFinal=" + dataFinal;
                }

                fetch(urlDoFiltro)
                    .then((res) => res.json())
                    .then((data) => {
                        const jsonModel = new JSONModel(data)

                        this.getView().setModel(jsonModel, modeloVenda);
                    })
                    .catch((err) => console.error(err));
            })
        },

        adicionarVenda() {
            this.processarEvento(() => {
                this.getRouter().navTo("appAdicionarVenda", {}, true);  
            })
        },

        aoPressionar(oEvent) {
            const oItem = oEvent.getSource();
            const oRouter = this.getOwnerComponent().getRouter();
            oRouter.navTo("appDetalhes", {
                id: window.encodeURIComponent(oItem.getBindingContext(modeloVenda).getProperty(ID))
            });
        }
    });
});