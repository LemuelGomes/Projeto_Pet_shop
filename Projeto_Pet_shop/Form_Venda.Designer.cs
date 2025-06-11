namespace Projeto_Pet_shop
{
    partial class Form_Venda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Venda));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button_FinalizarVenda = new System.Windows.Forms.Button();
            this.button_Adicionar = new System.Windows.Forms.Button();
            this.dataGridView_VendaRealizada = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_CodVenda = new System.Windows.Forms.Label();
            this.label_Data = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label_TotalVenda = new System.Windows.Forms.Label();
            this.comboBox_TipoPagamento = new System.Windows.Forms.ComboBox();
            this.textBox_TaxaCartao = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button_Remover = new System.Windows.Forms.Button();
            this.button_Atualizar = new System.Windows.Forms.Button();
            this.textBox_Pesquisar = new System.Windows.Forms.TextBox();
            this.button_CancelarVenda = new System.Windows.Forms.Button();
            this.button_Pesquisar = new System.Windows.Forms.Button();
            this.dataGridView_Venda = new System.Windows.Forms.DataGridView();
            this.panel_Vendas = new System.Windows.Forms.Panel();
            this.button_Sair = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_VendaRealizada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Venda)).BeginInit();
            this.panel_Vendas.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_FinalizarVenda
            // 
            this.button_FinalizarVenda.FlatAppearance.BorderSize = 0;
            this.button_FinalizarVenda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_FinalizarVenda.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_FinalizarVenda.Image = ((System.Drawing.Image)(resources.GetObject("button_FinalizarVenda.Image")));
            this.button_FinalizarVenda.Location = new System.Drawing.Point(829, 232);
            this.button_FinalizarVenda.Name = "button_FinalizarVenda";
            this.button_FinalizarVenda.Size = new System.Drawing.Size(86, 78);
            this.button_FinalizarVenda.TabIndex = 4;
            this.button_FinalizarVenda.UseVisualStyleBackColor = true;
            this.button_FinalizarVenda.Click += new System.EventHandler(this.button_FinalizarVenda_Click);
            // 
            // button_Adicionar
            // 
            this.button_Adicionar.FlatAppearance.BorderSize = 0;
            this.button_Adicionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Adicionar.Image = ((System.Drawing.Image)(resources.GetObject("button_Adicionar.Image")));
            this.button_Adicionar.Location = new System.Drawing.Point(200, 436);
            this.button_Adicionar.Name = "button_Adicionar";
            this.button_Adicionar.Size = new System.Drawing.Size(143, 123);
            this.button_Adicionar.TabIndex = 1;
            this.button_Adicionar.UseVisualStyleBackColor = true;
            this.button_Adicionar.Click += new System.EventHandler(this.button_Adicionar_Click);
            // 
            // dataGridView_VendaRealizada
            // 
            this.dataGridView_VendaRealizada.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_VendaRealizada.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_VendaRealizada.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView_VendaRealizada.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DarkBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_VendaRealizada.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_VendaRealizada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_VendaRealizada.Location = new System.Drawing.Point(464, 103);
            this.dataGridView_VendaRealizada.Name = "dataGridView_VendaRealizada";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView_VendaRealizada.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_VendaRealizada.Size = new System.Drawing.Size(359, 335);
            this.dataGridView_VendaRealizada.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(466, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "Código da Venda:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(870, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 22);
            this.label2.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(581, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 8;
            // 
            // label_CodVenda
            // 
            this.label_CodVenda.BackColor = System.Drawing.Color.White;
            this.label_CodVenda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_CodVenda.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_CodVenda.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label_CodVenda.Location = new System.Drawing.Point(653, 73);
            this.label_CodVenda.Name = "label_CodVenda";
            this.label_CodVenda.Size = new System.Drawing.Size(42, 32);
            this.label_CodVenda.TabIndex = 9;
            // 
            // label_Data
            // 
            this.label_Data.AutoSize = true;
            this.label_Data.BackColor = System.Drawing.Color.Transparent;
            this.label_Data.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Data.ForeColor = System.Drawing.Color.DarkBlue;
            this.label_Data.Location = new System.Drawing.Point(627, 9);
            this.label_Data.Name = "label_Data";
            this.label_Data.Size = new System.Drawing.Size(148, 23);
            this.label_Data.TabIndex = 10;
            this.label_Data.Text = "22/06/2025";
            this.label_Data.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.SteelBlue;
            this.label5.Location = new System.Drawing.Point(464, 462);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 56);
            this.label5.TabIndex = 11;
            this.label5.Text = "TOTAL :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_TotalVenda
            // 
            this.label_TotalVenda.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label_TotalVenda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_TotalVenda.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TotalVenda.ForeColor = System.Drawing.Color.SteelBlue;
            this.label_TotalVenda.Location = new System.Drawing.Point(579, 462);
            this.label_TotalVenda.Name = "label_TotalVenda";
            this.label_TotalVenda.Size = new System.Drawing.Size(241, 56);
            this.label_TotalVenda.TabIndex = 12;
            this.label_TotalVenda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox_TipoPagamento
            // 
            this.comboBox_TipoPagamento.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_TipoPagamento.FormattingEnabled = true;
            this.comboBox_TipoPagamento.Location = new System.Drawing.Point(464, 528);
            this.comboBox_TipoPagamento.Name = "comboBox_TipoPagamento";
            this.comboBox_TipoPagamento.Size = new System.Drawing.Size(263, 31);
            this.comboBox_TipoPagamento.TabIndex = 13;
            // 
            // textBox_TaxaCartao
            // 
            this.textBox_TaxaCartao.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_TaxaCartao.Location = new System.Drawing.Point(733, 528);
            this.textBox_TaxaCartao.Name = "textBox_TaxaCartao";
            this.textBox_TaxaCartao.Size = new System.Drawing.Size(54, 31);
            this.textBox_TaxaCartao.TabIndex = 5;
            this.textBox_TaxaCartao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_TaxaCartao.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.SteelBlue;
            this.label4.Location = new System.Drawing.Point(793, 531);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 23);
            this.label4.TabIndex = 14;
            this.label4.Text = "%";
            this.label4.Visible = false;
            // 
            // button_Remover
            // 
            this.button_Remover.FlatAppearance.BorderSize = 0;
            this.button_Remover.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Remover.Image = ((System.Drawing.Image)(resources.GetObject("button_Remover.Image")));
            this.button_Remover.Location = new System.Drawing.Point(374, 232);
            this.button_Remover.Name = "button_Remover";
            this.button_Remover.Size = new System.Drawing.Size(84, 63);
            this.button_Remover.TabIndex = 15;
            this.button_Remover.UseVisualStyleBackColor = true;
            this.button_Remover.Click += new System.EventHandler(this.button_Remover_Click);
            // 
            // button_Atualizar
            // 
            this.button_Atualizar.FlatAppearance.BorderSize = 0;
            this.button_Atualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Atualizar.Image = ((System.Drawing.Image)(resources.GetObject("button_Atualizar.Image")));
            this.button_Atualizar.Location = new System.Drawing.Point(374, 119);
            this.button_Atualizar.Name = "button_Atualizar";
            this.button_Atualizar.Size = new System.Drawing.Size(84, 63);
            this.button_Atualizar.TabIndex = 16;
            this.button_Atualizar.UseVisualStyleBackColor = true;
            this.button_Atualizar.Click += new System.EventHandler(this.button_Atualizar_Click);
            // 
            // textBox_Pesquisar
            // 
            this.textBox_Pesquisar.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Pesquisar.Location = new System.Drawing.Point(3, 3);
            this.textBox_Pesquisar.Name = "textBox_Pesquisar";
            this.textBox_Pesquisar.Size = new System.Drawing.Size(340, 29);
            this.textBox_Pesquisar.TabIndex = 0;
            // 
            // button_CancelarVenda
            // 
            this.button_CancelarVenda.FlatAppearance.BorderSize = 0;
            this.button_CancelarVenda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_CancelarVenda.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_CancelarVenda.Image = ((System.Drawing.Image)(resources.GetObject("button_CancelarVenda.Image")));
            this.button_CancelarVenda.Location = new System.Drawing.Point(3, 436);
            this.button_CancelarVenda.Name = "button_CancelarVenda";
            this.button_CancelarVenda.Size = new System.Drawing.Size(143, 123);
            this.button_CancelarVenda.TabIndex = 5;
            this.button_CancelarVenda.UseVisualStyleBackColor = true;
            this.button_CancelarVenda.Click += new System.EventHandler(this.button_CancelarVenda_Click);
            // 
            // button_Pesquisar
            // 
            this.button_Pesquisar.FlatAppearance.BorderSize = 0;
            this.button_Pesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Pesquisar.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Pesquisar.Image = ((System.Drawing.Image)(resources.GetObject("button_Pesquisar.Image")));
            this.button_Pesquisar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Pesquisar.Location = new System.Drawing.Point(105, 38);
            this.button_Pesquisar.Name = "button_Pesquisar";
            this.button_Pesquisar.Size = new System.Drawing.Size(141, 48);
            this.button_Pesquisar.TabIndex = 1;
            this.button_Pesquisar.Text = "Pesquisar";
            this.button_Pesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Pesquisar.UseVisualStyleBackColor = true;
            this.button_Pesquisar.Click += new System.EventHandler(this.button_Pesquisar_Click);
            // 
            // dataGridView_Venda
            // 
            this.dataGridView_Venda.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_Venda.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_Venda.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView_Venda.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.DarkBlue;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Venda.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_Venda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Venda.Location = new System.Drawing.Point(3, 95);
            this.dataGridView_Venda.Name = "dataGridView_Venda";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView_Venda.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView_Venda.Size = new System.Drawing.Size(340, 335);
            this.dataGridView_Venda.TabIndex = 2;
            // 
            // panel_Vendas
            // 
            this.panel_Vendas.Controls.Add(this.dataGridView_Venda);
            this.panel_Vendas.Controls.Add(this.button_Pesquisar);
            this.panel_Vendas.Controls.Add(this.button_CancelarVenda);
            this.panel_Vendas.Controls.Add(this.textBox_Pesquisar);
            this.panel_Vendas.Controls.Add(this.button_Adicionar);
            this.panel_Vendas.Location = new System.Drawing.Point(12, 12);
            this.panel_Vendas.Name = "panel_Vendas";
            this.panel_Vendas.Size = new System.Drawing.Size(346, 561);
            this.panel_Vendas.TabIndex = 0;
            // 
            // button_Sair
            // 
            this.button_Sair.FlatAppearance.BorderSize = 0;
            this.button_Sair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Sair.Image = ((System.Drawing.Image)(resources.GetObject("button_Sair.Image")));
            this.button_Sair.Location = new System.Drawing.Point(846, 12);
            this.button_Sair.Name = "button_Sair";
            this.button_Sair.Size = new System.Drawing.Size(62, 64);
            this.button_Sair.TabIndex = 17;
            this.button_Sair.UseVisualStyleBackColor = true;
            this.button_Sair.Click += new System.EventHandler(this.button_Sair_Click);
            // 
            // Form_Venda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(920, 608);
            this.Controls.Add(this.button_Sair);
            this.Controls.Add(this.button_Atualizar);
            this.Controls.Add(this.button_Remover);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button_FinalizarVenda);
            this.Controls.Add(this.textBox_TaxaCartao);
            this.Controls.Add(this.comboBox_TipoPagamento);
            this.Controls.Add(this.label_TotalVenda);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label_Data);
            this.Controls.Add(this.label_CodVenda);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_VendaRealizada);
            this.Controls.Add(this.panel_Vendas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_Venda";
            this.Text = "Caixa de Vendas";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_VendaRealizada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Venda)).EndInit();
            this.panel_Vendas.ResumeLayout(false);
            this.panel_Vendas.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_FinalizarVenda;
        private System.Windows.Forms.Button button_Adicionar;
        private System.Windows.Forms.DataGridView dataGridView_VendaRealizada;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_CodVenda;
        private System.Windows.Forms.Label label_Data;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_TotalVenda;
        private System.Windows.Forms.ComboBox comboBox_TipoPagamento;
        private System.Windows.Forms.TextBox textBox_TaxaCartao;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_Remover;
        private System.Windows.Forms.Button button_Atualizar;
        private System.Windows.Forms.TextBox textBox_Pesquisar;
        private System.Windows.Forms.Button button_CancelarVenda;
        private System.Windows.Forms.Button button_Pesquisar;
        private System.Windows.Forms.DataGridView dataGridView_Venda;
        private System.Windows.Forms.Panel panel_Vendas;
        private System.Windows.Forms.Button button_Sair;
    }
}