namespace Projeto_Pet_shop
{
    partial class Form_Login
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Login));
            this.button_Entrar = new System.Windows.Forms.Button();
            this.button_Limpar = new System.Windows.Forms.Button();
            this.textBox_Usuario = new System.Windows.Forms.TextBox();
            this.textBox_Senha = new System.Windows.Forms.TextBox();
            this.labelUSUARIO = new System.Windows.Forms.Label();
            this.labelSENHA = new System.Windows.Forms.Label();
            this.labelERRO = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_Entrar
            // 
            this.button_Entrar.BackColor = System.Drawing.Color.Transparent;
            this.button_Entrar.FlatAppearance.BorderSize = 0;
            this.button_Entrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Entrar.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Entrar.ForeColor = System.Drawing.Color.Lime;
            this.button_Entrar.Location = new System.Drawing.Point(12, 511);
            this.button_Entrar.Name = "button_Entrar";
            this.button_Entrar.Size = new System.Drawing.Size(83, 36);
            this.button_Entrar.TabIndex = 0;
            this.button_Entrar.Text = "Entrar";
            this.button_Entrar.UseVisualStyleBackColor = false;
            this.button_Entrar.Click += new System.EventHandler(this.button_Entrar_Click);
            // 
            // button_Limpar
            // 
            this.button_Limpar.BackColor = System.Drawing.Color.Transparent;
            this.button_Limpar.FlatAppearance.BorderSize = 0;
            this.button_Limpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Limpar.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Limpar.ForeColor = System.Drawing.Color.Yellow;
            this.button_Limpar.Location = new System.Drawing.Point(460, 511);
            this.button_Limpar.Name = "button_Limpar";
            this.button_Limpar.Size = new System.Drawing.Size(90, 36);
            this.button_Limpar.TabIndex = 1;
            this.button_Limpar.Text = "Limpar";
            this.button_Limpar.UseVisualStyleBackColor = false;
            this.button_Limpar.Click += new System.EventHandler(this.button_Limpar_Click);
            // 
            // textBox_Usuario
            // 
            this.textBox_Usuario.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Usuario.Location = new System.Drawing.Point(179, 477);
            this.textBox_Usuario.Name = "textBox_Usuario";
            this.textBox_Usuario.Size = new System.Drawing.Size(215, 26);
            this.textBox_Usuario.TabIndex = 3;
            // 
            // textBox_Senha
            // 
            this.textBox_Senha.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Senha.Location = new System.Drawing.Point(182, 543);
            this.textBox_Senha.Name = "textBox_Senha";
            this.textBox_Senha.PasswordChar = '●';
            this.textBox_Senha.Size = new System.Drawing.Size(212, 26);
            this.textBox_Senha.TabIndex = 4;
            // 
            // labelUSUARIO
            // 
            this.labelUSUARIO.AutoSize = true;
            this.labelUSUARIO.BackColor = System.Drawing.Color.CornflowerBlue;
            this.labelUSUARIO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelUSUARIO.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUSUARIO.ForeColor = System.Drawing.Color.White;
            this.labelUSUARIO.Location = new System.Drawing.Point(239, 451);
            this.labelUSUARIO.Name = "labelUSUARIO";
            this.labelUSUARIO.Size = new System.Drawing.Size(83, 23);
            this.labelUSUARIO.TabIndex = 5;
            this.labelUSUARIO.Text = "Usuário";
            this.labelUSUARIO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSENHA
            // 
            this.labelSENHA.AutoSize = true;
            this.labelSENHA.BackColor = System.Drawing.Color.CornflowerBlue;
            this.labelSENHA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelSENHA.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSENHA.ForeColor = System.Drawing.Color.White;
            this.labelSENHA.Location = new System.Drawing.Point(246, 517);
            this.labelSENHA.Name = "labelSENHA";
            this.labelSENHA.Size = new System.Drawing.Size(69, 23);
            this.labelSENHA.TabIndex = 6;
            this.labelSENHA.Text = "Senha";
            this.labelSENHA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelERRO
            // 
            this.labelERRO.BackColor = System.Drawing.Color.Transparent;
            this.labelERRO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelERRO.ForeColor = System.Drawing.Color.Crimson;
            this.labelERRO.Location = new System.Drawing.Point(179, 501);
            this.labelERRO.Name = "labelERRO";
            this.labelERRO.Size = new System.Drawing.Size(215, 15);
            this.labelERRO.TabIndex = 7;
            this.labelERRO.Text = "Usuário e/ou Senha Incorretos!";
            this.labelERRO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Projeto_Pet_shop.Properties.Resources.Imagem_Loja_Petshop_Amigos_Nat;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(562, 576);
            this.Controls.Add(this.labelERRO);
            this.Controls.Add(this.labelSENHA);
            this.Controls.Add(this.labelUSUARIO);
            this.Controls.Add(this.textBox_Senha);
            this.Controls.Add(this.textBox_Usuario);
            this.Controls.Add(this.button_Limpar);
            this.Controls.Add(this.button_Entrar);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Login";
            this.Text = "Pet_Shop";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Login_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Entrar;
        private System.Windows.Forms.Button button_Limpar;
        private System.Windows.Forms.TextBox textBox_Usuario;
        private System.Windows.Forms.TextBox textBox_Senha;
        private System.Windows.Forms.Label labelUSUARIO;
        private System.Windows.Forms.Label labelSENHA;
        private System.Windows.Forms.Label labelERRO;
    }
}

