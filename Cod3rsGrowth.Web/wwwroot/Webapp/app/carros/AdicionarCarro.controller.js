sap.ui.define([
    "ui5/carro/app/common/BaseController",
    "sap/ui/core/routing/History",
    "sap/ui/model/json/JSONModel",
    "ui5/carro/model/formatter",
    "ui5/carro/model/validacao",
	"sap/m/MessageStrip",
	"sap/m/MessageBox"

], function (BaseController, History, JSONModel, Formatter, validacao, MessageStrip, MessageBox) {
    "use strict";

    let _rota;
    const modeloCores = "Cores";
    const parametroNome = "name";
    const modeloMarcas = "Marcas";
    const idDoInputFlex = "InputFlex";
    const idDoInputValor = "InputValor";
    const idDoInputCor = "SelecionarCor";
    const idDoInputModelo = "InputModelo";
    const idDoInputMarca = "SelecionarMarca";
    const rotaCriarCarro = "appAdicionarCarro";
    const rotaListagemCarros = "appListagemCarro";
    const url= "http://localhost:5071/api/Carros/";
    const idDoMessageStripErroCriarCarro = "erroCriarCarro";
    const urlCores = "http://localhost:5071/api/Carros/Cores";
    const urlMarcas = "http://localhost:5071/api/Carros/Marcas";
    const idDoMessageStripSucessoCriacao = "sucessoAoCriarCarro";

    return BaseController.extend("ui5.carro.app.carros.AdicionarCarro", {
        formatter: Formatter,

        onInit() {
            this.aoCoincidirRota();
        },

        aoCoincidirRota() {
            this.processarEvento(() => {
                var rota = sap.ui.core.UIComponent.getRouterFor(this);
                rota.getRoute(rotaCriarCarro).attachMatched(this._carregarEventosCriar, this);
            });
        },

        _carregarEventosCriar(oEvent) {
            this._carregarDescricaoCores();
            this._carregarDescricaoMarcas();
            var oRouter = this.getRouter();
            _rota = oRouter.getRoute(oEvent.getParameter(parametroNome))._oConfig.name;
        },

        _carregarDescricaoCores(){
            let sucesso = true;
            fetch(urlCores)
                .then((res) => {
                    if (!res.ok)
                        sucesso = false;
                    return res.json()
                })
                .then((data) => {
                    if (sucesso) {
                        const cores = data.map((item) => ({ text: item }));
                        this.getView().setModel(new JSONModel({
                            descricao: cores
                        }), modeloCores);
                    } else {
                        this._erroNaRequisicaoDaApi(data);
                    }
                })
                .catch((err) => MessageBox.error(err));
        },

        _carregarDescricaoMarcas(){
            let sucesso = true;
            fetch(urlMarcas)
                .then((res) => {
                    if (!res.ok) sucesso = false;
                    return res.json();
                })
                .then((data) => {
                    if (sucesso) {
                        const marcas = data.map((item) => ({ text: item }));
                        this.getView().setModel(new JSONModel({
                            descricao: marcas
                        }), modeloMarcas);
                    } else {
                        this._erroNaRequisicaoDaApi(data);
                    }
                })
                .catch((err) => MessageBox.error(err));
        },

        aoColetarValorDoVeiculo(){
            var inputValor = this.oView.byId(idDoInputValor);
            var valor = inputValor.getValue();
            return parseFloat(valor);
        },
        
        aoColetarModelo() {
            const inputModelo = this.oView.byId(idDoInputModelo);
            const modelo = inputModelo.getValue();
            return modelo;
        },

        aoColetarMarca(){
            const marca = this.oView.byId(idDoInputMarca).getSelectedKey();
            return parseInt(marca);
        },
        
        aoColetarCor(){
            const cor = this.oView.byId(idDoInputCor).getSelectedKey();
            return parseInt(cor);
        },

        aoObterSeEhFlex() {
            const pago = this.oView.byId(idDoInputFlex).getState();
            return pago;
        },

        aoClicarNoBotaoAdicionarCriarCarro() {
            this.processarEvento(() => {

                var marca = this.aoColetarMarca();
                var modelo = this.aoColetarModelo();
                var cor = this.aoColetarCor();
                var valor = this.aoColetarValorDoVeiculo();
                var flex = this.aoObterSeEhFlex();

                const inputModelo = this.oView.byId(idDoInputModelo);
                const inputValor = this.oView.byId(idDoInputValor);

                let validacaoDados = validacao.validarDadosCarro(inputModelo, inputValor);

                if(validacaoDados){
                    const carro = {
                        "marca": marca,
                        "modelo": modelo,
                        "cor": cor,
                        "valorDoVeiculo": valor,
                        "flex": flex
                    }
                    const metodo = "POST"
                    let sucesso = true;
                    fetch(url, {
                        method: metodo,
                        body: JSON.stringify(carro),
                        headers: { "Content-type": "application/json; charset=UTF-8" }
                    })
                        .then(res => {
                            if (!res.ok) {
                                sucesso = false;
                            }
                            return res.json();
                        })
                        .then(data => {
                            if (!sucesso) {
                                this._erroNaRequisicaoDaApi(data);
                                this.getView().byId(idDoMessageStripErroCriarCarro).setVisible(true);
                            }
                            else {
                                this.getView().byId(idDoMessageStripSucessoCriacao).setVisible(true);
                            }
                        })
                        .catch(err => { MessageBox.error(err); });
                }
            })
        },

        aoClicarVoltarParaATelaDeListagem() {
            this.processarEvento(() => {
                var history;

                history = History.getInstance();
                this.getRouter().navTo(rotaListagemCarros, {}, true);
            })
        }
    });
}, true);