using System;
using System.Data;
using System.Data.SQLite;
using System.Linq;
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

            // 1) Configura seleção para linhas inteiras e sem multiseleção
            dataGridView_VendaRealizada.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_VendaRealizada.MultiSelect = false;
            dataGridView_Venda.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_Venda.MultiSelect = false;

            // 2) Define colunas do grid do carrinho (VendaRealizada)
            dataGridView_VendaRealizada.Columns.Clear();
            dataGridView_VendaRealizada.Columns.Add("descricao", "Descrição");
            dataGridView_VendaRealizada.Columns.Add("quantidade", "Quantidade");
            dataGridView_VendaRealizada.Columns.Add("preco", "Preço");

            // 3) Ajusta quais colunas são editáveis
            //    - "descricao" e "preco" nunca editáveis
            //    - "quantidade" editável para que o usuário possa alterar a quantidade antes de Atualizar
            dataGridView_VendaRealizada.Columns["descricao"].ReadOnly = true;
            dataGridView_VendaRealizada.Columns["preco"].ReadOnly = true;
            dataGridView_VendaRealizada.Columns["quantidade"].ReadOnly = false;

            // 4) Associa eventos
            this.Load += Form_Venda_Load;
            button_Pesquisar.Click += button_Pesquisar_Click;
            button_Adicionar.Click += button_Adicionar_Click;
            button_NovaVenda.Click += button_NovaVenda_Click;
            button_FinalizarVenda.Click += button_FinalizarVenda_Click;
            button_CancelarVenda.Click += button_CancelarVenda_Click;
            comboBox_TipoPagamento.SelectedIndexChanged += comboBox_TipoPagamento_SelectedIndexChanged;
            textBox_TaxaCartao.TextChanged += textBox_TaxaCartao_TextChanged;

            // 5) Prepara a tela (data, botões, etc.)
            InicializarCaixa();
        }

        private void Form_Venda_Load(object sender, EventArgs e)
        {
            CarregarProdutos();
            // Exibe o próximo ID de venda no Label
            label_CodVenda.Text = ObterProximoIdVenda().ToString();
            button_NovaVenda.PerformClick();
            CheckCarrinhoVazio();
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
            label4.Visible = false;  // suposição: label4 é o rótulo da taxa
        }

        private void CarregarProdutos(string filtro = "")
        {
            try
            {
                if (ClassSQLite.conexao.State != ConnectionState.Open)
                    ClassSQLite.conexao.Open();

                if (string.IsNullOrWhiteSpace(filtro))
                {
                    ClassSQLite.comando.CommandText =
                        "SELECT id, descricao_produto, preco_produto FROM tbl_produtos;";
                }
                else
                {
                    ClassSQLite.comando.CommandText =
                        "SELECT id, descricao_produto, preco_produto " +
                        "FROM tbl_produtos " +
                        "WHERE descricao_produto LIKE '%" + filtro + "%';";
                }

                var da = new SQLiteDataAdapter(ClassSQLite.comando);
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
                if (ClassSQLite.conexao.State == ConnectionState.Open)
                    ClassSQLite.conexao.Close();
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
            textBox_Pesquisar.Clear();

            // Atualiza o próximo ID de venda
            label_CodVenda.Text = ObterProximoIdVenda().ToString();
            CarregarProdutos();
            CheckCarrinhoVazio();
        }

        private void button_Adicionar_Click(object sender, EventArgs e)
        {
            if (dataGridView_Venda.SelectedRows.Count == 0) return;

            var row = dataGridView_Venda.SelectedRows[0];
            string desc = row.Cells["descricao_produto"].Value.ToString();
            decimal preco = Convert.ToDecimal(row.Cells["preco_produto"].Value);

            dataGridView_VendaRealizada.Rows.Add(desc, 1, preco);
            AtualizarTotal();
            CheckCarrinhoVazio();
        }
        private void CheckCarrinhoVazio()
        {
            // Conta apenas linhas “de verdade” (não IsNewRow)
            bool carrinhoVazio = dataGridView_VendaRealizada.Rows
                .Cast<DataGridViewRow>()
                .All(r => r.IsNewRow);

            comboBox_TipoPagamento.Enabled = !carrinhoVazio;
            button_FinalizarVenda.Enabled = !carrinhoVazio;
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
            // Conta apenas as linhas válidas (não-NewRow)
            int linhasValidas = dataGridView_VendaRealizada.Rows
                .Cast<DataGridViewRow>()
                .Count(r => !r.IsNewRow);

            if (linhasValidas == 0)
            {
                MessageBox.Show("Adicione itens ao carrinho antes de finalizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (ClassSQLite.conexao.State != ConnectionState.Open)
                    ClassSQLite.conexao.Open();

                // (restante do seu código de inserção permanece igual)
                string carrinhoStr = "";
                foreach (DataGridViewRow linha in dataGridView_VendaRealizada.Rows)
                {
                    if (linha.IsNewRow)
                        continue;

                    string desc = linha.Cells["descricao"].Value.ToString();
                    int qtd = Convert.ToInt32(linha.Cells["quantidade"].Value);
                    carrinhoStr += $"{desc} x{qtd}; ";
                }

                string dataVenda = DateTime.Parse(label_Data.Text).ToString("yyyy-MM-dd");

                // Insere na tbl_venda
                ClassSQLite.comando.CommandText =
                    "INSERT INTO tbl_venda (data_venda, carrinho, fk_colaborador) " +
                    "VALUES (@data, @carrinho, @colab);";
                ClassSQLite.comando.Parameters.Clear();
                ClassSQLite.comando.Parameters.AddWithValue("@data", dataVenda);
                ClassSQLite.comando.Parameters.AddWithValue("@carrinho", carrinhoStr);
                ClassSQLite.comando.Parameters.AddWithValue("@colab", Sessao.IdColaborador);
                ClassSQLite.comando.ExecuteNonQuery();

                // Recupera id gerado
                ClassSQLite.comando.CommandText = "SELECT last_insert_rowid();";
                int idVenda = Convert.ToInt32(ClassSQLite.comando.ExecuteScalar());
                label_CodVenda.Text = idVenda.ToString();

                // Insere na tbl_pagamento
                decimal valor = Convert.ToDecimal(label_TotalVenda.Text);
                string tipo = comboBox_TipoPagamento.SelectedItem.ToString();
                ClassSQLite.comando.CommandText =
                    "INSERT INTO tbl_pagamento " +
                    "(data_pagamento, tipo_pagamento, valor_total, fk_colaborador) " +
                    "VALUES (@data, @tipo, @valor, @colab);";
                ClassSQLite.comando.Parameters.Clear();
                ClassSQLite.comando.Parameters.AddWithValue("@data", dataVenda);
                ClassSQLite.comando.Parameters.AddWithValue("@tipo", tipo);
                ClassSQLite.comando.Parameters.AddWithValue("@valor", valor);
                ClassSQLite.comando.Parameters.AddWithValue("@colab", Sessao.IdColaborador);
                ClassSQLite.comando.ExecuteNonQuery();

                MessageBox.Show($"Venda #{idVenda} finalizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button_NovaVenda.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao finalizar venda: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (ClassSQLite.conexao.State == ConnectionState.Open)
                    ClassSQLite.conexao.Close();
                ClassSQLite.comando.Parameters.Clear();
            }
        }

        private int ObterProximoIdVenda()
        {
            int proximo = 1;
            try
            {
                if (ClassSQLite.conexao.State != ConnectionState.Open)
                    ClassSQLite.conexao.Open();

                ClassSQLite.comando.CommandText =
                  "SELECT seq FROM sqlite_sequence WHERE name = 'tbl_venda';";
                object obj = ClassSQLite.comando.ExecuteScalar();
                if (obj != null && int.TryParse(obj.ToString(), out var ultimo))
                {
                    proximo = ultimo + 1;
                }
            }
            catch
            {
                // Se não existir registro em sqlite_sequence, mantém proximo = 1
            }
            finally
            {
                if (ClassSQLite.conexao.State == ConnectionState.Open)
                    ClassSQLite.conexao.Close();
            }
            return proximo;
        }

        private void button_Remover_Click(object sender, EventArgs e)
        {
            // Verifica se existe alguma linha selecionada
            if (dataGridView_VendaRealizada.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um item para remover.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Remove todas as linhas selecionadas (normalmente é uma só)
            foreach (DataGridViewRow linha in dataGridView_VendaRealizada.SelectedRows)
            {
                dataGridView_VendaRealizada.Rows.Remove(linha);
            }

            // Recalcula o total (chama o método já existente)
            AtualizarTotal();
            CheckCarrinhoVazio();
        }

        private void button_Atualizar_Click(object sender, EventArgs e)
        {
            // 1) Verifica se alguma linha está selecionada
            if (dataGridView_VendaRealizada.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um item para atualizar a quantidade.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dataGridView_VendaRealizada.SelectedRows[0];

            // 2) Tenta converter o valor da célula "quantidade" para inteiro
            if (!int.TryParse(row.Cells["quantidade"].Value?.ToString(), out int novaQuantidade) || novaQuantidade < 1)
            {
                MessageBox.Show("Quantidade inválida. Digite um número inteiro maior ou igual a 1.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Restaura para 1, por segurança
                row.Cells["quantidade"].Value = 1;
                return;
            }

            // 3) Se quiser, você pode também ajustar alguma outra lógica no próprio row,
            //    mas como “quantidade” e “preço” são colunas separadas e “AtualizarTotal” multiplica ambos,
            //    basta chamar o recálculo abaixo.

            AtualizarTotal();
            CheckCarrinhoVazio();
        }

        private void button_CancelarVenda_Click(object sender, EventArgs e)
        {
            button_NovaVenda.PerformClick();
        }
    }
}