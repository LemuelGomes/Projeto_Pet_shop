using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

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
                if (ClassSQLite.conexao.State != ConnectionState.Open)
                    ClassSQLite.conexao.Open();

                ClassSQLite.comando.CommandText =
                    "SELECT id_pessoa " +
                    "FROM tbl_pessoa " +
                    "WHERE email = @email AND senha = @senha;";
                ClassSQLite.comando.Parameters.Clear();
                ClassSQLite.comando.Parameters.AddWithValue("@email", textBox_Usuario.Text);
                ClassSQLite.comando.Parameters.AddWithValue("@senha", textBox_Senha.Text);
                object objPessoa = ClassSQLite.comando.ExecuteScalar();
                if (objPessoa == null)
                {
                    labelERRO.Text = "Usuário e/ou senha incorretos!";
                    textBox_Senha.Clear();
                    return;
                }
                int idPessoa = Convert.ToInt32(objPessoa);

                ClassSQLite.comando.CommandText =
                    "SELECT id_colaborador, departamento, data_demissao " +
                    "FROM tbl_colaborador " +
                    "WHERE fk_pessoa = @fk_pessoa;";
                ClassSQLite.comando.Parameters.Clear();
                ClassSQLite.comando.Parameters.AddWithValue("@fk_pessoa", idPessoa);

                using (var readerCol = ClassSQLite.comando.ExecuteReader())
                {
                    if (!readerCol.Read())
                    {
                        MessageBox.Show("Colaborador não cadastrado. Fale com o administrador.");
                        readerCol.Close();
                        return;
                    }

                    int idColab = readerCol.GetInt32(0);
                    string departamento = readerCol.GetString(1);
                    var dataDemissaoObj = readerCol["data_demissao"];
                    readerCol.Close();

                    if (dataDemissaoObj != DBNull.Value && !string.IsNullOrWhiteSpace(dataDemissaoObj.ToString()))
                    {
                        MessageBox.Show("Usuário inativo (colaborador desligado).", "Acesso negado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    Sessao.IdColaborador = idColab;

                    ClassSQLite.conexao.Close();

                    this.Hide();
                    if (departamento == "ADM")
                        new Form_Gerenciamento().ShowDialog();
                    else
                        new Form_Venda().ShowDialog();
                    this.Close();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao entrar: " + erro.Message);
            }
            finally
            {
                if (ClassSQLite.conexao.State == ConnectionState.Open)
                    ClassSQLite.conexao.Close();
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
                    else
                    {
                        Application.Exit();
                    }
                }
            }

        }
    }
}