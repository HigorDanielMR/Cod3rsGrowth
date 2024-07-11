sap.ui.define([
    "sap/ui/core/UIComponent",
    "sap/ui/model/json/JSONModel",
    "sap/ui/model/resource/ResourceModel"
 ], (UIComponent, JSONModel, ResourceModel) => {
    "use strict";
 
    return UIComponent.extend("ui5.walkthrough.Component", {
       metadata : {
          "interfaces": ["sap.ui.core.IAsyncContentCreation"],
          "rootView": {
             "viewName": "ui5.walkthrough.view.App",
             "type": "XML",
             "id": "app"
          }
       },
 
       init() {
          // set i18n model
          const i18nModel = new ResourceModel({
             bundleName: "ui5.walkthrough.i18n.i18n"
          });
          this.setModel(i18nModel, "i18n");

            UIComponent.prototype.init.apply(this, arguments);
    
            this.getRouter().initialize();
       }
    });
 });
 