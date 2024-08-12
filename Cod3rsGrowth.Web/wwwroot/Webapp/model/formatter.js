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
        }
    }
}, true);