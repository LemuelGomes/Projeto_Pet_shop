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
    public partial class FormCadProdutos : Form
    {
        string servidor;
        MySqlConnection conexao;
        MySqlCommand comando;

        public FormCadProdutos()
        {
            InitializeComponent();

            textBoxID.Enabled = false;
            servidor = "Server=localhost;Database=loja_pet_shop;Uid=root;Pwd=";
            conexao = new MySqlConnection(servidor);
            comando = conexao.CreateCommand();
            atualizar_dataGRID();
        }
        private void atualizar_dataGRID()
        {
            try
            {
                conexao.Open();
                comando.CommandText = "SELECT * FROM produtos;";
                MySqlDataAdapter adaptadorProdutos = new MySqlDataAdapter(comando);
                DataTable tabelaProdutos = new DataTable();
                adaptadorProdutos.Fill(tabelaProdutos);
                dataGridViewPRODUTOS.DataSource = tabelaProdutos;
                dataGridViewPRODUTOS.Columns["id"].HeaderText = "Código";
                dataGridViewPRODUTOS.Columns["descricao_produto"].HeaderText = "Descrição";
                dataGridViewPRODUTOS.Columns["categoria_produto"].HeaderText = "Categoria";
                dataGridViewPRODUTOS.Columns["valor_produto"].HeaderText = "Preço";                
            }
            catch
            {
                MessageBox.Show("Não conseguimos atualizar sua lista de produtos, fale com o administrador do sistema!");
            }
            finally
            {
                conexao.Close();
            }
        }
        private void buttonCadProd_Click(object sender, EventArgs e)
        {
            bool novoProduto = true;

            if (textBoxDESCPRODUTO.Text != "" && textBoxCATPRODUTO.Text != "")
            {
                if (novoProduto)
                {
                    try
                    {
                        conexao.Open();
                        comando.CommandText = "SELECT descricao_produto FROM produtos WHERE descricao_produto = '" + textBoxDESCPRODUTO.Text + "';";

                        MySqlDataReader resultado = comando.ExecuteReader();

                        if (resultado.Read())
                        {
                            novoProduto = false;
                            MessageBox.Show("Produto já Cadastrado!!!");
                        }
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show("Erro ao cadastrar o produto. Fale com o administrador do sistema.");
                    }
                    finally
                    {
                        conexao.Close();
                    }
                    atualizar_dataGRID();

                    if (novoProduto == true && textBoxDESCPRODUTO.Text != "" && textBoxVALORPRODUTO.Text != "")
                    {
                        try
                        {
                            conexao.Open();
                            comando.CommandText = "INSERT INTO produtos (descricao_produto, categoria_produto, valor_produto) VALUES ('" + textBoxDESCPRODUTO.Text + "', '" + textBoxCATPRODUTO.Text + "', '" + textBoxVALORPRODUTO.Text.Replace(",", ".") + "');";
                            comando.ExecuteNonQuery();
                        }
                        catch (Exception erro)
                        {
                            MessageBox.Show("Seu produto não foi cadastrado verifique com o administrador do sistema");
                        }
                        finally
                        {
                            conexao.Close();
                            MessageBox.Show("Produto cadastrado com sucesso!");
                            textBoxDESCPRODUTO.Clear();
                            textBoxCATPRODUTO.Clear();
                            textBoxVALORPRODUTO.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Algum campo não está preenchido!");
                    }
                }
            }
        }
        private void buttonFECHAR_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void buttonEXCLUIR_Click(object sender, EventArgs e)
        {
            try
            {
                conexao.Open();
                comando.CommandText = "DELETE FROM produtos WHERE id = " + textBoxID.Text + ";";
                comando.ExecuteNonQuery();
                MessageBox.Show("Produto exluído com sucesso!");
            }
            catch (Exception erro)
            {
                MessageBox.Show("O produto não foi excluido, verifique o ID do produto!");
            }
            finally
            {
                conexao.Close();
                textBoxID.Clear();
                textBoxDESCPRODUTO.Clear();
                textBoxCATPRODUTO.Clear();
                textBoxVALORPRODUTO.Clear();
            }
            atualizar_dataGRID();
        }
        private void buttonATUALIZAR_Click(object sender, EventArgs e)
        {
            try
            {
                conexao.Open();
                comando.CommandText = "SELECT * FROM produtos;";
                MySqlDataAdapter adaptadorProdutos = new MySqlDataAdapter(comando);
                DataTable tabelaProdutos = new DataTable();
                adaptadorProdutos.Fill(tabelaProdutos);
                dataGridViewPRODUTOS.DataSource = tabelaProdutos;
                dataGridViewPRODUTOS.Columns["id"].HeaderText = "Código";
                dataGridViewPRODUTOS.Columns["descricao_produto"].HeaderText = "Descrição";
                dataGridViewPRODUTOS.Columns["categoria_produto"].HeaderText = "Categoria";
                dataGridViewPRODUTOS.Columns["valor_produto"].HeaderText = "Preço";
                MessageBox.Show("Sua lista de produtos foi atualizada com sucesso!");
            }
            catch
            {
                MessageBox.Show("Não conseguimos atualizar sua lista de produtos, fale com o administrador do sistema!");
            }
            finally
            {
                conexao.Close();
            }
        }
        private void dataGridViewPRODUTOS_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxID.Text = dataGridViewPRODUTOS.CurrentRow.Cells[0].Value.ToString();
            textBoxDESCPRODUTO.Text = dataGridViewPRODUTOS.CurrentRow.Cells[1].Value.ToString();
            textBoxCATPRODUTO.Text = dataGridViewPRODUTOS.CurrentRow.Cells[2].Value.ToString();
            textBoxVALORPRODUTO.Text = dataGridViewPRODUTOS.CurrentRow.Cells[3].Value.ToString().Replace(".", ",");
        }
        private void buttonATUALIZARL_Click(object sender, EventArgs e)
        {
            try
            {
                conexao.Open();
                comando.CommandText = "UPDATE produtos SET descricao_produto = '" + textBoxDESCPRODUTO.Text + "', categoria_produto = '" + textBoxCATPRODUTO.Text + "', valor_produto = '" + textBoxVALORPRODUTO.Text.Replace(",", ".") + "' WHERE id = '" + textBoxID.Text + "';";
                comando.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Seu produto não foi atualizado na lista! Verifique com o administrador!");
            }
            finally
            {
                conexao.Close();
                MessageBox.Show("Seu produto foi atualizado na lista!");
                textBoxDESCPRODUTO.Clear();
                textBoxCATPRODUTO.Clear();
                textBoxVALORPRODUTO.Clear();
                textBoxID.Clear();
            }
        }
        private void dataGridViewPRODUTOS_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                conexao.Open();
                comando.CommandText = "UPDATE produtos SET descricao_produto = '" + dataGridViewPRODUTOS.CurrentRow.Cells[1].Value.ToString() + "', categoria_produto = '" + dataGridViewPRODUTOS.CurrentRow.Cells[2].Value.ToString() + "', valor_produto = '" + dataGridViewPRODUTOS.CurrentRow.Cells[3].Value.ToString().Replace(",", ".") + "' WHERE id = '" + textBoxID.Text + "';";
                comando.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Seu produto não foi atualizado na lista! Verifique com o administrador!");
            }
            finally
            {
                conexao.Close();
                MessageBox.Show("Seu produto foi atualizado na lista!");
                textBoxDESCPRODUTO.Clear();
                textBoxCATPRODUTO.Clear();
                textBoxVALORPRODUTO.Clear();
                textBoxID.Clear();
            }
        }
    }
}