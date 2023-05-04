﻿using MySql.Data.MySqlClient;
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

            servidor = "Server=localhost;Database=loja_pet_shop;Uid=root;Pwd=";
            conexao = new MySqlConnection(servidor);
            comando = conexao.CreateCommand();
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
                MessageBox.Show("Registro exluído com sucesso!");
            }
            catch (Exception erro)
            {
                MessageBox.Show("O produto não foi excluido, verifique o ID do produto!");
            }
            finally
            {
                conexao.Close();
                textBoxID.Clear();
            }
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
        }
    }
}

