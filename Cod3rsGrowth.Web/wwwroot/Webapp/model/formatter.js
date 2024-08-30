sap.ui.define([
    "sap/ui/core/format/DateFormat",
    "sap/ui/core/format/NumberFormat"
], function (DateFormat, NumberFormat) {
    "use strict";

    return {
        formatarData(data) {

            if (!data) {
                return data;
            }
            const oDateFormat = DateFormat.getDateInstance({
                pattern: "dd/MM/YYYY"
            });
            return oDateFormat.format(new Date(data));
        },

        formatarDataParaApi(data) {
            if (!data) {
                return data;
            }
            const oDateFormat = DateFormat.getDateInstance({
                pattern: "yyyy-MM-dd"
            });
            return oDateFormat.format(new Date(data));
        },

        formatarValorDaMoeda(value) {
            const oNumberFormat = NumberFormat.getCurrencyInstance({
                currencyCode: false
            });

            return oNumberFormat.format(value, "R$");
        },

        alterarStatusDoPagamento(StatusPagamento) {
            const oResourceBundle = this.getOwnerComponent().getModel("i18n").getResourceBundle();
            switch (StatusPagamento) {
                case true:
                    return oResourceBundle.getText("Status.PagamentoConcluido");
                case false:
                    return oResourceBundle.getText("Status.PagamentoPendente");
                default:
                    return StatusPagamento;
            }
        },

        formatarFlex(Flex) {
            const oResourceBundle = this.getOwnerComponent().getModel("i18n").getResourceBundle();
            switch (Flex) {
                case true:
                    return oResourceBundle.getText("Flex.Sim");
                case false:
                    return oResourceBundle.getText("Flex.Nao");
                default:
                    return Flex;
            }
        },

        formatarMarcaParaInteiro(Marca){
            const marcas = {
               "Audi": 0,
               "Bentley": 1,
               "BMW": 2,
               "Bugatti": 3,
               "Chevrolet": 4,
               "Ferrari": 5,
               "Fiat": 6,
               "Ford": 7,
               "Honda": 8,
               "Hyundai": 9,
               "Jaguar" :10, 
               "Kia" :11, 
               "Lamborghini" :12, 
               "LandRover" :13, 
               "Maserati" :14, 
               "Mercedes" :15, 
               "Mitsubishi" :16, 
               "Nissan" :17, 
               "Peugeot" :18, 
               "Porsche" :19, 
               "Renault" :20, 
               "RollsRoyce" :21, 
               "Subaru" :22, 
               "Tesla" :23, 
               "Toyota" :24, 
               "Volkswagen" :25
            };

            return marcas[Marca]
        },

        formatarMarca(Marca) {
            const oResourceBundle = this.getOwnerComponent().getModel("i18n").getResourceBundle();
            const marcas = {
                0: "Audi",
                1: "Bentley",
                2: "BMW",
                3: "Bugatti",
                4: "Chevrolet",
                5: "Ferrari",
                6: "Fiat",
                7: "Ford",
                8: "Honda",
                9: "Hyundai",
                10: "Jaguar",
                11: "Kia",
                12: "Lamborghini",
                13: "LandRover",
                14: "Maserati",
                15: "Mercedes",
                16: "Mitsubishi",
                17: "Nissan",
                18: "Peugeot",
                19: "Porsche",
                20: "Renault",
                21: "RollsRoyce",
                22: "Subaru",
                23: "Tesla",
                24: "Toyota",
                25: "Volkswagen"
            };
            
            return oResourceBundle.getText(`Marca.${marcas[Marca] || Marca}`);
        },

        formatarCorParaInteiro(Cor){
            const cores = {
                "Amarelo": 0,
                "Azul": 1, 
                "Bege": 2, 
                "Bordô": 3, 
                "Branco": 4, 
                "Cinza": 5, 
                "Ciano": 6, 
                "Dourado": 7, 
                "Grafite": 8, 
                "Laranja": 9, 
                "Magenta": 10,
                "Marrom": 11,
                "Prata": 12,
                "Preto": 13,
                "Rosa": 14,
                "Roxo": 15,
                "Turquesa": 16,
                "Verde": 17,
                "Vermelho": 18,
                "Violeta": 19
            };
            
            return cores[Cor];
        },

        formatarCor(Cor) {
            const oResourceBundle = this.getOwnerComponent().getModel("i18n").getResourceBundle();
            const cores = {
                0: "Amarelo",
                1: "Azul",
                2: "Bege",
                3: "Bordô",
                4: "Branco",
                5: "Cinza",
                6: "Ciano",
                7: "Dourado",
                8: "Grafite",
                9: "Laranja",
                10: "Magenta",
                11: "Marrom",
                12: "Prata",
                13: "Preto",
                14: "Rosa",
                15: "Roxo",
                16: "Turquesa",
                17: "Verde",
                18: "Vermelho",
                19: "Violeta"
            };
            
            return oResourceBundle.getText(`Cor.${cores[Cor] || Cor}`);
        },

        formatarFlexFiltro(Flex){
            switch (Flex) {
                case "true":
                     return "true";
                case "false":
                    return "false";
                case "null":
                    return null;
            }
        }
    }
}, true);