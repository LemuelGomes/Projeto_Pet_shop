using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Globalization;

namespace Projeto_Pet_shop
{
    public partial class Form_CadProdutos : Form
    {
        private int idProdutoSelecionado = 0;

        public Form_CadProdutos()
        {
            InitializeComponent();
            textBox_PrecoCusto.Leave += PrecoTextBox_Leave;
            textBox_PrecoVenda.Leave += PrecoTextBox_Leave;
            atualizar_dataGRID();
        }
        private void PrecoTextBox_Leave(object sender, EventArgs e)
        {
            var txt = (TextBox)sender;
            // Tenta parsear qualquer número ou moeda no formato pt-BR
            if (decimal.TryParse(txt.Text,
                    NumberStyles.Number | NumberStyles.AllowCurrencySymbol,
                    new CultureInfo("pt-BR"),
                    out var valor))
            {
                // Formata como R$ 1.234,56
                txt.Text = valor.ToString("C", new CultureInfo("pt-BR"));
            }
            else
            {
                // Se não for válido, limpa ou mantém o texto anterior
                txt.Text = "";
            }
        }


        private void atualizar_dataGRID()
        {
            try
            {
                ClassSQLite.conexao.Open();
                ClassSQLite.comando.CommandText =
                    "SELECT id, descricao_produto, categoria_produto, quantidade_produto, preco_custo, preco_produto " +
                    "FROM tbl_produtos;";
                var adaptadorProdutos = new SQLiteDataAdapter(ClassSQLite.comando);
                var tabelaProdutos = new DataTable();
                adaptadorProdutos.Fill(tabelaProdutos);

                dataGridViewPRODUTOS.DataSource = tabelaProdutos;
                dataGridViewPRODUTOS.Columns["id"].Visible = false;
                dataGridViewPRODUTOS.Columns["descricao_produto"].HeaderText = "Descrição";
                dataGridViewPRODUTOS.Columns["categoria_produto"].HeaderText = "Categoria";
                dataGridViewPRODUTOS.Columns["quantidade_produto"].HeaderText = "Estoque";
                dataGridViewPRODUTOS.Columns["preco_custo"].HeaderText = "Preço de Custo";
                dataGridViewPRODUTOS.Columns["preco_produto"].HeaderText = "Preço do Produto";
            }
            catch
            {
                MessageBox.Show(
                    "Não conseguimos atualizar sua lista de produtos, fale com o administrador do sistema!",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                ClassSQLite.conexao.Close();
            }
        }

        private void button_CadProduto_Click(object sender, EventArgs e)
        {
            // 1) Validação dos campos
            if (string.IsNullOrWhiteSpace(textBox_Descricao.Text) ||
                string.IsNullOrWhiteSpace(textBox_Categoria.Text) ||
                string.IsNullOrWhiteSpace(textBox_Quantidade.Text) ||
                string.IsNullOrWhiteSpace(textBox_PrecoCusto.Text) ||
                string.IsNullOrWhiteSpace(textBox_PrecoVenda.Text))
            {
                MessageBox.Show("Preencha todos os campos obrigatórios.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2) Conversão dos valores numéricos
            if (!int.TryParse(textBox_Quantidade.Text, out int quantidade))
            {
                MessageBox.Show("Quantidade inválida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Para ler valores formatados em pt-BR (ex: "R$ 1.234,56")
            var cultura = new System.Globalization.CultureInfo("pt-BR");

            if (!decimal.TryParse(textBox_PrecoCusto.Text,
                    System.Globalization.NumberStyles.Currency,
                    cultura,
                    out decimal precoCusto))
            {
                MessageBox.Show("Preço de custo inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(textBox_PrecoVenda.Text,
                    System.Globalization.NumberStyles.Currency,
                    cultura,
                    out decimal precoVenda))
            {
                MessageBox.Show("Preço de venda inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (ClassSQLite.conexao.State != ConnectionState.Open)
                    ClassSQLite.conexao.Open();

                // 3) Comando parametrizado para evitar injeção e formatação manual
                ClassSQLite.comando.CommandText = @"
            INSERT INTO tbl_produtos
              (descricao_produto,
               categoria_produto,
               quantidade_produto,
               preco_custo,
               preco_produto,
               fk_colaborador,
               fk_pagamento)
            VALUES
              (@desc,
               @cat,
               @qtd,
               @custo,
               @venda,
               @colab,
               NULL);";

                ClassSQLite.comando.Parameters.Clear();
                ClassSQLite.comando.Parameters.AddWithValue("@desc", textBox_Descricao.Text.Trim());
                ClassSQLite.comando.Parameters.AddWithValue("@cat", textBox_Categoria.Text.Trim());
                ClassSQLite.comando.Parameters.AddWithValue("@qtd", quantidade);
                ClassSQLite.comando.Parameters.AddWithValue("@custo", precoCusto);
                ClassSQLite.comando.Parameters.AddWithValue("@venda", precoVenda);
                ClassSQLite.comando.Parameters.AddWithValue("@colab", Sessao.IdColaborador);

                // 4) Executa o INSERT
                ClassSQLite.comando.ExecuteNonQuery();

                MessageBox.Show("Produto cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 5) Limpa os campos
                textBox_Descricao.Clear();
                textBox_Categoria.Clear();
                textBox_Quantidade.Clear();
                textBox_PrecoCusto.Clear();
                textBox_PrecoVenda.Clear();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao cadastrar produto:\n" + erro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (ClassSQLite.conexao.State == ConnectionState.Open)
                    ClassSQLite.conexao.Close();
            }

            // 6) Atualiza o grid
            atualizar_dataGRID();
        }

        private void buttonFECHAR_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var Form_CadProdutos = new Form_Gerenciamento())
            {
                Form_CadProdutos.ShowDialog();
            }
            this.Close();
        }

        private void button_AtualizarLista_Click(object sender, EventArgs e)
        {
            atualizar_dataGRID();
            MessageBox.Show("A lista de produtos foi atualizada!");
        }

        private void button_ExcluirProd_Click(object sender, EventArgs e)
        {
            if (textBox_Descricao.Text == "")
            {
                MessageBox.Show("Digite a descrição do produto para buscar.");
                return;
            }

            int idProduto = 0;

            try
            {
                ClassSQLite.conexao.Open();
                ClassSQLite.comando.CommandText =
                    "SELECT id, categoria_produto, quantidade_produto, preco_custo, preco_produto " +
                    "FROM tbl_produtos " +
                    "WHERE descricao_produto = @desc;";
                ClassSQLite.comando.Parameters.Clear();
                ClassSQLite.comando.Parameters.AddWithValue("@desc", textBox_Descricao.Text);
                SQLiteDataReader leitor = ClassSQLite.comando.ExecuteReader();

                if (leitor.Read())
                {
                    idProduto = leitor.GetInt32(0);
                    textBox_Categoria.Text = leitor.GetString(1);
                    textBox_Quantidade.Text = leitor.GetInt32(2).ToString();
                    textBox_PrecoCusto.Text = leitor.GetDouble(3).ToString();
                    textBox_PrecoVenda.Text = leitor.GetDouble(4).ToString();
                }
                else
                {
                    MessageBox.Show("Produto não encontrado.");
                    leitor.Close();
                    return;
                }
                leitor.Close();

                var resp = MessageBox.Show(
                    "Deseja realmente excluir este produto?",
                    "Confirmar exclusão",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resp == DialogResult.Yes)
                {
                    ClassSQLite.comando.CommandText =
                        "DELETE FROM tbl_produtos WHERE id = @id;";
                    ClassSQLite.comando.Parameters.Clear();
                    ClassSQLite.comando.Parameters.AddWithValue("@id", idProduto);
                    ClassSQLite.comando.ExecuteNonQuery();
                }

                textBox_Descricao.Clear();
                textBox_Categoria.Clear();
                textBox_Quantidade.Clear();
                textBox_PrecoCusto.Clear();
                textBox_PrecoVenda.Clear();
                MessageBox.Show("Produto excluído com sucesso.");
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao excluir produto: " + erro.Message);
            }
            finally
            {
                ClassSQLite.conexao.Close();
            }

            atualizar_dataGRID();

        }

        private void button_Atualizar_Click(object sender, EventArgs e)
        {
            // 1) Verifica se a descrição foi informada
            if (string.IsNullOrWhiteSpace(textBox_Descricao.Text))
            {
                MessageBox.Show(
                    "Digite a descrição do produto para buscar ou atualizar.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Cultura pt-BR para ler preços formatados
            var cultura = new System.Globalization.CultureInfo("pt-BR");

            try
            {
                // 2) Abre conexão se necessário
                if (ClassSQLite.conexao.State != ConnectionState.Open)
                    ClassSQLite.conexao.Open();

                // 3) Se não temos produto selecionado, buscamos pelo texto
                if (idProdutoSelecionado == 0)
                {
                    ClassSQLite.comando.CommandText = @"
                SELECT id, categoria_produto, quantidade_produto, preco_custo, preco_produto
                  FROM tbl_produtos
                 WHERE descricao_produto = @desc;
            ";
                    ClassSQLite.comando.Parameters.Clear();
                    ClassSQLite.comando.Parameters.AddWithValue("@desc", textBox_Descricao.Text.Trim());

                    using (var leitor = ClassSQLite.comando.ExecuteReader())
                    {
                        if (leitor.Read())
                        {
                            idProdutoSelecionado = leitor.GetInt32(0);
                            textBox_Categoria.Text = leitor.GetString(1);
                            textBox_Quantidade.Text = leitor.GetInt32(2).ToString();
                            textBox_PrecoCusto.Text = leitor.GetDouble(3).ToString("C", cultura);
                            textBox_PrecoVenda.Text = leitor.GetDouble(4).ToString("C", cultura);
                        }
                        else
                        {
                            MessageBox.Show(
                                "Produto não encontrado.",
                                "Aviso",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );
                        }
                    }
                }
                else
                {
                    // 4) Temos produto selecionado: atualiza seus campos
                    // Valida quantidade
                    if (!int.TryParse(textBox_Quantidade.Text, out int quantidade) || quantidade < 0)
                    {
                        MessageBox.Show("Quantidade inválida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Valida preços
                    if (!decimal.TryParse(textBox_PrecoCusto.Text, System.Globalization.NumberStyles.Currency, cultura, out decimal precoCusto))
                    {
                        MessageBox.Show("Preço de custo inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (!decimal.TryParse(textBox_PrecoVenda.Text, System.Globalization.NumberStyles.Currency, cultura, out decimal precoVenda))
                    {
                        MessageBox.Show("Preço de venda inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    ClassSQLite.comando.CommandText = @"
                UPDATE tbl_produtos
                   SET descricao_produto  = @desc,
                       categoria_produto  = @cat,
                       quantidade_produto = @qtd,
                       preco_custo        = @custo,
                       preco_produto      = @venda
                 WHERE id = @id;
            ";
                    ClassSQLite.comando.Parameters.Clear();
                    ClassSQLite.comando.Parameters.AddWithValue("@desc", textBox_Descricao.Text.Trim());
                    ClassSQLite.comando.Parameters.AddWithValue("@cat", textBox_Categoria.Text.Trim());
                    ClassSQLite.comando.Parameters.AddWithValue("@qtd", quantidade);
                    ClassSQLite.comando.Parameters.AddWithValue("@custo", precoCusto);
                    ClassSQLite.comando.Parameters.AddWithValue("@venda", precoVenda);
                    ClassSQLite.comando.Parameters.AddWithValue("@id", idProdutoSelecionado);

                    ClassSQLite.comando.ExecuteNonQuery();
                    MessageBox.Show(
                        "Produto atualizado com sucesso.",
                        "Sucesso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    // 5) Limpa estado para próxima atualização
                    idProdutoSelecionado = 0;
                    textBox_Descricao.Clear();
                    textBox_Categoria.Clear();
                    textBox_Quantidade.Clear();
                    textBox_PrecoCusto.Clear();
                    textBox_PrecoVenda.Clear();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(
                    "Erro ao atualizar produto:\n" + erro.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                // 6) Fecha conexão e atualiza grid
                if (ClassSQLite.conexao.State == ConnectionState.Open)
                    ClassSQLite.conexao.Close();

                atualizar_dataGRID();
            }
        }

    }
}