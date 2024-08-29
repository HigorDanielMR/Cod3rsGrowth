sap.ui.define([
    "ui5/carro/app/common/BaseController",
    "ui5/carro/model/formatter",
    "sap/ui/model/json/JSONModel",
    "sap/m/MessageBox"

], function (BaseController, Formatter, JSONModel, MessageBox) {
    "use strict";

    let idCarro;
    const MODELO_CARRO = "Carro";
    const METODO_DELETE = "DELETE";
    const ROTA_DETALHES = "appDetalhesCarro";
    const PARAMETRO_ARGUMENTOS = "arguments";
    const ROTA_EDITAR_CARRO = "appEditarCarro";
    const ROTA_LISTAGEM_CARROS = "appListagemCarro";
    const URL_CARRO = "http://localhost:5071/api/Carros/";

    return BaseController.extend("ui5.carro.app.carros.DetalhesCarro", {
        formatter: Formatter,

        onInit() {
            this.aoCoincidirRota();
        },

        aoCoincidirRota() {
            this.processarEvento(() => {
                const rota = this.getRouter();
                rota.getRoute(ROTA_DETALHES).attachMatched(this._carregarCarro, this);
            });
        },

        _carregarEventos(oEvent) {
            this._carregarCarro(oEvent);
        },

        _carregarCarro(oEvent) {
            idCarro = oEvent.getParameter(PARAMETRO_ARGUMENTOS).id;
            let query = URL_CARRO + idCarro;

            fetch(query)
                .then((res) => {
                    return res.json()
                })
                .then((carro) => {
                    if (!carro.Detail) {
                        const jsonModel = new JSONModel(carro)
                        this.getView().setModel(jsonModel, MODELO_CARRO);
                    }
                    else this._erroNaRequisicaoDaApi(carro);
                });

        },

        aoClicarNoBotaoRemoverCarro() {
            this.processarEvento(() => {
                MessageBox.information(`Deseja excluir o carro com ID ${idCarro} ?`,
                    {
                        title: "Remover carro",
                        actions: [MessageBox.Action.NO, MessageBox.Action.YES],
                        onClose: (action) => {
                            if (action === MessageBox.Action.YES) {
                                this._remover(URL_CARRO, METODO_DELETE, idCarro);
                            }
                        }
                    }
                );
            })
        },

        _remover(url, metodo, id) {
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

                    })
                    .then(data => {
                        if (data.Detail) this._erroNaRequisicaoDaApi(data);
                    });
            })
        },

        _sucessoAoRemover(){
            MessageBox.success("Carro removido com sucesso!", {
                actions: ["Ok"],
                title: "Sucesso",
                onClose:() => {
                    this.getRouter().navTo(ROTA_LISTAGEM_CARROS, {}, true);
                }
            });
        },

        aoClicarVoltarParaTelaDeListagem() {
            this.processarEvento(() => {
                this.getRouter().navTo(ROTA_LISTAGEM_CARROS, {}, true);
            })
        },
        
        aoClicarNoBotaoEditar(oEvent){
            this.processarEvento(() =>{
                const oItem = oEvent.getSource();
                const oRouter = this.getOwnerComponent().getRouter();
                oRouter.navTo(ROTA_EDITAR_CARRO, {
                    id: oItem._getPropertiesToPropagate().oModels.Carro.oData.id
                });
            })
        }
    });
}, true);