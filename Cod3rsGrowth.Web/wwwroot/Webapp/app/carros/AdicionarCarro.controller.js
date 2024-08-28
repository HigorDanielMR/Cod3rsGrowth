sap.ui.define([
    "ui5/carro/app/common/BaseController",
    "sap/ui/model/json/JSONModel",
    "ui5/carro/model/formatter",
    "ui5/carro/model/validacao"

], function (BaseController, JSONModel, Formatter, validacao) {
    "use strict";

    const urlApi= "http://localhost:5071/api/Carros/";

    let _rota;
    let idCarro;
    const modeloCores = "Cores";
    const parametroNome = "name";
    const modeloMarcas = "Marcas";
    const idDoInputFlex = "InputFlex";
    const idDoInputValor = "InputValor";
    const idDoInputCor = "SelecionarCor";
    const idDoInputModelo = "InputModelo";
    const recursoCores = urlApi + "Cores";
    const parametroArgumento = "arguments";
    const recursoMarcas = urlApi + "Marcas";
    const idDoInputMarca = "SelecionarMarca";
    const rotaEditarCarro = "appEditarCarro";
    const rotaCriarCarro = "appAdicionarCarro";
    const rotaListagemCarros = "appListagemCarro";
    const idTituloViewCriarCarro = "TituloEditarCarro";
    const textoParaAdicionarTituloEdicao = "Editar Carro";
    const textoParaAdicionarTituloCriacao = "Adicionar Carro";
    const idDoMessageStripErroCriarCarro = "erroAoCriarCarro";
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
                var rota = this.getRouter();
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
            const inputs = [
                { id: idDoInputModelo },
                { id: idDoInputValor },
                { id: idDoInputMarca },
                { id: idDoInputCor },
                { id: idDoInputFlex, isSwitch: true }
            ];
        
            inputs.forEach(input => {
                const element = this.oView.byId(input.id);
                if (input.isSwitch) {
                    element.setState(false);
                } else {
                    element.setValue(null);
                    element.setValueState(sap.ui.core.ValueState.None);
                    element.setValueStateText('');
                }
            });
        },        

        _removerMessageStrip(){
            const messageStripIds = [
                idDoMessageStripErroCriarCarro,
                idDoMessageStripErroEditarCarro,
                idDoMessageStripSucessoCriacao,
                idDoMessageStripSucessoEditar
            ];

            messageStripIds.forEach(id => {
                this.getView().byId(id).setVisible(false);
            })
        },

        _carregarDescricaoCores(){
            fetch(recursoCores)
                .then((res) => {
                    return res.json()
                })
                .then((data) => {
                    if (!data.Detail) {
                        const cores = data.map((item) => ({ text: item }));
                        this.getView().setModel(new JSONModel({
                            descricao: cores
                        }), modeloCores);
                    } else {
                        this._erroNaRequisicaoDaApi(data);
                    }
                })
        },

        _carregarDescricaoMarcas(){
            fetch(recursoMarcas)
                .then((res) => {
                    return res.json();
                })
                .then((data) => {
                    if (!data.Detail) {
                        const marcas = data.map((item) => ({ text: item }));
                        this.getView().setModel(new JSONModel({
                            descricao: marcas
                        }), modeloMarcas);
                    } else {
                        this._erroNaRequisicaoDaApi(data);
                    }
                })
        },

        _mudarTituloDaViewCriar() {
            this.getView().byId(idTituloViewCriarCarro).setText(textoParaAdicionarTituloCriacao);
        },

        obterValor(){
            var inputValor = this.oView.byId(idDoInputValor);
            return inputValor;
        },
        
        obterModelo() {
            const inputModelo = this.oView.byId(idDoInputModelo);
            return inputModelo;
        },

        obterMarca(){
            return parseInt(this.oView.byId(idDoInputMarca).getSelectedKey());
        },
        
        obterCor(){
            return parseInt(this.oView.byId(idDoInputCor).getSelectedKey());
        },

        obterFlex() {
            return this.oView.byId(idDoInputFlex).getState();
        },

        aoClicarNoBotaoAdicionarCriarCarro() {
            this.processarEvento(() => {

                var marca = this.obterMarca();
                var modelo = this.obterModelo().getValue();
                var cor = this.obterCor();
                var valor = this.obterValor().getValue();
                var flex = this.obterFlex();

                let resultadoValidacao = validacao.validarDadosCarro(this.obterModelo(), this.obterValor());
  
                if(!resultadoValidacao){
                    _rota === rotaEditarCarro ? this.getView().byId(idDoMessageStripErroEditarCarro).setVisible(true)
                     : this.getView().byId(idDoMessageStripErroCriarCarro).setVisible(true);
                } 
                if(resultadoValidacao){
                    if(_rota === rotaEditarCarro){
                        const urlEditar = urlApi + idCarro;
                        const carro = {
                            "id": parseInt(idCarro),
                            "marca": marca,
                            "modelo": modelo,
                            "cor": cor,
                            "valorDoVeiculo": parseFloat(valor),
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
                            "valorDoVeiculo": parseFloat(valor),
                            "flex": flex
                        }
                        const metodo = "POST"
                        this._requisicaoHttp(urlApi, metodo, carro, idDoMessageStripSucessoCriacao, idDoMessageStripErroCriarCarro)
                    }
                }
            })
        },

        _mudarTituloDaViewEdicao() {
            this.getView().byId(idTituloViewCriarCarro).setText(textoParaAdicionarTituloEdicao);
        },
        
        _carregarDadosCarro(carro) {
            this.oView.byId(idDoInputModelo).setValue(carro.modelo);
            this.oView.byId(idDoInputValor).setValue(carro.valorDoVeiculo);
            this.oView.byId(idDoInputFlex).setState(carro.flex);
            this.oView.byId(idDoInputMarca).setSelectedKey(carro.marca);
            this.oView.byId(idDoInputCor).setSelectedKey(carro.cor);
        },
        
        _obterCarroPorId(oEvent) {
            idCarro = oEvent.getParameter(parametroArgumento).id;
            let query = urlApi + idCarro;
        
            fetch(query)
                .then(res => {
                    return res.json();
                })
                .then(carro => {
                    !carro.Detail ? this._carregarDadosCarro(carro)
                    : this._erroNaRequisicaoDaApi(carro);
                })
        },

        aoClicarBotaoVoltar() {
            this.processarEvento(() => {
                this.getRouter().navTo(rotaListagemCarros, {}, true);
            })
        }
    });
}, true);