using MySql.Data.MySqlClient;
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
    public partial class Form_Venda : Form
    {
        private int idVendaAtual = 0;
        private decimal baseTotal = 0m;   // guarda o total sem taxa

        public Form_Venda()
        {
            InitializeComponent();

            // 1) Configura colunas do grid do carrinho
            dataGridView_VendaRealizada.Columns.Clear();
            dataGridView_VendaRealizada.Columns.Add("descricao", "Descrição");
            dataGridView_VendaRealizada.Columns.Add("quantidade", "Quantidade");
            dataGridView_VendaRealizada.Columns.Add("preco", "Preço");

            // 2) Associa eventos
            this.Load += Form_Venda_Load;
            button_Pesquisar.Click += button_Pesquisar_Click;
            button_Adicionar.Click += button_Adicionar_Click;
            button_NovaVenda.Click += button_NovaVenda_Click;
            button_FinalizarVenda.Click += button_FinalizarVenda_Click;
            button_CancelarVenda.Click += button_CancelarVenda_Click;
            comboBox_TipoPagamento.SelectedIndexChanged += comboBox_TipoPagamento_SelectedIndexChanged;
            textBox_TaxaCartao.TextChanged += textBox_TaxaCartao_TextChanged;

            // 3) Prepara a tela
            InicializarCaixa();
        }

        private void Form_Venda_Load(object sender, EventArgs e)
        {
            CarregarProdutos();
            // Exibe o próximo ID de venda no Label
            label_CodVenda.Text = ObterProximoIdVenda().ToString();
        }

        private void InicializarCaixa()
        {
            label_Data.Text = DateTime.Now.ToShortDateString();
            label_TotalVenda.Text = "0.00";
            label_CodVenda.Text = "";
            button_FinalizarVenda.Enabled = false;
            button_CancelarVenda.Enabled = false;

            comboBox_TipoPagamento.Items.Clear();
            comboBox_TipoPagamento.Items.Add("Dinheiro");
            comboBox_TipoPagamento.Items.Add("Cartão");
            comboBox_TipoPagamento.SelectedIndex = 0;
            textBox_TaxaCartao.Enabled = false;
            label4.Visible = false;
        }

        private void CarregarProdutos(string filtro = "")
        {
            try
            {
                if (ClassMYSQL.conexao.State != ConnectionState.Open)
                    ClassMYSQL.conexao.Open();

                ClassMYSQL.comando.CommandText = string.IsNullOrWhiteSpace(filtro)
                  ? "SELECT id, descricao_produto, preco_produto FROM tbl_produtos;"
                  : "SELECT id, descricao_produto, preco_produto " +
                    "FROM tbl_produtos WHERE descricao_produto LIKE '%" + filtro + "%';";

                var da = new MySqlDataAdapter(ClassMYSQL.comando);
                var dt = new DataTable();
                da.Fill(dt);

                dataGridView_Venda.DataSource = dt;
                dataGridView_Venda.Columns["id"].Visible = false;
                dataGridView_Venda.Columns["descricao_produto"].HeaderText = "Descrição";
                dataGridView_Venda.Columns["preco_produto"].HeaderText = "Preço";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar produtos: " + ex.Message);
            }
            finally
            {
                if (ClassMYSQL.conexao.State == ConnectionState.Open)
                    ClassMYSQL.conexao.Close();
            }
        }

        private void button_Pesquisar_Click(object sender, EventArgs e)
            => CarregarProdutos(textBox_Pesquisar.Text);

        private void button_NovaVenda_Click(object sender, EventArgs e)
        {
            idVendaAtual = 0;
            baseTotal = 0m;
            dataGridView_VendaRealizada.Rows.Clear();
            comboBox_TipoPagamento.SelectedIndex = 0;
            label_TotalVenda.Text = "0.00";
            textBox_TaxaCartao.Clear();
            textBox_TaxaCartao.Enabled = false;
            label4.Visible = false;
            button_FinalizarVenda.Enabled = true;
            button_CancelarVenda.Enabled = true;
            label_Data.Text = DateTime.Now.ToShortDateString();

            // Atualiza o próximo ID de venda
            label_CodVenda.Text = ObterProximoIdVenda().ToString();
        }

        private void button_Adicionar_Click(object sender, EventArgs e)
        {
            if (dataGridView_Venda.SelectedRows.Count == 0) return;

            var row = dataGridView_Venda.SelectedRows[0];
            string desc = row.Cells["descricao_produto"].Value.ToString();
            decimal preco = Convert.ToDecimal(row.Cells["preco_produto"].Value);

            dataGridView_VendaRealizada.Rows.Add(desc, 1, preco);
            AtualizarTotal();
        }

        private void AtualizarTotal()
        {
            baseTotal = 0m;
            foreach (DataGridViewRow linha in dataGridView_VendaRealizada.Rows)
            {
                int q = Convert.ToInt32(linha.Cells["quantidade"].Value);
                decimal p = Convert.ToDecimal(linha.Cells["preco"].Value);
                baseTotal += q * p;
            }
            label_TotalVenda.Text = baseTotal.ToString("0.00");
        }

        private void comboBox_TipoPagamento_SelectedIndexChanged(object sender, EventArgs e)
            => textBox_TaxaCartao.Enabled = (comboBox_TipoPagamento.SelectedItem.ToString() == "Cartão");

        private void textBox_TaxaCartao_TextChanged(object sender, EventArgs e)
        {
            if (comboBox_TipoPagamento.SelectedItem.ToString() == "Cartão" &&
                decimal.TryParse(textBox_TaxaCartao.Text, out var taxaPct))
            {
                label4.Visible = true;
                var tot = baseTotal * (1 + taxaPct / 100m);
                label_TotalVenda.Text = tot.ToString("0.00");
            }
            else
            {
                label_TotalVenda.Text = baseTotal.ToString("0.00");
            }
        }

        private void button_FinalizarVenda_Click(object sender, EventArgs e)
        {
            if (dataGridView_VendaRealizada.Rows.Count == 0)
            {
                MessageBox.Show("Adicione itens ao carrinho antes de finalizar.");
                return;
            }

            try
            {
                if (ClassMYSQL.conexao.State != ConnectionState.Open)
                    ClassMYSQL.conexao.Open();

                // monta string do carrinho
                string carrinhoStr = "";
                foreach (DataGridViewRow linha in dataGridView_VendaRealizada.Rows)
                {
                    if (linha.IsNewRow) continue;
                    string desc = linha.Cells["descricao"].Value.ToString();
                    int qtd = Convert.ToInt32(linha.Cells["quantidade"].Value);
                    carrinhoStr += $"{desc} x{qtd}; ";
                }

                // prepara data em yyyy-MM-dd
                string dataVenda = DateTime.Parse(label_Data.Text)
                                      .ToString("yyyy-MM-dd");

                // 1) insere na tbl_venda usando Sessao.IdColaborador
                ClassMYSQL.comando.CommandText =
                    "INSERT INTO tbl_venda (data_venda, carrinho, fk_colaborador) " +
                    "VALUES (@data, @carrinho, @colab);";
                ClassMYSQL.comando.Parameters.Clear();
                ClassMYSQL.comando.Parameters.AddWithValue("@data", dataVenda);
                ClassMYSQL.comando.Parameters.AddWithValue("@carrinho", carrinhoStr);
                ClassMYSQL.comando.Parameters.AddWithValue("@colab", Sessao.IdColaborador);
                ClassMYSQL.comando.ExecuteNonQuery();

                // 2) recupera o id gerado
                ClassMYSQL.comando.CommandText = "SELECT LAST_INSERT_ID();";
                int idVenda = Convert.ToInt32(ClassMYSQL.comando.ExecuteScalar());
                label_CodVenda.Text = idVenda.ToString();

                // 3) insere na tbl_pagamento também com Sessao.IdColaborador
                decimal valor = Convert.ToDecimal(label_TotalVenda.Text);
                string tipo = comboBox_TipoPagamento.SelectedItem.ToString();
                ClassMYSQL.comando.CommandText =
                    "INSERT INTO tbl_pagamento " +
                    "(data_pagamento, tipo_pagamento, valor_total, fk_colaborador) " +
                    "VALUES (@data, @tipo, @valor, @colab);";
                ClassMYSQL.comando.Parameters.Clear();
                ClassMYSQL.comando.Parameters.AddWithValue("@data", dataVenda);
                ClassMYSQL.comando.Parameters.AddWithValue("@tipo", tipo);
                ClassMYSQL.comando.Parameters.AddWithValue("@valor", valor);
                ClassMYSQL.comando.Parameters.AddWithValue("@colab", Sessao.IdColaborador);
                ClassMYSQL.comando.ExecuteNonQuery();

                MessageBox.Show("Venda #" + idVenda + " finalizada com sucesso!");
                button_FinalizarVenda.Enabled = false;
                button_CancelarVenda.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao finalizar venda: " + ex.Message);
            }
            finally
            {
                if (ClassMYSQL.conexao.State == ConnectionState.Open)
                    ClassMYSQL.conexao.Close();
                ClassMYSQL.comando.Parameters.Clear();
            }
        }

        private void button_CancelarVenda_Click(object sender, EventArgs e)
            => button_NovaVenda.PerformClick();

        // Busca o próximo AUTO_INCREMENT de tbl_venda e retorna como inteiro
        private int ObterProximoIdVenda()
        {
            int proximo = 0;
            try
            {
                if (ClassMYSQL.conexao.State != ConnectionState.Open)
                    ClassMYSQL.conexao.Open();

                ClassMYSQL.comando.CommandText =
                  "SELECT AUTO_INCREMENT " +
                  "FROM information_schema.TABLES " +
                  "WHERE TABLE_SCHEMA=DATABASE() AND TABLE_NAME='tbl_venda';";
                var obj = ClassMYSQL.comando.ExecuteScalar();
                proximo = obj != null ? Convert.ToInt32(obj) : 0;
            }
            catch { /* ignorar */ }
            finally
            {
                if (ClassMYSQL.conexao.State == ConnectionState.Open)
                    ClassMYSQL.conexao.Close();
            }
            return proximo;
        }
    }
}
