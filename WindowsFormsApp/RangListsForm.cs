using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using DataAccessLayer.Utilities;
using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class RangListsForm : Form
    {
        private Form1 f1 = new Form1();
        private FileRepository<AppSettings> appSettingsRepo = new FileRepository<AppSettings>(FilePaths.appSettingsPath);
        public RangListsForm()
        {
            var language = appSettingsRepo.LoadSingle().Language;
            LanguageUtility.SetNewLanguage(language, SetLanguage);
        }

        private void RangListsForm_Load(object sender, EventArgs e)
        {
            ShowPlayersRankList();
            ShowMatchesRankList();
        }

        private void SetLanguage(string culture)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(culture);

            Controls.Clear();
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void ShowPlayersRankList()
        {
            var rankedPlayers = f1.GetRankedPlayers();

            foreach (var player in rankedPlayers)
            {
                var image = System.Drawing.Image.FromFile(player.ProfileURL);
                var profileImage = image.GetThumbnailImage(100, 70, null, IntPtr.Zero);
                var imgCell = new DataGridViewImageCell
                {
                    Value = profileImage,
                    Tag = player.ProfileURL
                };

                DataGridViewRow row = new DataGridViewRow();
                row.Cells.Add(imgCell);
                row.Cells.Add(new DataGridViewTextBoxCell { Value = player.PlayerName });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = player.Goals });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = player.YellowCards });
                row.Height = 70;

                dgvPlayers.Rows.Add(row);
            }

            dgvPlayers.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvPlayers.BorderStyle = BorderStyle.None;
        }

        private void ShowMatchesRankList()
        {
            var rankedMatches = f1.GetRankedMatches();

            foreach (var match in rankedMatches)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Cells.Add(new DataGridViewTextBoxCell { Value = match.Location });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = match.Attendance });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = match.HomeCountry });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = match.AwayCountry });

                dgvMatches.Rows.Add(row);
            }

            dgvMatches.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvMatches.BorderStyle = BorderStyle.None;
        }

        private void btnCreatePdf_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PDF Files (*.pdf)|*.pdf";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                CreatePdf(sfd.FileName);
            }
        }

        private Document CreatePdf(string path)
        {
            PdfDocument pdfDoc = new PdfDocument(new PdfWriter(path));
            Document doc = new Document(pdfDoc);

            doc.Add(new Paragraph("Rank list of players"));
            doc.Add(CreateTableForPrint(dgvPlayers));
            doc.Add(new Paragraph());
            doc.Add(new Paragraph("Rank list of matches"));
            doc.Add(CreateTableForPrint(dgvMatches));

            doc.Close();

            return doc;
        }

        private Table CreateTableForPrint(DataGridView dgv)
        {
            Table tbl = new Table(dgv.ColumnCount);

            foreach (DataGridViewColumn column in dgv.Columns)
            {
                tbl.AddHeaderCell(new Cell().Add(new Paragraph(column.HeaderText)));
            }

            foreach (DataGridViewRow row in dgv.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                     if (cell.ValueType == typeof(System.Drawing.Image))
                     {
                         ImageData imageData = ImageDataFactory.Create(cell.Tag.ToString());
                         iText.Layout.Element.Image image = new iText.Layout.Element.Image(imageData);
                         image = image.ScaleToFit(70, 70);
                         tbl.AddCell(new Cell().Add(image));
                     }
                     else
                     {
                         tbl.AddCell(new Cell().Add(new Paragraph(cell.Value.ToString())));
                     }
                    
                }
            }

            return tbl;
        }
    }
}
