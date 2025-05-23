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

        private void button_Entrar_Click(object sender, EventArgs e)
        {
            if (textBox_Usuario.Text == "" || textBox_Senha.Text == "")
            {
                MessageBox.Show("Verifique se você digitou o usuário e senha!");
                return;
            }

            try
            {
                // 1) Abre conexão
                if (ClassMYSQL.conexao.State != ConnectionState.Open)
                    ClassMYSQL.conexao.Open();

                // 2) Pega o id_pessoa
                ClassMYSQL.comando.CommandText =
                    "SELECT id_pessoa " +
                    "FROM tbl_pessoa " +
                    "WHERE email = '" + textBox_Usuario.Text + "' " +
                    "  AND senha = '" + textBox_Senha.Text + "';";
                object objPessoa = ClassMYSQL.comando.ExecuteScalar();
                if (objPessoa == null)
                {
                    labelERRO.Text = "Usuário e/ou senha incorretos!";
                    textBox_Senha.Clear();
                    return;
                }
                int idPessoa = Convert.ToInt32(objPessoa);

                // 3) Pega id_colaborador e departamento numa só consulta
                ClassMYSQL.comando.CommandText =
                    "SELECT id_colaborador, departamento " +
                    "FROM tbl_colaborador " +
                    "WHERE fk_pessoa = " + idPessoa + ";";
                using (var readerCol = ClassMYSQL.comando.ExecuteReader())
                {
                    if (!readerCol.Read())
                    {
                        MessageBox.Show("Colaborador não cadastrado. Fale com o administrador.");
                        return;
                    }

                    int idColab = readerCol.GetInt32("id_colaborador");
                    string departamento = readerCol.GetString("departamento");
                    readerCol.Close();

                    // 4) Armazena o id correto de colaborador na sessão
                    Sessao.IdColaborador = idColab;

                    // 5) Fecha a conexão antes de abrir o próximo form
                    ClassMYSQL.conexao.Close();

                    // 6) Navega para a tela adequada
                    this.Hide();
                    if (departamento == "ADM")
                        new Form_Gerenciamento().ShowDialog();
                    else // Operador (ou outro departamento padrão)
                        new Form_Venda().ShowDialog();

                    // 7) Fecha o login quando voltar
                    this.Close();
                }
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
            if (e.CloseReason == CloseReason.UserClosing)
            {
                var resp = MessageBox.Show(
                    "Deseja realmente sair da aplicação?",
                    "Confirmar saída",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resp == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }

}