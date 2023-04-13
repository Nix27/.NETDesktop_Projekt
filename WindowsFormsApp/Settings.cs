using DataAccessLayer.Events;
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
    public partial class Settings : Form
    {
        private FileRepository<AppSettings> settingsRepo = new FileRepository<AppSettings>(FilePaths.appSettingsPath);
        string language;

        public Settings()
        {
            InitializeComponent();
        }

        public AppSettings GetSettings()
        {
            return new AppSettings
            {
                Championship = cmbChampionships.SelectedItem.ToString(),
                Language = cmbLanguages.SelectedItem.ToString()
            };
        } 

        private void Settings_Load(object sender, EventArgs e)
        {
            if (File.Exists(FilePaths.appSettingsPath))
            {
                var appSettings = settingsRepo.LoadSingle();
                language = appSettings.Language;
                LanguageUtility.SetNewLanguage(language, SetCulture);

                SetComboBoxes(appSettings.Championship, language, appSettings);
            }
            else
            {
                SetCulture("en");

                cmbChampionships.SelectedIndex = 0;
                cmbLanguages.SelectedIndex = 0;
            }
        }

        public event EventHandler<LanguageChangedEventArgs> OnLanguageChanged;
        private void btnOk_Click(object sender, EventArgs e)
        {
            Forms.CostumMessageBoxForm msgBoxForm = new Forms.CostumMessageBoxForm();

            if(language == "Croatian" || language == "Hrvatski")
                msgBoxForm.SetTitleAndQuestion("Promjena postavki", "Jeste li sigurni da želite promijeniti postavke?");
            else
                msgBoxForm.SetTitleAndQuestion("Change settings", "Are sure you want to change the settings?");

            msgBoxForm.AcceptButton = msgBoxForm.Controls.Find("btnYes", false).FirstOrDefault() as Button;
            msgBoxForm.CancelButton = msgBoxForm.Controls.Find("btnNo", false).FirstOrDefault() as Button;

            var appSettings = GetSettings();
            if (msgBoxForm.ShowDialog() == DialogResult.OK)
            {
                settingsRepo.SaveSingle(appSettings);

                language = appSettings.Language;
                LanguageUtility.SetNewLanguage(language, SetCulture);

                SetComboBoxes(appSettings.Championship, language, appSettings);

                string culture = language == "Croatian" || language == "Hrvatski" ? "hr" : "en";
                OnLanguageChanged?.Invoke(Parent.Parent, new LanguageChangedEventArgs { Culture = culture });
            }
        }

        private void SetCulture(string culture)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(culture);

            Controls.Clear();
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
        }
        private void SetComboBoxes(string championship, string lng, AppSettings aps)
        {
            if (lng == "Croatian" || lng == "Hrvatski")
                cmbLanguages.SelectedIndex = 0;
            else
                cmbLanguages.SelectedIndex = 1;

            if (aps.Championship == "Men" || aps.Championship == "Muško")
                cmbChampionships.SelectedIndex = 0;
            else
                cmbChampionships.SelectedIndex = 1;
        }
    }
}
