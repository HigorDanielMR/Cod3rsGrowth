sap.ui.define([
    "ui5/carro/app/common/BaseController",
    "ui5/carro/model/formatter",
    "sap/ui/model/json/JSONModel",
    "sap/m/MessageBox"

], function (BaseController, Formatter, JSONModel, MessageBox) {
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
                const rota = this.getRouter();
                rota.getRoute(rotaDetalhe).attachMatched(this._carregarEventos, this);
            });
        },

        _carregarEventos(oEvent) {
            this._obterVendaPorId(oEvent);
        },

        _obterVendaPorId(oEvent) {
            idVenda = oEvent.getParameter(parametroArgumento).id;
            let query = urlVenda + idVenda;

            fetch(query)
                .then((res) => {
                    return res.json()
                })
                .then((venda) => {
                    if(!venda.Detail){
                        const jsonModel = new JSONModel(venda)
                        idCarro = this._carregarIdCarro(venda);
                        this._carregarCarroAssociado(idCarro);
                        this.getView().setModel(jsonModel, modeloVenda);
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
                                this._remover(urlVenda, metodoDelete, idVenda);
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
                    this.getRouter().navTo(rotaListagem, {}, true);
                }
            });
        },

        _carregarCarroAssociado(id){
            let query = urlCarro + id;

            fetch(query)
                .then((res) => {
                    return res.json()
                })
                .then((carro) => {
                    const jsonModel = new JSONModel(carro)

                    !carro.Detail ? this.getView().setModel(jsonModel, modeloCarro)
                        : this._erroNaRequisicaoDaApi(carro);
                });
        },
        
        _carregarIdCarro(venda) {
            return venda.idDoCarroVendido;
        },

        aoClicarVoltarParaTelaDeListagem() {
            this.processarEvento(() => {
                this.getRouter().navTo(rotaListagem, {}, true);
            })
        },

        aoClicarNoBotaoEditarDeveAbrirATelaDeModificarVenda(oEvent){
            this.processarEvento(() => { 
                const oItem = oEvent.getSource(); 
                const oRouter = this.getOwnerComponent().getRouter();
                oRouter.navTo(rotaEditarVenda, {
                    id: window.encodeURIComponent(oItem.getBindingContext(modeloVenda).getProperty(id))
                });
            })
        }
    });
}, true);