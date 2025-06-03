using System;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace Projeto_Pet_shop
{
    public partial class Form_CadColaborador : Form
    {
        public Form_CadColaborador()
        {
            InitializeComponent();
        }

        private void button_Cadastrar_Click(object sender, EventArgs e)
        {
            if (textBox_Nome.Text == "" ||
                textBox_Sobrenome.Text == "" ||
                textBox_Email.Text == "" ||
                textBox_CPF.Text == "" ||
                textBox_Senha.Text == "" ||
                (!radioButton_ADM.Checked && !radioButton_Operador.Checked) ||
                textBox_Cargo.Text == "")
            {
                MessageBox.Show("Preencha todos os campos obrigatórios.");
                return;
            }

            string departamento = radioButton_ADM.Checked ? "ADM" : "Operador";

            try
            {
                ClassSQLite.conexao.Open();

                // 1) Insere na tbl_pessoa
                ClassSQLite.comando.CommandText =
                    "INSERT INTO tbl_pessoa (nome, sobrenome, email, cpf, senha) " +
                    "VALUES ('" + textBox_Nome.Text + "', " +
                            " '" + textBox_Sobrenome.Text + "', " +
                            " '" + textBox_Email.Text + "', " +
                            " '" + textBox_CPF.Text + "', " +
                            " '" + textBox_Senha.Text + "');";
                ClassSQLite.comando.ExecuteNonQuery();

                // 2) Recupera o último ID gerado em tbl_pessoa
                ClassSQLite.comando.CommandText = "SELECT last_insert_rowid();";
                int idPessoa = Convert.ToInt32(ClassSQLite.comando.ExecuteScalar());

                // 3) Insere na tbl_colaborador usando esse idPessoa
                ClassSQLite.comando.CommandText =
                    "INSERT INTO tbl_colaborador " +
                    "(data_admissao, data_demissao, departamento, cargo, fk_pessoa) " +
                    "VALUES (" +
                    " '" + dateTimePicker_Admissao.Value.ToString("yyyy-MM-dd") + "', " +
                       " NULL, " +
                    " '" + departamento + "', " +
                    " '" + textBox_Cargo.Text + "', " +
                      idPessoa +
                    ");";
                ClassSQLite.comando.ExecuteNonQuery();

                MessageBox.Show("Cadastro de colaborador realizado com sucesso!");
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao cadastrar colaborador: " + erro.Message);
            }
            finally
            {
                ClassSQLite.conexao.Close();
            }

            // Volta ao Form_Gerenciamento
            this.Hide();
            using (var formGerenciamento = new Form_Gerenciamento())
            {
                formGerenciamento.ShowDialog();
            }
            this.Close();
        }

        private void Form_CadColaborador_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
                using (var formGerenciamento = new Form_Gerenciamento())
                {
                    formGerenciamento.ShowDialog();
                }
                this.Close();
            }
        }
    }
}