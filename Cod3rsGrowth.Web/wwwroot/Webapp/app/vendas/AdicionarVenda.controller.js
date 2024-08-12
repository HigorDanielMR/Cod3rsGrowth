sap.ui.define([
    "ui5/carro/app/common/BaseController",
    "sap/ui/core/routing/History",
    "sap/ui/model/json/JSONModel",
    "ui5/carro/model/formatter",
    "ui5/carro/model/validacao",
	"sap/m/MessageBox"

], function (BaseController, History, JSONModel, Formatter, validacao, MessageBox) {
    "use strict";

    let idVenda;
    var _Rota;
    let dataEditar;
    let idCarro;
    const estiverVazio = 0;
    const primeiroCarro = 0;
    const voltarUmaPagina = -1;
    const modeloCarro = "Carros";
    const modeloVenda = "Venda";
    const ParametroNome = "name";
    const idDoInputCpf = "InputCpf";
    const idDoTituloTela = "Title1";
    const idDoInputPago = "InputPago";
    const idDoInputNome = "InputNome";
    const idDoInputEmail = "InputEmail";
    const RotaEditar = "appEditarVenda";
    const RotaCriar = "appAdicionarVenda";
    const RotaViewListagem = "appListagem";
    const ParametroArgumento = "arguments";
    const idDoInputTelefone = "InputTelefone";
    const TextoParaAdicionarTituloEdicao = "Editar Venda";
    const TextoParaAdicionarTituloCriar = "Adicionar Venda";
    const idDoMessageStripSucessoEdicao = "sucessoAoEditarVenda";
    const idDoMessageStripSucessoCriacao = "sucessoAoCriarVenda";
    let urlObterVendaPorId = "http://localhost:5071/api/Vendas/";
    const idDaTabelaCarrosDisponiveis = "TabelaCarrosDisponiveis";
    const urlCarroObterPorId = "http://localhost:5071/api/Carros/";
    const idDoMessageStripErroSelecionarCarro = "erroSelecionarCarro";
    let urlCarrosDisponiveis = "http://localhost:5071/api/Carros/Disponiveis";

    return BaseController.extend("ui5.carro.app.vendas.AdicionarVenda", {
        formatter: Formatter,

        onInit() {
            this.aoCoincidirRota();
        },

        aoCoincidirRota() {
            this.processarEvento(() => {
                var rota = sap.ui.core.UIComponent.getRouterFor(this);
                rota.getRoute(RotaEditar).attachPatternMatched(this._carregarEventosEditar, this);

                rota.getRoute(RotaCriar).attachMatched(this._carregarEventosCriar, this);
            });
        },

        _carregarEventosEditar(oEvent) {
            var oRouter = this.getRouter();
            _Rota = oRouter.getRoute(oEvent.getParameter(ParametroNome))._oConfig.name;
            this._obterVendaPorId(oEvent);
            this._mudarTituloDaViewEdicao();
            this.getView().byId(idDoMessageStripSucessoEdicao).setVisible(false);

        },

        _carregarEventosCriar(oEvent) {
            this._mudarTituloDaViewCriar();
            this._limparInput();
            this._carregarCarros();
            var oRouter = this.getRouter();
            _Rota = oRouter.getRoute(oEvent.getParameter(ParametroNome))._oConfig.name;
        },

        _limparInput() {
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
            const pago = this.oView.byId(idDoInputPago).setSelected(false)
            this.getView().byId(idDoMessageStripSucessoCriacao).setVisible(false);
            this.getView().byId(idDoMessageStripErroSelecionarCarro).setVisible(false);
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
            var Titulo = this.getView().byId(idDoTituloTela).setText(TextoParaAdicionarTituloCriar);
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
            const pago = this.oView.byId(idDoInputPago).getSelected();
            return pago;
        },

        aoClicarNoBotaoAdicionarDeveAdicionarVenda() {
            this.processarEvento(() => {
                let sucesso = true;
                const url = "http://localhost:5071/api/Vendas/";
                const nome = this.aoColetarNome();
                const cpf = this.aoColetarCpf();
                const email = this.aoColetarEmail();
                const telefone = this.aoColetarTelefone();
                const carroEscolhido = this._obterCarroSelecionado();
                const pago = this.aoObterStatusPagamento();
                const data = Date.now();

                if (_Rota === RotaEditar) {
                    const urlEditar = url + idVenda;
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

                    fetch(urlEditar, {
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
                            if (!sucesso) this._erroNaRequisicaoDaApi(data);
                        })
                        .catch(err => { MessageBox.error(err); });

                    this.getView().byId(idDoMessageStripSucessoEdicao).setVisible(true);
                }
                else if (_Rota === RotaCriar) {
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
                            if (!sucesso) this._erroNaRequisicaoDaApi(data);
                        })
                        .catch(err => { MessageBox.error(err); });
                    this.getView().byId(idDoMessageStripSucessoCriacao).setVisible(true);
                }
            })
        },

        _obterDescricaoCor() {
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

        _obterDescricaoMarca() {
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

        _obterCarroSelecionado() {
            const Tabela = this.getView().byId(idDaTabelaCarrosDisponiveis);
            const ListaComCarroSelecionado = Tabela.getSelectedItems();

            if (ListaComCarroSelecionado.length === estiverVazio) {
                this.getView().byId(idDoMessageStripErroSelecionarCarro).setVisible(true);
                throw new Error('Carro não selecionado');
            }
            else {
                this.getView().byId(idDoMessageStripErroSelecionarCarro).setVisible(false);
            }

            const CarroSelecionado = ListaComCarroSelecionado[primeiroCarro];
            const ContextoAssociado = CarroSelecionado.getBindingContext(modeloCarro);
            const Carro = ContextoAssociado.getObject();

            return Carro;
        },
        
        _mudarTituloDaViewEdicao() {
            var Titulo = this.getView().byId(idDoTituloTela).setText(TextoParaAdicionarTituloEdicao);
            return Titulo;
        },   

        _obterVendaPorId(oEvent) {
            idVenda = oEvent.getParameter(ParametroArgumento).id;
            let query = urlObterVendaPorId + idVenda;
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
            const pago = this.oView.byId(idDoInputPago).setSelected(venda.pago)

            return venda.idDoCarroVendido;
        },

        aoClicarDeveVoltarParaATelaDeListagem() {
            this.processarEvento(() => {
                var history, previousHash;

                history = History.getInstance();
                previousHash = history.getPreviousHash();

                if (previousHash !== undefined) {
                    window.history.go(voltarUmaPagina);
                } else {
                    this.getRouter().navTo(RotaViewListagem, {}, true);
                }
            })
        }
    });
}, true);