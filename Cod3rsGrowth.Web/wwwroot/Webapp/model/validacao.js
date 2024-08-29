sap.ui.define([
    "sap/ui/core/format/DateFormat",
    "sap/ui/core/format/NumberFormat"

], function () {
    "use strict";
    
    return {

        validarNome(inputNome) {
            const tamanhoMaximoNome = 100;
            var nome = inputNome.getValue();
            const regexParaConterApenasLetras = /^[a-zA-ZáàâãéèêíïóôõöúçñÁÀÂÃÉÈÊÍÏÓÔÕÖÚÇÑ ]+$/;
            var ehValido = true;
            if (!nome) {
                inputNome.setValueState(sap.ui.core.ValueState.Error);
                inputNome.setValueStateText('Nome não pode estar em branco.');
                ehValido = false;
            }
            else if (nome.length > tamanhoMaximoNome) {
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
            const tamanhoPadraoCpf = 11;
            var cpf = inputCpf.getValue();
            const regexParaCaracteresEspeciais = /[\W_]/g;
            const regexParaVerificarSeOsNumerosSaoSequenciais = /^(\d)\1+$/;
            const cpfSemMascara = cpf.replace(regexParaCaracteresEspeciais, "");
            var ehValido = true;

            if (!cpfSemMascara) {
                inputCpf.setValueState(sap.ui.core.ValueState.Error);
                inputCpf.setValueStateText('CPF não pode estar em branco');
                ehValido = false;
            }
            else if (cpfSemMascara.length < tamanhoPadraoCpf) {
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
            const tamanhoPadraoTelefone = 11;
            var telefone = inputTelefone.getValue();
            const regexParaCaracteresEspeciais = /[\W_]/g;
            const telefoneSemMascara = telefone.replace(regexParaCaracteresEspeciais, "");
            var ehValido = true;

            if (!telefoneSemMascara) {
                inputTelefone.setValueState(sap.ui.core.ValueState.Error);
                inputTelefone.setValueStateText('Telefone não pode estar em branco');
                ehValido = false;
            }
            else if (telefoneSemMascara.length < tamanhoPadraoTelefone) {
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

            if (!email) {
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
        },

        validarModelo(inputModelo){
            var modelo = inputModelo.getValue();
            var limiteMinimoDeCaracteres = 2;
            var limiteMaximoDeCaracteres = 50;
            var ehValido = true;

            if (!modelo) {
                inputModelo.setValueState(sap.ui.core.ValueState.Error);
                inputModelo.setValueStateText('Modelo não pode estar em branco.');
                ehValido = false;
            }
            else if (modelo.length < limiteMinimoDeCaracteres) {
                inputModelo.setValueState(sap.ui.core.ValueState.Error);
                inputModelo.setValueStateText('Nome não pode ter menos de 2 caracteres.')
                ehValido = false;
            }
            else if (modelo.length > limiteMaximoDeCaracteres){
                inputModelo.setValueState(sap.ui.core.ValueState.Error);
                inputModelo.setValueStateText("Modelo não pode ter mais de 50 caracteres.")
            }
            else {
                inputModelo.setValueState(sap.ui.core.ValueState.None);
                inputModelo.setValueStateText('');
                ehValido = true;
            }
            return ehValido;
        },

        validarValorDoCarro(inputValor){
            
            var valor = inputValor.getValue();
            const valorPadrao = 0;
            var ehValido = true;
            const tamanhoMaximoValor = 15;

            if (!valor){
                inputValor.setValueState(sap.ui.core.ValueState.Error);
                inputValor.setValueStateText('Valor não pode estar vazio.');
                ehValido = false;
            }
            else if(valor.length < valorPadrao){
                inputValor.setValueState(sap.ui.core.ValueState.Error);
                inputValor.setValueStateText('Valor deve ser maior ou igual a 0.');
                ehValido = false;
            }
            else if(valor.length > tamanhoMaximoValor){
                inputValor.setValueState(sap.ui.core.ValueState.Error);
                inputValor.setValueStateText('Valor não pode passar de um trilhão.');
                ehValido = false;
            }
            else {
                inputValor.setValueState(sap.ui.core.ValueState.None);
                inputValor.setValueStateText('');
                ehValido = true;
            }
            return ehValido;
        },

        validarDadosCarro(modelo, valor){
            var EhModeloValido = this.validarModelo(modelo);
            var EhValorValido = this.validarValorDoCarro(valor);

            return EhModeloValido && EhValorValido
        }
    }
});