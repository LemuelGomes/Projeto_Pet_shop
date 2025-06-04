using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Pet_shop
{
    public partial class Form_GestaodePessoas : Form
    {
        public Form_GestaodePessoas()
        {
            InitializeComponent();

            // 1) Seleção em linha inteira e sem multiseleção
            dataGridView_Gestao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_Gestao.MultiSelect = false;

            // 2) Permite edição direta de todas as colunas (inclusive "senha")
            dataGridView_Gestao.ReadOnly = false;

            // 3) Ao clicar numa célula, podemos forçar edição se for coluna "senha"
            dataGridView_Gestao.CellClick += DataGridView_Gestao_CellClick;

            CarregarGestao();
        }

        private void CarregarGestao(string filtro = "")
        {
            try
            {
                if (ClassSQLite.conexao.State != ConnectionState.Open)
                    ClassSQLite.conexao.Open();

                var sql = new StringBuilder();
                sql.AppendLine("SELECT ");
                sql.AppendLine("  p.id_pessoa,");
                sql.AppendLine("  c.id_colaborador,");
                sql.AppendLine("  p.nome,");
                sql.AppendLine("  p.sobrenome,");
                sql.AppendLine("  p.email,");
                sql.AppendLine("  p.cpf,");
                sql.AppendLine("  p.senha,");
                sql.AppendLine("  c.data_admissao,");
                sql.AppendLine("  c.data_demissao,");
                sql.AppendLine("  c.departamento,");
                sql.AppendLine("  c.cargo");
                sql.AppendLine("FROM tbl_pessoa p");
                sql.AppendLine("INNER JOIN tbl_colaborador c ON p.id_pessoa = c.fk_pessoa");

                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    sql.AppendLine("WHERE ");
                    sql.AppendLine("  p.nome           LIKE @f OR");
                    sql.AppendLine("  p.sobrenome      LIKE @f OR");
                    sql.AppendLine("  p.email          LIKE @f OR");
                    sql.AppendLine("  p.cpf            LIKE @f OR");
                    sql.AppendLine("  p.senha          LIKE @f OR");
                    sql.AppendLine("  c.data_admissao  LIKE @f OR");
                    sql.AppendLine("  c.data_demissao  LIKE @f OR");
                    sql.AppendLine("  c.departamento   LIKE @f OR");
                    sql.AppendLine("  c.cargo          LIKE @f");
                }

                ClassSQLite.comando.CommandText = sql.ToString();
                ClassSQLite.comando.Parameters.Clear();
                if (!string.IsNullOrWhiteSpace(filtro))
                    ClassSQLite.comando.Parameters.AddWithValue("@f", $"%{filtro}%");

                var da = new SQLiteDataAdapter(ClassSQLite.comando);
                var dt = new DataTable();
                da.Fill(dt);

                dataGridView_Gestao.DataSource = dt;

                // Oculta colunas de ID
                dataGridView_Gestao.Columns["id_pessoa"].Visible = false;
                dataGridView_Gestao.Columns["id_colaborador"].Visible = false;

                // Ajuste de cabeçalhos
                dataGridView_Gestao.Columns["nome"].HeaderText = "Nome";
                dataGridView_Gestao.Columns["sobrenome"].HeaderText = "Sobrenome";
                dataGridView_Gestao.Columns["email"].HeaderText = "Email";
                dataGridView_Gestao.Columns["cpf"].HeaderText = "CPF";
                dataGridView_Gestao.Columns["senha"].HeaderText = "Senha";
                dataGridView_Gestao.Columns["data_admissao"].HeaderText = "Data Admissão";
                dataGridView_Gestao.Columns["data_demissao"].HeaderText = "Data Demissão";
                dataGridView_Gestao.Columns["departamento"].HeaderText = "Departamento";
                dataGridView_Gestao.Columns["cargo"].HeaderText = "Cargo";

                // 4) Registra CellFormatting para mascarar a coluna "senha"
                dataGridView_Gestao.CellFormatting -= DataGridView_Gestao_CellFormatting;
                dataGridView_Gestao.CellFormatting += DataGridView_Gestao_CellFormatting;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao carregar dados de gestão:\n" + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                if (ClassSQLite.conexao.State == ConnectionState.Open)
                    ClassSQLite.conexao.Close();
            }
        }

        private void DataGridView_Gestao_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Se for a coluna "senha" e houver valor
            if (dataGridView_Gestao.Columns[e.ColumnIndex].Name == "senha" && e.Value != null)
            {
                // Verifica se esta célula está em edição
                bool emEdicao =
                    dataGridView_Gestao.CurrentCellAddress.X == e.ColumnIndex &&
                    dataGridView_Gestao.CurrentCellAddress.Y == e.RowIndex &&
                    dataGridView_Gestao.IsCurrentCellInEditMode;

                if (!emEdicao)
                {
                    // Mascarar com asteriscos
                    var textoOriginal = e.Value.ToString();
                    e.Value = new string('*', textoOriginal.Length);
                    e.FormattingApplied = true;
                }
                // Se estiver em edição, mostra o valor real para o usuário editar
            }
        }

        private void DataGridView_Gestao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Se clicar no cabeçalho ou fora de linha, ignora
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            // Se for coluna "senha", inicia o modo de edição naquela célula
            if (dataGridView_Gestao.Columns[e.ColumnIndex].Name == "senha")
            {
                dataGridView_Gestao.CurrentCell = dataGridView_Gestao.Rows[e.RowIndex].Cells[e.ColumnIndex];
                dataGridView_Gestao.BeginEdit(true);
            }
        }

        private void button_Pesquisar_Click(object sender, EventArgs e)
        {
            CarregarGestao(textBox_Pesquisar.Text.Trim());
        }

        private void button_Limpar_Click(object sender, EventArgs e)
        {
            textBox_Pesquisar.Clear();
            CarregarGestao();
        }

        private void button_Menu_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var frm = new Form_Gerenciamento())
            {
                frm.ShowDialog();
            }
            this.Close();
        }

        private void button_Atualizar_Click(object sender, EventArgs e)
        {
            if (dataGridView_Gestao.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Selecione um colaborador para atualizar.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            var row = dataGridView_Gestao.SelectedRows[0];

            // Obtém as chaves primárias
            int idPessoa = Convert.ToInt32(row.Cells["id_pessoa"].Value);
            int idColaborador = Convert.ToInt32(row.Cells["id_colaborador"].Value);

            // Lê valores editáveis em tbl_pessoa
            string nome = row.Cells["nome"].Value?.ToString() ?? "";
            string sobrenome = row.Cells["sobrenome"].Value?.ToString() ?? "";
            string email = row.Cells["email"].Value?.ToString() ?? "";
            string cpf = row.Cells["cpf"].Value?.ToString() ?? "";

            // Lê valor editável em tbl_pessoa: senha
            string senha = row.Cells["senha"].Value?.ToString() ?? "";

            // Lê valores editáveis em tbl_colaborador
            string dataAdm = row.Cells["data_admissao"].Value?.ToString() ?? "";
            string dataDem = row.Cells["data_demissao"].Value?.ToString() ?? "";
            string departamento = row.Cells["departamento"].Value?.ToString() ?? "";
            string cargo = row.Cells["cargo"].Value?.ToString() ?? "";

            // Se data_demissao preenchida, pergunta desligamento
            if (!string.IsNullOrWhiteSpace(dataDem))
            {
                var resp = MessageBox.Show(
                    "Você alterou Data Demissão.\nDeseja realmente desligar o colaborador? (Conta ficará inativa)",
                    "Confirmar Desligamento",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resp == DialogResult.No)
                {
                    CarregarGestao(textBox_Pesquisar.Text.Trim());
                    return;
                }
            }

            try
            {
                ClassSQLite.conexao.Open();

                // Atualiza tbl_pessoa (incluindo senha)
                ClassSQLite.comando.CommandText = @"
                    UPDATE tbl_pessoa
                       SET nome      = @nome,
                           sobrenome = @sobrenome,
                           email     = @email,
                           cpf       = @cpf,
                           senha     = @senha
                     WHERE id_pessoa = @idPessoa;
                ";
                ClassSQLite.comando.Parameters.Clear();
                ClassSQLite.comando.Parameters.AddWithValue("@nome", nome);
                ClassSQLite.comando.Parameters.AddWithValue("@sobrenome", sobrenome);
                ClassSQLite.comando.Parameters.AddWithValue("@email", email);
                ClassSQLite.comando.Parameters.AddWithValue("@cpf", cpf);
                ClassSQLite.comando.Parameters.AddWithValue("@senha", senha);
                ClassSQLite.comando.Parameters.AddWithValue("@idPessoa", idPessoa);
                ClassSQLite.comando.ExecuteNonQuery();

                // Atualiza tbl_colaborador
                ClassSQLite.comando.CommandText = @"
                    UPDATE tbl_colaborador
                       SET data_admissao = @dataAdm,
                           data_demissao = CASE WHEN @dataDem = '' THEN NULL ELSE @dataDem END,
                           departamento  = @departamento,
                           cargo         = @cargo
                     WHERE id_colaborador = @idColab;
                ";
                ClassSQLite.comando.Parameters.Clear();
                ClassSQLite.comando.Parameters.AddWithValue("@dataAdm", dataAdm);
                ClassSQLite.comando.Parameters.AddWithValue("@dataDem", dataDem);
                ClassSQLite.comando.Parameters.AddWithValue("@departamento", departamento);
                ClassSQLite.comando.Parameters.AddWithValue("@cargo", cargo);
                ClassSQLite.comando.Parameters.AddWithValue("@idColab", idColaborador);
                ClassSQLite.comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao atualizar colaborador:\n" + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                if (ClassSQLite.conexao.State == ConnectionState.Open)
                    ClassSQLite.conexao.Close();
            }

            // Recarrega o grid após atualização
            CarregarGestao(textBox_Pesquisar.Text.Trim());
        }
    }
}
