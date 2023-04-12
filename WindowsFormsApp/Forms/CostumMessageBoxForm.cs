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
        private FileRepository<AppSettings> appSettingsRepo = new FileRepository<AppSettings>(FilePaths.appSettingsPath);
        public CostumMessageBoxForm()
        {
            if (File.Exists(FilePaths.appSettingsPath))
            {
                var language = appSettingsRepo.LoadSingle().Language;
                if (language == "Croatian" || language == "Hrvatski")
                    SetLanguage("hr");
                else
                    SetLanguage("en");
            }
            else
                InitializeComponent();
        }

        private void SetLanguage(string culture)
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
