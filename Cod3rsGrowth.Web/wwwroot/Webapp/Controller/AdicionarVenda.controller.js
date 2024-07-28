sap.ui.define([
    "ui5/carro/controller/BaseController",
    "sap/ui/core/routing/History",
    "sap/ui/model/json/JSONModel",
    "ui5/carro/model/formatter",
    "sap/m/MessageToast",
    "ui5/carro/model/validacao"

], function (BaseController, History, JSONModel, Formatter, MessageToast, validacao) {
    "use strict";

    var idDoInputCpf = "InputCpf"
    var NomeDaAPICarro = "Carros"
    var idDoInputPago = "InputPago"
    var idDoInputNome = "InputNome"
    var idDoInputEmail = "InputEmail"
    var idDoInputTelefone = "InputTelefone"
    var urlCarro = "http://localhost:5071/api/Carros/Disponiveis"


    return BaseController.extend("ui5.carro.controller.AdicionarVenda", {
        formatter: Formatter,

        onInit() {
            fetch(urlCarro)
                .then((res) => res.json())
                .then((data) => {
                    const jsonModel = new JSONModel(data)

                    this.getView().setModel(jsonModel, NomeDaAPICarro);
                })
                .catch((err) => console.error(err));
        },

        coletarNome() {
            const inputNome = this.oView.byId(idDoInputNome);
            const nome = inputNome.getValue();
            validacao.validarNome(inputNome, nome);
            return nome;
        },

        coletarCpf() {
            const inputCpf = this.oView.byId(idDoInputCpf);
            const cpf = inputCpf.getValue();
            validacao.validarCpf(inputCpf, cpf);
            return cpf;
        },

        coletarTelefone() {
            const inputTelefone = this.oView.byId(idDoInputTelefone);
            const telefone = inputTelefone.getValue();
            validacao.validarTelefone(inputTelefone, telefone);
            return telefone;
        },
        coletarEmail() {
            const inputEmail = this.oView.byId(idDoInputEmail);
            const email = inputEmail.getValue();
            validacao.validarEmail(inputEmail, email);
            return email;
        },
        coletarPago() {
            const pago = this.oView.byId(idDoInputPago).getSelected();
            return pago;
        },

        formatarData(data) {
            const novaData = new Date(data);

            const dia = novaData.getDate().toString().padStart(2, '0');
            const mes = (novaData.getMonth() + 1).toString().padStart(2, '0');
            const ano = novaData.getFullYear();

            return `${ano}-${mes}-${dia}`;
        },

        selecionarCarro() {
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

        adicionarVenda() {
            var urlPost = "http://localhost:5071/api/Vendas/";
            var carroEscolhido = this.selecionarCarro();
            var data = Date.now();

            var venda = {
                "nome": this.coletarNome(),
                "cpf": this.coletarCpf(),
                "email": this.coletarEmail(),
                "telefone": this.coletarTelefone(),
                "idDoCarroVendido": carroEscolhido.id,
                "dataDeCompra": this.formatarData(data),
                "valorTotal": carroEscolhido.valorDoVeiculo,
                "pago": this.coletarPago()
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

        },

        voltarParaATelaDeListagem() {
            var history, previousHash;

            history = History.getInstance();
            previousHash = history.getPreviousHash();

            if (previousHash !== undefined) {
                window.history.go(voltarUmaPagina);
            } else {
                this.getRouter().navTo("appListagem", {}, true);
            }
        }
    });
}, true);