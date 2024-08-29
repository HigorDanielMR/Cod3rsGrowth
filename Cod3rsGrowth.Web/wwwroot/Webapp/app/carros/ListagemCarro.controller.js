sap.ui.define([
    "ui5/carro/app/common/BaseController",
    "sap/ui/model/json/JSONModel",
    "ui5/carro/model/formatter"

], function (BaseController, JSONModel, Formatter) {
    "use strict";

    const id = "id";    
    const MODELO_CORES = "Cores";
    const MODELO_CARRO = "Carros";
    const MODELO_MARCAS = "Marcas";
    const ID_DO_FILTRO_FLEX = "FiltroFlex";
    const ID_DO_FILTRO_COR = "FiltroCores";
    const ID_DO_FILTRO_MARCA = "FiltroMarcas";
    const ID_DO_FILTRO_MODELO = "FiltroModelo";
    const ROTA_LISTAGEM_VENDA = "appListagem";
    const ROTA_DETALHES = "appDetalhesCarro";
    const ROTA_LISTAGEM_CARRO = "appListagemCarro";
    const ROTA_ADICIONAR_CARRO = "appAdicionarCarro";
    let URL_API = "http://localhost:5071/api/Carros/";    
    const RECURSOS_CORES = URL_API + "Cores";
    const RECURSOS_MARCAS = URL_API + "Marcas";

    return BaseController.extend("ui5.carro.app.carros.ListagemCarro", {
        formatter: Formatter,

        onInit() {
            this.aoCoincidirRota();
        },

        aoCoincidirRota() {
            this.processarEvento(() => {
                var rota = this.getRouter();
                rota.getRoute(ROTA_LISTAGEM_CARRO).attachMatched(this._carregarEventos, this);
            });
        },

        _carregarEventos(){
            this._carregarListaDeCarros();
            this._carregarDescricaoCores();
            this._carregarDescricaoMarcas();
        },

        _carregarListaDeCarros() {
            fetch(URL_API)
                .then((res) => {
                    return res.json()
                })
                .then((carro) => {
                    const jsonModel = new JSONModel(carro)

                    !carro.Detail ? this.getView().setModel(jsonModel, MODELO_CARRO)
                        : this._erroNaRequisicaoDaApi(carro);
                })
        },

        _carregarDescricaoCores(){
            fetch(RECURSOS_CORES)
                .then((res) => {
                    return res.json()
                })
                .then((data) => {
                    if (!data.Detail) {
                        const cores = data.map((item) => ({ text: item }));
                        cores.unshift({ text: "Todas" });
        
                        this.getView().setModel(new JSONModel({
                            descricao: cores
                        }), MODELO_CORES);
                    }
                    else {
                        this._erroNaRequisicaoDaApi(data);
                    }
                })
        },

        _carregarDescricaoMarcas(){
            fetch(RECURSOS_MARCAS)
                .then((res) => {
                    return res.json();
                })
                .then((data) => {
                    if (!data.Detail) {
                        const marcas = data.map((item) => ({ text: item }));
                        marcas.unshift({ text: "Todas" });
        
                        this.getView().setModel(new JSONModel({
                            descricao: marcas
                        }), MODELO_MARCAS);
                    }
                    else {
                        this._erroNaRequisicaoDaApi(data);
                    }
                })
        },        
        
        obterModelo() {
            return this.oView.byId(ID_DO_FILTRO_MODELO).getValue();
        },

        obterMarca(){
            return this.oView.byId(ID_DO_FILTRO_MARCA).getSelectedKey();
        },
        
        obterCor(){
            return this.oView.byId(ID_DO_FILTRO_COR).getSelectedKey();
        },

        obterFlex(){
            const flex = this.oView.byId(ID_DO_FILTRO_FLEX).getSelectedKey();
            return Formatter.formatarFlexFiltro(flex);
        },

        aoFiltrarCarro() {
            this.processarEvento(() => {
                let urlDoFiltro = URL_API + "?";
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

                        !carros.Detail ? this.getView().setModel(jsonModel, MODELO_CARRO)
                            : this._erroNaRequisicaoDaApi(carros);
                    })
            })
        },

        aoClicarDeveIParaAListagemVendas(){
            this.processarEvento(() => {
                this.getRouter().navTo(ROTA_LISTAGEM_VENDA, {}, true);  
            })
        },

        aoClicarNoBotaoAdicionarCarro() {
            this.processarEvento(() => {
                this.getRouter().navTo(ROTA_ADICIONAR_CARRO, {}, true);  
            })
        },

        aoPressionar(oEvent) {
            const oItem = oEvent.getSource();
            const oRouter = this.getOwnerComponent().getRouter();
            oRouter.navTo(ROTA_DETALHES, {
                id: window.encodeURIComponent(oItem.getBindingContext(MODELO_CARRO).getProperty(id))
            });
        }
    });
});