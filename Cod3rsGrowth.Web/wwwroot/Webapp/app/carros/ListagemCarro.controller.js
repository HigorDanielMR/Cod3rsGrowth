sap.ui.define([
    "ui5/carro/app/common/BaseController",
    "sap/ui/model/json/JSONModel",
    "ui5/carro/model/formatter",
    "sap/m/MessageBox"

], function (BaseController, JSONModel, Formatter, MessageBox) {
    "use strict";

    const id = "id";    
    const modeloCarro = "Carros";
    const rotaListagemCarro = "appListagemCarro";
    const rotaListagemVenda = "appListagem";
    const rotaDetalhes = "appDetalhes";
    const idDoFiltroModelo = "FiltroModelo";
    const idDoFiltroMarca = "FiltroMarcas";
    const idDoFiltroCor = "FiltroCores";
    const idDoFiltroFlex = "FiltroFlex";
    const modeloCores = "Cores";
    const modeloMarcas = "Marcas";
    let url = "http://localhost:5071/api/Carros/";    
    const rotaAdicionarCarro = "appAdicionarCarro";

    return BaseController.extend("ui5.carro.app.carros.ListagemCarro", {
        formatter: Formatter,

        onInit() {
            this.aoCoincidirRota();
        },

        aoCoincidirRota() {
            this.processarEvento(() => {
                var rota = sap.ui.core.UIComponent.getRouterFor(this);
                rota.getRoute(rotaListagemCarro).attachMatched(this._carregarEventos, this);
            });
        },

        _carregarEventos(){
            this._carregarListaDeCarros();
            this._carregarDescricaoCores();
            this._carregarDescricaoMarcas();
        },

        _carregarListaDeCarros() {
            let sucesso = true;
            fetch(url)
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

        _carregarDescricaoCores(){
            let sucesso = true;
            const urlCores = "http://localhost:5071/api/Carros/Cores";
            fetch(urlCores)
                .then((res) => {
                    if (!res.ok)
                        sucesso = false;
                    return res.json()
                })
                .then((data) => {
                    if (sucesso) {
                        const cores = data.map((item) => ({ text: item }));
                        cores.unshift({ text: "Todas" });
        
                        this.getView().setModel(new JSONModel({
                            descricao: cores
                        }), modeloCores);
                    } else {
                        this._erroNaRequisicaoDaApi(data);
                    }
                })
                .catch((err) => console.error(err));
        },

        _carregarDescricaoMarcas(){
            let sucesso = true;
            const urlMarcas = "http://localhost:5071/api/Carros/Marcas";
            fetch(urlMarcas)
                .then((res) => {
                    if (!res.ok) sucesso = false;
                    return res.json();
                })
                .then((data) => {
                    if (sucesso) {
                        const marcas = data.map((item) => ({ text: item }));
                        marcas.unshift({ text: "Todas" });
        
                        this.getView().setModel(new JSONModel({
                            descricao: marcas
                        }), modeloMarcas);
                    } else {
                        this._erroNaRequisicaoDaApi(data);
                    }
                })
                .catch((err) => console.error(err));
        },        
        
        aoColetarModelo() {
            const modelo = this.oView.byId(idDoFiltroModelo).getValue();
            return modelo;
        },

        aoColetarMarca(){
            const marca = this.oView.byId(idDoFiltroMarca).getSelectedKey();
            return marca;
        },
        
        aoColetarCor(){
            const cor = this.oView.byId(idDoFiltroCor).getSelectedKey();
            return cor;
        },

        aoColetarSeEhFlex(){
            const flex = this.oView.byId(idDoFiltroFlex).getSelectedKey();
            const flexFormatado = Formatter.formatarFlexFiltro(flex)
            return flexFormatado;
        },

        aoFiltrarCarro() {
            this.processarEvento(() => {
                let sucesso = true;
                let urlDoFiltro = url + "?";
                let modelo = this.aoColetarModelo();
                let marca = this.aoColetarMarca();
                let cor = this.aoColetarCor();
                let flex = this.aoColetarSeEhFlex();

                if (cor === "Todas" || marca === "Todas"){
                    cor = null;
                    marca = null;
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
                        if (!res.ok)
                            sucesso = false;
                        return res.json()
                    })
                    .then((carros) => {
                        const jsonModel = new JSONModel(carros)
                        sucesso ? this.getView().setModel(jsonModel, modeloCarro)
                            : this._erroNaRequisicaoDaApi(carros);
                    })
                    .catch((err) => console.error(err));
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
                id: window.encodeURIComponent(oItem.getBindingContext(modeloVenda).getProperty(id))
            });
        }
    });
});