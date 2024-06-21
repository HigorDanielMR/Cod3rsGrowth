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
            AoClicarNoBotaoAdicionarCarro = new Button();
            AoClicarNoBotaoCancelarCarro = new Button();
            selecionarValorDoVeiculo = new TextBox();
            panel1 = new Panel();
            panel2 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // txtModelo
            // 
            txtModelo.Location = new Point(12, 40);
            txtModelo.Name = "txtModelo";
            txtModelo.Size = new Size(390, 23);
            txtModelo.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 18);
            label1.Name = "label1";
            label1.Size = new Size(61, 19);
            label1.TabIndex = 1;
            label1.Text = "Modelo";
            // 
            // selecionarMarca
            // 
            selecionarMarca.FormattingEnabled = true;
            selecionarMarca.Location = new Point(11, 97);
            selecionarMarca.Name = "selecionarMarca";
            selecionarMarca.Size = new Size(196, 23);
            selecionarMarca.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(11, 75);
            label2.Name = "label2";
            label2.Size = new Size(51, 19);
            label2.TabIndex = 3;
            label2.Text = "Marca";
            // 
            // selecionarCor
            // 
            selecionarCor.FormattingEnabled = true;
            selecionarCor.Location = new Point(213, 97);
            selecionarCor.Name = "selecionarCor";
            selecionarCor.Size = new Size(188, 23);
            selecionarCor.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(213, 75);
            label3.Name = "label3";
            label3.Size = new Size(33, 19);
            label3.TabIndex = 5;
            label3.Text = "Cor";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(11, 135);
            label4.Name = "label4";
            label4.Size = new Size(118, 19);
            label4.TabIndex = 7;
            label4.Text = "Valor do Veiculo";
            // 
            // selecionarFlex
            // 
            selecionarFlex.AutoSize = true;
            selecionarFlex.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            selecionarFlex.Location = new Point(346, 157);
            selecionarFlex.Name = "selecionarFlex";
            selecionarFlex.Size = new Size(55, 23);
            selecionarFlex.TabIndex = 8;
            selecionarFlex.Text = "Flex";
            selecionarFlex.UseVisualStyleBackColor = true;
            // 
            // AoClicarNoBotaoAdicionarCarro
            // 
            AoClicarNoBotaoAdicionarCarro.BackColor = Color.DarkGray;
            AoClicarNoBotaoAdicionarCarro.FlatStyle = FlatStyle.Flat;
            AoClicarNoBotaoAdicionarCarro.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            AoClicarNoBotaoAdicionarCarro.Location = new Point(11, 26);
            AoClicarNoBotaoAdicionarCarro.Name = "AoClicarNoBotaoAdicionarCarro";
            AoClicarNoBotaoAdicionarCarro.Size = new Size(94, 28);
            AoClicarNoBotaoAdicionarCarro.TabIndex = 9;
            AoClicarNoBotaoAdicionarCarro.Text = "Adicionar";
            AoClicarNoBotaoAdicionarCarro.UseVisualStyleBackColor = false;
            AoClicarNoBotaoAdicionarCarro.Click += AoClicarNoBotaoAdicionarCarro_Click;
            // 
            // AoClicarNoBotaoCancelarCarro
            // 
            AoClicarNoBotaoCancelarCarro.BackColor = Color.DarkGray;
            AoClicarNoBotaoCancelarCarro.FlatStyle = FlatStyle.Flat;
            AoClicarNoBotaoCancelarCarro.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            AoClicarNoBotaoCancelarCarro.Location = new Point(307, 26);
            AoClicarNoBotaoCancelarCarro.Name = "AoClicarNoBotaoCancelarCarro";
            AoClicarNoBotaoCancelarCarro.Size = new Size(94, 28);
            AoClicarNoBotaoCancelarCarro.TabIndex = 10;
            AoClicarNoBotaoCancelarCarro.Text = "Cancelar";
            AoClicarNoBotaoCancelarCarro.UseVisualStyleBackColor = false;
            AoClicarNoBotaoCancelarCarro.Click += AoClicarNoBotaoCancelarCarro_Click;
            // 
            // selecionarValorDoVeiculo
            // 
            selecionarValorDoVeiculo.AutoCompleteCustomSource.AddRange(new string[] { "R$   " });
            selecionarValorDoVeiculo.Location = new Point(11, 157);
            selecionarValorDoVeiculo.Name = "selecionarValorDoVeiculo";
            selecionarValorDoVeiculo.PlaceholderText = "R$";
            selecionarValorDoVeiculo.Size = new Size(196, 23);
            selecionarValorDoVeiculo.TabIndex = 13;
            selecionarValorDoVeiculo.Text = "0,00";
            selecionarValorDoVeiculo.TextChanged += selecionarValorDoVeiculo_TextChanged;
            selecionarValorDoVeiculo.KeyPress += selecionarValorDoVeiculo_KeyPress;
            // 
            // panel1
            // 
            panel1.Controls.Add(AoClicarNoBotaoAdicionarCarro);
            panel1.Controls.Add(AoClicarNoBotaoCancelarCarro);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 232);
            panel1.Name = "panel1";
            panel1.Size = new Size(414, 63);
            panel1.TabIndex = 14;
            // 
            // panel2
            // 
            panel2.Controls.Add(selecionarValorDoVeiculo);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(txtModelo);
            panel2.Controls.Add(selecionarFlex);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(selecionarCor);
            panel2.Controls.Add(selecionarMarca);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(414, 232);
            panel2.TabIndex = 15;
            // 
            // CriandoCarro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(414, 295);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "CriandoCarro";
            Text = "Cadatro de Carro";
            Load += FormCriandoCarro_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
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
        private Button AoClicarNoBotaoAdicionarCarro;
        private Button AoClicarNoBotaoCancelarCarro;
        private NumericUpDown numericUpDown1;
        private TextBox selecionarValorDoVeiculo;
        private Panel panel1;
        private Panel panel2;
    }
}