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
            labelERRO.Text = "";
        }

        private void buttonENTRAR_Click(object sender, EventArgs e)
        {
            if (textBoxUSUARIO.Text != "" && textBoxSENHA.Text != "")
            {
                try
                {
                    ClassMYSQL.conexao.Open();
                    ClassMYSQL.comando.CommandText = "SELECT email, senha FROM tbl_pessoa WHERE email = '" + textBoxUSUARIO.Text + "' AND senha = '" + textBoxSENHA.Text + "';";

                    MySqlDataReader resultadoPesquisa = ClassMYSQL.comando.ExecuteReader();

                    if (resultadoPesquisa.Read())
                    {
                        Form_Gerenciamento gerenciamento = new Form_Gerenciamento();
                        gerenciamento.ShowDialog();
                    }
                    else
                    {
                        labelERRO.Text = ("Usuário e/ou Senha Incorreto!");                        
                        textBoxSENHA.Clear();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro ao entrar com o usuário. Fale com o administrador do sistema.");
                }
                finally
                {
                    ClassMYSQL.conexao.Close();
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

        

        private void buttonFECHAR_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}