sap.ui.define([
    "ui5/carro/app/common/BaseController",
    "sap/ui/model/json/JSONModel",
    "ui5/carro/model/formatter",
    "ui5/carro/model/validacao",
	"sap/m/MessageBox"

], function (BaseController, JSONModel, Formatter, validacao, MessageBox) {
    "use strict";

    var _rota;
    let idVenda;
    let idCarro;
    let dataEditar;
    const primeiroCarro = 0;
    const modeloCarro = "Carros";
    const parametroNome = "name";
    const idDoInputCpf = "InputCpf";
    const idDoTituloTela = "Title1";
    const idDoInputPago = "InputPago";
    const idDoInputNome = "InputNome";
    const idDoInputEmail = "InputEmail";
    const rotaEditar = "appEditarVenda";
    const rotaCriar = "appAdicionarVenda";
    const rotaViewListagem = "appListagem";
    const parametroArgumento = "arguments";
    const idDoInputTelefone = "InputTelefone";
    let urlVenda = "http://localhost:5071/api/Vendas/";
    const urlCarro = "http://localhost:5071/api/Carros/";
    const textoParaAdicionarTituloEdicao = "Editar Venda";
    const textoParaAdicionarTituloCriar = "Adicionar Venda";
    const idDoMessageStripErroCriarVenda = "erroCriarVenda";
    const idDoMessageStripErroEditarVenda = "erroEditarVenda";
    const idDoMessageStripSucessoEdicao = "sucessoAoEditarVenda";
    const idObjectStatusCarroNaoSelecionado = "selecioneUmCarro";
    const idDoMessageStripSucessoCriacao = "sucessoAoCriarVenda";
    const idDaTabelaCarrosDisponiveis = "TabelaCarrosDisponiveis";
    const recursoCarrosDisponiveus = urlCarro + "?Disponiveis=true";

    return BaseController.extend("ui5.carro.app.vendas.AdicionarVenda", {
        formatter: Formatter,

        onInit() {
            this.aoCoincidirRota();
        },

        aoCoincidirRota() {
            this.processarEvento(() => {
                var rota = this.getRouter();
                rota.getRoute(rotaEditar).attachMatched(this._carregarEventosEditar, this);

                rota.getRoute(rotaCriar).attachMatched(this._carregarEventosCriar, this);
            });
        },

        _carregarEventosEditar(oEvent) {
            this._mudarTituloDaViewEdicao();
            this._limparInputs();
            this._removerMessageStrip();
            this._obterVendaPorId(oEvent);
            var oRouter = this.getRouter();
            _rota = oRouter.getRoute(oEvent.getParameter(parametroNome))._oConfig.name;

        },

        _carregarEventosCriar(oEvent) {
            this._mudarTituloDaViewCriar();
            this._limparInputs();
            this._carregarCarros();
            this._removerMessageStrip();
            var oRouter = this.getRouter();
            _rota = oRouter.getRoute(oEvent.getParameter(parametroNome))._oConfig.name;
        },

        _limparInputs() {
            const inputs = [
                { id: idDoInputNome },
                { id: idDoInputCpf },
                { id: idDoInputEmail },
                { id: idDoInputTelefone },
                { id: idDoInputPago, isSwitch: true }
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
                idDoMessageStripErroCriarVenda,
                idDoMessageStripErroEditarVenda,
                idDoMessageStripSucessoCriacao,
                idDoMessageStripSucessoEdicao
            ];

            messageStripIds.forEach(id => {
                this.getView().byId(id).setVisible(false);
            })
        },

        _carregarCarros() {
            fetch(recursoCarrosDisponiveus)
                .then((res) => {
                    return res.json()
                })
                .then((carro) => {
                    const jsonModel = new JSONModel(carro)

                    !carro.Detail ? this.getView().setModel(jsonModel, modeloCarro)
                        : this._erroNaRequisicaoDaApi(carro);
                })
        },

        _mudarTituloDaViewCriar() {
            this.getView().byId(idDoTituloTela).setText(textoParaAdicionarTituloCriar);
        },

        obterNome() {
            const inputNome = this.oView.byId(idDoInputNome);
            return inputNome;
        },

        obterCpf() {
            const inputCpf = this.oView.byId(idDoInputCpf);
            return inputCpf;
        },

        obterTelefone() {
            const inputTelefone = this.oView.byId(idDoInputTelefone);
            return inputTelefone;
        },

        obterEmail() {
            const inputEmail = this.oView.byId(idDoInputEmail);
            return inputEmail;
        },

        obterStatusPagamento() {
            return this.oView.byId(idDoInputPago).getState();
        },

        aoClicarNoBotaoAdicionarDeveAdicionarVenda() {
            this.processarEvento(() => {
                    const nome = this.obterNome().getValue();
                    const cpf = this.obterCpf().getValue();
                    const email = this.obterEmail().getValue();
                    const telefone = this.obterTelefone().getValue();
                    const carroEscolhido = this._obterCarroSelecionado();
                    const pago = this.obterStatusPagamento();
                    const data = Date.now();

                    let resultadoValidacao = validacao.validarDados(this.obterNome(), this.obterCpf(), this.obterTelefone(), this.obterEmail());

                    if(!resultadoValidacao){
                        _rota === rotaCriar ? this.getView().byId(idDoMessageStripErroCriarVenda).setVisible(true)
                            : this.getView().byId(idDoMessageStripErroEditarVenda).setVisible(true);
                    }

                    if(resultadoValidacao && carroEscolhido){

                        if (_rota === rotaEditar) {
                            const urlEditar = urlVenda + idVenda;
                            const venda = {
                                "id": idVenda,
                                "nome": nome,
                                "cpf": cpf,
                                "email": email,
                                "telefone": telefone,
                                "idDoCarroVendido": carroEscolhido.id,
                                "dataDeCompra": dataEditar,
                                "valorTotal": carroEscolhido.valorDoVeiculo,
                                "pago": pago
                            }
                            const metodo = "PATCH"
                            this._requisicaoHttp(urlEditar, metodo, venda, idDoMessageStripSucessoEdicao, idDoMessageStripErroEditarVenda);
                        }
                        else {
                            const venda = {
                                "nome": nome,
                                "cpf": cpf,
                                "email": email,
                                "telefone": telefone,
                                "idDoCarroVendido": carroEscolhido.id,
                                "dataDeCompra": Formatter.formatarDataParaApi(data),
                                "valorTotal": carroEscolhido.valorDoVeiculo,
                                "pago": pago
                            }
                            const metodo = "POST"
                            this._requisicaoHttp(urlVenda, metodo, venda, idDoMessageStripSucessoCriacao, idDoMessageStripErroCriarVenda);
                        }
                    }

            })
        },

        _obterCarroSelecionado() {
            const estiverVazio = 0;
            const Tabela = this.getView().byId(idDaTabelaCarrosDisponiveis);
            const ListaComCarroSelecionado = Tabela.getSelectedItems();

            if (ListaComCarroSelecionado.length === estiverVazio) {
                this.oView.byId(idObjectStatusCarroNaoSelecionado).setVisible(true);
                return;
            }

            const CarroSelecionado = ListaComCarroSelecionado[primeiroCarro];
            const ContextoAssociado = CarroSelecionado.getBindingContext(modeloCarro);
            const Carro = ContextoAssociado.getObject();

            return Carro;

        },
        
        _mudarTituloDaViewEdicao() {
            this.getView().byId(idDoTituloTela).setText(textoParaAdicionarTituloEdicao);
        },   

        _obterVendaPorId(oEvent) {
            idVenda = oEvent.getParameter(parametroArgumento).id;
            let query = urlVenda + idVenda;

            fetch(query)
                .then(res => {
                    return res.json();
                })
                .then(venda => {
                    
                    if (!venda.Detail) {
                        let id = this._carregarDados(venda);
                        idCarro = id;
                        dataEditar = venda.dataDeCompra;
                        this._carregarCarrosEditar(idCarro);
                    }
                    else {
                        this._erroNaRequisicaoDaApi(venda);
                    }
                })
        },

        _carregarCarrosEditar(id) {
            let query = urlCarro + id;
            let carroEspecifico;

            fetch(recursoCarrosDisponiveus)
                .then(res => res.json())
                .then(data => {
                    this.getView().setModel(new JSONModel(data), modeloCarro);
                    return fetch(query);
                })
                .then(resp => resp.json())
                .then(carro => {
                    if (!carro.Detail){
                        carroEspecifico = carro;

                        const listaDeCarros = this.getView().getModel(modeloCarro).getData();
                        listaDeCarros.push(carroEspecifico);

                        this.getView().getModel(modeloCarro).setData(listaDeCarros);
                    }
                    else{
                        this._erroNaRequisicaoDaApi(carro);
                    }
                })
                .catch(err => { MessageBox.error(err); });
        },

        _carregarDados(venda) {
            this.oView.byId(idDoInputNome).setValue(venda.nome);
            this.oView.byId(idDoInputCpf).setValue(venda.cpf);
            this.oView.byId(idDoInputEmail).setValue(venda.email);
            this.oView.byId(idDoInputTelefone).setValue(venda.telefone);
            this.oView.byId(idDoInputPago).setState(venda.pago)

            return venda.idDoCarroVendido;
        },

        aoClicarBotaoVoltar() {
            this.processarEvento(() => {
                this.getRouter().navTo(rotaViewListagem, {}, true);
            })
        }
    });
}, true);