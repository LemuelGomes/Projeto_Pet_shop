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
    public partial class Form_CadProdutos : Form
    {
        public Form_CadProdutos()
        {
            InitializeComponent();

            atualizar_dataGRID();
        }
        private void atualizar_dataGRID()
        {
            try
            {
                ClassMYSQL.conexao.Open();
                ClassMYSQL.comando.CommandText = "SELECT descricao_produto, categoria_produto, quantidade_produto, preco_custo, preco_produto FROM tbl_produtos;";
                MySqlDataAdapter adaptadorProdutos = new MySqlDataAdapter(ClassMYSQL.comando);
                DataTable tabelaProdutos = new DataTable();
                adaptadorProdutos.Fill(tabelaProdutos);
                dataGridViewPRODUTOS.DataSource = tabelaProdutos;
                dataGridViewPRODUTOS.Columns["descricao_produto"].HeaderText = "Descrição";
                dataGridViewPRODUTOS.Columns["categoria_produto"].HeaderText = "Categoria";
                dataGridViewPRODUTOS.Columns["quantidade_produto"].HeaderText = "Estoque";
                dataGridViewPRODUTOS.Columns["preco_custo"].HeaderText = "Preço de Custo";
                dataGridViewPRODUTOS.Columns["preco_produto"].HeaderText = "Preço do Produto";
            }
            catch
            {
                MessageBox.Show("Não conseguimos atualizar sua lista de produtos, fale com o administrador do sistema!");
            }
            finally
            {
                ClassMYSQL.conexao.Close();
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
                if (ClassMYSQL.conexao.State != ConnectionState.Open)
                    ClassMYSQL.conexao.Open();

                ClassMYSQL.comando.CommandText =
                    "INSERT INTO tbl_produtos " +
                    "(descricao_produto, categoria_produto, quantidade_produto, preco_custo, preco_produto, fk_colaborador, fk_pagamento) " +
                    "VALUES (" +
                       " '" + textBox_Descricao.Text + "'," +
                       " '" + textBox_Categoria.Text + "'," +
                         textBox_Quantidade.Text + "," +
                         textBox_PrecoCusto.Text.Replace(',', '.') + "," +
                         textBox_PrecoVenda.Text.Replace(',', '.') + "," +
                         Sessao.IdColaborador + "," +
                         " NULL" +
                    ");";
    
                ClassMYSQL.comando.ExecuteNonQuery();
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
                if (ClassMYSQL.conexao.State == ConnectionState.Open)
                    ClassMYSQL.conexao.Close();
            }
            atualizar_dataGRID();
        }
        private void buttonFECHAR_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_Gerenciamento Form_CadProdutos = new Form_Gerenciamento();
            Form_CadProdutos.ShowDialog();
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

            try
            {
                if (ClassMYSQL.conexao.State != ConnectionState.Open)
                    ClassMYSQL.conexao.Open();

                ClassMYSQL.comando.CommandText =
                    "SELECT id, categoria_produto, quantidade_produto, preco_custo, preco_produto" +
                    "FROM tbl_produtos " +
                    "WHERE descricao_produto = '" + textBox_Descricao.Text + "';";
                MySqlDataReader leitor = ClassMYSQL.comando.ExecuteReader();

                int idProduto = 0;
                if (leitor.Read())
                {
                    idProduto = leitor.GetInt32("id");
                    textBox_Categoria.Text = leitor.GetString("categoria_produto");
                    textBox_Quantidade.Text = leitor.GetInt32("quantidade_produto").ToString();
                    textBox_PrecoCusto.Text = leitor.GetDecimal("preco_custo").ToString();
                    textBox_PrecoVenda.Text = leitor.GetDecimal("preco_produto").ToString();
                }
                else
                {
                    leitor.Close();
                    MessageBox.Show("Produto não encontrado.");
                    return;
                }
                leitor.Close();

                atualizar_dataGRID();

                DialogResult resp = MessageBox.Show(
                    "Deseja realmente excluir este produto?",
                    "Confirmar exclusão",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resp == DialogResult.Yes)
                {
                    ClassMYSQL.comando.CommandText =
                        "DELETE FROM tbl_produtos WHERE id = " + idProduto + ";";
                    ClassMYSQL.comando.ExecuteNonQuery();
                    MessageBox.Show("Produto excluído com sucesso.");
                }

                textBox_Descricao.Clear();
                textBox_Categoria.Clear();
                textBox_Quantidade.Clear();
                textBox_PrecoCusto.Clear();
                textBox_PrecoVenda.Clear();

                atualizar_dataGRID();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao excluir produto: " + erro.Message);
            }
            finally
            {
                if (ClassMYSQL.conexao.State == ConnectionState.Open)
                    ClassMYSQL.conexao.Close();
            }
        }
    }
}