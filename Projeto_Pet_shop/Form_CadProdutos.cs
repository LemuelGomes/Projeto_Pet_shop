using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Projeto_Pet_shop
{
    public partial class Form_CadProdutos : Form
    {
        private int idProdutoSelecionado = 0;

        public Form_CadProdutos()
        {
            InitializeComponent();
            atualizar_dataGRID();
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
                dataGridViewPRODUTOS.Columns["id"].Visible = false;              // esconde o ID
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
            if (textBox_Descricao.Text == "" ||
                textBox_Categoria.Text == "" ||
                textBox_Quantidade.Text == "" ||
                textBox_PrecoCusto.Text == "" ||
                textBox_PrecoVenda.Text == "")
            {
                MessageBox.Show("Preencha todos os campos obrigatórios.");
                return;
            }

            try
            {
                if (ClassSQLite.conexao.State != ConnectionState.Open)
                    ClassSQLite.conexao.Open();

                ClassSQLite.comando.CommandText =
                    "INSERT INTO tbl_produtos " +
                    "(descricao_produto, categoria_produto, quantidade_produto, preco_custo, preco_produto, fk_colaborador, fk_pagamento) " +
                    "VALUES (" +
                       " @desc, " +
                       " @cat, " +
                         "@qtd, " +
                         "@custo, " +
                         "@venda, " +
                         "@colab, " +
                         "NULL" +
                    ");";
                ClassSQLite.comando.Parameters.Clear();
                ClassSQLite.comando.Parameters.AddWithValue("@desc", textBox_Descricao.Text);
                ClassSQLite.comando.Parameters.AddWithValue("@cat", textBox_Categoria.Text);
                ClassSQLite.comando.Parameters.AddWithValue("@qtd", Convert.ToInt32(textBox_Quantidade.Text));
                ClassSQLite.comando.Parameters.AddWithValue("@custo", Convert.ToDouble(textBox_PrecoCusto.Text.Replace(',', '.')));
                ClassSQLite.comando.Parameters.AddWithValue("@venda", Convert.ToDouble(textBox_PrecoVenda.Text.Replace(',', '.')));
                ClassSQLite.comando.Parameters.AddWithValue("@colab", Sessao.IdColaborador);

                ClassSQLite.comando.ExecuteNonQuery();
                MessageBox.Show("Produto cadastrado com sucesso!");

                textBox_Descricao.Clear();
                textBox_Categoria.Clear();
                textBox_PrecoCusto.Clear();
                textBox_PrecoVenda.Clear();
                textBox_Quantidade.Clear();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao cadastrar produto: " + erro.Message);
            }
            finally
            {
                if (ClassSQLite.conexao.State == ConnectionState.Open)
                    ClassSQLite.conexao.Close();
            }
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

                atualizar_dataGRID();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao excluir produto: " + erro.Message);
            }
            finally
            {
                ClassSQLite.conexao.Close();
            }
        }

        private void button_Atualizar_Click(object sender, EventArgs e)
        {
            // 1) Verifica se descrição foi informada
            if (textBox_Descricao.Text == "")
            {
                MessageBox.Show("Digite a descrição do produto para buscar ou atualizar.");
                return;
            }

            try
            {
                ClassSQLite.conexao.Open();

                if (idProdutoSelecionado == 0)
                {
                    ClassSQLite.comando.CommandText =
                        "SELECT id, categoria_produto, quantidade_produto, preco_custo, preco_produto " +
                        "FROM tbl_produtos " +
                        "WHERE descricao_produto = @desc;";
                    ClassSQLite.comando.Parameters.Clear();
                    ClassSQLite.comando.Parameters.AddWithValue("@desc", textBox_Descricao.Text);

                    var leitor = ClassSQLite.comando.ExecuteReader();
                    if (leitor.Read())
                    {
                        idProdutoSelecionado = leitor.GetInt32(0);
                        textBox_Categoria.Text = leitor.GetString(1);
                        textBox_Quantidade.Text = leitor.GetInt32(2).ToString();
                        textBox_PrecoCusto.Text = leitor.GetDouble(3).ToString();
                        textBox_PrecoVenda.Text = leitor.GetDouble(4).ToString();
                    }
                    else
                    {
                        MessageBox.Show("Produto não encontrado.");
                    }
                    leitor.Close();
                }
                else
                {
                    ClassSQLite.comando.CommandText =
                        "UPDATE tbl_produtos SET " +
                        "descricao_produto   = @desc, " +
                        "categoria_produto   = @cat, " +
                        "quantidade_produto  = @qtd, " +
                        "preco_custo         = @custo, " +
                        "preco_produto       = @venda " +
                        "WHERE id = @id;";

                    ClassSQLite.comando.Parameters.Clear();
                    ClassSQLite.comando.Parameters.AddWithValue("@desc", textBox_Descricao.Text);
                    ClassSQLite.comando.Parameters.AddWithValue("@cat", textBox_Categoria.Text);
                    ClassSQLite.comando.Parameters.AddWithValue("@qtd", Convert.ToInt32(textBox_Quantidade.Text));
                    ClassSQLite.comando.Parameters.AddWithValue("@custo", Convert.ToDouble(textBox_PrecoCusto.Text.Replace(',', '.')));
                    ClassSQLite.comando.Parameters.AddWithValue("@venda", Convert.ToDouble(textBox_PrecoVenda.Text.Replace(',', '.')));
                    ClassSQLite.comando.Parameters.AddWithValue("@id", idProdutoSelecionado);

                    ClassSQLite.comando.ExecuteNonQuery();
                    MessageBox.Show("Produto atualizado com sucesso.");

                    // volta ao estado inicial
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
                MessageBox.Show("Erro ao atualizar produto: " + erro.Message);
            }
            finally
            {
                ClassSQLite.conexao.Close();
                atualizar_dataGRID();
            }
        }

        private void Form_CadProdutos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
                using (var frm = new Form_Gerenciamento())
                {
                    frm.ShowDialog();
                }
                this.Close();
            }
        }
    }
}