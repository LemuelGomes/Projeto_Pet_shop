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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_CadProdutos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Descricao = new System.Windows.Forms.TextBox();
            this.textBox_Categoria = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_PrecoCusto = new System.Windows.Forms.TextBox();
            this.button_CadProduto = new System.Windows.Forms.Button();
            this.button_Fechar = new System.Windows.Forms.Button();
            this.button_ExcluirProd = new System.Windows.Forms.Button();
            this.dataGridViewPRODUTOS = new System.Windows.Forms.DataGridView();
            this.button_AtualizarLista = new System.Windows.Forms.Button();
            this.button_Atualizar = new System.Windows.Forms.Button();
            this.textBox_PrecoVenda = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_Quantidade = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPRODUTOS)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(410, 43);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cadastro de Produtos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.Location = new System.Drawing.Point(80, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(269, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Descrição do Produto";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_Descricao
            // 
            this.textBox_Descricao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Descricao.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Descricao.Location = new System.Drawing.Point(19, 134);
            this.textBox_Descricao.Name = "textBox_Descricao";
            this.textBox_Descricao.Size = new System.Drawing.Size(368, 29);
            this.textBox_Descricao.TabIndex = 2;
            // 
            // textBox_Categoria
            // 
            this.textBox_Categoria.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_Categoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Categoria.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Categoria.Location = new System.Drawing.Point(19, 211);
            this.textBox_Categoria.Name = "textBox_Categoria";
            this.textBox_Categoria.Size = new System.Drawing.Size(368, 29);
            this.textBox_Categoria.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.SteelBlue;
            this.label3.Location = new System.Drawing.Point(80, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(266, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "Categoria do Produto";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.SteelBlue;
            this.label4.Location = new System.Drawing.Point(20, 263);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Preço de Custo";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_PrecoCusto
            // 
            this.textBox_PrecoCusto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_PrecoCusto.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_PrecoCusto.Location = new System.Drawing.Point(19, 291);
            this.textBox_PrecoCusto.Name = "textBox_PrecoCusto";
            this.textBox_PrecoCusto.Size = new System.Drawing.Size(172, 29);
            this.textBox_PrecoCusto.TabIndex = 6;
            // 
            // button_CadProduto
            // 
            this.button_CadProduto.BackColor = System.Drawing.Color.Transparent;
            this.button_CadProduto.FlatAppearance.BorderSize = 0;
            this.button_CadProduto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_CadProduto.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_CadProduto.ForeColor = System.Drawing.Color.SteelBlue;
            this.button_CadProduto.Image = ((System.Drawing.Image)(resources.GetObject("button_CadProduto.Image")));
            this.button_CadProduto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_CadProduto.Location = new System.Drawing.Point(85, 439);
            this.button_CadProduto.Name = "button_CadProduto";
            this.button_CadProduto.Size = new System.Drawing.Size(222, 41);
            this.button_CadProduto.TabIndex = 7;
            this.button_CadProduto.Text = "Cadastrar Produto";
            this.button_CadProduto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_CadProduto.UseVisualStyleBackColor = false;
            this.button_CadProduto.Click += new System.EventHandler(this.button_CadProduto_Click);
            // 
            // button_Fechar
            // 
            this.button_Fechar.BackColor = System.Drawing.Color.Transparent;
            this.button_Fechar.FlatAppearance.BorderSize = 0;
            this.button_Fechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Fechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Fechar.ForeColor = System.Drawing.Color.SteelBlue;
            this.button_Fechar.Image = ((System.Drawing.Image)(resources.GetObject("button_Fechar.Image")));
            this.button_Fechar.Location = new System.Drawing.Point(1083, 458);
            this.button_Fechar.Name = "button_Fechar";
            this.button_Fechar.Size = new System.Drawing.Size(69, 42);
            this.button_Fechar.TabIndex = 8;
            this.button_Fechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Fechar.UseVisualStyleBackColor = false;
            this.button_Fechar.Click += new System.EventHandler(this.buttonFECHAR_Click);
            // 
            // button_ExcluirProd
            // 
            this.button_ExcluirProd.BackColor = System.Drawing.Color.Transparent;
            this.button_ExcluirProd.FlatAppearance.BorderSize = 0;
            this.button_ExcluirProd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ExcluirProd.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ExcluirProd.ForeColor = System.Drawing.Color.SteelBlue;
            this.button_ExcluirProd.Image = ((System.Drawing.Image)(resources.GetObject("button_ExcluirProd.Image")));
            this.button_ExcluirProd.Location = new System.Drawing.Point(427, 387);
            this.button_ExcluirProd.Name = "button_ExcluirProd";
            this.button_ExcluirProd.Size = new System.Drawing.Size(196, 41);
            this.button_ExcluirProd.TabIndex = 9;
            this.button_ExcluirProd.Text = "Excluir Produto";
            this.button_ExcluirProd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_ExcluirProd.UseVisualStyleBackColor = false;
            this.button_ExcluirProd.Click += new System.EventHandler(this.button_ExcluirProd_Click);
            // 
            // dataGridViewPRODUTOS
            // 
            this.dataGridViewPRODUTOS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewPRODUTOS.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewPRODUTOS.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewPRODUTOS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DarkBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewPRODUTOS.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewPRODUTOS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPRODUTOS.Location = new System.Drawing.Point(427, 93);
            this.dataGridViewPRODUTOS.Name = "dataGridViewPRODUTOS";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewPRODUTOS.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewPRODUTOS.Size = new System.Drawing.Size(725, 288);
            this.dataGridViewPRODUTOS.TabIndex = 12;
            // 
            // button_AtualizarLista
            // 
            this.button_AtualizarLista.BackColor = System.Drawing.Color.Transparent;
            this.button_AtualizarLista.FlatAppearance.BorderSize = 0;
            this.button_AtualizarLista.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_AtualizarLista.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_AtualizarLista.ForeColor = System.Drawing.Color.SteelBlue;
            this.button_AtualizarLista.Image = ((System.Drawing.Image)(resources.GetObject("button_AtualizarLista.Image")));
            this.button_AtualizarLista.Location = new System.Drawing.Point(910, 387);
            this.button_AtualizarLista.Name = "button_AtualizarLista";
            this.button_AtualizarLista.Size = new System.Drawing.Size(242, 37);
            this.button_AtualizarLista.TabIndex = 13;
            this.button_AtualizarLista.Text = "Atualizar lista de Produtos";
            this.button_AtualizarLista.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_AtualizarLista.UseVisualStyleBackColor = false;
            this.button_AtualizarLista.Click += new System.EventHandler(this.button_AtualizarLista_Click);
            // 
            // button_Atualizar
            // 
            this.button_Atualizar.BackColor = System.Drawing.Color.Transparent;
            this.button_Atualizar.FlatAppearance.BorderSize = 0;
            this.button_Atualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Atualizar.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Atualizar.ForeColor = System.Drawing.Color.SteelBlue;
            this.button_Atualizar.Image = ((System.Drawing.Image)(resources.GetObject("button_Atualizar.Image")));
            this.button_Atualizar.Location = new System.Drawing.Point(664, 387);
            this.button_Atualizar.Name = "button_Atualizar";
            this.button_Atualizar.Size = new System.Drawing.Size(135, 41);
            this.button_Atualizar.TabIndex = 14;
            this.button_Atualizar.Text = "Atualizar";
            this.button_Atualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Atualizar.UseVisualStyleBackColor = false;
            this.button_Atualizar.Click += new System.EventHandler(this.button_Atualizar_Click);
            // 
            // textBox_PrecoVenda
            // 
            this.textBox_PrecoVenda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_PrecoVenda.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_PrecoVenda.Location = new System.Drawing.Point(209, 291);
            this.textBox_PrecoVenda.Name = "textBox_PrecoVenda";
            this.textBox_PrecoVenda.Size = new System.Drawing.Size(173, 29);
            this.textBox_PrecoVenda.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.SteelBlue;
            this.label6.Location = new System.Drawing.Point(211, 263);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(176, 25);
            this.label6.TabIndex = 15;
            this.label6.Text = "Preço de Venda";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_Quantidade
            // 
            this.textBox_Quantidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Quantidade.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Quantidade.Location = new System.Drawing.Point(19, 363);
            this.textBox_Quantidade.Name = "textBox_Quantidade";
            this.textBox_Quantidade.Size = new System.Drawing.Size(120, 29);
            this.textBox_Quantidade.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.SteelBlue;
            this.label7.Location = new System.Drawing.Point(20, 331);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 29);
            this.label7.TabIndex = 17;
            this.label7.Text = "Estoque";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form_CadProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1164, 512);
            this.Controls.Add(this.textBox_Quantidade);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_PrecoVenda);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button_Atualizar);
            this.Controls.Add(this.button_AtualizarLista);
            this.Controls.Add(this.dataGridViewPRODUTOS);
            this.Controls.Add(this.button_ExcluirProd);
            this.Controls.Add(this.button_Fechar);
            this.Controls.Add(this.button_CadProduto);
            this.Controls.Add(this.textBox_PrecoCusto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_Categoria);
            this.Controls.Add(this.textBox_Descricao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_CadProdutos";
            this.Text = "Cadastro de Produtos";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPRODUTOS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Descricao;
        private System.Windows.Forms.TextBox textBox_Categoria;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_PrecoCusto;
        private System.Windows.Forms.Button button_CadProduto;
        private System.Windows.Forms.Button button_Fechar;
        private System.Windows.Forms.Button button_ExcluirProd;
        private System.Windows.Forms.DataGridView dataGridViewPRODUTOS;
        private System.Windows.Forms.Button button_AtualizarLista;
        private System.Windows.Forms.Button button_Atualizar;
        private System.Windows.Forms.TextBox textBox_PrecoVenda;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_Quantidade;
        private System.Windows.Forms.Label label7;
    }
}