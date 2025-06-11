namespace Projeto_Pet_shop
{
    partial class Form_CadColaborador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_CadColaborador));
            this.button_Cadastrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_Nome = new System.Windows.Forms.TextBox();
            this.textBox_Sobrenome = new System.Windows.Forms.TextBox();
            this.textBox_Email = new System.Windows.Forms.TextBox();
            this.textBox_CPF = new System.Windows.Forms.TextBox();
            this.textBox_Senha = new System.Windows.Forms.TextBox();
            this.dateTimePicker_Admissao = new System.Windows.Forms.DateTimePicker();
            this.textBox_Cargo = new System.Windows.Forms.TextBox();
            this.groupBox_Departamento = new System.Windows.Forms.GroupBox();
            this.radioButton_Operador = new System.Windows.Forms.RadioButton();
            this.radioButton_ADM = new System.Windows.Forms.RadioButton();
            this.button_Sair = new System.Windows.Forms.Button();
            this.groupBox_Departamento.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Cadastrar
            // 
            this.button_Cadastrar.BackColor = System.Drawing.Color.Transparent;
            this.button_Cadastrar.FlatAppearance.BorderSize = 0;
            this.button_Cadastrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Cadastrar.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Cadastrar.ForeColor = System.Drawing.Color.Green;
            this.button_Cadastrar.Image = ((System.Drawing.Image)(resources.GetObject("button_Cadastrar.Image")));
            this.button_Cadastrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Cadastrar.Location = new System.Drawing.Point(59, 523);
            this.button_Cadastrar.Name = "button_Cadastrar";
            this.button_Cadastrar.Size = new System.Drawing.Size(205, 41);
            this.button_Cadastrar.TabIndex = 0;
            this.button_Cadastrar.Text = "Cadastrar";
            this.button_Cadastrar.UseVisualStyleBackColor = false;
            this.button_Cadastrar.Click += new System.EventHandler(this.button_Cadastrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nome do Colaborador";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(274, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sobrenome do Colaborador";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "CPF";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 266);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(224, 23);
            this.label5.TabIndex = 5;
            this.label5.Text = "Senha do Colaborador";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 326);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(183, 23);
            this.label6.TabIndex = 6;
            this.label6.Text = "Data de Admissão";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 386);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 23);
            this.label7.TabIndex = 7;
            this.label7.Text = "Cargo";
            // 
            // textBox_Nome
            // 
            this.textBox_Nome.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Nome.Location = new System.Drawing.Point(12, 54);
            this.textBox_Nome.Name = "textBox_Nome";
            this.textBox_Nome.Size = new System.Drawing.Size(269, 26);
            this.textBox_Nome.TabIndex = 8;
            // 
            // textBox_Sobrenome
            // 
            this.textBox_Sobrenome.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Sobrenome.Location = new System.Drawing.Point(12, 111);
            this.textBox_Sobrenome.Name = "textBox_Sobrenome";
            this.textBox_Sobrenome.Size = new System.Drawing.Size(269, 26);
            this.textBox_Sobrenome.TabIndex = 9;
            // 
            // textBox_Email
            // 
            this.textBox_Email.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Email.Location = new System.Drawing.Point(12, 170);
            this.textBox_Email.Name = "textBox_Email";
            this.textBox_Email.Size = new System.Drawing.Size(269, 26);
            this.textBox_Email.TabIndex = 10;
            // 
            // textBox_CPF
            // 
            this.textBox_CPF.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_CPF.Location = new System.Drawing.Point(12, 231);
            this.textBox_CPF.Name = "textBox_CPF";
            this.textBox_CPF.Size = new System.Drawing.Size(269, 26);
            this.textBox_CPF.TabIndex = 11;
            // 
            // textBox_Senha
            // 
            this.textBox_Senha.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Senha.Location = new System.Drawing.Point(12, 292);
            this.textBox_Senha.Name = "textBox_Senha";
            this.textBox_Senha.Size = new System.Drawing.Size(269, 26);
            this.textBox_Senha.TabIndex = 12;
            // 
            // dateTimePicker_Admissao
            // 
            this.dateTimePicker_Admissao.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_Admissao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_Admissao.Location = new System.Drawing.Point(12, 352);
            this.dateTimePicker_Admissao.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker_Admissao.Name = "dateTimePicker_Admissao";
            this.dateTimePicker_Admissao.Size = new System.Drawing.Size(269, 26);
            this.dateTimePicker_Admissao.TabIndex = 13;
            this.dateTimePicker_Admissao.Value = new System.DateTime(2025, 5, 20, 19, 39, 13, 0);
            // 
            // textBox_Cargo
            // 
            this.textBox_Cargo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Cargo.Location = new System.Drawing.Point(12, 412);
            this.textBox_Cargo.Name = "textBox_Cargo";
            this.textBox_Cargo.Size = new System.Drawing.Size(269, 26);
            this.textBox_Cargo.TabIndex = 14;
            // 
            // groupBox_Departamento
            // 
            this.groupBox_Departamento.Controls.Add(this.radioButton_Operador);
            this.groupBox_Departamento.Controls.Add(this.radioButton_ADM);
            this.groupBox_Departamento.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_Departamento.Location = new System.Drawing.Point(12, 444);
            this.groupBox_Departamento.Name = "groupBox_Departamento";
            this.groupBox_Departamento.Size = new System.Drawing.Size(269, 56);
            this.groupBox_Departamento.TabIndex = 15;
            this.groupBox_Departamento.TabStop = false;
            this.groupBox_Departamento.Text = "Departamento";
            // 
            // radioButton_Operador
            // 
            this.radioButton_Operador.AutoSize = true;
            this.radioButton_Operador.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_Operador.Location = new System.Drawing.Point(162, 26);
            this.radioButton_Operador.Name = "radioButton_Operador";
            this.radioButton_Operador.Size = new System.Drawing.Size(93, 22);
            this.radioButton_Operador.TabIndex = 1;
            this.radioButton_Operador.TabStop = true;
            this.radioButton_Operador.Text = "Operador";
            this.radioButton_Operador.UseVisualStyleBackColor = true;
            // 
            // radioButton_ADM
            // 
            this.radioButton_ADM.AutoSize = true;
            this.radioButton_ADM.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_ADM.Location = new System.Drawing.Point(6, 26);
            this.radioButton_ADM.Name = "radioButton_ADM";
            this.radioButton_ADM.Size = new System.Drawing.Size(124, 22);
            this.radioButton_ADM.TabIndex = 0;
            this.radioButton_ADM.TabStop = true;
            this.radioButton_ADM.Text = "Administrador";
            this.radioButton_ADM.UseVisualStyleBackColor = true;
            // 
            // button_Sair
            // 
            this.button_Sair.BackColor = System.Drawing.Color.Transparent;
            this.button_Sair.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_Sair.FlatAppearance.BorderSize = 0;
            this.button_Sair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Sair.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Sair.Image = ((System.Drawing.Image)(resources.GetObject("button_Sair.Image")));
            this.button_Sair.Location = new System.Drawing.Point(455, 525);
            this.button_Sair.Name = "button_Sair";
            this.button_Sair.Size = new System.Drawing.Size(47, 41);
            this.button_Sair.TabIndex = 16;
            this.button_Sair.UseVisualStyleBackColor = false;
            this.button_Sair.Click += new System.EventHandler(this.button_Sair_Click);
            // 
            // Form_CadColaborador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(514, 578);
            this.Controls.Add(this.button_Sair);
            this.Controls.Add(this.groupBox_Departamento);
            this.Controls.Add(this.textBox_Cargo);
            this.Controls.Add(this.dateTimePicker_Admissao);
            this.Controls.Add(this.textBox_Senha);
            this.Controls.Add(this.textBox_CPF);
            this.Controls.Add(this.textBox_Email);
            this.Controls.Add(this.textBox_Sobrenome);
            this.Controls.Add(this.textBox_Nome);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Cadastrar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_CadColaborador";
            this.Text = "Cadastro de Colaborador";
            this.groupBox_Departamento.ResumeLayout(false);
            this.groupBox_Departamento.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Cadastrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_Nome;
        private System.Windows.Forms.TextBox textBox_Sobrenome;
        private System.Windows.Forms.TextBox textBox_Email;
        private System.Windows.Forms.TextBox textBox_CPF;
        private System.Windows.Forms.TextBox textBox_Senha;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Admissao;
        private System.Windows.Forms.TextBox textBox_Cargo;
        private System.Windows.Forms.GroupBox groupBox_Departamento;
        private System.Windows.Forms.RadioButton radioButton_Operador;
        private System.Windows.Forms.RadioButton radioButton_ADM;
        private System.Windows.Forms.Button button_Sair;
    }
}