using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Pet_shop
{
    public partial class Form_Gerenciamento : Form
    {
        public Form_Gerenciamento()
        {
            InitializeComponent();
            this.FormClosing += Form_Gerenciamento_FormClosing;
        }
        private void cadastrarColaboradorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_CadColaborador FormGerenciamento = new Form_CadColaborador();
            FormGerenciamento.Closed += (s, args) => this.Close();
            FormGerenciamento.Show();
        }

        private void alterarSenhaColaboradorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_AlterarSenha FormGerenciamento = new Form_AlterarSenha();
            FormGerenciamento.Closed += (s, args) => this.Close();
            FormGerenciamento.Show();
        }

        private void cadastrarProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_CadProdutos FormBarbearia = new Form_CadProdutos();
            FormBarbearia.Closed += (s, args) => this.Close();
            FormBarbearia.ShowDialog();
        }

        private void relatórioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_Relatorio FormGerenciamento = new Form_Relatorio();
            FormGerenciamento.Closed += (s, args) => this.Close();
            FormGerenciamento.Show();
        }

        private void gestãoDePessoasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_GestaodePessoas FormGerenciamento = new Form_GestaodePessoas();
            FormGerenciamento.Closed += (s, args) => this.Close();
            FormGerenciamento.Show();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult decisao = MessageBox.Show("Deseja realmente sair?", "Voltar para Login", MessageBoxButtons.YesNo);

            if (decisao == DialogResult.Yes)
            {
                this.Hide();
                Form_Login FormGerenciamento = new Form_Login();
                FormGerenciamento.Closed += (s, args) => this.Close();
                FormGerenciamento.Show();
            }
            else
            {
                return;
            }
        }

        private void configurçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_Suporte FormGerenciamento = new Form_Suporte();
            FormGerenciamento.Closed += (s, args) => this.Close();
            FormGerenciamento.Show();
        }

        private void cadastrarColaboradorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_CadColaborador Form_Gerenciamento = new Form_CadColaborador();
            Form_Gerenciamento.ShowDialog();
            this.Close();
        }

        private void cadastrarProdutosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_CadProdutos Form_Gerenciamento = new Form_CadProdutos();
            Form_Gerenciamento.ShowDialog();
            this.Close();
        }

        private void alterarSenhaColaboradorToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form_AlterarSenha Form_Gerenciamento = new Form_AlterarSenha();
            Form_Gerenciamento.ShowDialog();
            this.Close();
        }

        private void relatórioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_Relatorio Form_Gerenciamento = new Form_Relatorio();
            Form_Gerenciamento.ShowDialog();
            this.Close();
        }

        private void gestãoDePessoasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_GestaodePessoas Form_Gerenciamento = new Form_GestaodePessoas();
            Form_Gerenciamento.ShowDialog();
            this.Close();
        }

        private void suporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_Suporte Form_Gerenciamento = new Form_Suporte();
            Form_Gerenciamento.ShowDialog();
            this.Close();
        }

        private void sairToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form_Login Form_Gerenciamento = new Form_Login();
            Form_Gerenciamento.ShowDialog();
            this.Close();
        }

        private void Form_Gerenciamento_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.Hide();
                Form_Login Form_Gerenciamento = new Form_Login();
                Form_Gerenciamento.ShowDialog();
                this.Close();
            }
        }
    }
}
