sap.ui.define([
    "sap/ui/core/format/DateFormat",
    "sap/ui/core/format/NumberFormat"
], function (DateFormat, NumberFormat) {
    "use strict";

    return {
        formatarData: function (date) {
            const oDateFormat = DateFormat.getDateInstance({
                pattern: "dd/MM/YYYY"
            });
            const sFormattedDate = oDateFormat.format(new Date(date));
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
        }
    }
}, true);