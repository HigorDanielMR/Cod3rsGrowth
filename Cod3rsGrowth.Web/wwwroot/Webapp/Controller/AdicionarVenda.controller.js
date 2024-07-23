sap.ui.define([
    "ui5/carro/controller/BaseController",
    "sap/ui/model/json/JSONModel"

], function (BaseController, JSONModel) {
    "use strict";

    var url = "http://localhost:5071/api/Carros"    
    var NomeDaAPI = "Carros"

    return BaseController.extend("ui5.carro.controller.AdicionarVenda", {
        onInit() {
            fetch(url)
                .then((res) => res.json())
                .then((data) => {
                    this.getView().setModel(new JSONModel(data), NomeDaAPI);
                })
                .catch((err) => console.error(err));
        }
    });
}, true);