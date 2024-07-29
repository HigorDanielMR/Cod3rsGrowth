sap.ui.define([
    "ui5/carro/controller/BaseController",
    "sap/ui/core/routing/History",
    "sap/ui/model/json/JSONModel",
    "ui5/carro/model/formatter",
    "sap/m/MessageToast",
    "ui5/carro/model/validacao"

], function (BaseController, History, JSONModel, Formatter, MessageToast, validacao) {
    "use strict";

    var ModeloCarro = "Carros"
    var idDoInputCpf = "InputCpf"
    var idDoInputPago = "InputPago"
    var idDoInputNome = "InputNome"
    var idDoInputEmail = "InputEmail"
    var idDoInputTelefone = "InputTelefone"
    var urlCarro = "http://localhost:5071/api/Carros/Disponiveis"


    return BaseController.extend("ui5.carro.controller.AdicionarVenda", {
        formatter: Formatter,

        onInit() {
            this._carregarCarros();
        },

        _carregarCarros() {
            fetch(urlCarro)
                .then((res) => res.json())
                .then((data) => {
                    const jsonModel = new JSONModel(data)

                    this.getView().setModel(jsonModel, ModeloCarro);
                })
                .catch((err) => console.error(err));
        },

        aoColetarNome() {
            const inputNome = this.oView.byId(idDoInputNome);
            const nome = inputNome.getValue();
            validacao.validarNome(inputNome, nome);
            return nome;
        },

        aoColetarCpf() {
            const inputCpf = this.oView.byId(idDoInputCpf);
            const cpf = inputCpf.getValue();
            validacao.validarCpf(inputCpf, cpf);
            return cpf;
        },

        aoColetarTelefone() {
            const inputTelefone = this.oView.byId(idDoInputTelefone);
            const telefone = inputTelefone.getValue();
            validacao.validarTelefone(inputTelefone, telefone);
            return telefone;
        },

        aoColetarEmail() {
            const inputEmail = this.oView.byId(idDoInputEmail);
            const email = inputEmail.getValue();
            validacao.validarEmail(inputEmail, email);
            return email;
        },

        aoColetarPago() {
            const pago = this.oView.byId(idDoInputPago).getSelected();
            return pago;
        },

        aoSelecionarCarro() {
            var carroSelecionado = this._coletarCarroSelecionado();
            return carroSelecionado;
        },

        aoClicarDeveAdicionarVenda() {
            this.processarEvento(() => {
                var urlPost = "http://localhost:5071/api/Vendas/";
                var carroEscolhido = this.aoSelecionarCarro();
                var data = Date.now();

                var venda = {
                    "nome": this.aoColetarNome(),
                    "cpf": this.aoColetarCpf(),
                    "email": this.aoColetarEmail(),
                    "telefone": this.aoColetarTelefone(),
                    "idDoCarroVendido": carroEscolhido.id,
                    "dataDeCompra": this.formatarData(data),
                    "valorTotal": carroEscolhido.valorDoVeiculo,
                    "pago": this.aoColetarPago()
                }

                fetch(urlPost, {
                    method: "POST",
                    body: JSON.stringify(venda),
                    headers: { "Content-type": "application/json; charset=UTF-8" }
                })
                    .then(response => response.json())
                    .then(json => console.log(json))
                    .catch(err => console.log(err));

                this.getView().byId("sucessoAoCriarVenda").setVisible(true);
            })
        },

        _coletarCarroSelecionado() {
            var oTable = this.getView().byId("TabelaCarrosDisponiveis");
            var aSelectedItems = oTable.getSelectedItems();

            if (aSelectedItems.length === 0) {
                this.getView().byId("erroSelecionarCarro").setVisible(true);
            }
            else {
                this.getView().byId("erroSelecionarCarro").setVisible(false);
            }

            var oSelectedItem = aSelectedItems[0];
            var oBindingContext = oSelectedItem.getBindingContext("Carros");
            var oSelectedCar = oBindingContext.getObject();

            return oSelectedCar;
        },

        aoClicarDeveVoltarParaATelaDeListagem() {
            this.processarEvento(() => {
                var history, previousHash;

                history = History.getInstance();
                previousHash = history.getPreviousHash();

                if (previousHash !== undefined) {
                    window.history.go(voltarUmaPagina);
                } else {
                    this.getRouter().navTo("appListagem", {}, true);
                }
            })
        }
    });
}, true);