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
            this.buttonENTRAR = new System.Windows.Forms.Button();
            this.buttonLIMPAR = new System.Windows.Forms.Button();
            this.textBoxUSUARIO = new System.Windows.Forms.TextBox();
            this.textBoxSENHA = new System.Windows.Forms.TextBox();
            this.labelUSUARIO = new System.Windows.Forms.Label();
            this.labelSENHA = new System.Windows.Forms.Label();
            this.labelERRO = new System.Windows.Forms.Label();
            this.buttonFECHAR = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonENTRAR
            // 
            this.buttonENTRAR.BackColor = System.Drawing.Color.DarkBlue;
            this.buttonENTRAR.FlatAppearance.BorderSize = 0;
            this.buttonENTRAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonENTRAR.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonENTRAR.ForeColor = System.Drawing.Color.White;
            this.buttonENTRAR.Location = new System.Drawing.Point(12, 455);
            this.buttonENTRAR.Name = "buttonENTRAR";
            this.buttonENTRAR.Size = new System.Drawing.Size(83, 36);
            this.buttonENTRAR.TabIndex = 0;
            this.buttonENTRAR.Text = "Entrar";
            this.buttonENTRAR.UseVisualStyleBackColor = false;
            this.buttonENTRAR.Click += new System.EventHandler(this.buttonENTRAR_Click);
            // 
            // buttonLIMPAR
            // 
            this.buttonLIMPAR.BackColor = System.Drawing.Color.DarkGray;
            this.buttonLIMPAR.FlatAppearance.BorderSize = 0;
            this.buttonLIMPAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLIMPAR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLIMPAR.ForeColor = System.Drawing.Color.White;
            this.buttonLIMPAR.Location = new System.Drawing.Point(467, 425);
            this.buttonLIMPAR.Name = "buttonLIMPAR";
            this.buttonLIMPAR.Size = new System.Drawing.Size(83, 36);
            this.buttonLIMPAR.TabIndex = 1;
            this.buttonLIMPAR.Text = "Limpar";
            this.buttonLIMPAR.UseVisualStyleBackColor = false;
            this.buttonLIMPAR.Click += new System.EventHandler(this.buttonLIMPAR_Click);
            // 
            // textBoxUSUARIO
            // 
            this.textBoxUSUARIO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUSUARIO.Location = new System.Drawing.Point(179, 477);
            this.textBoxUSUARIO.Name = "textBoxUSUARIO";
            this.textBoxUSUARIO.Size = new System.Drawing.Size(215, 22);
            this.textBoxUSUARIO.TabIndex = 3;
            // 
            // textBoxSENHA
            // 
            this.textBoxSENHA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSENHA.Location = new System.Drawing.Point(224, 543);
            this.textBoxSENHA.Name = "textBoxSENHA";
            this.textBoxSENHA.PasswordChar = '●';
            this.textBoxSENHA.Size = new System.Drawing.Size(124, 22);
            this.textBoxSENHA.TabIndex = 4;
            // 
            // labelUSUARIO
            // 
            this.labelUSUARIO.BackColor = System.Drawing.Color.CornflowerBlue;
            this.labelUSUARIO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelUSUARIO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUSUARIO.ForeColor = System.Drawing.Color.White;
            this.labelUSUARIO.Location = new System.Drawing.Point(240, 455);
            this.labelUSUARIO.Name = "labelUSUARIO";
            this.labelUSUARIO.Size = new System.Drawing.Size(90, 19);
            this.labelUSUARIO.TabIndex = 5;
            this.labelUSUARIO.Text = "Usuário";
            this.labelUSUARIO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSENHA
            // 
            this.labelSENHA.BackColor = System.Drawing.Color.CornflowerBlue;
            this.labelSENHA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelSENHA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSENHA.ForeColor = System.Drawing.Color.White;
            this.labelSENHA.Location = new System.Drawing.Point(240, 521);
            this.labelSENHA.Name = "labelSENHA";
            this.labelSENHA.Size = new System.Drawing.Size(90, 19);
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
            // buttonFECHAR
            // 
            this.buttonFECHAR.BackColor = System.Drawing.Color.DarkGray;
            this.buttonFECHAR.FlatAppearance.BorderSize = 0;
            this.buttonFECHAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFECHAR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFECHAR.ForeColor = System.Drawing.Color.Red;
            this.buttonFECHAR.Location = new System.Drawing.Point(467, 486);
            this.buttonFECHAR.Name = "buttonFECHAR";
            this.buttonFECHAR.Size = new System.Drawing.Size(83, 36);
            this.buttonFECHAR.TabIndex = 8;
            this.buttonFECHAR.Text = "Fechar";
            this.buttonFECHAR.UseVisualStyleBackColor = false;
            this.buttonFECHAR.Click += new System.EventHandler(this.buttonFECHAR_Click);
            // 
            // Form_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Projeto_Pet_shop.Properties.Resources.Imagem_Loja_Petshop_Amigos_Nat;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(562, 567);
            this.Controls.Add(this.buttonFECHAR);
            this.Controls.Add(this.labelERRO);
            this.Controls.Add(this.labelSENHA);
            this.Controls.Add(this.labelUSUARIO);
            this.Controls.Add(this.textBoxSENHA);
            this.Controls.Add(this.textBoxUSUARIO);
            this.Controls.Add(this.buttonLIMPAR);
            this.Controls.Add(this.buttonENTRAR);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Login";
            this.Text = "Pet_Shop";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonENTRAR;
        private System.Windows.Forms.Button buttonLIMPAR;
        private System.Windows.Forms.TextBox textBoxUSUARIO;
        private System.Windows.Forms.TextBox textBoxSENHA;
        private System.Windows.Forms.Label labelUSUARIO;
        private System.Windows.Forms.Label labelSENHA;
        private System.Windows.Forms.Label labelERRO;
        private System.Windows.Forms.Button buttonFECHAR;
    }
}

