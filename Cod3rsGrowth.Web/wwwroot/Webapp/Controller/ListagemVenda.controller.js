sap.ui.define([
    "ui5/carro/controller/BaseController",
    "sap/ui/model/json/JSONModel"
], function (BaseController, JSONModel) {
    "use strict";

    var NomeDaAPI = "Vendas"
    return BaseController.extend("ui5.carro.controller.ListagemVenda", {
        onInit() {
            const oViewModel = new JSONModel({
                currency: "R$"
            });
            this.getView().setModel(oViewModel, "view");

            fetch("http://localhost:5071/api/Vendas")
                .then((res) => res.json())
                .then((data) => {
                    const jsonModel = new JSONModel(data)

                    this.getView().setModel(jsonModel, NomeDaAPI);
                })
                .catch((err) => console.error(err));
        }

    });
});