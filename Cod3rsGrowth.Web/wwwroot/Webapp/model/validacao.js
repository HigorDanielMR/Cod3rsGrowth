sap.ui.define([
    "sap/ui/core/format/DateFormat",
    "sap/ui/core/format/NumberFormat"

], function () {
    "use strict";
    
    return {

        validarNome(inputNome, nome) {
            nome = inputNome.getValue().trim();
            const regexParaConterApenasLetras = /^[a-zA-ZáàâãéèêíïóôõöúçñÁÀÂÃÉÈÊÍÏÓÔÕÖÚÇÑ ]+$/;

            if (nome === '') {
                inputNome.setValueState(sap.ui.core.ValueState.Error);
                inputNome.setValueStateText('Nome não pode estar em branco.');
                throw new Error('Nome não pode estar em branco.');
            }
            else if (nome.length > 100) {
                inputNome.setValueState(sap.ui.core.ValueState.Error);
                inputNome.setValueStateText('Nome não pode ter mais de 100 caracteres.')
                throw new Error('Nome não pode ter mais de 100 caracteres.');

            }
            else if (!regexParaConterApenasLetras.test(nome)) {
                inputNome.setValueState(sap.ui.core.ValueState.Error);
                inputNome.setValueStateText('Nome pode conter apenas letras.')
                throw new Error('Nome pode conter apenas letras.');
            }
            else {
                inputNome.setValueState(sap.ui.core.ValueState.None);
                inputNome.setValueStateText('');
            }
        },

        validarCpf(inputCpf, cpf) {
            cpf = inputCpf.getValue();
            const regexParaCaracteresEspeciais = /[\W_]/g;
            const regexParaVerificarSeOsNumerosSaoSequenciais = /^(\d)\1+$/;
            const cpfSemMascara = cpf.replace(regexParaCaracteresEspeciais, "");

            if (cpfSemMascara === '') {
                inputCpf.setValueState(sap.ui.core.ValueState.Error);
                inputCpf.setValueStateText('CPF não pode estar em branco');
                throw new Error('CPF não pode estar em branco');
            }
            else if (cpfSemMascara.length < 11) {
                inputCpf.setValueState(sap.ui.core.ValueState.Error);
                inputCpf.setValueStateText('CPF incompleto.');
                throw new Error('CPF incompleto.');
            }
            else if (regexParaVerificarSeOsNumerosSaoSequenciais.test(cpfSemMascara)) {
                inputCpf.setValueState(sap.ui.core.ValueState.Error);
                inputCpf.setValueStateText('CPF inválido.');
                throw new Error('CPF inválido.');
            }
            else {
                inputCpf.setValueState(sap.ui.core.ValueState.None);
                inputCpf.setValueStateText('');
            }
        },

        validarTelefone(inputTelefone, telefone) {
            telefone = inputTelefone.getValue().trim();
            const regexParaCaracteresEspeciais = /[\W_]/g;

            const telefoneSemMascara = telefone.replace(regexParaCaracteresEspeciais, "");

            if (telefoneSemMascara === '') {
                inputTelefone.setValueState(sap.ui.core.ValueState.Error);
                inputTelefone.setValueStateText('Telefone não pode estar em branco');
                throw new Error('Telefone não pode estar em branco');
            }
            else if (telefoneSemMascara.length < 11) {
                inputTelefone.setValueState(sap.ui.core.ValueState.Error);
                inputTelefone.setValueStateText('Telefone incompleto.');
                throw new Error('Telefone incompleto.');
            }
            else {
                inputTelefone.setValueState(sap.ui.core.ValueState.None);
                inputTelefone.setValueStateText('');
            }
        },

        validarEmail(inputEmail, email) {
            email = inputEmail.getValue().trim();
            const regexParaEmail = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$/;

            if (email === '') {
                inputEmail.setValueState(sap.ui.core.ValueState.Error);
                inputEmail.setValueStateText('Email não pode estar em branco');
                throw new Error('Email não pode estar em branco');
            }
            else if (!regexParaEmail.test(email)) {
                inputEmail.setValueState(sap.ui.core.ValueState.Error);
                inputEmail.setValueStateText('Email inválido.');
                throw new Error('Email inválido.');
            }
            else {
                inputEmail.setValueState(sap.ui.core.ValueState.None);
                inputEmail.setValueStateText('');
            }
        }
    }
});