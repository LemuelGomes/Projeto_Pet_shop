using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Projeto_Pet_shop
{
    public partial class Form_Relatorio : Form
    {
        public Form_Relatorio()
        {
            InitializeComponent();

            // Configurações iniciais do DataGridView
            dataGridView_Relatorio.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_Relatorio.MultiSelect = false;
            dataGridView_Relatorio.ReadOnly = true;

            // Só associamos filtros após os ComboBoxes serem populados (no Load)
            this.Load += Form_Relatorio_Load;

            button_Limpar.Click += button_Limpar_Click;
            button_GerarRelatorio.Click += button_GerarRelatorio_Click;
            button_Sair.Click += (s, e) => this.Close();
        }

        private void Form_Relatorio_Load(object sender, EventArgs e)
        {
            // 1) Preenche todos os ComboBoxes
            CarregarCombos();

            // 2) Agora que eles estão preenchidos, podemos associar os eventos
            comboBox_Colaborador.SelectedIndexChanged += Filtros_Changed;
            comboBox_Periodo.SelectedIndexChanged += Filtros_Changed;
            comboBox_TipoPagamento.SelectedIndexChanged += Filtros_Changed;

            // 3) Carrega o grid pela primeira vez
            CarregarRelatorio();
        }

        private void CarregarCombos()
        {
            try
            {
                // Abre conexão se ainda não estiver aberta
                if (ClassSQLite.conexao.State != ConnectionState.Open)
                    ClassSQLite.conexao.Open();

                // ---------- 1) Carrega Colaboradores ----------
                comboBox_Colaborador.Items.Clear();
                comboBox_Colaborador.Items.Add("Todos");  // índice 0
                ClassSQLite.comando.CommandText =
                    "SELECT c.id_colaborador, p.nome || ' ' || p.sobrenome AS nome_completo " +
                    "FROM tbl_colaborador c " +
                    "JOIN tbl_pessoa p ON c.fk_pessoa = p.id_pessoa " +
                    "ORDER BY p.nome, p.sobrenome;";
                using (var reader = ClassSQLite.comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int idCol = reader.GetInt32(0);
                        string nome = reader.GetString(1);
                        comboBox_Colaborador.Items.Add(new ComboItem { Id = idCol, Text = nome });
                    }
                }
                if (comboBox_Colaborador.Items.Count > 0)
                    comboBox_Colaborador.SelectedIndex = 0;


                // ---------- 2) Configura comboBox_Periodo com 3 opções fixas ----------
                comboBox_Periodo.Items.Clear();
                comboBox_Periodo.Items.Add("Todos");   // índice 0
                comboBox_Periodo.Items.Add("Mensal");  // índice 1
                comboBox_Periodo.Items.Add("Anual");   // índice 2
                comboBox_Periodo.SelectedIndex = 0;    // Padrão: “Todos”


                // ---------- 3) Carrega Tipos de Pagamento ----------
                comboBox_TipoPagamento.Items.Clear();
                comboBox_TipoPagamento.Items.Add("Todos");  // índice 0
                ClassSQLite.comando.CommandText =
                    "SELECT DISTINCT tipo_pagamento FROM tbl_pagamento ORDER BY tipo_pagamento;";
                using (var reader = ClassSQLite.comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string t = reader.GetString(0);
                        comboBox_TipoPagamento.Items.Add(t);
                    }
                }
                if (comboBox_TipoPagamento.Items.Count > 0)
                    comboBox_TipoPagamento.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao carregar filtros:\n" + ex.Message,
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

        private void Filtros_Changed(object sender, EventArgs e)
        {
            CarregarRelatorio();
        }

        private void button_Limpar_Click(object sender, EventArgs e)
        {
            if (comboBox_Colaborador.Items.Count > 0) comboBox_Colaborador.SelectedIndex = 0;
            if (comboBox_Periodo.Items.Count > 0) comboBox_Periodo.SelectedIndex = 0;
            if (comboBox_TipoPagamento.Items.Count > 0) comboBox_TipoPagamento.SelectedIndex = 0;

            CarregarRelatorio();
        }

        private void CarregarRelatorio()
        {
            try
            {
                if (ClassSQLite.conexao.State != ConnectionState.Open)
                    ClassSQLite.conexao.Open();

                var sb = new StringBuilder();
                sb.AppendLine("SELECT ");
                sb.AppendLine("  v.id_venda AS VendaID,");
                sb.AppendLine("  v.data_venda AS DataVenda,");
                sb.AppendLine("  v.carrinho AS ItensVendidos,");
                sb.AppendLine("  p.nome || ' ' || p.sobrenome AS Colaborador,");
                sb.AppendLine("  pag.tipo_pagamento AS TipoPagamento,");
                sb.AppendLine("  pag.valor_total AS ValorTotal");
                sb.AppendLine("FROM tbl_venda v");
                sb.AppendLine("JOIN tbl_colaborador c ON v.fk_colaborador = c.id_colaborador");
                sb.AppendLine("JOIN tbl_pessoa p ON c.fk_pessoa = p.id_pessoa");
                sb.AppendLine("LEFT JOIN tbl_pagamento pag ON pag.fk_colaborador = c.id_colaborador");
                sb.AppendLine("  AND date(pag.data_pagamento) = v.data_venda");

                var filtros = new StringBuilder();
                var cmd = ClassSQLite.comando;
                cmd.Parameters.Clear();

                // ---- Filtro Colaborador ----
                if (comboBox_Colaborador.SelectedIndex > 0)
                {
                    var itemCol = comboBox_Colaborador.SelectedItem as ComboItem;
                    filtros.AppendLine(filtros.Length == 0 ? "WHERE " : "AND ");
                    filtros.AppendLine("  c.id_colaborador = @idColab");
                    cmd.Parameters.AddWithValue("@idColab", itemCol.Id);
                }

                // ---- Filtro Período: “Mensal” ou “Anual” ----
                if (comboBox_Periodo.SelectedIndex == 1)
                {
                    // Mensal: filtra pelo ano-mês atual
                    string anoMes = DateTime.Now.ToString("yyyy-MM");
                    filtros.AppendLine(filtros.Length == 0 ? "WHERE " : "AND ");
                    filtros.AppendLine("  strftime('%Y-%m', v.data_venda) = @periodo");
                    cmd.Parameters.AddWithValue("@periodo", anoMes);
                }
                else if (comboBox_Periodo.SelectedIndex == 2)
                {
                    // Anual: filtra pelo ano atual
                    string ano = DateTime.Now.ToString("yyyy");
                    filtros.AppendLine(filtros.Length == 0 ? "WHERE " : "AND ");
                    filtros.AppendLine("  strftime('%Y', v.data_venda) = @ano");
                    cmd.Parameters.AddWithValue("@ano", ano);
                }
                // Se “Todos” (índice 0), não filtra por data

                // ---- Filtro Tipo de Pagamento ----
                if (comboBox_TipoPagamento.SelectedIndex > 0)
                {
                    string tp = comboBox_TipoPagamento.SelectedItem.ToString();
                    filtros.AppendLine(filtros.Length == 0 ? "WHERE " : "AND ");
                    filtros.AppendLine("  pag.tipo_pagamento = @tipo");
                    cmd.Parameters.AddWithValue("@tipo", tp);
                }

                // Monta SQL final
                var sqlFinal = new StringBuilder();
                sqlFinal.Append(sb);
                sqlFinal.Append(filtros);

                cmd.CommandText = sqlFinal.ToString();

                var da = new SQLiteDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);

                dataGridView_Relatorio.DataSource = dt;

                // Ajuste de Colunas (altera nome de cabeçalhos)
                if (dataGridView_Relatorio.Columns.Contains("VendaID"))
                    dataGridView_Relatorio.Columns["VendaID"].HeaderText = "ID Venda";
                if (dataGridView_Relatorio.Columns.Contains("DataVenda"))
                    dataGridView_Relatorio.Columns["DataVenda"].HeaderText = "Data da Venda";
                if (dataGridView_Relatorio.Columns.Contains("ItensVendidos"))
                    dataGridView_Relatorio.Columns["ItensVendidos"].HeaderText = "Itens Vendidos";
                if (dataGridView_Relatorio.Columns.Contains("Colaborador"))
                    dataGridView_Relatorio.Columns["Colaborador"].HeaderText = "Colaborador";
                if (dataGridView_Relatorio.Columns.Contains("TipoPagamento"))
                    dataGridView_Relatorio.Columns["TipoPagamento"].HeaderText = "Tipo Pagamento";
                if (dataGridView_Relatorio.Columns.Contains("ValorTotal"))
                    dataGridView_Relatorio.Columns["ValorTotal"].HeaderText = "Valor Total";

                // AutoSize para cabeçalhos e células
                dataGridView_Relatorio.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView_Relatorio.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao carregar relatório:\n" + ex.Message,
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

        private void button_GerarRelatorio_Click(object sender, EventArgs e)
        {
            if (dataGridView_Relatorio.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Não há dados para exportar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            using (var sfd = new SaveFileDialog())
            {
                // Um único diálogo com duas opções de formato
                sfd.Filter = "Excel Workbook (*.xlsx)|*.xlsx|PDF File (*.pdf)|*.pdf";
                sfd.FileName = $"Relatorio_{DateTime.Now:yyyyMMdd_HHmm}";
                if (sfd.ShowDialog() != DialogResult.OK)
                    return;

                string extension = Path.GetExtension(sfd.FileName).ToLower();
                try
                {
                    if (extension == ".xlsx")
                    {
                        ExportarParaExcel(sfd.FileName);
                        MessageBox.Show(
                            $"Arquivo Excel salvo em:\n{sfd.FileName}",
                            "Sucesso",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                    else if (extension == ".pdf")
                    {
                        ExportarParaPdf(sfd.FileName);
                        MessageBox.Show(
                            $"Arquivo PDF salvo em:\n{sfd.FileName}",
                            "Sucesso",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                    else
                    {
                        MessageBox.Show(
                            "Por favor, escolha uma extensão válida (.xlsx ou .pdf).",
                            "Erro",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Erro ao salvar arquivo:\n" + ex.Message,
                        "Erro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        private void ExportarParaExcel(string caminho)
        {
            using (var wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add("Relatório");

                // 1) Cabeçalhos
                for (int col = 0; col < dataGridView_Relatorio.Columns.Count; col++)
                {
                    ws.Cell(1, col + 1).Value = dataGridView_Relatorio.Columns[col].HeaderText;
                }

                // 2) Conteúdo
                for (int row = 0; row < dataGridView_Relatorio.Rows.Count; row++)
                {
                    for (int col = 0; col < dataGridView_Relatorio.Columns.Count; col++)
                    {
                        var cellValue = dataGridView_Relatorio.Rows[row].Cells[col].Value;
                        string texto = cellValue == null ? "" : cellValue.ToString();
                        ws.Cell(row + 2, col + 1).SetValue(texto);
                    }
                }

                // 3) Formatar como tabela com bordas e estilo
                int lastRow = dataGridView_Relatorio.Rows.Count + 1;
                int lastCol = dataGridView_Relatorio.Columns.Count;
                var tabela = ws.Range(1, 1, lastRow, lastCol).CreateTable();
                tabela.Theme = XLTableTheme.TableStyleMedium9;

                // 4) Ajustar largura das colunas
                ws.Columns().AdjustToContents();

                // 5) Salvar no caminho escolhido
                wb.SaveAs(caminho);
            }
        }

        private void ExportarParaPdf(string caminho)
        {
            // Documento PDF em landscape (paisagem)
            var doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate(), 20, 20, 20, 20);
            using (var fs = new FileStream(caminho, FileMode.Create, FileAccess.Write))
            {
                iTextSharp.text.pdf.PdfWriter.GetInstance(doc, fs);
                doc.Open();

                var fonteCabecalho = iTextSharp.text.FontFactory.GetFont(
                    iTextSharp.text.FontFactory.HELVETICA_BOLD, 10);
                var fonteCelula = iTextSharp.text.FontFactory.GetFont(
                    iTextSharp.text.FontFactory.HELVETICA, 9);

                int numCols = dataGridView_Relatorio.Columns.Count;
                var tabelaPdf = new iTextSharp.text.pdf.PdfPTable(numCols)
                {
                    WidthPercentage = 100,
                    HeaderRows = 1
                };

                // Definir larguras aproximadas de colunas
                float[] larguras = new float[numCols];
                for (int i = 0; i < numCols; i++)
                    larguras[i] = (float)dataGridView_Relatorio.Columns[i].Width;
                tabelaPdf.SetWidths(larguras);

                // Cabeçalhos
                for (int col = 0; col < numCols; col++)
                {
                    string textoCab = dataGridView_Relatorio.Columns[col].HeaderText;
                    var cellCab = new iTextSharp.text.pdf.PdfPCell(
                        new Phrase(textoCab, fonteCabecalho))
                    {
                        BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY,
                        HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                        Padding = 5
                    };
                    tabelaPdf.AddCell(cellCab);
                }

                // Conteúdo
                for (int row = 0; row < dataGridView_Relatorio.Rows.Count; row++)
                {
                    for (int col = 0; col < numCols; col++)
                    {
                        var cel = dataGridView_Relatorio.Rows[row].Cells[col].Value;
                        string texto = cel == null ? "" : cel.ToString();

                        var cell = new iTextSharp.text.pdf.PdfPCell(
                            new Phrase(texto, fonteCelula))
                        {
                            Padding = 4
                        };
                        tabelaPdf.AddCell(cell);
                    }
                }

                doc.Add(tabelaPdf);
                doc.Close();
            }
        }
    }

    /// <summary>
    /// Classe auxiliar para popular ComboBox com pares (Id, Texto).
    /// </summary>
    internal class ComboItem
    {
        public object Id { get; set; }
        public string Text { get; set; }
        public override string ToString() => Text;
    }
}
