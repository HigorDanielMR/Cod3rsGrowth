sap.ui.define([
    "sap/ui/core/format/DateFormat",
    "sap/ui/core/format/NumberFormat"
], function (DateFormat, NumberFormat) {
    "use strict";

    return {
        formatarData(data) {

            if (data === null || data === undefined) {
                return data;
            }
            const oDateFormat = DateFormat.getDateInstance({
                pattern: "dd/MM/YYYY"
            });
            const sFormattedDate = oDateFormat.format(new Date(data));
            return sFormattedDate;
        },

        formatarDataParaApi(data) {
            if (data === null || data === undefined) {
                return data;
            }
            const oDateFormat = DateFormat.getDateInstance({
                pattern: "yyyy-MM-dd"
            });
            const sFormattedDate = oDateFormat.format(new Date(data));
            return sFormattedDate;
        },

        formatarValorDaMoeda: function (value) {
            const oNumberFormat = NumberFormat.getCurrencyInstance({
                currencyCode: false
            });

            return oNumberFormat.format(value, "R$");
        },

        alterarStatusDoPagamento: function (StatusPagamento) {
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
            switch (Marca) {
                case 0:
                    return oResourceBundle.getText("Marca.Audi");
                case 1:
                    return oResourceBundle.getText("Marca.Bentley");
                case 2:
                    return oResourceBundle.getText("Marca.BMW");
                case 3:
                    return oResourceBundle.getText("Marca.Bugatti");
                case 4:
                    return oResourceBundle.getText("Marca.Chevrolet");
                case 5:
                    return oResourceBundle.getText("Marca.Ferrari");
                case 6:
                    return oResourceBundle.getText("Marca.Fiat");
                case 7:
                    return oResourceBundle.getText("Marca.Ford");
                case 8:
                    return oResourceBundle.getText("Marca.Honda");
                case 9:
                    return oResourceBundle.getText("Marca.Hyundai");
                case 10:
                    return oResourceBundle.getText("Marca.Jaguar");
                case 11:
                    return oResourceBundle.getText("Marca.Kia");
                case 12:
                    return oResourceBundle.getText("Marca.Lamborghini");
                case 13:
                    return oResourceBundle.getText("Marca.LandRover");
                case 14:
                    return oResourceBundle.getText("Marca.Maserati");
                case 15:
                    return oResourceBundle.getText("Marca.Mercedes");
                case 16:
                    return oResourceBundle.getText("Marca.Mitsubishi");
                case 17:
                    return oResourceBundle.getText("Marca.Nissan");
                case 18:
                    return oResourceBundle.getText("Marca.Peugeot");
                case 19:
                    return oResourceBundle.getText("Marca.Porsche");
                case 20:
                    return oResourceBundle.getText("Marca.Renault");
                case 21:
                    return oResourceBundle.getText("Marca.RollsRoyce");
                case 22:
                    return oResourceBundle.getText("Marca.Subaru");
                case 23:
                    return oResourceBundle.getText("Marca.Tesla");
                case 24:
                    return oResourceBundle.getText("Marca.Toyota");
                case 25:
                    return oResourceBundle.getText("Marca.Volkswagen");
                default:
                    return Marca;
            }
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
            switch (Cor) {
                case 0:
                    return oResourceBundle.getText("Cor.Amarelo");
                case 1:
                    return oResourceBundle.getText("Cor.Azul");
                case 2:
                    return oResourceBundle.getText("Cor.Bege");
                case 3:
                    return oResourceBundle.getText("Cor.Bordo");
                case 4:
                    return oResourceBundle.getText("Cor.Branco");
                case 5:
                    return oResourceBundle.getText("Cor.Cinza");
                case 6:
                    return oResourceBundle.getText("Cor.Ciano");
                case 7:
                    return oResourceBundle.getText("Cor.Dourado");
                case 8:
                    return oResourceBundle.getText("Cor.Grafite");
                case 9:
                    return oResourceBundle.getText("Cor.Laranja");
                case 10:
                    return oResourceBundle.getText("Cor.Magenta");
                case 11:
                    return oResourceBundle.getText("Cor.Marrom");
                case 12:
                    return oResourceBundle.getText("Cor.Prata");
                case 13:
                    return oResourceBundle.getText("Cor.Prateado");
                case 14:
                    return oResourceBundle.getText("Cor.Preto");
                case 15:
                    return oResourceBundle.getText("Cor.Preto");
                case 16:
                    return oResourceBundle.getText("Cor.Rosa");
                case 17:
                    return oResourceBundle.getText("Cor.Roxo");
                case 18:
                    return oResourceBundle.getText("Cor.Turquesa");
                case 19:
                    return oResourceBundle.getText("Cor.Verde");
                case 20:
                    return oResourceBundle.getText("Cor.Vermelho");
                case 21:
                    return oResourceBundle.getText("Cor.Violeta");
                default:
                    return Cor;
            }
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