using DataAccessLayer.Utilities;
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

            foreach (var player in rankedPlayers)
            {
                var image = System.Drawing.Image.FromFile(player.ProfileURL);
                var profileImage = image.GetThumbnailImage(100, 70, null, IntPtr.Zero);
                rankedPlayersTable.Rows.Add(profileImage, player.PlayerName, player.Amount);
            }

            dgvPlayers.RowTemplate.Height = 70;
            dgvPlayers.DataSource = rankedPlayersTable;

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
            PdfDocument pdfMatches = new PdfDocument(new PdfWriter(FilePaths.pdfMatchesPath));
            Document doc = new Document(pdfMatches);

            Table tbl = new Table(dgvMatches.ColumnCount);

            foreach (DataGridViewColumn column in dgvMatches.Columns)
            {
                tbl.AddHeaderCell(new Cell().Add(new Paragraph(column.HeaderText)));
            }

            foreach (DataGridViewRow row in dgvMatches.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if(cell.Value != null)
                        tbl.AddCell(new Cell().Add(new Paragraph(cell.Value.ToString())));
                }
            }

            doc.Add(tbl);
            doc.Close();
        }
    }
}
