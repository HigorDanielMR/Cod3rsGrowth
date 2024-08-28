sap.ui.define([
    "ui5/carro/app/common/BaseController",
    "sap/ui/model/json/JSONModel",
    "ui5/carro/model/formatter",
    "sap/m/MessageBox"

], function (BaseController, JSONModel, Formatter, MessageBox) {
    "use strict";

    const id = "id";    
    const modeloCores = "Cores";
    const modeloCarro = "Carros";
    const modeloMarcas = "Marcas";
    const idDoFiltroFlex = "FiltroFlex";
    const idDoFiltroCor = "FiltroCores";
    const idDoFiltroMarca = "FiltroMarcas";
    const idDoFiltroModelo = "FiltroModelo";
    const rotaListagemVenda = "appListagem";
    const rotaDetalhes = "appDetalhesCarro";
    const rotaListagemCarro = "appListagemCarro";
    let urlApi = "http://localhost:5071/api/Carros/";    
    const rotaAdicionarCarro = "appAdicionarCarro";
    const recursoCores = urlApi + "Cores";
    const recursoMarcas = urlApi + "Marcas";

    return BaseController.extend("ui5.carro.app.carros.ListagemCarro", {
        formatter: Formatter,

        onInit() {
            this.aoCoincidirRota();
        },

        aoCoincidirRota() {
            this.processarEvento(() => {
                var rota = this.getRouter();
                rota.getRoute(rotaListagemCarro).attachMatched(this._carregarEventos, this);
            });
        },

        _carregarEventos(){
            this._carregarListaDeCarros();
            this._carregarDescricaoCores();
            this._carregarDescricaoMarcas();
        },

        _carregarListaDeCarros() {
            fetch(urlApi)
                .then((res) => {
                    return res.json()
                })
                .then((carro) => {
                    const jsonModel = new JSONModel(carro)

                    !carro.Detail ? this.getView().setModel(jsonModel, modeloCarro)
                        : this._erroNaRequisicaoDaApi(carro);
                })
        },

        _carregarDescricaoCores(){
            fetch(recursoCores)
                .then((res) => {
                    return res.json()
                })
                .then((data) => {
                    if (!data.Detail) {
                        const cores = data.map((item) => ({ text: item }));
                        cores.unshift({ text: "Todas" });
        
                        this.getView().setModel(new JSONModel({
                            descricao: cores
                        }), modeloCores);
                    }
                    else {
                        this._erroNaRequisicaoDaApi(data);
                    }
                })
                .catch((err) => MessageBox.error(err));
        },

        _carregarDescricaoMarcas(){
            fetch(recursoMarcas)
                .then((res) => {
                    return res.json();
                })
                .then((data) => {
                    if (!data.Detail) {
                        const marcas = data.map((item) => ({ text: item }));
                        marcas.unshift({ text: "Todas" });
        
                        this.getView().setModel(new JSONModel({
                            descricao: marcas
                        }), modeloMarcas);
                    }
                    else {
                        this._erroNaRequisicaoDaApi(data);
                    }
                })
                .catch((err) => MessageBox.error(err));
        },        
        
        obterModelo() {
            return this.oView.byId(idDoFiltroModelo).getValue();
        },

        obterMarca(){
            return this.oView.byId(idDoFiltroMarca).getSelectedKey();
        },
        
        obterCor(){
            return this.oView.byId(idDoFiltroCor).getSelectedKey();
        },

        obterFlex(){
            const flex = this.oView.byId(idDoFiltroFlex).getSelectedKey();
            return Formatter.formatarFlexFiltro(flex);
        },

        aoFiltrarCarro() {
            this.processarEvento(() => {
                let urlDoFiltro = urlApi + "?";
                let modelo = this.obterModelo();
                let marca = this.obterMarca();
                let cor = this.obterCor();
                let flex = this.obterFlex();

                if (cor === "Todas"){
                    cor = null;
                }
                if (marca === "Todas") {
                    marca = null
                }

                if (modelo) {
                    urlDoFiltro += "Modelo=" + modelo + "&";
                }
                if(marca){
                    urlDoFiltro += "Marca=" + marca + "&";
                }
                if(cor){
                    urlDoFiltro += "Cor=" + cor + "&";
                }
                if(flex){
                    urlDoFiltro += "Flex=" + flex + "&";
                }

                fetch(urlDoFiltro)
                    .then((res) => {
                        return res.json()
                    })
                    .then((carros) => {
                        const jsonModel = new JSONModel(carros)

                        !carros.Detail ? this.getView().setModel(jsonModel, modeloCarro)
                            : this._erroNaRequisicaoDaApi(carros);
                    })
            })
        },

        aoClicarDeveIParaAListagemVendas(){
            this.processarEvento(() => {
                this.getRouter().navTo(rotaListagemVenda, {}, true);  
            })
        },

        aoClicarNoBotaoAdicionarCarro() {
            this.processarEvento(() => {
                this.getRouter().navTo(rotaAdicionarCarro, {}, true);  
            })
        },

        aoPressionar(oEvent) {
            const oItem = oEvent.getSource();
            const oRouter = this.getOwnerComponent().getRouter();
            oRouter.navTo(rotaDetalhes, {
                id: window.encodeURIComponent(oItem.getBindingContext(modeloCarro).getProperty(id))
            });
        }
    });
});