QUnit.config.autostart = false;

sap.ui.require([
	"sap/ui/core/Core",
	"ui5/carro/test/integration/Jornadas"
], async (Core) => {
	"use strict";

	await Core.ready();

	sap.ui.require([
		"ui5/carro/test/integration/Jornadas"
	], () => {
		QUnit.start();
	});
});
