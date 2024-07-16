sap.ui.define([
	"sap/ui/core/mvc/XMLView"
], (XMLView) => {
	"use strict";
	XMLView.create({
		viewName: "ui5.carro.view.App"
	}).then((oView) => oView.placeAt("content"));
});
