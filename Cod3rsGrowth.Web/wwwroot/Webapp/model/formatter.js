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
            switch (Marca) {
                case "Audi":
                    return 0;
                case 'Bentley':
                    return 1;
                case "BMW":
                    return 2;
                case "Bugatti":
                    return 3;
                case "Chevrolet":
                    return 4;
                case "Ferrari":
                    return 5;
                case "Fiat":
                    return 6;
                case "Ford":
                    return 7;
                case "Honda":
                    return 8;
                case "Hyundai":
                    return 9;
                case "Jaguar":
                    return 10;
                case "Kia":
                    return 11;
                case 'Lamborghini':
                    return 12;
                case "Land Rover":
                    return 13;
                case "Maserati":
                    return 14;
                case "Mercedes":
                    return 15;
                case "Mitsubishi":
                    return 16;
                case "Nissan":
                    return 17;
                case "Peugeot":
                    return 18;
                case "Porsche":
                    return 19;
                case "Renault":
                    return 20;
                case "Rolls Royce":
                    return 21;
                case "Subaru":
                    return 22;
                case "Tesla":
                    return 23;
                case "Toyota":
                    return 24;
                case "Volkswagen":
                    return 25;
                case "Todos":
                    return null;
                default:
                    return Marca;
            }
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
            switch (Cor) {
                case "Amarelo":
                    return 0;
                case "Azul":
                    return 1;
                case "Bege":
                    return 2;
                case "Bordô":
                    return 3;
                case "Branco":
                    return 4;
                case "Cinza":
                    return 5;
                case "Ciano":
                    return 6;
                case "Dourado":
                    return 7;
                case "Grafite":
                    return 8;
                case "Laranja":
                    return 9;
                case "Magenta":
                    return 10;
                case "Marrom":
                    return 11;
                case "Prata":
                    return 12;
                case "Prateado":
                    return 13;
                case "Preto":
                    return 14;
                case "Preto":
                    return 15;
                case "Rosa":
                    return 16;
                case "Roxo":
                    return 17;
                case "Turquesa":
                    return 18;
                case "Verde":
                    return 19;
                case "Vermelho":
                    return 20;
                case "Violeta":
                    return 21;
                case "Todos":
                    return null;
                default:
                    return Cor;
            }
        },

        formatarCor(Cor) {
            const oResourceBundle = this.getOwnerComponent().getModel("i18n").getResourceBundle();
            const cores = {
                0: "Amarelo",
                1: "Azul",
                2: "Bege",
                3: "Bordo",
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