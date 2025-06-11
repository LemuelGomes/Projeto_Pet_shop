using System;
using System.Data;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Projeto_Pet_shop
{
    public partial class Form_Venda : Form
    {
        private decimal baseTotal = 0m;
        private readonly CultureInfo ptBR = new CultureInfo("pt-BR");

        public Form_Venda()
        {
            InitializeComponent();

            // configura DataGridViews
            dataGridView_Venda.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_Venda.MultiSelect = false;
            dataGridView_VendaRealizada.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_VendaRealizada.MultiSelect = false;

            // define colunas do carrinho
            dataGridView_VendaRealizada.Columns.Clear();
            dataGridView_VendaRealizada.Columns.Add("descricao", "Descrição");
            dataGridView_VendaRealizada.Columns.Add("quantidade", "Quantidade");
            dataGridView_VendaRealizada.Columns.Add("preco", "Preço");
            dataGridView_VendaRealizada.Columns["descricao"].ReadOnly = true;
            dataGridView_VendaRealizada.Columns["preco"].ReadOnly = true;
            dataGridView_VendaRealizada.Columns["quantidade"].ReadOnly = false;

            // eventos
            this.Load += Form_Venda_Load;
            button_Pesquisar.Click += button_Pesquisar_Click;
            button_Atualizar.Click += button_Atualizar_Click;
            button_CancelarVenda.Click += button_CancelarVenda_Click;
            comboBox_TipoPagamento.SelectedIndexChanged += ComboBox_TipoPagamento_SelectedIndexChanged;
            textBox_TaxaCartao.TextChanged += TextBox_TaxaCartao_TextChanged;

            InicializarCaixa();
        }

        private void Form_Venda_Load(object sender, EventArgs e)
        {
            CarregarProdutos();
            label_CodVenda.Text = ObterProximoIdVenda().ToString();
            CancelarVenda();
        }

        private void InicializarCaixa()
        {
            label_Data.Text = DateTime.Now.ToShortDateString();
            label_TotalVenda.Text = (0m).ToString("C", ptBR);
            comboBox_TipoPagamento.Items.Clear();
            comboBox_TipoPagamento.Items.AddRange(new[] { "Dinheiro", "Cartão" });
            comboBox_TipoPagamento.SelectedIndex = 0;
            textBox_TaxaCartao.Clear();
            textBox_TaxaCartao.Enabled = false;
            button_FinalizarVenda.Enabled = false;
            textBox_Pesquisar.Text = "";
            CarregarProdutos();
        }

        private void CarregarProdutos(string filtro = "")
        {
            try
            {
                if (ClassSQLite.conexao.State != ConnectionState.Open)
                    ClassSQLite.conexao.Open();

                string sql = string.IsNullOrWhiteSpace(filtro)
                ? "SELECT id, descricao_produto, preco_produto, quantidade_produto FROM tbl_produtos;"
                : "SELECT id, descricao_produto, preco_produto FROM tbl_produtos WHERE descricao_produto LIKE @filtro;";

                ClassSQLite.comando.CommandText = sql;
                ClassSQLite.comando.Parameters.Clear();
                if (!string.IsNullOrWhiteSpace(filtro))
                    ClassSQLite.comando.Parameters.AddWithValue("@filtro", "%" + filtro + "%");

                var da = new SQLiteDataAdapter(ClassSQLite.comando);
                var dt = new DataTable();
                da.Fill(dt);
                dataGridView_Venda.DataSource = dt;
                dataGridView_Venda.Columns["id"].Visible = false;
                dataGridView_Venda.Columns["descricao_produto"].HeaderText = "Descrição";
                dataGridView_Venda.Columns["preco_produto"].HeaderText = "Preço";
                dataGridView_Venda.Columns["quantidade_produto"].HeaderText = "Estoque";
            }
            finally
            {
                if (ClassSQLite.conexao.State == ConnectionState.Open)
                    ClassSQLite.conexao.Close();
            }
        }

        private void button_Pesquisar_Click(object sender, EventArgs e)
        {
            CarregarProdutos(textBox_Pesquisar.Text);
        }

        private void button_Adicionar_Click(object sender, EventArgs e)
        {
            if (dataGridView_Venda.SelectedRows.Count == 0) return;
            var row = dataGridView_Venda.SelectedRows[0];
            string desc = row.Cells["descricao_produto"].Value.ToString();
            decimal preco = Convert.ToDecimal(row.Cells["preco_produto"].Value);
            dataGridView_VendaRealizada.Rows.Add(desc, 1, preco);
            AtualizarTotal();
            RecalcularComTaxa();
            CheckCarrinhoVazio();
        }

        private void button_Atualizar_Click(object sender, EventArgs e)
        {
            if (dataGridView_VendaRealizada.SelectedRows.Count == 0) return;
            var row = dataGridView_VendaRealizada.SelectedRows[0];
            if (!int.TryParse(row.Cells["quantidade"].Value?.ToString(), out int q) || q < 1)
            {
                row.Cells["quantidade"].Value = 1;
            }
            AtualizarTotal();
            RecalcularComTaxa();
            CheckCarrinhoVazio();
        }

        private void button_Remover_Click(object sender, EventArgs e)
        {
            if (dataGridView_VendaRealizada.SelectedRows.Count == 0) return;
            foreach (DataGridViewRow r in dataGridView_VendaRealizada.SelectedRows)
                dataGridView_VendaRealizada.Rows.Remove(r);
            AtualizarTotal();
            CheckCarrinhoVazio();
        }

        private void button_CancelarVenda_Click(object sender, EventArgs e)
        {
            CancelarVenda();
        }

        private void AtualizarTotal()
        {
            baseTotal = dataGridView_VendaRealizada.Rows.Cast<DataGridViewRow>()
                .Where(r => !r.IsNewRow)
                .Sum(r => Convert.ToInt32(r.Cells["quantidade"].Value) * Convert.ToDecimal(r.Cells["preco"].Value));
            label_TotalVenda.Text = baseTotal.ToString("C", ptBR);
        }

        private void ComboBox_TipoPagamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox_TaxaCartao.Enabled = comboBox_TipoPagamento.SelectedItem.ToString() == "Cartão";
            label4.Enabled = comboBox_TipoPagamento.SelectedItem.ToString() == "Cartão";
            textBox_TaxaCartao.Visible = comboBox_TipoPagamento.SelectedItem.ToString() == "Cartão";
            label4.Visible = comboBox_TipoPagamento.SelectedItem.ToString() == "Cartão";
            RecalcularComTaxa();
        }

        private void TextBox_TaxaCartao_TextChanged(object sender, EventArgs e)
        {
            RecalcularComTaxa();
        }

        private void RecalcularComTaxa()
        {
            if (comboBox_TipoPagamento.SelectedItem.ToString() == "Cartão"
                && decimal.TryParse(textBox_TaxaCartao.Text, NumberStyles.Any, ptBR, out var tx))
            {
                label_TotalVenda.Text = (baseTotal * (1 + tx / 100m)).ToString("C", ptBR);
            }
            else
            {
                label_TotalVenda.Text = baseTotal.ToString("C", ptBR);
            }
        }

        private void CheckCarrinhoVazio()
        {
            bool vazio = dataGridView_VendaRealizada.Rows.Cast<DataGridViewRow>()
                .All(r => r.IsNewRow);
            if (vazio)
                CancelarVenda();
            else
                button_FinalizarVenda.Enabled = true;
        }

        private void CancelarVenda()
        {
            dataGridView_VendaRealizada.Rows.Clear();
            baseTotal = 0m;
            label_TotalVenda.Text = baseTotal.ToString("C", ptBR);
            textBox_TaxaCartao.Clear();
            textBox_TaxaCartao.Enabled = false;
            button_FinalizarVenda.Enabled = false;
            label_Data.Text = DateTime.Now.ToShortDateString();
            label_CodVenda.Text = ObterProximoIdVenda().ToString();

            InicializarCaixa();
        }

        private void button_FinalizarVenda_Click(object sender, EventArgs e)
        {
            // 1) coleta os itens da venda
            var itens = dataGridView_VendaRealizada
                            .Rows
                            .Cast<DataGridViewRow>()
                            .Where(r => !r.IsNewRow)
                            .ToList();

            try
            {
                // 2) abre conexão
                if (ClassSQLite.conexao.State != ConnectionState.Open)
                    ClassSQLite.conexao.Open();

                // 3) inicia transação
                using (var tx = ClassSQLite.conexao.BeginTransaction())
                using (var cmd = ClassSQLite.conexao.CreateCommand())
                {
                    cmd.Transaction = tx;

                    // 4) atualiza estoque de cada produto
                    cmd.CommandText =
                        "UPDATE tbl_produtos " +
                        "SET quantidade_produto = quantidade_produto - @qtd " +
                        "WHERE descricao_produto = @desc;";
                    foreach (var row in itens)
                    {
                        int qtd = Convert.ToInt32(row.Cells["quantidade"].Value);
                        string desc = row.Cells["descricao"].Value.ToString();

                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@qtd", qtd);
                        cmd.Parameters.AddWithValue("@desc", desc);

                        int affected = cmd.ExecuteNonQuery();
                        if (affected == 0)
                            throw new InvalidOperationException(
                                $"Produto '{desc}' não encontrado no estoque.");
                    }

                    // 5) insere registro de venda
                    cmd.CommandText =
                        "INSERT INTO tbl_venda (data_venda, carrinho, fk_colaborador) " +
                        "VALUES (@dt, @carr, @col);";
                    cmd.Parameters.Clear();
                    string dt = DateTime.Now.ToString("yyyy-MM-dd");
                    string carr = string.Join("; ",
                        itens.Select(r => $"{r.Cells["descricao"].Value} x{r.Cells["quantidade"].Value}")) + ";";

                    cmd.Parameters.AddWithValue("@dt", dt);
                    cmd.Parameters.AddWithValue("@carr", carr);
                    cmd.Parameters.AddWithValue("@col", Sessao.IdColaborador);
                    cmd.ExecuteNonQuery();

                    // 6) obtém o ID da venda
                    cmd.CommandText = "SELECT last_insert_rowid();";
                    var idv = Convert.ToInt32(cmd.ExecuteScalar());
                    label_CodVenda.Text = idv.ToString();

                    // 7) insere o pagamento
                    cmd.CommandText =
                        "INSERT INTO tbl_pagamento (data_pagamento, tipo_pagamento, valor_total, fk_colaborador) " +
                        "VALUES (@dt, @tipo, @valor, @col);";
                    cmd.Parameters.Clear();
                    var ptBR = new CultureInfo("pt-BR");
                    decimal valor = decimal.Parse(label_TotalVenda.Text, NumberStyles.Currency, ptBR);
                    string tipo = comboBox_TipoPagamento.SelectedItem.ToString();

                    cmd.Parameters.AddWithValue("@dt", dt);
                    cmd.Parameters.AddWithValue("@tipo", tipo);
                    cmd.Parameters.AddWithValue("@valor", valor);
                    cmd.Parameters.AddWithValue("@col", Sessao.IdColaborador);
                    cmd.ExecuteNonQuery();

                    // 8) confirma todas as operações
                    tx.Commit();
                }

                MessageBox.Show(
                    $"Venda #{label_CodVenda.Text} finalizada com sucesso!",
                    "Sucesso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CancelarVenda();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao finalizar venda: " + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                // 11) fecha conexão
                if (ClassSQLite.conexao.State == ConnectionState.Open)
                    ClassSQLite.conexao.Close();
            }
        }

        private int ObterProximoIdVenda()
        {
            int p = 1;
            try
            {
                if (ClassSQLite.conexao.State != ConnectionState.Open)
                    ClassSQLite.conexao.Open();
                ClassSQLite.comando.CommandText = "SELECT seq FROM sqlite_sequence WHERE name='tbl_venda'";
                var o = ClassSQLite.comando.ExecuteScalar();
                if (o != null && int.TryParse(o.ToString(), out var s))
                    p = s + 1;
            }
            catch { }
            finally
            {
                if (ClassSQLite.conexao.State == ConnectionState.Open)
                    ClassSQLite.conexao.Close();
            }
            return p;
        }

        private void button_Sair_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_Login Form_Venda = new Form_Login();
            Form_Venda.ShowDialog();
            this.Close();
        }
    }
}