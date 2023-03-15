using DataAccessLayer.Models;
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

            cmbChampionships.SelectedIndex = 0;
            cmbLanguages.SelectedIndex = 0;
        }
    }
}
