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

    var _rota;
    let idVenda;
    let idCarro;
    let dataEditar;
    const modeloCores = "Cores";
    const modeloMarcas = "Marcas";
    const rotaListagemCarros = "appListagemCarro";
    const estiverVazio = 0;
    const primeiroCarro = 0;
    const modeloCarro = "Carros";
    const parametroNome = "name";
    const idDoInputCpf = "InputCpf";
    const idDoTituloTela = "Title1";
    const idDoInputFlex = "InputFlex";
    const idDoInputModelo = "InputModelo";
    const idDoInputValor = "InputValor";
    const idDoInputMarca = "SelecionarMarca";
    const idDoInputCor = "SelecionarCor"
    const idDoInputEmail = "InputEmail";
    const rotaEditar = "appEditarVenda";
    const rotaCriarCarro = "appAdicionarCarro";
    const rotaViewListagem = "appListagem";
    const parametroArgumento = "arguments";
    const idDoInputTelefone = "InputTelefone";
    const textoParaAdicionarTituloEdicao = "Editar Venda";
    const textoParaAdicionarTituloCriar = "Adicionar Venda";
    const idDoMessageStripErroCriarCarro = "erroCriarCarro";
    const idDoMessageStripSucessoEdicao = "sucessoAoEditarVenda";
    const idObjectStatusCarroNaoSelecionado = "selecioneUmCarro";
    const idDoMessageStripSucessoCriacao = "sucessoAoCriarCarro";
    let urlObterVendaPorId = "http://localhost:5071/api/Vendas/";
    const idDaTabelaCarrosDisponiveis = "TabelaCarrosDisponiveis";
    const url= "http://localhost:5071/api/Carros/";

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
            const urlCores = "http://localhost:5071/api/Carros/Cores";
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
                .catch((err) => console.error(err));
        },

        _carregarDescricaoMarcas(){
            let sucesso = true;
            const urlMarcas = "http://localhost:5071/api/Carros/Marcas";
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
                .catch((err) => console.error(err));
        },

        aoColetarValorDoVeiculo(){
            var inputValor = this.oView.byId(idDoInputValor);
            var valor = inputValor.getValue();
            return parseInt(valor);
        },

        aoColetarModelo() {
            const inputModelo = this.oView.byId(idDoInputModelo);
            const modelo = inputModelo.getValue();
            return modelo;
        },

        aoColetarMarca(){
            const marca = this.oView.byId(idDoInputMarca).getSelectedKey();
            return marca;
        },
        
        aoColetarCor(){
            const cor = this.oView.byId(idDoInputCor).getSelectedKey();
            return cor;
        },

        aoObterSeEhFlex() {
            const pago = this.oView.byId(idDoInputFlex).getState();
            return pago;
        },

        aoClicarNoBotaoAdicionarDeveCriarCarro() {
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
                    this._requisicaoHttp(url, metodo, carro, idDoMessageStripSucessoCriacao, idDoMessageStripErroCriarCarro);
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
                    return res.json();
                })
                .then(data => {
                    if (!sucesso) {
                        this._erroNaRequisicaoDaApi(data);
                        this.getView().byId(idMessageErro).setVisible(true);
                    }
                    else {
                        this.getView().byId(idMessageSucesso).setVisible(true);
                    }
                })
                .catch(err => { MessageBox.error(err); });
        },

        aoClicarDeveVoltarParaATelaDeListagem() {
            this.processarEvento(() => {
                var history;

                history = History.getInstance();
                this.getRouter().navTo(rotaListagemCarros, {}, true);
            })
        }
    });
}, true);