sap.ui.define([
    "ui5/carro/app/common/BaseController",
    "sap/ui/model/json/JSONModel",
    "ui5/carro/model/formatter",
    "ui5/carro/model/validacao"

], function (BaseController, JSONModel, Formatter, validacao) {
    "use strict";

    const URL_API= "http://localhost:5071/api/Carros/";

    let _rota;
    let idCarro;
    const MODELO_CORES = "Cores";
    const PARAMETRO_NOME = "name";
    const MODELO_MARCAS = "Marcas";
    const ID_DO_INPUT_FLEX = "InputFlex";
    const ID_DO_INPUT_VALOR = "InputValor";
    const ID_DO_INPUT_COR = "SelecionarCor";
    const ID_DO_INPUT_MODELO = "InputModelo";
    const RECURSOS_CORES = URL_API + "Cores";
    const PARAMETRO_ARGUMENTOS = "arguments";
    const RECURSOS_MARCAS = URL_API + "Marcas";
    const ID_DO_INPUT_MARCA = "SelecionarMarca";
    const ROTA_EDITAR_CARRO = "appEditarCarro";
    const ROTA_CRIAR_CARRO = "appAdicionarCarro";
    const ROTA_LISTAGEM_CARROS = "appListagemCarro";
    const ID_TITULO_VIEW_CRIAR_CARRO = "TituloEditarCarro";
    const TEXTO_PARA_ADICIONAR_TITULO_EDICAO = "Editar Carro";
    const TEXTO_PARA_ADICIONAR_TITULO_CRIACAO = "Adicionar Carro";
    const ID_DO_MESSAGE_STRIP_ERRO_CRIAR_CARRO = "erroAoCriarCarro";
    const ID_DO_MESSAGE_STRIP_ERRO_EDITAR_CARRO = "erroAoEditarCarro";
    const ID_DO_MESSAGE_STRIP_SUCESSO_CRIACAO = "sucessoAoCriarCarro";
    const ID_DO_MESSAGE_STRIP_SUCESSO_EDITAR = "sucessoAoEditarCarro";

    return BaseController.extend("ui5.carro.app.carros.AdicionarCarro", {
        formatter: Formatter,

        onInit() {
            this.aoCoincidirRota();
        },

        aoCoincidirRota() {
            this.processarEvento(() => {
                var rota = this.getRouter();
                rota.getRoute(ROTA_CRIAR_CARRO).attachMatched(this._carregarEventosCriar, this);
                rota.getRoute(ROTA_EDITAR_CARRO).attachMatched(this._carregarEventodEditar, this);
            });
        },

        _carregarEventodEditar(oEvent) {
            this._mudarTituloDaVIEW_EDICAO();
            this._removerMessageStrip();
            this._limparInputs();
            this._obterCarroPorId(oEvent);
            this._carregarDescricaoCores();
            this._carregarDescricaoMarcas();
            var oRouter = this.getRouter();
            _rota = oRouter.getRoute(oEvent.getParameter(PARAMETRO_NOME))._oConfig.name;
        },

        _carregarEventosCriar(oEvent) {
            this._mudarTituloDaViewCriar();
            this._limparInputs();
            this._removerMessageStrip();
            this._carregarDescricaoCores();
            this._carregarDescricaoMarcas();
            var oRouter = this.getRouter();
            _rota = oRouter.getRoute(oEvent.getParameter(PARAMETRO_NOME))._oConfig.name;
        },

        _limparInputs() {
            const inputs = [
                { id: ID_DO_INPUT_MODELO },
                { id: ID_DO_INPUT_VALOR },
                { id: ID_DO_INPUT_MARCA },
                { id: ID_DO_INPUT_COR },
                { id: ID_DO_INPUT_FLEX, isSwitch: true }
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
                ID_DO_MESSAGE_STRIP_ERRO_CRIAR_CARRO,
                ID_DO_MESSAGE_STRIP_ERRO_EDITAR_CARRO,
                ID_DO_MESSAGE_STRIP_SUCESSO_CRIACAO,
                ID_DO_MESSAGE_STRIP_SUCESSO_EDITAR
            ];

            messageStripIds.forEach(id => {
                this.getView().byId(id).setVisible(false);
            })
        },

        _carregarDescricaoCores(){
            fetch(RECURSOS_CORES)
                .then((res) => {
                    return res.json()
                })
                .then((data) => {
                    if (!data.Detail) {
                        const cores = data.map((item) => ({ text: item }));
                        this.getView().setModel(new JSONModel({
                            descricao: cores
                        }), MODELO_CORES);
                    } else {
                        this._erroNaRequisicaoDaApi(data);
                    }
                })
        },

        _carregarDescricaoMarcas(){
            fetch(RECURSOS_MARCAS)
                .then((res) => {
                    return res.json();
                })
                .then((data) => {
                    if (!data.Detail) {
                        const marcas = data.map((item) => ({ text: item }));
                        this.getView().setModel(new JSONModel({
                            descricao: marcas
                        }), MODELO_MARCAS);
                    } else {
                        this._erroNaRequisicaoDaApi(data);
                    }
                })
        },

        _mudarTituloDaViewCriar() {
            this.getView().byId(ID_TITULO_VIEW_CRIAR_CARRO).setText(TEXTO_PARA_ADICIONAR_TITULO_CRIACAO);
        },

        obterValor(){
            var inputValor = this.oView.byId(ID_DO_INPUT_VALOR);
            return inputValor;
        },
        
        obterModelo() {
            const inputModelo = this.oView.byId(ID_DO_INPUT_MODELO);
            return inputModelo;
        },

        obterMarca(){
            return parseInt(this.oView.byId(ID_DO_INPUT_MARCA).getSelectedKey());
        },
        
        obterCor(){
            return parseInt(this.oView.byId(ID_DO_INPUT_COR).getSelectedKey());
        },

        obterFlex() {
            return this.oView.byId(ID_DO_INPUT_FLEX).getState();
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
                    _rota === ROTA_EDITAR_CARRO ? this.getView().byId(ID_DO_MESSAGE_STRIP_ERRO_EDITAR_CARRO).setVisible(true)
                     : this.getView().byId(ID_DO_MESSAGE_STRIP_ERRO_CRIAR_CARRO).setVisible(true);
                } 
                if(resultadoValidacao){
                    if(_rota === ROTA_EDITAR_CARRO){
                        const urlEditar = URL_API + idCarro;
                        const carro = {
                            "id": parseInt(idCarro),
                            "marca": marca,
                            "modelo": modelo,
                            "cor": cor,
                            "valorDoVeiculo": parseFloat(valor),
                            "flex": flex
                        }
                        const metodo = "PATCH"
                        this._requisicaoHttp(urlEditar, metodo, carro, ID_DO_MESSAGE_STRIP_SUCESSO_EDITAR, ID_DO_MESSAGE_STRIP_ERRO_EDITAR_CARRO)
                    }
                    if(_rota === ROTA_CRIAR_CARRO){
                        const carro = {
                            "marca": marca,
                            "modelo": modelo,
                            "cor": cor,
                            "valorDoVeiculo": parseFloat(valor),
                            "flex": flex
                        }
                        const metodo = "POST"
                        this._requisicaoHttp(URL_API, metodo, carro, ID_DO_MESSAGE_STRIP_SUCESSO_CRIACAO, ID_DO_MESSAGE_STRIP_ERRO_CRIAR_CARRO)
                    }
                }
            })
        },

        _mudarTituloDaVIEW_EDICAO() {
            this.getView().byId(ID_TITULO_VIEW_CRIAR_CARRO).setText(TEXTO_PARA_ADICIONAR_TITULO_EDICAO);
        },
        
        _carregarDadosCarro(carro) {
            this.oView.byId(ID_DO_INPUT_MODELO).setValue(carro.modelo);
            this.oView.byId(ID_DO_INPUT_VALOR).setValue(carro.valorDoVeiculo);
            this.oView.byId(ID_DO_INPUT_FLEX).setState(carro.flex);
            this.oView.byId(ID_DO_INPUT_MARCA).setSelectedKey(carro.marca);
            this.oView.byId(ID_DO_INPUT_COR).setSelectedKey(carro.cor);
        },
        
        _obterCarroPorId(oEvent) {
            idCarro = oEvent.getParameter(PARAMETRO_ARGUMENTOS).id;
            let query = URL_API + idCarro;
        
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
                this.getRouter().navTo(ROTA_LISTAGEM_CARROS, {}, true);
            })
        }
    });
}, true);