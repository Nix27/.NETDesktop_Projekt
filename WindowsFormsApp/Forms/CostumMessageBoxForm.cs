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

namespace WindowsFormsApp.Forms
{
    public partial class CostumMessageBoxForm : Form
    {
        private FileRepository<AppSettings> appSettingsRepo = new FileRepository<AppSettings>(FilePaths.APP_SETTINGS_PATH);
        public CostumMessageBoxForm()
        {
            if (File.Exists(FilePaths.APP_SETTINGS_PATH))
            {
                var language = appSettingsRepo.LoadSingle().Language;
                LanguageUtility.SetNewLanguage(language, SetCulture);
            }
            else
                InitializeComponent();
        }

        private void SetCulture(string culture)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(culture);

            Controls.Clear();
            InitializeComponent();
        }

        public void SetTitleAndQuestion(string title, string question)
        {
            this.Text = title;
            lblQuestion.Text = question;
        }
    }
}
