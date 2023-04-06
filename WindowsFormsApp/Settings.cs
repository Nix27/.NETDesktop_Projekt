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
            AppSettings aps = new AppSettings();
            cmbChampionships.Items.AddRange(aps.Championships.ToArray());
            cmbLanguages.Items.AddRange(aps.Languages.ToArray());

            if (File.Exists(FilePaths.appSettingsPath))
            {
                var appSettings = settingsRepo.LoadSingle();
                cmbChampionships.SelectedItem = appSettings.Championship;
                cmbLanguages.SelectedItem = appSettings.Language;
            }
            else
            {
                cmbChampionships.SelectedIndex = 0;
                cmbLanguages.SelectedIndex = 0;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Forms.CostumMessageBoxForm msgBoxForm = new Forms.CostumMessageBoxForm();

            msgBoxForm.SetTitleAndQuestion("Change settings", "Are sure you want to change the settings?");
            msgBoxForm.AcceptButton = msgBoxForm.Controls.Find("btnYes", false).FirstOrDefault() as Button;
            msgBoxForm.CancelButton = msgBoxForm.Controls.Find("btnNo", false).FirstOrDefault() as Button;

            if(msgBoxForm.ShowDialog() == DialogResult.OK)
            {
                var appSettings = GetSettings();
                settingsRepo.SaveSingle(appSettings);
            }
        }
    }
}
