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

                // Verifica se já existe um email igual
                ClassSQLite.comando.CommandText =
                    "SELECT COUNT(1) FROM tbl_pessoa WHERE email = @e;";
                ClassSQLite.comando.Parameters.Clear();
                ClassSQLite.comando.Parameters.AddWithValue("@e", textBox_Email.Text.Trim());
                int existente = Convert.ToInt32(ClassSQLite.comando.ExecuteScalar());
                if (existente > 0)
                {
                    MessageBox.Show(
                        "Este e-mail já está cadastrado. Por favor, informe outro.",
                        "E-mail duplicado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                // 1) Insere na tbl_pessoa
                ClassSQLite.comando.CommandText =
                    "INSERT INTO tbl_pessoa (nome, sobrenome, email, cpf, senha) " +
                    "VALUES (@nome, @sobrenome, @email, @cpf, @senha);";
                ClassSQLite.comando.Parameters.Clear();
                ClassSQLite.comando.Parameters.AddWithValue("@nome", textBox_Nome.Text.Trim());
                ClassSQLite.comando.Parameters.AddWithValue("@sobrenome", textBox_Sobrenome.Text.Trim());
                ClassSQLite.comando.Parameters.AddWithValue("@email", textBox_Email.Text.Trim());
                ClassSQLite.comando.Parameters.AddWithValue("@cpf", textBox_CPF.Text.Trim());
                ClassSQLite.comando.Parameters.AddWithValue("@senha", textBox_Senha.Text.Trim());
                ClassSQLite.comando.ExecuteNonQuery();

                // 2) Recupera o último ID gerado em tbl_pessoa
                ClassSQLite.comando.CommandText = "SELECT last_insert_rowid();";
                int idPessoa = Convert.ToInt32(ClassSQLite.comando.ExecuteScalar());

                // 3) Insere na tbl_colaborador usando esse idPessoa
                ClassSQLite.comando.CommandText =
                    "INSERT INTO tbl_colaborador " +
                    "(data_admissao, data_demissao, departamento, cargo, fk_pessoa) " +
                    "VALUES (@adm, NULL, @dep, @cargo, @id);";
                ClassSQLite.comando.Parameters.Clear();
                ClassSQLite.comando.Parameters.AddWithValue("@adm", dateTimePicker_Admissao.Value.ToString("yyyy-MM-dd"));
                ClassSQLite.comando.Parameters.AddWithValue("@dep", departamento);
                ClassSQLite.comando.Parameters.AddWithValue("@cargo", textBox_Cargo.Text.Trim());
                ClassSQLite.comando.Parameters.AddWithValue("@id", idPessoa);
                ClassSQLite.comando.ExecuteNonQuery();

                MessageBox.Show("Cadastro de colaborador realizado com sucesso!");
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao cadastrar colaborador:\n" + erro.Message);
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

        private void button_Sair_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_Gerenciamento Form_CadColaborador = new Form_Gerenciamento();
            Form_CadColaborador.ShowDialog();
            this.Close();
        }
    }
}