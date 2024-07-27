﻿QUnit.config.autostart = false;

sap.ui.require([
	"sap/ui/core/Core"
], async (Core) => {
	"use strict";

	await Core.ready();

	sap.ui.require([
		"ui5/carro/test/integration/JornadaTelaDeListagem"
	], () => {
		QUnit.start();
	});
});