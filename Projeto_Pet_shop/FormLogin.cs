using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Projeto_Pet_shop
{
    public partial class FormLogin : Form
    {
        string servidor;
        MySqlConnection conexao;
        MySqlCommand comando;

        public FormLogin()
        {
            InitializeComponent();
            servidor = "Server=localhost;Database=loja_pet_shop;Uid=root;Pwd=";
            conexao = new MySqlConnection(servidor);
            comando = conexao.CreateCommand();
            labelERRO.Text = "";
        }

        private void buttonENTRAR_Click(object sender, EventArgs e)
        {
            if (textBoxUSUARIO.Text != "" && textBoxSENHA.Text != "")
            {
                try
                {
                    conexao.Open();
                    comando.CommandText = "SELECT usuario, senha FROM colaborador WHERE usuario = '" + textBoxUSUARIO.Text + "' AND senha = '" + textBoxSENHA.Text + "';";

                    MySqlDataReader resultadoPesquisa = comando.ExecuteReader();

                    if (resultadoPesquisa.Read())
                    {                        
                        FormCadProdutos FormLogin = new FormCadProdutos();
                        FormLogin.ShowDialog();
                        textBoxUSUARIO.Clear();
                        textBoxSENHA.Clear();
                    }
                    else
                    {
                        labelERRO.Text = ("Usuário e/ou Senha Incorreto!");                        
                        textBoxSENHA.Clear();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro ao entrar com o usuário.Fale com o administrador do sistema.");
                }
                finally
                {
                    conexao.Close();
                }
            }
            else
            {
                MessageBox.Show("Usuário e/ou Senha não inseridos!");
            }
        }

        private void buttonLIMPAR_Click(object sender, EventArgs e)
        {
            textBoxUSUARIO.Clear();
            textBoxSENHA.Clear();
            labelERRO.Text = "";
        }

        private void buttonCADASTRAR_Click(object sender, EventArgs e)
        {
            bool novoUsuario = true;

            if (textBoxUSUARIO.Text != "" && textBoxSENHA.Text != "")
            {
                try
                {
                    conexao.Open();
                    comando.CommandText = "SELECT usuario, senha FROM colaborador WHERE usuario = '" + textBoxUSUARIO.Text + "' AND senha = '" + textBoxSENHA.Text + "';";

                    MySqlDataReader resultadoPesquisa = comando.ExecuteReader();

                    if (resultadoPesquisa.Read())
                    {
                        novoUsuario = false;
                        MessageBox.Show("Usuário já Cadastrado!");
                        textBoxUSUARIO.Clear();
                        textBoxSENHA.Clear();
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

                /// ---------------- ///

                if (novoUsuario)
                {
                    try
                    {
                        conexao.Open();
                        comando.CommandText = "INSERT INTO colaborador(usuario, senha) VALUES ('" + textBoxUSUARIO.Text + "', '" + textBoxSENHA.Text + "');";
                        comando.ExecuteNonQuery();
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show("Erro ao cadastrar o usuário. Fale com o administrador do sistema.");
                    }
                    finally
                    {
                        conexao.Close();
                        MessageBox.Show("Usuário cadastrado com sucesso!");
                    }
                    textBoxUSUARIO.Clear();
                    textBoxSENHA.Clear();
                }
            }
            else
            {
                MessageBox.Show("Usuário e/ou Senha não inseridos!");
            }
        }

        private void buttonFECHAR_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Obrigado por utilizar nosso Programa de Cadastro!");
            Application.Exit();
        }
    }
}
