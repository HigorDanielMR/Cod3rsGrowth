sap.ui.define([
    "ui5/carro/app/common/BaseController",
    "sap/ui/core/routing/History",
    "sap/ui/model/json/JSONModel",
    "ui5/carro/model/formatter",
    "ui5/carro/model/validacao",
	"sap/m/MessageBox"

], function (BaseController, History, JSONModel, Formatter, validacao, MessageBox) {
    "use strict";

    let _rota;
    let idCarro;
    const modeloCores = "Cores";
    const parametroNome = "name";
    const modeloMarcas = "Marcas";
    const idDoInputFlex = "InputFlex";
    const idDoInputValor = "InputValor";
    const idDoInputCor = "SelecionarCor";
    const idDoInputModelo = "InputModelo";
    const parametroArgumento = "arguments";
    const idDoInputMarca = "SelecionarMarca";
    const rotaEditarCarro = "appEditarCarro";
    const rotaCriarCarro = "appAdicionarCarro";
    const rotaListagemCarros = "appListagemCarro";
    const url= "http://localhost:5071/api/Carros/";
    const idTituloViewCriarCarro = "TituloEditarCarro";
    const textoParaAdicionarTituloEdicao = "Editar Carro";
    const textoParaAdicionarTituloCriacao = "Adicionar Carro";
    const urlCores = "http://localhost:5071/api/Carros/Cores";
    const idDoMessageStripErroCriarCarro = "erroAoCriarCarro";
    const urlMarcas = "http://localhost:5071/api/Carros/Marcas";
    const idDoMessageStripErroEditarCarro = "erroAoEditarCarro";
    const idDoMessageStripSucessoCriacao = "sucessoAoCriarCarro";
    const idDoMessageStripSucessoEditar = "sucessoAoEditarCarro";

    return BaseController.extend("ui5.carro.app.carros.AdicionarCarro", {
        formatter: Formatter,

        onInit() {
            this.aoCoincidirRota();
        },

        aoCoincidirRota() {
            this.processarEvento(() => {
                var rota = sap.ui.core.UIComponent.getRouterFor(this);
                rota.getRoute(rotaCriarCarro).attachMatched(this._carregarEventosCriar, this);
                rota.getRoute(rotaEditarCarro).attachMatched(this._carregarEventodEditar, this);
            });
        },

        _carregarEventodEditar(oEvent) {
            this._mudarTituloDaViewEdicao();
            this._removerMessageStrip();
            this._limparInputs();
            this._obterCarroPorId(oEvent);
            this._carregarDescricaoCores();
            this._carregarDescricaoMarcas();
            var oRouter = this.getRouter();
            _rota = oRouter.getRoute(oEvent.getParameter(parametroNome))._oConfig.name;
        },

        _carregarEventosCriar(oEvent) {
            this._mudarTituloDaViewCriar();
            this._limparInputs();
            this._removerMessageStrip();
            this._carregarDescricaoCores();
            this._carregarDescricaoMarcas();
            var oRouter = this.getRouter();
            _rota = oRouter.getRoute(oEvent.getParameter(parametroNome))._oConfig.name;
        },

        _limparInputs() {
            const inputModelo = this.oView.byId(idDoInputModelo);
            const modelo = inputModelo.setValue(null);
            inputModelo.setValueState(sap.ui.core.ValueState.None);
            inputModelo.setValueStateText('');
            const inputValor = this.oView.byId(idDoInputValor);
            const valor = inputValor.setValue(null);
            inputValor.setValueState(sap.ui.core.ValueState.None);
            inputValor.setValueStateText('');
            const flex = this.oView.byId(idDoInputFlex).setState(false)
        },

        _removerMessageStrip(){
            this.getView().byId(idDoMessageStripErroCriarCarro).setVisible(false);
            this.getView().byId(idDoMessageStripErroEditarCarro).setVisible(false);
            this.getView().byId(idDoMessageStripSucessoCriacao).setVisible(false);
            this.getView().byId(idDoMessageStripSucessoEditar).setVisible(false);
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

        _mudarTituloDaViewCriar() {
            var Titulo = this.getView().byId(idTituloViewCriarCarro).setText(textoParaAdicionarTituloCriacao);
            return Titulo;
        },

        aoColetarValorDoVeiculo(){
            var inputValor = this.oView.byId(idDoInputValor);
            var valor = inputValor.getValue();
            validacao.validarValorDoCarro(inputValor);
            return parseFloat(valor);
        },
        
        aoColetarModelo() {
            const inputModelo = this.oView.byId(idDoInputModelo);
            const modelo = inputModelo.getValue();
            validacao.validarModelo(inputModelo);
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

                        
                if(!validacaoDados){
                    if(_rota === rotaEditarCarro) this.getView().byId(idDoMessageStripErroEditarCarro).setVisible(true);
                    if(_rota === rotaCriarCarro) this.getView().byId(idDoMessageStripErroCriarCarro).setVisible(true);
                } 
                if(validacaoDados){
                    if(_rota === rotaEditarCarro){
                        const urlEditar = url + idCarro;
                        const carro = {
                            "id": parseInt(idCarro),
                            "marca": marca,
                            "modelo": modelo,
                            "cor": cor,
                            "valorDoVeiculo": valor,
                            "flex": flex
                        }
                        const metodo = "PATCH"
                        this._requisicaoHttp(urlEditar, metodo, carro, idDoMessageStripSucessoEditar, idDoMessageStripErroEditarCarro)
                    }
                    if(_rota === rotaCriarCarro){
                        const carro = {
                            "marca": marca,
                            "modelo": modelo,
                            "cor": cor,
                            "valorDoVeiculo": valor,
                            "flex": flex
                        }
                        const metodo = "POST"
                        this._requisicaoHttp(url, metodo, carro, idDoMessageStripSucessoCriacao, idDoMessageStripErroCriarCarro)
                    }
                }
            })
        },

        _requisicaoHttp(url, metodo, carro, idMessageSucesso, idMessageErro) {
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
                    console.log(res)
                    return res.json();
                })
                .then(data => {
                    console.log(data)
                    if (!sucesso) {
                        this._erroNaRequisicaoDaApi(data);
                        this.getView().byId(idMessageErro).setVisible(true);
                    }
                    if(sucesso) {
                        this.getView().byId(idMessageErro).setVisible(false);
                        this.getView().byId(idMessageSucesso).setVisible(true);
                    }
                })
                .catch(err => { MessageBox.error(err); });
        },

        _mudarTituloDaViewEdicao() {
            var Titulo = this.getView().byId(idTituloViewCriarCarro).setText(textoParaAdicionarTituloEdicao);
            return Titulo;
        },
        
        _carregarDadosCarro(carro) {
            const modelo = this.oView.byId(idDoInputModelo).setValue(carro.modelo);
            const valor = this.oView.byId(idDoInputValor).setValue(carro.valorDoVeiculo);
            const flex = this.oView.byId(idDoInputFlex).setState(carro.flex);
            const marca = this.oView.byId(idDoInputMarca).setSelectedKey(carro.marca);
            const cor = this.oView.byId(idDoInputCor).setSelectedKey(carro.cor);
        },
        
        _obterCarroPorId(oEvent) {
            idCarro = oEvent.getParameter(parametroArgumento).id;
            let query = url + idCarro;
            let sucesso = true;
        
            fetch(query)
                .then(res => {
                    if (!res.ok) {
                        sucesso = false;
                    }
                    return res.json();
                })
                .then(carro => {
        
                    if (sucesso) {
                        this._carregarDadosCarro(carro);
                    }
                    else {
                        this._erroNaRequisicaoDaApi(carro);
                    }
                })
                .catch(err => { MessageBox.error(err); });
        },

        aoClicarBotaoVoltar() {
            this.processarEvento(() => {
                var history;

                history = History.getInstance();
                this.getRouter().navTo(rotaListagemCarros, {}, true);
            })
        }
    });
}, true);