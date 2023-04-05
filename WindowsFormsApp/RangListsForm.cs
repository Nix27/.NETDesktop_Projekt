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
        public RangListsForm()
        {
            InitializeComponent();
        }

        private void RangListsForm_Load(object sender, EventArgs e)
        {
            ShowPlayersRankList(Utility.EventType.Goals);
            ShowMatchesRankList();
        }

        private void btnGoals_Click(object sender, EventArgs e)
        {
            ShowPlayersRankList(Utility.EventType.Goals);
        }

        private void btnYellowCards_Click(object sender, EventArgs e)
        {
            ShowPlayersRankList(Utility.EventType.YellowCards);
        }

        private void ShowPlayersRankList(Utility.EventType et)
        {
            var rankedPlayers = f1.GetRankedPlayers(et);

            DataTable rankedPlayersTable = new DataTable();

            rankedPlayersTable.Columns.Add("Profile", typeof(System.Drawing.Image));
            rankedPlayersTable.Columns.Add("Name", typeof(string));
            rankedPlayersTable.Columns.Add(et == Utility.EventType.Goals ? "Goals" : "Yellow cards", typeof(int));

            dgvPlayers.Columns.Add("Profile", "Profile");
            dgvPlayers.Columns.Add("Name", "Name");
            dgvPlayers.Columns.Add("Number", et == Utility.EventType.Goals ? "Goals" : "Yellow cards");

            dgvPlayers.RowTemplate.Height = 70;

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
                row.Cells.Add(new DataGridViewTextBoxCell { Value = player.Amount });

                dgvPlayers.Rows.Add(row);
            }

            dgvPlayers.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvPlayers.BorderStyle = BorderStyle.None;
        }

        private void ShowMatchesRankList()
        {
            var rankedMatches = f1.GetRankedMatches();

            DataTable rankedMatchesTable = new DataTable();

            rankedMatchesTable.Columns.Add("Location", typeof(string));
            rankedMatchesTable.Columns.Add("Attendance", typeof(int));
            rankedMatchesTable.Columns.Add("Home country", typeof(string));
            rankedMatchesTable.Columns.Add("Away country", typeof(string));

            foreach (var match in rankedMatches)
            {
                rankedMatchesTable.Rows.Add(match.Location, match.Attendance, match.HomeCountry, match.AwayCountry);
            }

            dgvMatches.DataSource = rankedMatchesTable;

            dgvMatches.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvMatches.BorderStyle = BorderStyle.None;
        }

        private void btnCreatePdf_Click(object sender, EventArgs e)
        {
            PdfDocument pdfDoc = new PdfDocument(new PdfWriter(FilePaths.pdfMatchesPath));
            Document doc = new Document(pdfDoc);

            doc.Add(new Paragraph("Rank list of players"));
            doc.Add(CreateTableForPrint(dgvPlayers));
            doc.Add(new Paragraph());
            doc.Add(new Paragraph("Rank list of matches"));
            doc.Add(CreateTableForPrint(dgvMatches));

            doc.Close();
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
                    if (cell.Value != null)
                    {
                        if (cell.ValueType == typeof(System.Drawing.Image))
                        {
                            ImageData imageData = ImageDataFactory.Create(cell.Tag.ToString());
                            iText.Layout.Element.Image image = new iText.Layout.Element.Image(imageData);
                            image = image.ScaleToFit(50, 50);
                            tbl.AddCell(new Cell().Add(image));
                        }
                        else
                        {
                            tbl.AddCell(new Cell().Add(new Paragraph(cell.Value.ToString())));
                        }
                    }
                }
            }

            return tbl;
        }
    }
}
