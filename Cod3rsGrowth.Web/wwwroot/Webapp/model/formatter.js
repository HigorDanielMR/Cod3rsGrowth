sap.ui.define([
    "sap/ui/core/format/DateFormat",
    "sap/ui/core/format/NumberFormat"
], function (DateFormat, NumberFormat) {
	"use strict";

    return {
        formatarData: function (date) {
            var oDateFormat = DateFormat.getDateInstance({
                pattern: "dd/MM/YYYY"
            });
            var sFormattedDate = oDateFormat.format(new Date(date));
            return sFormattedDate;
        },
        formatarValorDaMoeda: function (value) {
            var oNumberFormat = NumberFormat.getCurrencyInstance({
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
        }
    }
}, /* bExport= */ true);