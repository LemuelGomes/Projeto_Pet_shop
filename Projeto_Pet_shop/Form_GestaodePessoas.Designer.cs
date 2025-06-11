namespace Projeto_Pet_shop
{
    partial class Form_GestaodePessoas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_GestaodePessoas));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Pesquisar = new System.Windows.Forms.TextBox();
            this.dataGridView_Gestao = new System.Windows.Forms.DataGridView();
            this.button_Atualizar = new System.Windows.Forms.Button();
            this.button_Menu = new System.Windows.Forms.Button();
            this.button_Excluir = new System.Windows.Forms.Button();
            this.button_Pesquisar = new System.Windows.Forms.Button();
            this.button_Limpar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Gestao)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pesquisar Registros";
            // 
            // textBox_Pesquisar
            // 
            this.textBox_Pesquisar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Pesquisar.Location = new System.Drawing.Point(215, 12);
            this.textBox_Pesquisar.Name = "textBox_Pesquisar";
            this.textBox_Pesquisar.Size = new System.Drawing.Size(273, 26);
            this.textBox_Pesquisar.TabIndex = 1;
            // 
            // dataGridView_Gestao
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView_Gestao.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_Gestao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_Gestao.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_Gestao.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView_Gestao.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Gestao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_Gestao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Gestao.Location = new System.Drawing.Point(12, 71);
            this.dataGridView_Gestao.Name = "dataGridView_Gestao";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView_Gestao.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_Gestao.Size = new System.Drawing.Size(943, 204);
            this.dataGridView_Gestao.TabIndex = 2;
            // 
            // button_Atualizar
            // 
            this.button_Atualizar.FlatAppearance.BorderSize = 0;
            this.button_Atualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Atualizar.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Atualizar.ForeColor = System.Drawing.Color.SteelBlue;
            this.button_Atualizar.Image = ((System.Drawing.Image)(resources.GetObject("button_Atualizar.Image")));
            this.button_Atualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Atualizar.Location = new System.Drawing.Point(826, 281);
            this.button_Atualizar.Name = "button_Atualizar";
            this.button_Atualizar.Size = new System.Drawing.Size(122, 34);
            this.button_Atualizar.TabIndex = 3;
            this.button_Atualizar.Text = "Atualizar";
            this.button_Atualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Atualizar.UseVisualStyleBackColor = true;
            this.button_Atualizar.Click += new System.EventHandler(this.button_Atualizar_Click);
            // 
            // button_Menu
            // 
            this.button_Menu.FlatAppearance.BorderSize = 0;
            this.button_Menu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Menu.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Menu.Image = ((System.Drawing.Image)(resources.GetObject("button_Menu.Image")));
            this.button_Menu.Location = new System.Drawing.Point(894, 396);
            this.button_Menu.Name = "button_Menu";
            this.button_Menu.Size = new System.Drawing.Size(54, 42);
            this.button_Menu.TabIndex = 4;
            this.button_Menu.UseVisualStyleBackColor = true;
            this.button_Menu.Click += new System.EventHandler(this.button_Menu_Click);
            // 
            // button_Excluir
            // 
            this.button_Excluir.FlatAppearance.BorderSize = 0;
            this.button_Excluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Excluir.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Excluir.ForeColor = System.Drawing.Color.Crimson;
            this.button_Excluir.Image = ((System.Drawing.Image)(resources.GetObject("button_Excluir.Image")));
            this.button_Excluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Excluir.Location = new System.Drawing.Point(12, 281);
            this.button_Excluir.Name = "button_Excluir";
            this.button_Excluir.Size = new System.Drawing.Size(222, 34);
            this.button_Excluir.TabIndex = 5;
            this.button_Excluir.Text = "Desligar Colaborador";
            this.button_Excluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Excluir.UseVisualStyleBackColor = true;
            this.button_Excluir.Click += new System.EventHandler(this.button_Excluir_Click);
            // 
            // button_Pesquisar
            // 
            this.button_Pesquisar.FlatAppearance.BorderSize = 0;
            this.button_Pesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Pesquisar.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Pesquisar.ForeColor = System.Drawing.Color.SteelBlue;
            this.button_Pesquisar.Image = ((System.Drawing.Image)(resources.GetObject("button_Pesquisar.Image")));
            this.button_Pesquisar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Pesquisar.Location = new System.Drawing.Point(494, 5);
            this.button_Pesquisar.Name = "button_Pesquisar";
            this.button_Pesquisar.Size = new System.Drawing.Size(141, 38);
            this.button_Pesquisar.TabIndex = 6;
            this.button_Pesquisar.Text = "Pesquisar";
            this.button_Pesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Pesquisar.UseVisualStyleBackColor = true;
            this.button_Pesquisar.Click += new System.EventHandler(this.button_Pesquisar_Click);
            // 
            // button_Limpar
            // 
            this.button_Limpar.FlatAppearance.BorderSize = 0;
            this.button_Limpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Limpar.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Limpar.ForeColor = System.Drawing.Color.Gold;
            this.button_Limpar.Image = ((System.Drawing.Image)(resources.GetObject("button_Limpar.Image")));
            this.button_Limpar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Limpar.Location = new System.Drawing.Point(843, 340);
            this.button_Limpar.Name = "button_Limpar";
            this.button_Limpar.Size = new System.Drawing.Size(105, 34);
            this.button_Limpar.TabIndex = 7;
            this.button_Limpar.Text = "Limpar";
            this.button_Limpar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Limpar.UseVisualStyleBackColor = true;
            this.button_Limpar.Click += new System.EventHandler(this.button_Limpar_Click);
            // 
            // Form_GestaodePessoas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(960, 450);
            this.Controls.Add(this.button_Limpar);
            this.Controls.Add(this.button_Pesquisar);
            this.Controls.Add(this.button_Excluir);
            this.Controls.Add(this.button_Menu);
            this.Controls.Add(this.button_Atualizar);
            this.Controls.Add(this.dataGridView_Gestao);
            this.Controls.Add(this.textBox_Pesquisar);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_GestaodePessoas";
            this.Text = "Gestão de Pessoas";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Gestao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Pesquisar;
        private System.Windows.Forms.DataGridView dataGridView_Gestao;
        private System.Windows.Forms.Button button_Atualizar;
        private System.Windows.Forms.Button button_Menu;
        private System.Windows.Forms.Button button_Excluir;
        private System.Windows.Forms.Button button_Pesquisar;
        private System.Windows.Forms.Button button_Limpar;
    }
}