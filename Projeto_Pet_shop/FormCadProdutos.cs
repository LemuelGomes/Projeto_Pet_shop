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
                    conexao.Open();

                    try
                    {
                        comando.CommandText = "INSERT INTO produtos (descricao_produto, categoria_produto, valor_produto) VALUES ('" + textBoxDESCPRODUTO.Text + "', '" + textBoxCATPRODUTO.Text + "', '" + textBoxVALORPRODUTO.Text + "');";
                        comando.ExecuteNonQuery();
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show(erro.Message);
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
        private void buttonFECHAR_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

