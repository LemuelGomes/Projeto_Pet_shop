namespace Projeto_Pet_shop
{
    partial class Form_CadProdutos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_CadProdutos));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxDESCPRODUTO = new System.Windows.Forms.TextBox();
            this.textBoxCATPRODUTO = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxVALORPRODUTO = new System.Windows.Forms.TextBox();
            this.buttonCadProd = new System.Windows.Forms.Button();
            this.buttonFECHAR = new System.Windows.Forms.Button();
            this.buttonEXCLUIR = new System.Windows.Forms.Button();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridViewPRODUTOS = new System.Windows.Forms.DataGridView();
            this.buttonATUALIZAR = new System.Windows.Forms.Button();
            this.buttonATUALIZARL = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPRODUTOS)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(-5, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(726, 43);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cadastro de Produtos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.Location = new System.Drawing.Point(12, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(246, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Descrição do Produto";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxDESCPRODUTO
            // 
            this.textBoxDESCPRODUTO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxDESCPRODUTO.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDESCPRODUTO.Location = new System.Drawing.Point(10, 150);
            this.textBoxDESCPRODUTO.Multiline = true;
            this.textBoxDESCPRODUTO.Name = "textBoxDESCPRODUTO";
            this.textBoxDESCPRODUTO.Size = new System.Drawing.Size(331, 78);
            this.textBoxDESCPRODUTO.TabIndex = 2;
            // 
            // textBoxCATPRODUTO
            // 
            this.textBoxCATPRODUTO.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxCATPRODUTO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCATPRODUTO.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCATPRODUTO.Location = new System.Drawing.Point(10, 275);
            this.textBoxCATPRODUTO.Name = "textBoxCATPRODUTO";
            this.textBoxCATPRODUTO.Size = new System.Drawing.Size(331, 29);
            this.textBoxCATPRODUTO.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.SteelBlue;
            this.label3.Location = new System.Drawing.Point(12, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(243, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "Categoria do Produto";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.SteelBlue;
            this.label4.Location = new System.Drawing.Point(12, 352);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Valor do Produto";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxVALORPRODUTO
            // 
            this.textBoxVALORPRODUTO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxVALORPRODUTO.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxVALORPRODUTO.Location = new System.Drawing.Point(10, 384);
            this.textBoxVALORPRODUTO.Name = "textBoxVALORPRODUTO";
            this.textBoxVALORPRODUTO.Size = new System.Drawing.Size(175, 29);
            this.textBoxVALORPRODUTO.TabIndex = 6;
            // 
            // buttonCadProd
            // 
            this.buttonCadProd.BackColor = System.Drawing.Color.White;
            this.buttonCadProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCadProd.ForeColor = System.Drawing.Color.SteelBlue;
            this.buttonCadProd.Image = global::Projeto_Pet_shop.Properties.Resources.salvar_buttom;
            this.buttonCadProd.Location = new System.Drawing.Point(9, 446);
            this.buttonCadProd.Name = "buttonCadProd";
            this.buttonCadProd.Size = new System.Drawing.Size(197, 41);
            this.buttonCadProd.TabIndex = 7;
            this.buttonCadProd.Text = "Cadastrar Produto";
            this.buttonCadProd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCadProd.UseVisualStyleBackColor = false;
            this.buttonCadProd.Click += new System.EventHandler(this.buttonCadProd_Click);
            // 
            // buttonFECHAR
            // 
            this.buttonFECHAR.BackColor = System.Drawing.Color.White;
            this.buttonFECHAR.FlatAppearance.BorderSize = 0;
            this.buttonFECHAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFECHAR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFECHAR.ForeColor = System.Drawing.Color.SteelBlue;
            this.buttonFECHAR.Image = global::Projeto_Pet_shop.Properties.Resources.sair_button;
            this.buttonFECHAR.Location = new System.Drawing.Point(741, 453);
            this.buttonFECHAR.Name = "buttonFECHAR";
            this.buttonFECHAR.Size = new System.Drawing.Size(97, 37);
            this.buttonFECHAR.TabIndex = 8;
            this.buttonFECHAR.Text = "Fechar";
            this.buttonFECHAR.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonFECHAR.UseVisualStyleBackColor = false;
            this.buttonFECHAR.Click += new System.EventHandler(this.buttonFECHAR_Click);
            // 
            // buttonEXCLUIR
            // 
            this.buttonEXCLUIR.BackColor = System.Drawing.Color.White;
            this.buttonEXCLUIR.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEXCLUIR.ForeColor = System.Drawing.Color.SteelBlue;
            this.buttonEXCLUIR.Image = global::Projeto_Pet_shop.Properties.Resources.excluir__1_;
            this.buttonEXCLUIR.Location = new System.Drawing.Point(244, 446);
            this.buttonEXCLUIR.Name = "buttonEXCLUIR";
            this.buttonEXCLUIR.Size = new System.Drawing.Size(172, 41);
            this.buttonEXCLUIR.TabIndex = 9;
            this.buttonEXCLUIR.Text = "Excluir Produto";
            this.buttonEXCLUIR.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonEXCLUIR.UseVisualStyleBackColor = false;
            this.buttonEXCLUIR.Click += new System.EventHandler(this.buttonEXCLUIR_Click);
            // 
            // textBoxID
            // 
            this.textBoxID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxID.Location = new System.Drawing.Point(313, 380);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(172, 29);
            this.textBoxID.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.SteelBlue;
            this.label5.Location = new System.Drawing.Point(384, 352);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 25);
            this.label5.TabIndex = 11;
            this.label5.Text = "ID";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridViewPRODUTOS
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewPRODUTOS.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewPRODUTOS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPRODUTOS.Location = new System.Drawing.Point(390, 91);
            this.dataGridViewPRODUTOS.Name = "dataGridViewPRODUTOS";
            this.dataGridViewPRODUTOS.Size = new System.Drawing.Size(448, 213);
            this.dataGridViewPRODUTOS.TabIndex = 12;
            this.dataGridViewPRODUTOS.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPRODUTOS_CellEndEdit);
            this.dataGridViewPRODUTOS.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewPRODUTOS_MouseClick);
            // 
            // buttonATUALIZAR
            // 
            this.buttonATUALIZAR.BackColor = System.Drawing.Color.White;
            this.buttonATUALIZAR.FlatAppearance.BorderSize = 0;
            this.buttonATUALIZAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonATUALIZAR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonATUALIZAR.ForeColor = System.Drawing.Color.SteelBlue;
            this.buttonATUALIZAR.Image = global::Projeto_Pet_shop.Properties.Resources.setas_circulares;
            this.buttonATUALIZAR.Location = new System.Drawing.Point(627, 310);
            this.buttonATUALIZAR.Name = "buttonATUALIZAR";
            this.buttonATUALIZAR.Size = new System.Drawing.Size(211, 37);
            this.buttonATUALIZAR.TabIndex = 13;
            this.buttonATUALIZAR.Text = "Atualizar lista de Produtos";
            this.buttonATUALIZAR.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonATUALIZAR.UseVisualStyleBackColor = false;
            this.buttonATUALIZAR.Click += new System.EventHandler(this.buttonATUALIZAR_Click);
            // 
            // buttonATUALIZARL
            // 
            this.buttonATUALIZARL.BackColor = System.Drawing.Color.White;
            this.buttonATUALIZARL.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonATUALIZARL.ForeColor = System.Drawing.Color.SteelBlue;
            this.buttonATUALIZARL.Image = global::Projeto_Pet_shop.Properties.Resources.setas_circulares;
            this.buttonATUALIZARL.Location = new System.Drawing.Point(451, 446);
            this.buttonATUALIZARL.Name = "buttonATUALIZARL";
            this.buttonATUALIZARL.Size = new System.Drawing.Size(113, 41);
            this.buttonATUALIZARL.TabIndex = 14;
            this.buttonATUALIZARL.Text = "Atualizar";
            this.buttonATUALIZARL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonATUALIZARL.UseVisualStyleBackColor = false;
            this.buttonATUALIZARL.Click += new System.EventHandler(this.buttonATUALIZARL_Click);
            // 
            // FormCadProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Projeto_Pet_shop.Properties.Resources._17545;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(850, 502);
            this.Controls.Add(this.buttonATUALIZARL);
            this.Controls.Add(this.buttonATUALIZAR);
            this.Controls.Add(this.dataGridViewPRODUTOS);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.buttonEXCLUIR);
            this.Controls.Add(this.buttonFECHAR);
            this.Controls.Add(this.buttonCadProd);
            this.Controls.Add(this.textBoxVALORPRODUTO);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxCATPRODUTO);
            this.Controls.Add(this.textBoxDESCPRODUTO);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCadProdutos";
            this.Text = "Cadastro de Produtos";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPRODUTOS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxDESCPRODUTO;
        private System.Windows.Forms.TextBox textBoxCATPRODUTO;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxVALORPRODUTO;
        private System.Windows.Forms.Button buttonCadProd;
        private System.Windows.Forms.Button buttonFECHAR;
        private System.Windows.Forms.Button buttonEXCLUIR;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridViewPRODUTOS;
        private System.Windows.Forms.Button buttonATUALIZAR;
        private System.Windows.Forms.Button buttonATUALIZARL;
    }
}