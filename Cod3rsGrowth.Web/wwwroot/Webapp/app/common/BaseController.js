sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/core/UIComponent",
	"sap/m/MessageBox"

], function (Controller, UIComponent, MessageBox) {
	"use strict";

	return Controller.extend("ui5.carro.controller.BaseController", {
		getRouter() {
			return UIComponent.getRouterFor(this);
		},

		processarEvento(action) {
			try {
				var promise = action();

				if (promise && typeof promise.catch === 'function') {
					promise.catch(error => MessageBox.error(error.message));
				}
			} catch (error) {
				MessageBox.error(error.message);
			}
		},

		_requisicaoHttp(url, metodo, objeto, idMessageSucesso, idMessageErro) {
			fetch(url, {
				method: metodo,
				body: JSON.stringify(objeto),
				headers: { "Content-type": "application/json; charset=UTF-8" }
			})
				.then(res => {
					return res.json();
				})
				.then(data => {
					if (data.Detail) {
						this._erroNaRequisicaoDaApi(data);
						this.getView().byId(idMessageSucesso).setVisible(false);
						this.getView().byId(idMessageErro).setVisible(true);
					}
					else {
						this.getView().byId(idMessageErro).setVisible(false);
						this.getView().byId(idMessageSucesso).setVisible(true);
					}
				})
                .catch((err) => MessageBox.error(err));
		},

		_erroNaRequisicaoDaApi(erroRfc) {
			const mensagemErroPrincipal = erroRfc.Extensions.Erros.join(', ');
			const mensagemErroCompleta = `<p><strong>Status:</strong> ${erroRfc.Status}</p>` +
				`<p><strong>Detalhes:</strong><br/> ${erroRfc.Detail}</p>` +
				"<p>Para mais ajuda acesse <a href='//www.sap.com' target='_top'>aqui</a>.";

			MessageBox.error(mensagemErroPrincipal, {
				title: "Error",
				details: mensagemErroCompleta,
				styleClass: "sapUiResponsivePadding--header sapUiResponsivePadding--content sapUiResponsivePadding--footer",
				dependentOn: this.getView()
			});
		}
	});

});
