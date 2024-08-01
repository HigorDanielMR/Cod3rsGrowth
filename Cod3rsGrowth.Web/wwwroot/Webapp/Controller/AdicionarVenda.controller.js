sap.ui.define([
    "ui5/carro/controller/BaseController",
    "sap/ui/core/routing/History",
    "sap/ui/model/json/JSONModel",
    "ui5/carro/model/formatter",
    "ui5/carro/model/validacao",
	"sap/m/MessageBox"

], function (BaseController, History, JSONModel, Formatter, validacao, MessageBox) {
    "use strict";

    const estiverVazio = 0;
    const primeiroCarro = 0;
    const modeloCarro = "Carros"
    const idDoInputCpf = "InputCpf"
    const idDoInputPago = "InputPago"
    const idDoInputNome = "InputNome"
    const idDoInputEmail = "InputEmail"
    const RotaCriar = "appAdicionarVenda"
    const idDoInputTelefone = "InputTelefone"
    const idDaTabelaCarrosDisponiveis = "TabelaCarrosDisponiveis"
    let urlCarro = "http://localhost:5071/api/Carros/Disponiveis"


    return BaseController.extend("ui5.carro.controller.AdicionarVenda", {
        formatter: Formatter,

        onInit() {
            this.aoCoincidirRota();
        },

        _carregarCarros() {
            fetch(urlCarro)
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
                rota.getRoute(RotaCriar).attachMatched(this._carregarCarros, this);
            });
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
                const urlPost = "http://localhost:5071/api/Vendas/";
                const carroEscolhido = this._obterCarroSelecionado();
                const data = Date.now();

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

                fetch(urlPost, {
                    method: "POST",
                    body: JSON.stringify(venda),
                    headers: { "Content-type": "application/json; charset=UTF-8" }
                })
                    .then(response => response.json())
                    .then(json => console.log(json))
                    .catch(err => console.log(err));

                this.getView().byId("sucessoAoCriarVenda").setVisible(true);
            })
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