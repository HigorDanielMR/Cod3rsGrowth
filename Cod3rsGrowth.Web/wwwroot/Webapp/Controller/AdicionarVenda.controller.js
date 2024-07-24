sap.ui.define([
    "ui5/carro/controller/BaseController",
    "sap/ui/core/routing/History",
    "sap/ui/model/json/JSONModel",
    "ui5/carro/model/formatter"

], function (BaseController, History, JSONModel, Formatter) {
    "use strict";

    var NomeDaAPICarro = "Carros"
    var NomeDaAPIVenda = "Vendas"
    var urlCarro = "http://localhost:5071/api/Carros/Disponiveis"    
    var urlVenda = "http://localhost:5071/api/Vendas"
    var idDoInputNome = "InputNome"
    var idDoInputTelefone = "InputTelefone"
    var idDoInputCpf = "InputCpf"
    var idDoInputEmail = "InputEmail"
    var idDoInputPago = "InputPago"


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

        cancelar() {
            var history, previousHash;

            history = History.getInstance();
            previousHash = history.getPreviousHash();

            if (previousHash !== undefined) {
                window.history.go(voltarUmaPagina);
            } else {
                this.getRouter().navTo("appListagem", {}, true /*no history*/);
            }
        },

        coletarNome() {
            const nome = this.oView.byId(idDoInputNome).getValue();
            return nome;
        },

        coletarCpf() {
            const cpf = this.oView.byId(idDoInputCpf).getValue();
            return cpf;
        },

        coletarTelefone() {
            const telefone = this.oView.byId(idDoInputTelefone).getValue();
            return telefone;
        },
        coletarEmail() {
            const telefone = this.oView.byId(idDoInputEmail).getValue();
            return telefone;
        },
        coletarPago() {
            const telefone = this.oView.byId(idDoInputPago).getSelected();
            return telefone;
        },
        selecionandoCarro: function (oEvent) {
            var oTable = oEvent.getSource(); 
            var aSelectedItems = oTable.getSelectedItems(); 

            var aSelectedCars = []; 
            
            for (var i = 0; i < aSelectedItems.length; i++) {
                var oSelectedItem = aSelectedItems[i];
                var oBindingContext = oSelectedItem.getBindingContext("Carros");
                var oSelectedCar = oBindingContext.getObject();
                
                aSelectedCars.push(oSelectedCar);
            }
            
            console.log("Carros selecionados:", aSelectedCars);
            
        },

        adicionarVenda() {
            
            var serviceUrl = "http://localhost:5071/api/Vendas/";
            var oDataModel = new sap.ui.model.odata.ODataModel(serviceUrl, true);

            var venda = {
                method: "POST",
                vendaNova: {
                    "nome": coletarNome(),
                    "cpf": coletarCpf(),
                    "email": coletarEmail(),
                    "telefone": coletarTelefone(),
                    "idDoCarroVendido": selecionadnoCarro(),
                    "dataDeCompra": Date.now(),
                    "valorTotal": selecionadnoCarro().valorDoVeiculo,
                    "pago": coletarPago()
                },
                success: function () {
                    console.log("Requisição POST bem-sucedida!");
                },
                error: function () {
                    console.error("Falha na requisição POST.");
                }
            };

            oDataModel.callFunction("NomeDaSuaFuncaoImport", mParameters);

        }
    });
}, true);