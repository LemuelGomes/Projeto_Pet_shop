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

            InitializeComponent();
            servidor = "Server=localhost;Database=loja_pet_shop;Uid=root;Pwd=";
            conexao = new MySqlConnection(servidor);
            comando = conexao.CreateCommand();
        }

        private void buttonCadProd_Click(object sender, EventArgs e)
        {
            bool novoProduto = true;

            if (novoProduto)
            {
                try
                {
                    conexao.Open();
                    comando.CommandText = "SELECT descricao_produto, categoria_produto FROM produtos WHERE descricao_produto = '" + textBoxDESCPRODUTO.Text + "' AND categoria_produto = '" + textBoxCATPRODUTO.Text + "';";

                    MySqlDataReader resultadoPesquisa = comando.ExecuteReader();

                    if (resultadoPesquisa.Read())
                    {
                        novoProduto = false;
                        MessageBox.Show("Produto já Cadastrado!");
                        textBoxDESCPRODUTO.Clear();
                        textBoxCATPRODUTO.Clear();
                        textBoxVALORPRODUTO.Clear();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro ao cadastrar o usuário.Fale com o administrador do sistema.");
                }
                finally
                {
                    conexao.Close();
                }

                // --------------------------------------- //

                try
                {
                    conexao.Open();
                    comando.CommandText = "INSERT INTO produtos(descricao_produto, categoria_produto, preco_produto, fk_colaborador) VALUES ('" + textBoxDESCPRODUTO.Text + "', '" + textBoxCATPRODUTO.Text + "', '" + textBoxVALORPRODUTO.Text + "', '" + 1 + "');";
                    comando.ExecuteNonQuery();
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro ao cadastrar o produto. Fale com o administrador do sistema.");
                }
                finally
                {
                    conexao.Close();
                    MessageBox.Show("Produto cadastrado com sucesso!");
                }
                textBoxDESCPRODUTO.Clear();
                textBoxCATPRODUTO.Clear();
                textBoxVALORPRODUTO.Clear();
            }
            else
            {
                MessageBox.Show("Algum campo não está preenchido!");
            }
        }
    }
}
