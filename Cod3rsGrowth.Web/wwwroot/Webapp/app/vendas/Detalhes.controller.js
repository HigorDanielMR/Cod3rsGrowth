sap.ui.define([
    "ui5/carro/app/common/BaseController",
    "ui5/carro/model/formatter",
    "sap/ui/core/routing/History",
    "sap/ui/model/json/JSONModel",
    "sap/m/MessageBox"

], function (BaseController, Formatter, History, JSONModel, MessageBox) {
    "use strict";

    let idCarro;
    let idVenda;
    const id = "id";
    const modeloVenda = "Venda";
    const modeloCarro = "Carro";
    const metodoDelete = "DELETE";
    const rotaDetalhe = "appDetalhes";
    const rotaListagem = "appListagem";
    const parametroArgumento = "arguments";
    const rotaEditarVenda = "appEditarVenda";
    const urlVenda = "http://localhost:5071/api/Vendas/";
    const urlCarro = "http://localhost:5071/api/Carros/";

    return BaseController.extend("ui5.carro.app.vendas.Detalhes", {
        formatter: Formatter,

        onInit() {
            this.aoCoincidirRota();
        },

        aoCoincidirRota() {
            this.processarEvento(() => {
                const rota = this.getOwnerComponent().getRouter();
                rota.getRoute(rotaDetalhe).attachMatched(this._obterVendaPorId, this);
            });
        },

        _obterVendaPorId(oEvent) {
            let idDesejado = oEvent.getParameter(parametroArgumento).id;
            let query = urlVenda + idDesejado;
            idVenda = idDesejado;
            let sucesso = true;
            fetch(query)
                .then((res) => {
                    if (!res.ok)
                        sucesso = false;
                    return res.json()
                })
                .then((venda) => {
                    if(sucesso){
                        const jsonModel = new JSONModel(venda)
                        let id = this._carregarIdCarro(venda);
                        idCarro = id;
                        this._carregarCarroAssociado(idCarro);
                        this.getView().setModel(jsonModel, modeloVenda);
                    } 
                    else this._erroNaRequisicaoDaApi(venda);
                });
        },

        aoClicarNoBotaoRemover() {
            const funcao = this;
            this.processarEvento(() =>{
                MessageBox.show(
                    `Deseja excluir a venda com ID ${idVenda} ?`,
                    {
                        icon: MessageBox.Icon.QUESTION,
                        title: "Confirmar remoção da venda",
                        actions: [MessageBox.Action.NO, MessageBox.Action.YES],
                        onClose(oAction) {
                            if (oAction === MessageBox.Action.YES) {
                                MessageBox.show(`Deseja excluir o carro com ID ${idCarro} ?`,
                                    {
                                        icon: MessageBox.Icon.QUESTION,
                                        title: "Confirmar remoção do carro",
                                        actions: [MessageBox.Action.NO, MessageBox.Action.YES],
                                        onClose(action) {
                                            if (action === MessageBox.Action.YES) {
                                                funcao._remover(urlVenda, metodoDelete, idVenda);
                                                funcao._remover(urlCarro, metodoDelete, idCarro);
                                                funcao.getRouter().navTo(rotaListagem, {}, true);
                                            } else {
                                                funcao._remover(urlVenda, metodoDelete, idVenda);
                                                funcao .getRouter().navTo(rotaListagem, {}, true);
                                            }
                                        }
                                    }
                                );
                            }
                        }
                    }
                );
            })
        },
        _remover(url, metodo, id){
            url += id;
            let sucesso = true;
            fetch(url, {
                method: metodo,
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json',
                    'Access-Control-Allow-Origin': '*'
                }
            })
                .then(res => {
                    if(!res.ok){
                        sucesso = false;
                    }
                    return res.json()
                }).then(data => {
                    if (!sucesso) {
                        this._erroNaRequisicaoDaApi(data);
                    }
                })
                .catch((err) => console.log(err));
        },

        _carregarCarroAssociado(id){
            let sucesso = true;
            let query = urlCarro + id;
            fetch(query)
                .then((res) => {
                    if (!res.ok) sucesso = false;
                    return res.json()
                })
                .then((carro) => {
                    const jsonModel = new JSONModel(carro)
                    sucesso ? this.getView().setModel(jsonModel, modeloCarro)
                        : this._erroNaRequisicaoDaApi(carro);
                });
        },
        
        _carregarIdCarro(venda) {
            return venda.idDoCarroVendido;
        },

        aoClicarVoltarParaTelaDeListagem() {
            this.processarEvento(() => {
                var history;
                history = History.getInstance();
                this.getRouter().navTo(rotaListagem, {}, true);
            })
        },

        aoClicarNoBotaoEditarDeveAbrirATelaDeModificarVenda(oEvent){
            this.processarEvento(() => {
                const oItem = oEvent.getSource();
                console.log(oItem);
                const oRouter = this.getOwnerComponent().getRouter();
                oRouter.navTo(rotaEditarVenda, {
                    id: window.encodeURIComponent(oItem.getBindingContext(modeloVenda).getProperty(id))
                });
            })
        }
    });
}, true);