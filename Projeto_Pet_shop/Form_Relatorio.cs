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

            dataGridView_Relatorio.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_Relatorio.MultiSelect = false;
            dataGridView_Relatorio.ReadOnly = true;

            this.Load += Form_Relatorio_Load;

            button_Limpar.Click += button_Limpar_Click;
            button_Sair.Click += (s, e) => this.Close();
        }

        private void Form_Relatorio_Load(object sender, EventArgs e)
        {
            CarregarCombos();

            comboBox_Colaborador.SelectedIndexChanged += Filtros_Changed;
            comboBox_TipoPagamento.SelectedIndexChanged += Filtros_Changed;

            monthCalendar_Periodo.DateChanged += Filtros_Changed;

            CarregarRelatorio();
        }

        private void CarregarCombos()
        {
            try
            {
                if (ClassSQLite.conexao.State != ConnectionState.Open)
                    ClassSQLite.conexao.Open();

                comboBox_Colaborador.Items.Clear();
                comboBox_Colaborador.Items.Add("Todos");
                ClassSQLite.comando.CommandText =
                    @"SELECT c.id_colaborador, p.nome || ' ' || p.sobrenome
                      FROM tbl_colaborador c
                      JOIN tbl_pessoa p ON c.fk_pessoa = p.id_pessoa
                      ORDER BY p.nome, p.sobrenome;";
                using (var reader = ClassSQLite.comando.ExecuteReader())
                {
                    while (reader.Read())
                        comboBox_Colaborador.Items.Add(
                          new ComboItem
                          {
                              Id = reader.GetInt32(0),
                              Text = reader.GetString(1)
                          });
                }
                if (comboBox_Colaborador.Items.Count > 0)
                    comboBox_Colaborador.SelectedIndex = 0;

                comboBox_TipoPagamento.Items.Clear();
                comboBox_TipoPagamento.Items.Add("Todos");
                ClassSQLite.comando.CommandText =
                    "SELECT DISTINCT tipo_pagamento FROM tbl_pagamento ORDER BY tipo_pagamento;";
                using (var reader = ClassSQLite.comando.ExecuteReader())
                {
                    while (reader.Read())
                        comboBox_TipoPagamento.Items.Add(reader.GetString(0));
                }
                if (comboBox_TipoPagamento.Items.Count > 0)
                    comboBox_TipoPagamento.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar filtros:\n" + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (comboBox_TipoPagamento.Items.Count > 0) comboBox_TipoPagamento.SelectedIndex = 0;
            monthCalendar_Periodo.SetSelectionRange(
                DateTime.Today, DateTime.Today);

            CarregarRelatorio();
        }

        private void CarregarRelatorio()
        {
            try
            {
                if (ClassSQLite.conexao.State != ConnectionState.Open)
                    ClassSQLite.conexao.Open();

                var sb = new StringBuilder();
                sb.AppendLine("SELECT");
                sb.AppendLine("  v.id_venda       AS VendaID,");
                sb.AppendLine("  v.data_venda     AS DataVenda,");
                sb.AppendLine("  v.carrinho       AS ItensVendidos,");
                sb.AppendLine("  p.nome || ' ' || p.sobrenome AS Colaborador,");
                sb.AppendLine("  pag.tipo_pagamento  AS TipoPagamento,");
                sb.AppendLine("  pag.valor_total     AS ValorTotal");
                sb.AppendLine("FROM tbl_venda v");
                sb.AppendLine("JOIN tbl_colaborador c ON v.fk_colaborador = c.id_colaborador");
                sb.AppendLine("JOIN tbl_pessoa p ON c.fk_pessoa = p.id_pessoa");
                sb.AppendLine("LEFT JOIN tbl_pagamento pag");
                sb.AppendLine("  ON pag.fk_colaborador = c.id_colaborador");
                sb.AppendLine("  AND date(pag.data_pagamento) = v.data_venda");

                var filtros = new StringBuilder();
                var cmd = ClassSQLite.comando;
                cmd.Parameters.Clear();

                // filtro por colaborador
                if (comboBox_Colaborador.SelectedIndex > 0)
                {
                    var item = (ComboItem)comboBox_Colaborador.SelectedItem;
                    filtros.AppendLine(filtros.Length == 0 ? "WHERE" : "AND");
                    filtros.AppendLine("  c.id_colaborador = @colab");
                    cmd.Parameters.AddWithValue("@colab", item.Id);
                }

                // filtro por data exata (ou intervalo, se o usuário arrastar o monthCalendar)
                var inicio = monthCalendar_Periodo.SelectionRange.Start;
                var fim = monthCalendar_Periodo.SelectionRange.End;
                if (inicio == fim)
                {
                    filtros.AppendLine(filtros.Length == 0 ? "WHERE" : "AND");
                    filtros.AppendLine("  date(v.data_venda) = @dataInicio");
                    cmd.Parameters.AddWithValue("@dataInicio", inicio.ToString("yyyy-MM-dd"));
                }
                else
                {
                    filtros.AppendLine(filtros.Length == 0 ? "WHERE" : "AND");
                    filtros.AppendLine("  date(v.data_venda) BETWEEN @dataInicio AND @dataFim");
                    cmd.Parameters.AddWithValue("@dataInicio", inicio.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@dataFim", fim.ToString("yyyy-MM-dd"));
                }

                // filtro por tipo de pagamento
                if (comboBox_TipoPagamento.SelectedIndex > 0)
                {
                    filtros.AppendLine(filtros.Length == 0 ? "WHERE" : "AND");
                    filtros.AppendLine("  pag.tipo_pagamento = @tipo");
                    cmd.Parameters.AddWithValue("@tipo", comboBox_TipoPagamento.SelectedItem);
                }

                // monta SQL final
                cmd.CommandText = sb.Append(filtros).ToString();

                // preenche o DataTable
                var da = new SQLiteDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);

                dataGridView_Relatorio.DataSource = dt;

                // ajustar cabeçalhos
                if (dataGridView_Relatorio.Columns.Contains("VendaID"))
                    dataGridView_Relatorio.Columns["VendaID"].HeaderText = "ID Venda";
                if (dataGridView_Relatorio.Columns.Contains("DataVenda"))
                    dataGridView_Relatorio.Columns["DataVenda"].HeaderText = "Data";
                if (dataGridView_Relatorio.Columns.Contains("ItensVendidos"))
                    dataGridView_Relatorio.Columns["ItensVendidos"].HeaderText = "Itens";
                if (dataGridView_Relatorio.Columns.Contains("Colaborador"))
                    dataGridView_Relatorio.Columns["Colaborador"].HeaderText = "Colab.";
                if (dataGridView_Relatorio.Columns.Contains("TipoPagamento"))
                    dataGridView_Relatorio.Columns["TipoPagamento"].HeaderText = "Pagamento";
                if (dataGridView_Relatorio.Columns.Contains("ValorTotal"))
                    dataGridView_Relatorio.Columns["ValorTotal"].HeaderText = "Valor";

                // auto‐size
                dataGridView_Relatorio.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView_Relatorio.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar relatório:\n" + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                sfd.Filter = "PDF File (*.pdf)|*.pdf|Excel Workbook (*.xlsx)|*.xlsx";
                sfd.DefaultExt = "pdf";
                sfd.AddExtension = true;
                sfd.FileName = $"Relatório_{DateTime.Now:dd-MM-yyyy}";

                if (sfd.ShowDialog() != DialogResult.OK)
                    return;

                var ext = Path.GetExtension(sfd.FileName).ToLowerInvariant();
                try
                {
                    if (ext == ".pdf")
                        ExportarParaPdf(sfd.FileName);
                    else if (ext == ".xlsx")
                        ExportarParaExcel(sfd.FileName);
                    else
                        throw new InvalidOperationException("Formato não suportado.");

                    MessageBox.Show(
                        $"Arquivo salvo em:\n{sfd.FileName}",
                        "Sucesso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Erro ao salvar o arquivo:\n" + ex.Message,
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
                for (int c = 0; c < dataGridView_Relatorio.Columns.Count; c++)
                    ws.Cell(1, c + 1).Value = dataGridView_Relatorio.Columns[c].HeaderText;
                for (int r = 0; r < dataGridView_Relatorio.Rows.Count; r++)
                    for (int c = 0; c < dataGridView_Relatorio.Columns.Count; c++)
                        ws.Cell(r + 2, c + 1).Value =
                            dataGridView_Relatorio.Rows[r].Cells[c].Value?.ToString() ?? "";

                var lastRow = dataGridView_Relatorio.Rows.Count + 1;
                var lastCol = dataGridView_Relatorio.Columns.Count;
                var table = ws.Range(1, 1, lastRow, lastCol).CreateTable();
                table.Theme = XLTableTheme.TableStyleMedium9;
                ws.Columns().AdjustToContents();
                wb.SaveAs(caminho);
            }
        }

        private void ExportarParaPdf(string caminho)
        {
            var doc = new Document(PageSize.A4.Rotate(), 20, 20, 20, 20);
            using (var fs = new FileStream(caminho, FileMode.Create))
            {
                PdfWriter.GetInstance(doc, fs);
                doc.Open();
                var fH = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);
                var fC = FontFactory.GetFont(FontFactory.HELVETICA, 9);

                int cols = dataGridView_Relatorio.Columns.Count;
                var pdfTable = new PdfPTable(cols) { WidthPercentage = 100, HeaderRows = 1 };
                float[] wsizes = new float[cols];
                for (int i = 0; i < cols; i++)
                    wsizes[i] = dataGridView_Relatorio.Columns[i].Width;
                pdfTable.SetWidths(wsizes);

                foreach (DataGridViewColumn col in dataGridView_Relatorio.Columns)
                {
                    var cell = new PdfPCell(new Phrase(col.HeaderText, fH))
                    {
                        BackgroundColor = BaseColor.LIGHT_GRAY,
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        Padding = 5
                    };
                    pdfTable.AddCell(cell);
                }

                foreach (DataGridViewRow row in dataGridView_Relatorio.Rows)
                {
                    foreach (DataGridViewCell col in row.Cells)
                    {
                        pdfTable.AddCell(new PdfPCell(new Phrase(col.Value?.ToString() ?? "", fC))
                        { Padding = 4 });
                    }
                }

                doc.Add(pdfTable);
                doc.Close();
            }
        }

        private void button_Sair_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var Form_Relatorio = new Form_Gerenciamento())
            {
                Form_Relatorio.ShowDialog();
            }
            this.Close();
        }
    }

    internal class ComboItem
    {
        public object Id { get; set; }
        public string Text { get; set; }
        public override string ToString() => Text;
    }
}

