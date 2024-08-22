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
    const estiverVazio = 0;
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
    const textoParaAdicionarTituloEdicao = "Editar Venda";
    const textoParaAdicionarTituloCriar = "Adicionar Venda";
    const idDoMessageStripErroCriarVenda = "erroCriarVenda";
    const idDoMessageStripErroEditarVenda = "erroEditarVenda";
    const idDoMessageStripSucessoEdicao = "sucessoAoEditarVenda";
    const idObjectStatusCarroNaoSelecionado = "selecioneUmCarro";
    const idDoMessageStripSucessoCriacao = "sucessoAoCriarVenda";
    const idDaTabelaCarrosDisponiveis = "TabelaCarrosDisponiveis";
    const urlCarroObterPorId = "http://localhost:5071/api/Carros/";
    let urlCarrosDisponiveis = "http://localhost:5071/api/Carros/Disponiveis";

    return BaseController.extend("ui5.carro.app.vendas.AdicionarVenda", {
        formatter: Formatter,

        onInit() {
            this.aoCoincidirRota();
        },

        aoCoincidirRota() {
            this.processarEvento(() => {
                var rota = sap.ui.core.UIComponent.getRouterFor(this);
                rota.getRoute(rotaEditar).attachPatternMatched(this._carregarEventosEditar, this);

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
            const inputNome = this.oView.byId(idDoInputNome);
            const nome = inputNome.setValue(null);
            inputNome.setValueState(sap.ui.core.ValueState.None);
            inputNome.setValueStateText('');
            const inputCpf = this.oView.byId(idDoInputCpf);
            const cpf = inputCpf.setValue(null);
            inputCpf.setValueState(sap.ui.core.ValueState.None);
            inputCpf.setValueStateText('');
            const inputEmail = this.oView.byId(idDoInputEmail);
            const email = inputEmail.setValue(null);
            inputEmail.setValueState(sap.ui.core.ValueState.None);
            inputEmail.setValueStateText('');
            const inputTelefone = this.oView.byId(idDoInputTelefone);
            const telefone = inputTelefone.setValue(null);
            inputTelefone.setValueState(sap.ui.core.ValueState.None);
            inputTelefone.setValueStateText('');
            const pago = this.oView.byId(idDoInputPago).setState(false)
        },

        _removerMessageStrip(){
            this.getView().byId(idDoMessageStripSucessoCriacao).setVisible(false);
            this.getView().byId(idDoMessageStripErroCriarVenda).setVisible(false);
            this.getView().byId(idDoMessageStripSucessoEdicao).setVisible(false);
            this.getView().byId(idDoMessageStripErroEditarVenda).setVisible(false);
            this.oView.byId(idObjectStatusCarroNaoSelecionado).setVisible(false);
        },

        _carregarCarros() {
            let sucesso = true;
            fetch(urlCarrosDisponiveis)
                .then((res) => {
                    if (!res.ok) {
                        sucesso = false;
                    }
                    return res.json()
                })
                .then((carro) => {
                    const jsonModel = new JSONModel(carro)

                    sucesso ? this.getView().setModel(jsonModel, modeloCarro)
                        : this._erroNaRequisicaoDaApi(carro);
                })
                .catch((err) => MessageBox.error(err));
        },

        _mudarTituloDaViewCriar() {
            var Titulo = this.getView().byId(idDoTituloTela).setText(textoParaAdicionarTituloCriar);
            return Titulo;
        },

        aoColetarNome() {
            const inputNome = this.oView.byId(idDoInputNome);
            const nome = inputNome.getValue();
            validacao.validarNome(inputNome, nome);
            return nome;
        },

        aoColetarCpf() {
            const inputCpf = this.oView.byId(idDoInputCpf);
            const cpf = inputCpf.getValue();
            validacao.validarCpf(inputCpf, cpf);
            return cpf;
        },

        aoColetarTelefone() {
            const inputTelefone = this.oView.byId(idDoInputTelefone);
            const telefone = inputTelefone.getValue();
            validacao.validarTelefone(inputTelefone, telefone);
            return telefone;
        },

        aoColetarEmail() {
            const inputEmail = this.oView.byId(idDoInputEmail);
            const email = inputEmail.getValue();
            validacao.validarEmail(inputEmail, email);
            return email;
        },

        aoObterStatusPagamento() {
            const pago = this.oView.byId(idDoInputPago).getState();
            return pago;
        },

        aoClicarNoBotaoAdicionarDeveAdicionarVenda() {
            this.processarEvento(() => {
                    const nome = this.aoColetarNome();
                    const cpf = this.aoColetarCpf();
                    const email = this.aoColetarEmail();
                    const telefone = this.aoColetarTelefone();
                    const carroEscolhido = this._obterCarroSelecionado();
                    const pago = this.aoObterStatusPagamento();
                    const data = Date.now();

                    const inputNome = this.oView.byId(idDoInputNome);
                    const inputCpf = this.oView.byId(idDoInputCpf);
                    const inputTelefone = this.oView.byId(idDoInputTelefone);
                    const inputEmail = this.oView.byId(idDoInputEmail);

                    let validacaoDados = validacao.validarDados(inputNome, inputCpf, inputTelefone, inputEmail);

                    if(validacaoDados && carroEscolhido){

                        if (_rota === rotaEditar) {
                            const urlEditar = urlVenda + idVenda;
                            const venda = {
                                "id": idVenda,
                                "nome": nome,
                                "cpf": cpf,
                                "email": email,
                                "telefone": telefone,
                                "idDoCarroVendido": carroEscolhido.id,
                                "dataDeCompra": this._carregarDataDeCompraEditar(dataEditar),
                                "valorTotal": carroEscolhido.valorDoVeiculo,
                                "pago": pago
                            }
                            const metodo = "PATCH"
                            this._requisicaoHttp(urlEditar, metodo, venda, idDoMessageStripSucessoEdicao, idDoMessageStripErroEditarVenda);
                        }
                        else if (_rota === rotaCriar) {
                            const venda = {
                                "nome": this.aoColetarNome(),
                                "cpf": this.aoColetarCpf(),
                                "email": this.aoColetarEmail(),
                                "telefone": this.aoColetarTelefone(),
                                "idDoCarroVendido": carroEscolhido.id,
                                "dataDeCompra": Formatter.formatarDataParaApi(data),
                                "valorTotal": carroEscolhido.valorDoVeiculo,
                                "pago": this.aoObterStatusPagamento()
                            }
                            const metodo = "POST"
                            this._requisicaoHttp(urlVenda, metodo, venda, idDoMessageStripSucessoCriacao, idDoMessageStripErroCriarVenda);
                        }
                    }

            })
        },

        _requisicaoHttp(url, metodo, venda, idMessageSucesso, idMessageErro) {
            let sucesso = true;
            fetch(url, {
                method: metodo,
                body: JSON.stringify(venda),
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

        _obterCarroSelecionado() {
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
            var Titulo = this.getView().byId(idDoTituloTela).setText(textoParaAdicionarTituloEdicao);
            return Titulo;
        },   

        _obterVendaPorId(oEvent) {
            idVenda = oEvent.getParameter(parametroArgumento).id;
            let query = urlVenda + idVenda;
            let sucesso = true;

            fetch(query)
                .then(res => {
                    if (!res.ok) {
                        sucesso = false;
                    }
                    return res.json();
                })
                .then(venda => {
                    
                    if (sucesso) {
                        let id = this._carregarDados(venda);
                        idCarro = id;
                        const data = venda.dataDeCompra;
                        this._carregarDataDeCompraEditar(data);
                        this._carregarCarrosEditar(idCarro);
                    }
                    else {
                        this._erroNaRequisicaoDaApi(venda);
                    }
                })
                .catch(err => { MessageBox.error(err); });
        },

        _carregarDataDeCompraEditar(data) {
            dataEditar = data;
            return dataEditar;
        },

        _carregarCarrosEditar(id) {

            let query = urlCarroObterPorId + id;
            let carroEspecifico;

            fetch(urlCarrosDisponiveis)
                .then(res => res.json())
                .then(data => {
                    this.getView().setModel(new JSONModel(data), modeloCarro);
                    return fetch(query);
                })
                .then(resp => resp.json())
                .then(carro => {
                    carroEspecifico = carro;

                    const listaDeCarros = this.getView().getModel(modeloCarro).getData();
                    listaDeCarros.push(carroEspecifico);

                    this.getView().getModel(modeloCarro).setData(listaDeCarros);
                })
                .catch(err => { MessageBox.error(err); });
        },

        _carregarDados(venda) {
            const nome = this.oView.byId(idDoInputNome).setValue(venda.nome);
            const cpf = this.oView.byId(idDoInputCpf).setValue(venda.cpf);
            const email = this.oView.byId(idDoInputEmail).setValue(venda.email);
            const telefone = this.oView.byId(idDoInputTelefone).setValue(venda.telefone);
            const pago = this.oView.byId(idDoInputPago).setState(venda.pago)

            return venda.idDoCarroVendido;
        },

        aoClicarVoltarParaATelaDeListagem() {
            this.processarEvento(() => {
                var history;

                history = History.getInstance();
                this.getRouter().navTo(rotaViewListagem, {}, true);
            })
        }
    });
}, true);