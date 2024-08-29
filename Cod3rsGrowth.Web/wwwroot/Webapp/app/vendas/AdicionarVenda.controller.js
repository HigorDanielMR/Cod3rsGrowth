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
    const PRIMEIRO_CARRO = 0;
    const MODELO_CARRO = "Carros";
    const PARAMETRO_NOME = "name";
    const ID_DO_INPUT_CPF = "InputCpf";
    const ID_DO_TITULO_TELA = "Title1";
    const ID_DO_INPUT_PAGO = "InputPago";
    const ID_DO_INPUT_NOME = "InputNome";
    const ID_DO_INPUT_EMAIL = "InputEmail";
    const ROTA_EDITAR = "appEditarVenda";
    const ROTA_CRIAR = "appAdicionarVenda";
    const ROTA_VIEW_LISTAGEM = "appListagem";
    const PARAMETRO_ARGUMENTOS = "arguments";
    const ID_DO_INPUT_TELEFONE = "InputTelefone";
    let URL_VENDA = "http://localhost:5071/api/Vendas/";
    const URL_CARRO = "http://localhost:5071/api/Carros/";
    const TEXTO_PARA_ADICIONAR_TITULO_EDICAO = "Editar Venda";
    const TEXTO_PARA_ADICIONAR_TITULO_CRIAR = "Adicionar Venda";
    const ID_DO_MESSAGE_STRIP_ERRO_CRIAR_VENDA = "erroCriarVenda";
    const ID_DO_MESSAGE_STRIP_ERRO_EDITAR_VENDA = "erroEditarVenda";
    const ID_DO_MESSAGE_STRIP_SUCESSO_EDICAO = "sucessoAoEditarVenda";
    const ID_OBJECT_STATUS_CARRO_NAO_SELECIONADO = "selecioneUmCarro";
    const ID_DO_MESSAGE_STRIP_SUCESSO_CRIACAO = "sucessoAoCriarVenda";
    const ID_DA_TABELA_CARROS_DISPONIVEIS = "TabelaCarrosDisponiveis";
    const RECURSO_CARROS_DISPONIVEIS = URL_CARRO + "?Disponiveis=true";

    return BaseController.extend("ui5.carro.app.vendas.AdicionarVenda", {
        formatter: Formatter,

        onInit() {
            this.aoCoincidirRota();
        },

        aoCoincidirRota() {
            this.processarEvento(() => {
                var rota = this.getRouter();
                rota.getRoute(ROTA_EDITAR).attachMatched(this._carregarEventosEditar, this);

                rota.getRoute(ROTA_CRIAR).attachMatched(this._carregarEventosCriar, this);
            });
        },

        _carregarEventosEditar(oEvent) {
            this._mudarTituloDaVIEW_EDICAO();
            this._limparInputs();
            this._removerMessageStrip();
            this._obterVendaPorId(oEvent);
            var oRouter = this.getRouter();
            _rota = oRouter.getRoute(oEvent.getParameter(PARAMETRO_NOME))._oConfig.name;

        },

        _carregarEventosCriar(oEvent) {
            this._mudarTituloDaViewCriar();
            this._limparInputs();
            this._carregarCarros();
            this._removerMessageStrip();
            var oRouter = this.getRouter();
            _rota = oRouter.getRoute(oEvent.getParameter(PARAMETRO_NOME))._oConfig.name;
        },

        _limparInputs() {
            const inputs = [
                { id: ID_DO_INPUT_NOME },
                { id: ID_DO_INPUT_CPF },
                { id: ID_DO_INPUT_EMAIL },
                { id: ID_DO_INPUT_TELEFONE },
                { id: ID_DO_INPUT_PAGO, ehSwitch: true }
            ];

            inputs.forEach(input => {
                const elemento = this.oView.byId(input.id);
                if (input.ehSwitch) {
                    elemento.setState(false);
                } else {
                    elemento.setValue(null);
                    elemento.setValueState(sap.ui.core.ValueState.None);
                    elemento.setValueStateText('');
                }
            });
        },


        _removerMessageStrip(){
            const messageStripIds = [
                ID_DO_MESSAGE_STRIP_ERRO_CRIAR_VENDA,
                ID_DO_MESSAGE_STRIP_ERRO_EDITAR_VENDA,
                ID_DO_MESSAGE_STRIP_SUCESSO_CRIACAO,
                ID_DO_MESSAGE_STRIP_SUCESSO_EDICAO
            ];

            messageStripIds.forEach(id => {
                this.getView().byId(id).setVisible(false);
            })
        },

        _carregarCarros() {
            fetch(RECURSO_CARROS_DISPONIVEIS)
                .then((res) => {
                    return res.json()
                })
                .then((carro) => {
                    const jsonModel = new JSONModel(carro)

                    !carro.Detail ? this.getView().setModel(jsonModel, MODELO_CARRO)
                        : this._erroNaRequisicaoDaApi(carro);
                })
        },

        _mudarTituloDaViewCriar() {
            this.getView().byId(ID_DO_TITULO_TELA).setText(TEXTO_PARA_ADICIONAR_TITULO_CRIAR);
        },

        obterNome() {
            const inputNome = this.oView.byId(ID_DO_INPUT_NOME);
            return inputNome;
        },

        obterCpf() {
            const inputCpf = this.oView.byId(ID_DO_INPUT_CPF);
            return inputCpf;
        },

        obterTelefone() {
            const inputTelefone = this.oView.byId(ID_DO_INPUT_TELEFONE);
            return inputTelefone;
        },

        obterEmail() {
            const inputEmail = this.oView.byId(ID_DO_INPUT_EMAIL);
            return inputEmail;
        },

        obterStatusPagamento() {
            return this.oView.byId(ID_DO_INPUT_PAGO).getState();
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
                        _rota === ROTA_CRIAR ? this.getView().byId(ID_DO_MESSAGE_STRIP_ERRO_CRIAR_VENDA).setVisible(true)
                            : this.getView().byId(ID_DO_MESSAGE_STRIP_ERRO_EDITAR_VENDA).setVisible(true);
                    }

                    if(resultadoValidacao && carroEscolhido){

                        if (_rota === ROTA_EDITAR) {
                            const urlEditar = URL_VENDA + idVenda;
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
                            this._requisicaoHttp(urlEditar, metodo, venda, ID_DO_MESSAGE_STRIP_SUCESSO_EDICAO, ID_DO_MESSAGE_STRIP_ERRO_EDITAR_VENDA);
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
                            this._requisicaoHttp(URL_VENDA, metodo, venda, ID_DO_MESSAGE_STRIP_SUCESSO_CRIACAO, ID_DO_MESSAGE_STRIP_ERRO_CRIAR_VENDA);
                        }
                    }

            })
        },

        _obterCarroSelecionado() {
            const estiverVazio = 0;
            const Tabela = this.getView().byId(ID_DA_TABELA_CARROS_DISPONIVEIS);
            const ListaComCarroSelecionado = Tabela.getSelectedItems();

            if (ListaComCarroSelecionado.length === estiverVazio) {
                this.oView.byId(ID_OBJECT_STATUS_CARRO_NAO_SELECIONADO).setVisible(true);
                return;
            }

            const CarroSelecionado = ListaComCarroSelecionado[PRIMEIRO_CARRO];
            const ContextoAssociado = CarroSelecionado.getBindingContext(MODELO_CARRO);
            const Carro = ContextoAssociado.getObject();

            return Carro;

        },
        
        _mudarTituloDaVIEW_EDICAO() {
            this.getView().byId(ID_DO_TITULO_TELA).setText(TEXTO_PARA_ADICIONAR_TITULO_EDICAO);
        },   

        _obterVendaPorId(oEvent) {
            idVenda = oEvent.getParameter(PARAMETRO_ARGUMENTOS).id;
            let query = URL_VENDA + idVenda;

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
            let query = URL_CARRO + id;

            fetch(RECURSO_CARROS_DISPONIVEIS)
                .then(res => res.json())
                .then(data => {
                    this.getView().setModel(new JSONModel(data), MODELO_CARRO);
                    return fetch(query);
                })
                .then(resp => resp.json())
                .then(carro => {
                    if (!carro.Detail){
                        const listaDeCarros = this.getView().getModel(MODELO_CARRO).getData();
                        listaDeCarros.push(carro);

                        this.getView().getModel(MODELO_CARRO).setData(listaDeCarros);
                    }
                    else{
                        this._erroNaRequisicaoDaApi(carro);
                    }
                })
        },

        _carregarDados(venda) {
            this.oView.byId(ID_DO_INPUT_NOME).setValue(venda.nome);
            this.oView.byId(ID_DO_INPUT_CPF).setValue(venda.cpf);
            this.oView.byId(ID_DO_INPUT_EMAIL).setValue(venda.email);
            this.oView.byId(ID_DO_INPUT_TELEFONE).setValue(venda.telefone);
            this.oView.byId(ID_DO_INPUT_PAGO).setState(venda.pago)

            return venda.idDoCarroVendido;
        },

        aoClicarBotaoVoltar() {
            this.processarEvento(() => {
                this.getRouter().navTo(ROTA_VIEW_LISTAGEM, {}, true);
            })
        }
    });
}, true);