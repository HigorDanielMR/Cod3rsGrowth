sap.ui.define([
    "ui5/carro/app/common/BaseController",
    "ui5/carro/model/formatter",
    "sap/ui/model/json/JSONModel",
    "sap/m/MessageBox"

], function (BaseController, Formatter, JSONModel, MessageBox) {
    "use strict";

    let idCarro;
    let idVenda;
    const ID = "id";
    const MODELO_VENDA = "Venda";
    const MODELO_CARRO = "Carro";
    const METODO_DELETE = "DELETE";
    const ROTA_DETALHES = "appDetalhes";
    const ROTA_LISTAGEM = "appListagem";
    const PARAMETRO_ARGUMENTOS = "arguments";
    const ROTA_EDITAR_VENDA = "appEditarVenda";
    const URL_VENDA = "http://localhost:5071/api/Vendas/";
    const URL_CARRO = "http://localhost:5071/api/Carros/";

    return BaseController.extend("ui5.carro.app.vendas.Detalhes", {
        formatter: Formatter,

        onInit() {
            this.aoCoincidirRota();
        },

        aoCoincidirRota() {
            this.processarEvento(() => {
                const rota = this.getRouter();
                rota.getRoute(ROTA_DETALHES).attachMatched(this._carregarEventos, this);
            });
        },

        _carregarEventos(oEvent) {
            this._obterVendaPorId(oEvent);
        },

        _obterVendaPorId(oEvent) {
            idVenda = oEvent.getParameter(PARAMETRO_ARGUMENTOS).id;
            let query = URL_VENDA + idVenda;

            fetch(query)
                .then((res) => {
                    return res.json()
                })
                .then((venda) => {
                    if(!venda.Detail){
                        const jsonModel = new JSONModel(venda)
                        idCarro = this._carregarIdCarro(venda);
                        this._carregarCarroAssociado(idCarro);
                        this.getView().setModel(jsonModel, MODELO_VENDA);
                    } 
                    else this._erroNaRequisicaoDaApi(venda);
                });
        },

        aoClicarNoBotaoRemover() {
            this.processarEvento(() =>{
                MessageBox.information(
                    `Deseja excluir a venda com ID ${idVenda} ?`,
                    {
                        title: "Confirmar remoção da venda",
                        actions: [MessageBox.Action.NO, MessageBox.Action.YES],
                        onClose:(oAction) => {
                            if (oAction === MessageBox.Action.YES) {
                                this._remover(URL_VENDA, METODO_DELETE, idVenda);
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
                            : res.json()

                    }).then(data => {
                        if (data.Detail) this._erroNaRequisicaoDaApi(data);
                    });
            })
        },

        _sucessoAoRemover(){
            MessageBox.success("Venda removida com sucesso!", {
                actions: ["Ok"],
                title: "Sucesso",
                onClose:() => {
                    this.getRouter().navTo(ROTA_LISTAGEM, {}, true);
                }
            });
        },

        _carregarCarroAssociado(id){
            let query = URL_CARRO + id;

            fetch(query)
                .then((res) => {
                    return res.json()
                })
                .then((carro) => {
                    const jsonModel = new JSONModel(carro)

                    !carro.Detail ? this.getView().setModel(jsonModel, MODELO_CARRO)
                        : this._erroNaRequisicaoDaApi(carro);
                });
        },
        
        _carregarIdCarro(venda) {
            return venda.idDoCarroVendido;
        },

        aoClicarVoltarParaTelaDeListagem() {
            this.processarEvento(() => {
                this.getRouter().navTo(ROTA_LISTAGEM, {}, true);
            })
        },

        aoClicarNoBotaoEditarDeveAbrirATelaDeModificarVenda(oEvent){
            this.processarEvento(() => { 
                const oItem = oEvent.getSource(); 
                const oRouter = this.getOwnerComponent().getRouter();
                oRouter.navTo(ROTA_EDITAR_VENDA, {
                    id: window.encodeURIComponent(oItem.getBindingContext(MODELO_VENDA).getProperty(ID))
                });
            })
        }
    });
}, true);