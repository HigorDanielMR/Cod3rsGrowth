namespace Cod3rsGrowth.Forms
{
    partial class CriandoCarro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtModelo = new TextBox();
            label1 = new Label();
            selecionarMarca = new ComboBox();
            label2 = new Label();
            selecionarCor = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            selecionarFlex = new CheckBox();
            AoClicarNoBotaoCriarCarro = new Button();
            AoClicarNoBotaoCancelarCarro = new Button();
            selecionarValorDoVeiculo = new TextBox();
            SuspendLayout();
            // 
            // txtModelo
            // 
            txtModelo.Location = new Point(12, 33);
            txtModelo.Name = "txtModelo";
            txtModelo.Size = new Size(390, 23);
            txtModelo.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 11);
            label1.Name = "label1";
            label1.Size = new Size(61, 19);
            label1.TabIndex = 1;
            label1.Text = "Modelo";
            // 
            // selecionarMarca
            // 
            selecionarMarca.FormattingEnabled = true;
            selecionarMarca.Location = new Point(12, 99);
            selecionarMarca.Name = "selecionarMarca";
            selecionarMarca.Size = new Size(196, 23);
            selecionarMarca.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(12, 77);
            label2.Name = "label2";
            label2.Size = new Size(51, 19);
            label2.TabIndex = 3;
            label2.Text = "Marca";
            // 
            // selecionarCor
            // 
            selecionarCor.FormattingEnabled = true;
            selecionarCor.Location = new Point(214, 99);
            selecionarCor.Name = "selecionarCor";
            selecionarCor.Size = new Size(188, 23);
            selecionarCor.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(214, 77);
            label3.Name = "label3";
            label3.Size = new Size(33, 19);
            label3.TabIndex = 5;
            label3.Text = "Cor";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(13, 136);
            label4.Name = "label4";
            label4.Size = new Size(118, 19);
            label4.TabIndex = 7;
            label4.Text = "Valor do Veiculo";
            // 
            // selecionarFlex
            // 
            selecionarFlex.AutoSize = true;
            selecionarFlex.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            selecionarFlex.Location = new Point(314, 160);
            selecionarFlex.Name = "selecionarFlex";
            selecionarFlex.Size = new Size(55, 23);
            selecionarFlex.TabIndex = 8;
            selecionarFlex.Text = "Flex";
            selecionarFlex.UseVisualStyleBackColor = true;
            // 
            // AoClicarNoBotaoCriarCarro
            // 
            AoClicarNoBotaoCriarCarro.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
            AoClicarNoBotaoCriarCarro.Location = new Point(12, 410);
            AoClicarNoBotaoCriarCarro.Name = "AoClicarNoBotaoCriarCarro";
            AoClicarNoBotaoCriarCarro.Size = new Size(94, 28);
            AoClicarNoBotaoCriarCarro.TabIndex = 9;
            AoClicarNoBotaoCriarCarro.Text = "Adicionar carro";
            AoClicarNoBotaoCriarCarro.UseVisualStyleBackColor = true;
            AoClicarNoBotaoCriarCarro.Click += AoClicarNoBotaoCriarCarro_Click;
            // 
            // AoClicarNoBotaoCancelarCarro
            // 
            AoClicarNoBotaoCancelarCarro.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            AoClicarNoBotaoCancelarCarro.Location = new Point(308, 410);
            AoClicarNoBotaoCancelarCarro.Name = "AoClicarNoBotaoCancelarCarro";
            AoClicarNoBotaoCancelarCarro.Size = new Size(94, 28);
            AoClicarNoBotaoCancelarCarro.TabIndex = 10;
            AoClicarNoBotaoCancelarCarro.Text = "Cancelar";
            AoClicarNoBotaoCancelarCarro.UseVisualStyleBackColor = true;
            AoClicarNoBotaoCancelarCarro.Click += AoClicarNoBotaoCancelarCarro_Click;
            // 
            // selecionarValorDoVeiculo
            // 
            selecionarValorDoVeiculo.AutoCompleteCustomSource.AddRange(new string[] { "R$   " });
            selecionarValorDoVeiculo.Location = new Point(12, 158);
            selecionarValorDoVeiculo.Name = "selecionarValorDoVeiculo";
            selecionarValorDoVeiculo.PlaceholderText = "R$";
            selecionarValorDoVeiculo.Size = new Size(196, 23);
            selecionarValorDoVeiculo.TabIndex = 13;
            selecionarValorDoVeiculo.KeyPress += selecionarValorDoVeiculo_KeyPress;
            // 
            // CriandoCarro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(414, 450);
            Controls.Add(selecionarValorDoVeiculo);
            Controls.Add(AoClicarNoBotaoCancelarCarro);
            Controls.Add(AoClicarNoBotaoCriarCarro);
            Controls.Add(selecionarFlex);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(selecionarCor);
            Controls.Add(label2);
            Controls.Add(selecionarMarca);
            Controls.Add(label1);
            Controls.Add(txtModelo);
            Name = "CriandoCarro";
            Text = "Form1";
            Load += FormCriandoCarro_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtModelo;
        private Label label1;
        private ComboBox selecionarMarca;
        private Label label2;
        private ComboBox selecionarCor;
        private Label label3;
        private Label label4;
        private CheckBox selecionarFlex;
        private Button AoClicarNoBotaoCriarCarro;
        private Button AoClicarNoBotaoCancelarCarro;
        private NumericUpDown numericUpDown1;
        private TextBox selecionarValorDoVeiculo;
    }
}