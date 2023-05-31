using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Resources;
using DataAccessLayer.Repositories;
using DataAccessLayer.Utilities;

namespace WPFApp.Windows
{
    /// <summary>
    /// Interaction logic for TeamDetails.xaml
    /// </summary>
    public partial class TeamDetails : Window
    {
        private FileRepository<WpfAppSettings> appSettingsRepo = new FileRepository<WpfAppSettings>(FilePaths.WPF_APP_SETTINGS_PATH);

        public TeamDetails()
        {
            InitializeComponent();
            DataContext = new NationalTeam();

            string language = appSettingsRepo.LoadSingle().Language;
            LanguageUtility.SetNewLanguage(language, SetCulture);
        }

        private void SetCulture(string culture)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(culture);

            ResourceManager rm = new ResourceManager("WPFApp.Languages.TeamDetailsLanguages.Resource", Assembly.GetExecutingAssembly());
            lbCountry.Content = rm.GetString("lbCountry");
            lbFifaCode.Content = rm.GetString("lbFifaCode");
            lbGamesPlayed.Content = rm.GetString("lbGamesPlayed");
            lbWins.Content = rm.GetString("lbWins");
            lbLosses.Content = rm.GetString("lbLosses");
            lbDraws.Content = rm.GetString("lbDraws");
            lbScoredGoals.Content = rm.GetString("lbScoredGoals");
            lbAgainstGoals.Content = rm.GetString("lbAgainstGoals");
            lbGoalsDifferential.Content = rm.GetString("lbGoalsDifferential");
            btnClose.Content = rm.GetString("btnClose");
            this.Title = rm.GetString("title");
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
