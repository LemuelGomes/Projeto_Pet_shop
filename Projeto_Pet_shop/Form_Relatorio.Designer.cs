﻿namespace Projeto_Pet_shop
{
    partial class Form_Relatorio
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
            this.dataGridView_Relatorio = new System.Windows.Forms.DataGridView();
            this.button_GerarRelatorio = new System.Windows.Forms.Button();
            this.comboBox_TipoPagamento = new System.Windows.Forms.ComboBox();
            this.comboBox_Periodo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_Colaborador = new System.Windows.Forms.ComboBox();
            this.button_Limpar = new System.Windows.Forms.Button();
            this.button_Sair = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Relatorio)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Relatorio
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView_Relatorio.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Relatorio.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_Relatorio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_Relatorio.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_Relatorio.Location = new System.Drawing.Point(392, 12);
            this.dataGridView_Relatorio.Name = "dataGridView_Relatorio";
            this.dataGridView_Relatorio.Size = new System.Drawing.Size(824, 347);
            this.dataGridView_Relatorio.TabIndex = 0;
            // 
            // button_GerarRelatorio
            // 
            this.button_GerarRelatorio.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_GerarRelatorio.Location = new System.Drawing.Point(481, 365);
            this.button_GerarRelatorio.Name = "button_GerarRelatorio";
            this.button_GerarRelatorio.Size = new System.Drawing.Size(160, 40);
            this.button_GerarRelatorio.TabIndex = 3;
            this.button_GerarRelatorio.Text = "Gerar Relatório";
            this.button_GerarRelatorio.UseVisualStyleBackColor = true;
            this.button_GerarRelatorio.Click += new System.EventHandler(this.button_GerarRelatorio_Click);
            // 
            // comboBox_TipoPagamento
            // 
            this.comboBox_TipoPagamento.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_TipoPagamento.FormattingEnabled = true;
            this.comboBox_TipoPagamento.Location = new System.Drawing.Point(203, 129);
            this.comboBox_TipoPagamento.Name = "comboBox_TipoPagamento";
            this.comboBox_TipoPagamento.Size = new System.Drawing.Size(183, 26);
            this.comboBox_TipoPagamento.TabIndex = 4;
            // 
            // comboBox_Periodo
            // 
            this.comboBox_Periodo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Periodo.FormattingEnabled = true;
            this.comboBox_Periodo.Location = new System.Drawing.Point(212, 195);
            this.comboBox_Periodo.Name = "comboBox_Periodo";
            this.comboBox_Periodo.Size = new System.Drawing.Size(174, 26);
            this.comboBox_Periodo.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Período Rendimento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(194, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tipo de Pagamento";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "Colaborador";
            // 
            // comboBox_Colaborador
            // 
            this.comboBox_Colaborador.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Colaborador.FormattingEnabled = true;
            this.comboBox_Colaborador.Location = new System.Drawing.Point(136, 60);
            this.comboBox_Colaborador.Name = "comboBox_Colaborador";
            this.comboBox_Colaborador.Size = new System.Drawing.Size(250, 26);
            this.comboBox_Colaborador.TabIndex = 9;
            // 
            // button_Limpar
            // 
            this.button_Limpar.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Limpar.Location = new System.Drawing.Point(12, 264);
            this.button_Limpar.Name = "button_Limpar";
            this.button_Limpar.Size = new System.Drawing.Size(160, 40);
            this.button_Limpar.TabIndex = 10;
            this.button_Limpar.Text = "Limpar Filtros";
            this.button_Limpar.UseVisualStyleBackColor = true;
            this.button_Limpar.Click += new System.EventHandler(this.button_Limpar_Click);
            // 
            // button_Sair
            // 
            this.button_Sair.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Sair.Location = new System.Drawing.Point(1108, 365);
            this.button_Sair.Name = "button_Sair";
            this.button_Sair.Size = new System.Drawing.Size(108, 40);
            this.button_Sair.TabIndex = 11;
            this.button_Sair.Text = "Sair";
            this.button_Sair.UseVisualStyleBackColor = true;
            // 
            // Form_Relatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 417);
            this.Controls.Add(this.button_Sair);
            this.Controls.Add(this.button_Limpar);
            this.Controls.Add(this.comboBox_Colaborador);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_Periodo);
            this.Controls.Add(this.comboBox_TipoPagamento);
            this.Controls.Add(this.button_GerarRelatorio);
            this.Controls.Add(this.dataGridView_Relatorio);
            this.Name = "Form_Relatorio";
            this.Text = "Emissão de Relatório";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Relatorio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Relatorio;
        private System.Windows.Forms.Button button_GerarRelatorio;
        private System.Windows.Forms.ComboBox comboBox_TipoPagamento;
        private System.Windows.Forms.ComboBox comboBox_Periodo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_Colaborador;
        private System.Windows.Forms.Button button_Limpar;
        private System.Windows.Forms.Button button_Sair;
    }
}