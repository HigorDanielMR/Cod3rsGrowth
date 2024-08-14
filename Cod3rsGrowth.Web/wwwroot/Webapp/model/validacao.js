sap.ui.define([
    "sap/ui/core/format/DateFormat",
    "sap/ui/core/format/NumberFormat"

], function () {
    "use strict";
    
    return {

        validarNome(inputNome) {
            var nome = inputNome.getValue();
            const regexParaConterApenasLetras = /^[a-zA-ZáàâãéèêíïóôõöúçñÁÀÂÃÉÈÊÍÏÓÔÕÖÚÇÑ ]+$/;
            var ehValido = true;
            if (nome === '') {
                inputNome.setValueState(sap.ui.core.ValueState.Error);
                inputNome.setValueStateText('Nome não pode estar em branco.');
                ehValido = false;
            }
            else if (nome.length > 100) {
                inputNome.setValueState(sap.ui.core.ValueState.Error);
                inputNome.setValueStateText('Nome não pode ter mais de 100 caracteres.')
                ehValido = false;
            }
            else if (!regexParaConterApenasLetras.test(nome)) {
                inputNome.setValueState(sap.ui.core.ValueState.Error);
                inputNome.setValueStateText('Nome pode conter apenas letras.')
                ehValido = false;
            }
            else {
                inputNome.setValueState(sap.ui.core.ValueState.None);
                inputNome.setValueStateText('');
                ehValido = true;
            }
            return ehValido;
        },

        validarCpf(inputCpf) {
            var cpf = inputCpf.getValue();
            const regexParaCaracteresEspeciais = /[\W_]/g;
            const regexParaVerificarSeOsNumerosSaoSequenciais = /^(\d)\1+$/;
            const cpfSemMascara = cpf.replace(regexParaCaracteresEspeciais, "");
            var ehValido = true;

            if (cpfSemMascara === '') {
                inputCpf.setValueState(sap.ui.core.ValueState.Error);
                inputCpf.setValueStateText('CPF não pode estar em branco');
                ehValido = false;
            }
            else if (cpfSemMascara.length < 11) {
                inputCpf.setValueState(sap.ui.core.ValueState.Error);
                inputCpf.setValueStateText('CPF incompleto.');
                ehValido = false;
            }
            else if (regexParaVerificarSeOsNumerosSaoSequenciais.test(cpfSemMascara)) {
                inputCpf.setValueState(sap.ui.core.ValueState.Error);
                inputCpf.setValueStateText('CPF inválido.');
                ehValido = false;
            }
            else {
                inputCpf.setValueState(sap.ui.core.ValueState.None);
                inputCpf.setValueStateText('');
                ehValido = true;
            }
            return ehValido;
        },

        validarTelefone(inputTelefone) {
            var telefone = inputTelefone.getValue();
            const regexParaCaracteresEspeciais = /[\W_]/g;
            const telefoneSemMascara = telefone.replace(regexParaCaracteresEspeciais, "");
            var ehValido = true;

            if (telefoneSemMascara === '') {
                inputTelefone.setValueState(sap.ui.core.ValueState.Error);
                inputTelefone.setValueStateText('Telefone não pode estar em branco');
                ehValido = false;
            }
            else if (telefoneSemMascara.length < 11) {
                inputTelefone.setValueState(sap.ui.core.ValueState.Error);
                inputTelefone.setValueStateText('Telefone incompleto.');
                ehValido = false;
            }
            else {
                inputTelefone.setValueState(sap.ui.core.ValueState.None);
                inputTelefone.setValueStateText('');
                ehValido = true;
            }
            return ehValido;
        },

        validarEmail(inputEmail) {
            var email = inputEmail.getValue();
            const regexParaEmail = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$/;
            var ehValido = true;

            if (email === '') {
                inputEmail.setValueState(sap.ui.core.ValueState.Error);
                inputEmail.setValueStateText('Email não pode estar em branco');
                ehValido = false;
            }
            else if (!regexParaEmail.test(email)) {
                inputEmail.setValueState(sap.ui.core.ValueState.Error);
                inputEmail.setValueStateText('Email inválido.');
                ehValido = false;
            }
            else {
                inputEmail.setValueState(sap.ui.core.ValueState.None);
                inputEmail.setValueStateText('');
                ehValido = true;
            }
            return ehValido;
        },

        validarDados(nome, cpf, telefone, email){
            var ehNomeValido = this.validarNome(nome);
            var ehCpfValido = this.validarCpf(cpf);
            var ehTelefoneValido = this.validarTelefone(telefone);
            var ehEmailValido = this.validarEmail(email);

            return ehNomeValido && ehCpfValido && ehTelefoneValido && ehEmailValido;
        }
    }
});