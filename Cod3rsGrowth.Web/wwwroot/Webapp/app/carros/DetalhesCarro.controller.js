sap.ui.define([
    "ui5/carro/app/common/BaseController",
    "ui5/carro/model/formatter",
    "sap/ui/core/routing/History",
    "sap/ui/model/json/JSONModel",
    "sap/m/MessageBox"

], function (BaseController, Formatter, History, JSONModel, MessageBox) {
    "use strict";

    let idCarro;
    let sucessoRemover = true;
    const modeloCarro = "Carro";
    const metodoDelete = "DELETE";
    const rotaDetalhe = "appDetalhesCarro";
    const parametroArgumento = "arguments";
    const rotaEditarCarro = "appEditarCarro";
    const rotaListagemCarros = "appListagemCarro";
    const urlCarro = "http://localhost:5071/api/Carros/";

    return BaseController.extend("ui5.carro.app.carros.DetalhesCarro", {
        formatter: Formatter,

        onInit() {
            this.aoCoincidirRota();
        },

        aoCoincidirRota() {
            this.processarEvento(() => {
                const rota = this.getOwnerComponent().getRouter();
                rota.getRoute(rotaDetalhe).attachMatched(this._carregarCarro, this);
            });
        },

        _carregarEventos(oEvent) {
            this._carregarCarro(oEvent);
        },

        _carregarCarro(oEvent) {
            let idDesejado = oEvent.getParameter(parametroArgumento).id;
            idCarro = idDesejado;
            let query = urlCarro + idDesejado;
            let sucesso = true;
            fetch(query)
                .then((res) => {
                    if (!res.ok)
                        sucesso = false;
                    return res.json()
                })
                .then((carro) => {
                    if (sucesso) {
                        const jsonModel = new JSONModel(carro)
                        this.getView().setModel(jsonModel, modeloCarro);
                    }
                    else this._erroNaRequisicaoDaApi(carro);
                });

        },

        aoClicarNoBotaoRemoverCarro() {
            const funcao = this;
            this.processarEvento(() => {
                MessageBox.information(`Deseja excluir o carro com ID ${idCarro} ?`,
                    {
                        title: "Remover carro",
                        actions: [MessageBox.Action.NO, MessageBox.Action.YES],
                        onClose(action) {
                            if (action === MessageBox.Action.YES) {
                                funcao._remover(urlCarro, metodoDelete, idCarro);
                            }
                        }
                    }
                );
            })
        },

        _remover(url, metodo, id) { debugger
            this.processarEvento(() => {
                url += id
                fetch(url, {
                    method: metodo,
                    headers: {
                        'Content-Type': 'application/json'
                    }
                })
                    .then(res => {
                        return res.ok ? this._sucessoAoRemover()
                            :  res.json()

                    }).then(data => {
                        if (data) this._erroNaRequisicaoDaApi(data);
                    });
            })
        },

        _sucessoAoRemover(){
            const funcao = this;
            MessageBox.success("Carro removido com sucesso!", {
                actions: ["Ok"],
                title: "Sucesso",
                onClose(){
                    funcao.getRouter().navTo(rotaListagemCarros, {}, true);
                }
            });
        },

        aoClicarVoltarParaTelaDeListagem() {
            this.processarEvento(() => {
                var history;
                history = History.getInstance();
                this.getRouter().navTo(rotaListagemCarros, {}, true);
            })
        },
        
        aoClicarNoBotaoEditar(oEvent){
            this.processarEvento(() =>{
                const oItem = oEvent.getSource();
                const oRouter = this.getOwnerComponent().getRouter();
                oRouter.navTo(rotaEditarCarro, {
                    id: oItem._getPropertiesToPropagate().oModels.Carro.oData.id
                });
            })
        }
    });
}, true);