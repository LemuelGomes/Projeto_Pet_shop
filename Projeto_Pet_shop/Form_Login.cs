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
    public partial class Form_Login : Form
    {

        public Form_Login()
        {
            InitializeComponent();
            this.FormClosing += Form_Login_FormClosing;
            labelERRO.Text = "";
        }

        private void button_Entrar_Click(object sender, EventArgs e)
        {
            if (textBox_Usuario.Text == "" || textBox_Senha.Text == "")
            {
                MessageBox.Show("Verifique se você digitou o usuário e senha!");
                return;
            }

            try
            {
                if (ClassMYSQL.conexao.State != ConnectionState.Open)
                    ClassMYSQL.conexao.Open();

                ClassMYSQL.comando.CommandText =
                    "SELECT id_pessoa FROM tbl_pessoa " +
                    "WHERE email = '" + textBox_Usuario.Text + "' " +
                    "  AND senha = '" + textBox_Senha.Text + "';";
                MySqlDataReader leitorPessoa = ClassMYSQL.comando.ExecuteReader();

                int id_pessoa = 0;
                if (leitorPessoa.Read())
                {
                    id_pessoa = leitorPessoa.GetInt32(0);
                }
                leitorPessoa.Close();

                if (id_pessoa == 0)
                {
                    labelERRO.Text = "Usuário e/ou senha incorretos!";
                    textBox_Senha.Clear();
                    return;
                }

                ClassMYSQL.comando.CommandText =
                    "SELECT departamento FROM tbl_colaborador " +
                    "WHERE fk_pessoa = " + id_pessoa + ";";
                string departamento = Convert.ToString(ClassMYSQL.comando.ExecuteScalar());

                ClassMYSQL.conexao.Close();
                this.Hide();

                if (departamento == "ADM")
                {
                    Sessao.IdColaborador = id_pessoa;
                    Form_Gerenciamento Form_Login = new Form_Gerenciamento();
                    Form_Login.ShowDialog();
                }
                else if (departamento == "Operador")
                {
                    Sessao.IdColaborador = id_pessoa;
                    Form_Venda Form_Login = new Form_Venda();
                    Form_Login.ShowDialog();
                }
                ClassMYSQL.conexao.Close();
                this.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao entrar: " + erro.Message);
            }
            finally
            {
                if (ClassMYSQL.conexao.State == ConnectionState.Open)
                    ClassMYSQL.conexao.Close();
            }
        }

        private void button_Limpar_Click(object sender, EventArgs e)
        {
            textBox_Usuario.Clear();
            textBox_Senha.Clear();
            labelERRO.Text = "";
        }

        private void Form_Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Fecha a aplicação.
        }
    }
}