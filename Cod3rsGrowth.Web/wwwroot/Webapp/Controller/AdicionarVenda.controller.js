sap.ui.define([
    "ui5/carro/controller/BaseController",
    "sap/ui/core/routing/History",
    "sap/ui/model/json/JSONModel",
    "ui5/carro/model/formatter",
    "ui5/carro/model/validacao",
	"sap/m/MessageBox"

], function (BaseController, History, JSONModel, Formatter, validacao, MessageBox) {
    "use strict";

    let idVenda;
    var _Rota;
    const estiverVazio = 0;
    const primeiroCarro = 0;
    const voltarUmaPagina = -1;
    const modeloCarro = "Carros"
    const modeloVenda = "Venda"
    const idDoInputCpf = "InputCpf"
    const idDoInputPago = "InputPago"
    const idDoInputNome = "InputNome"
    const idDoInputEmail = "InputEmail"
    const RotaCriar = "appAdicionarVenda"
    const idDoInputTelefone = "InputTelefone"
    const idDaTabelaCarrosDisponiveis = "TabelaCarrosDisponiveis"
    let urlCarrosDisponiveis = "http://localhost:5071/api/Carros/Disponiveis"
    let urlObterVendaPorId = "http://localhost:5071/api/Vendas/"
    const urlCarroObterPorId = "http://localhost:5071/api/Carros/"

    return BaseController.extend("ui5.carro.controller.AdicionarVenda", {
        formatter: Formatter,

        onInit() {
            this.aoCoincidirRota();
        },

        _carregarCarros() {
            fetch(urlCarrosDisponiveis)
                .then((res) => res.json())
                .then((data) => {
                    const jsonModel = new JSONModel(data)

                    this.getView().setModel(jsonModel, modeloCarro);
                })
                .catch((err) => MessageBox.error(err));
        },

        aoCoincidirRota() {
            this.processarEvento(() => {
                var rota = sap.ui.core.UIComponent.getRouterFor(this);
                rota.getRoute("appEditarVenda").attachPatternMatched(this._carregarEventosEditar, this);

                rota.getRoute(RotaCriar).attachMatched(this._carregarCarros, this);
            });
        },

        _carregarEventosEditar(oEvent) {
            this._mudarTituloDaView();
            this._obterVendaPorId(oEvent);
            var oRouter = this.getRouter();
            _Rota = oRouter.getRoute(oEvent.getParameter("name"))._oConfig.name;
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
                const url = "http://localhost:5071/api/Vendas/";
                const nome = this.aoColetarNome();
                const cpf = this.aoColetarCpf();
                const email = this.aoColetarEmail();
                const telefone = this.aoColetarTelefone();
                const carroEscolhido = this._obterCarroSelecionado();
                const pago = this.aoObterStatusPagamento();
                const data = Date.now();

                if (_Rota === "appEditarVenda") {
                    const urlEditar = url + idVenda;
                    const venda = {
                        "id": idVenda,
                        "nome": nome,
                        "cpf": cpf,
                        "email": email,
                        "telefone": telefone,
                        "idDoCarroVendido": carroEscolhido.id,
                        "valorTotal": carroEscolhido.valorDoVeiculo,
                        "pago": pago
                    }

                    const metodo = "PATCH"
                    this._requisicaoHTTP(metodo, urlEditar, venda)
                }
                else if (_Rota === RotaCriar) {
                    const venda = {
                        "nome": this.aoColetarNome(),
                        "cpf": this.aoColetarCpf(),
                        "email": this.aoColetarEmail(),
                        "telefone": this.aoColetarTelefone(),
                        "idDoCarroVendido": carroEscolhido.id,
                        "dataDeCompra": this.formatarData(data),
                        "valorTotal": carroEscolhido.valorDoVeiculo,
                        "pago": this.aoObterStatusPagamento()
                    }
                    const metodo = "POST"
                    this._requisicaoHTTP(metodo, url, venda)
                    this.getView().byId("sucessoAoCriarVenda").setVisible(true);

                }
                else {
                    this.getView().byId("erroAoCriarVenda").setVisible(true);

                }
            })
        },

        _requisicaoHTTP(metodo, url, venda) {
            fetch(url, {
                method: metodo,
                body: JSON.stringify(venda),
                headers: { "Content-type": "application/json; charset=UTF-8" }
            })
                .then(response => response.json())
                .then(json => console.log(json))
                .catch(err => console.log(err));
        },

        _obterCarroSelecionado() {
            const Tabela = this.getView().byId(idDaTabelaCarrosDisponiveis);
            const ListaComCarroSelecionado = Tabela.getSelectedItems();

            if (ListaComCarroSelecionado.length === estiverVazio) {
                this.getView().byId("erroSelecionarCarro").setVisible(true);
            }
            else {
                this.getView().byId("erroSelecionarCarro").setVisible(false);
            }

            const CarroSelecionado = ListaComCarroSelecionado[primeiroCarro];
            const ContextoAssociado = CarroSelecionado.getBindingContext(modeloCarro);
            const Carro = ContextoAssociado.getObject();

            return Carro;
        },
        
        _mudarTituloDaView(){
            var Titulo = this.getView().byId("Title1").setText("Editar Venda");

            return Titulo;
        },   

        _obterVendaPorId(oEvent) {
            idVenda = oEvent.getParameter("arguments").id;
            let query = urlObterVendaPorId + idVenda;
            fetch(query)
                .then(resp => resp.json())
                .then(venda => {

                    const id = this._carregarDados(venda)
                    this._carregarCarrosEditar(id)
                });
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
                .catch(err => {
                    MessageBox.error(err);
                });
        },

        _carregarDados(venda) {
            const nome = this.oView.byId(idDoInputNome).setValue(venda.nome);
            const cpf = this.oView.byId(idDoInputCpf).setValue(venda.cpf);
            const email = this.oView.byId(idDoInputEmail).setValue(venda.email);
            const telefone = this.oView.byId(idDoInputTelefone).setValue(venda.telefone);

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
                    this.getRouter().navTo("appListagem", {}, true);
                }
            })
        }
    });
}, true);