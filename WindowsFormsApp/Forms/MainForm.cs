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
        private FileRepository<AppSettings> appSettingsRepo = new FileRepository<AppSettings>(FilePaths.APP_SETTINGS_PATH);
        private Settings formSettings = new Settings();
        string language;
        
        public MainForm()
        {
            InitializeComponent();

            if (!File.Exists(FilePaths.APP_SETTINGS_PATH))
            {
                if (formSettings.ShowDialog() == DialogResult.OK)
                {
                    var appSettingsForSave = formSettings.GetSettings();
                    appSettingsRepo.SaveSingle(appSettingsForSave);
                }
            }

            language = appSettingsRepo.LoadSingle().Language;
            LanguageUtility.SetNewLanguage(language, SetCulture);
        }

        private void FormSettings_OnLanguageChanged(object? sender, DataAccessLayer.Events.LanguageChangedEventArgs e)
        {
            SetCulture(e.Culture);
            Settings frmSettings = new Settings();
            frmSettings.OnLanguageChanged += FormSettings_OnLanguageChanged;
            OpenNewForm(frmSettings);
        }

        public void SetCulture(string culture)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(culture);

            ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));

            this.Text = resources.GetString("$this.Text");
            btnHome.Text = resources.GetString("btnHome.Text");
            btnRangLists.Text = resources.GetString("btnRangLists.Text");
            btnSettings.Text = resources.GetString("btnSettings.Text");
        }

        private void OpenNewForm(Form childForm)
        {
            if(activeForm != null) activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.Dock = DockStyle.Fill;
            this.pnlMainContainer.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            OpenNewForm(new StartForm());
        }

        private void btnRangLists_Click(object sender, EventArgs e)
        {
            OpenNewForm(new RangListsForm());
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Settings frmSettings = new Settings();
            frmSettings.OnLanguageChanged += FormSettings_OnLanguageChanged;
            OpenNewForm(frmSettings);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            OpenNewForm(new StartForm());
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) 
        {
            Forms.CostumMessageBoxForm msgBoxFrom = new Forms.CostumMessageBoxForm();

            if (language == Constants.CROATIAN_LANGUAGE_ENG || language == Constants.CROATIAN_LANGUAGE_CRO)
                msgBoxFrom.SetTitleAndQuestion("Izlaz", "Jeste li sigurni da želite izaći iz aplikacije?");
            else
                msgBoxFrom.SetTitleAndQuestion("Exit", "Are you sure you want to exit the application?");

            if (msgBoxFrom.ShowDialog() == DialogResult.Cancel)
                e.Cancel = true;
        }
    }
}
