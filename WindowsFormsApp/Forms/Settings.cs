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
        private FileRepository<AppSettings> settingsRepo = new FileRepository<AppSettings>(FilePaths.APP_SETTINGS_PATH);
        private string language;

        public event EventHandler<LanguageChangedEventArgs> OnLanguageChanged;

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
            if (File.Exists(FilePaths.APP_SETTINGS_PATH))
            {
                var appSettings = settingsRepo.LoadSingle();
                language = appSettings.Language;
                LanguageUtility.SetNewLanguage(language, SetCulture);

                SetComboBoxes(language, appSettings);
            }
            else
            {
                SetCulture("en");

                cmbChampionships.SelectedIndex = 0;
                cmbLanguages.SelectedIndex = 0;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Forms.CostumMessageBoxForm msgBoxForm = new Forms.CostumMessageBoxForm();

            if(language == Constants.CROATIAN_LANGUAGE_ENG || language == Constants.CROATIAN_LANGUAGE_CRO)
                msgBoxForm.SetTitleAndQuestion("Promjena postavki", "Jeste li sigurni da želite promijeniti postavke?");
            else
                msgBoxForm.SetTitleAndQuestion("Change settings", "Are sure you want to change the settings?");

            var appSettings = GetSettings();
            if (msgBoxForm.ShowDialog() == DialogResult.OK)
            {
                settingsRepo.SaveSingle(appSettings);

                language = appSettings.Language;
                LanguageUtility.SetNewLanguage(language, SetCulture);

                SetComboBoxes(language, appSettings);

                string culture = language == Constants.CROATIAN_LANGUAGE_ENG || language == Constants.CROATIAN_LANGUAGE_CRO ? "hr" : "en";
                OnLanguageChanged?.Invoke(Parent.Parent, new LanguageChangedEventArgs { Culture = culture });
            }
        }

        private void SetCulture(string culture)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(culture);

            Controls.Clear();
            InitializeComponent();
        }
        private void SetComboBoxes(string lng, AppSettings aps)
        {
            if (lng == Constants.CROATIAN_LANGUAGE_ENG || lng == Constants.CROATIAN_LANGUAGE_CRO)
                cmbLanguages.SelectedIndex = 0;
            else
                cmbLanguages.SelectedIndex = 1;

            if (aps.Championship == Constants.MEN_REPRESENTATION_ENG || aps.Championship == Constants.MEN_REPRESENTATION_CRO)
                cmbChampionships.SelectedIndex = 0;
            else
                cmbChampionships.SelectedIndex = 1;
        }
    }
}
