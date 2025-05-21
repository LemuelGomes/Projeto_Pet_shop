using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

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

            string departamento;
            if (radioButton_ADM.Checked)
                departamento = "ADM";
            else
                departamento = "Operador";

            try
            {
                ClassMYSQL.conexao.Open();
                ClassMYSQL.comando.CommandText =
                    "INSERT INTO tbl_pessoa (nome, sobrenome, email, cpf, senha) " +
                    "VALUES ('" + textBox_Nome.Text + "', " +
                            " '" + textBox_Sobrenome.Text + "', " +
                            " '" + textBox_Email.Text + "', " +
                            " '" + textBox_CPF.Text + "', " +
                            " '" + textBox_Senha.Text + "');";
                ClassMYSQL.comando.ExecuteNonQuery();

                ClassMYSQL.comando.CommandText = "SELECT LAST_INSERT_ID();";
                MySqlDataReader readerID = ClassMYSQL.comando.ExecuteReader();
                int idPessoa = 0;

                if (readerID.Read())
                {
                    idPessoa = readerID.GetInt32(0);
                }
                readerID.Close();
                ClassMYSQL.comando.CommandText =
                    "INSERT INTO tbl_colaborador " +
                    "(data_admissao, data_demissao, departamento, cargo, fk_pessoa) " +
                    "VALUES (" +
                    " '" + dateTimePicker_Admissao.Value.ToString("yyyy-MM-dd") + "'," +
                       " NULL, " +
                    " '" + departamento + "', " +
                    " '" + textBox_Cargo.Text + "', " +
                      idPessoa +
                    ");";
                ClassMYSQL.comando.ExecuteNonQuery();

                MessageBox.Show("Cadastro de colaborador realizado com sucesso!");
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao cadastrar colaborador: " + erro.Message);
            }
            finally
            {
                ClassMYSQL.conexao.Close();
            }
            this.Hide();
            Form_Gerenciamento Form_CadColaborador = new Form_Gerenciamento();
            Form_CadColaborador.ShowDialog();
            this.Close();
        }
    }
}
