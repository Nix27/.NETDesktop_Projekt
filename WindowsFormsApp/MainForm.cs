using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using DataAccessLayer.Utilities;
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
    public partial class MainForm : Form
    {
        private Form activeForm;
        private FileRepository<AppSettings> appSettingsRepo = new FileRepository<AppSettings>(FilePaths.appSettingsPath);
        private Settings formSettings = new Settings();
        string language;
        public MainForm()
        {
            if (!File.Exists(FilePaths.appSettingsPath))
            {
                if (formSettings.ShowDialog() == DialogResult.OK)
                {
                    var appSettingsForSave = formSettings.GetSettings();
                    appSettingsRepo.SaveSingle(appSettingsForSave);
                }
            }

            language = appSettingsRepo.LoadSingle().Language;
            if(language == "Croatian" || language == "Hrvatski")
            {
                SetLanguage("hr");
            }
            else
            {
                SetLanguage("en");
            }
            
        }

        private void SetLanguage(string culture)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(culture);

            Controls.Clear();
            InitializeComponent();
        }

        private void OpenNewForm(Form childForm)
        {
            if(activeForm != null) activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.pnlMainContainer.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            OpenNewForm(new Form1());
        }

        private void btnRangLists_Click(object sender, EventArgs e)
        {
            OpenNewForm(new RangListsForm());
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            OpenNewForm(new Settings());
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            OpenNewForm(new Form1());
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Forms.CostumMessageBoxForm msgBoxFrom = new Forms.CostumMessageBoxForm();

            if(language == "Croatian" || language == "Hrvatski")
                msgBoxFrom.SetTitleAndQuestion("Izlaz", "Jeste li sigurni da želite izaći iz aplikacije?");
            else
                msgBoxFrom.SetTitleAndQuestion("Exit", "Are you sure you want to exit the application?");

            msgBoxFrom.AcceptButton = msgBoxFrom.Controls.Find("btnYes", false).FirstOrDefault() as Button;
            msgBoxFrom.CancelButton = msgBoxFrom.Controls.Find("btnNo", false).FirstOrDefault() as Button;

            if (msgBoxFrom.ShowDialog() == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
    }
}
