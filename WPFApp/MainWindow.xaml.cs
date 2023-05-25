using DataAccessLayer.IRepositories;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using DataAccessLayer.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFApp.Windows;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Settings appSettings = new Settings();
        private FileRepository<WpfAppSettings> appSettingsRepo = new FileRepository<WpfAppSettings>(FilePaths.WPF_APP_SETTINGS_PATH);
        private readonly IRepositoryFetch repoFetch = new RepositoryFetch();
        private FileRepository<NationalTeam> selectedTeamRepo;
        private string championship;
        private IList<NationalTeam> allTeams;
        private IList<Match> allMatches;
        private static NationalTeam favouriteTeam;

        public MainWindow()
        {
            InitializeComponent();

            if (!File.Exists(FilePaths.WPF_APP_SETTINGS_PATH))
            {
                if(appSettings.ShowDialog() == true)
                {
                    var settingsForSave = appSettings.GetSettings();
                    appSettingsRepo.SaveSingle(settingsForSave);
                }
                else
                {
                    Application.Current.Shutdown();
                }
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var loadedAppSettings = appSettingsRepo.LoadSingle();
                championship = loadedAppSettings.Championship;

                string selectedTeamPath = championship == Constants.MEN_REPRESENTATION_ENG || championship == Constants.MEN_REPRESENTATION_CRO ? FilePaths.SELECTED_MEN_TEAM_PATH : FilePaths.SELECTED_WOMEN_TEAM_PATH;
                selectedTeamRepo = new FileRepository<NationalTeam>(selectedTeamPath);

                string methodForGetData = ConfigUtility.ReadConfig();
                string urlForTeams = string.Empty;
                string urlForMatches = string.Empty;

                if(methodForGetData == Constants.API_METHOD)
                {
                    urlForTeams = championship == Constants.MEN_REPRESENTATION_ENG || championship == Constants.MEN_REPRESENTATION_CRO ? Links.MEN_ALL_TEAMS_LINK : Links.WOMEN_ALL_TEAMS_LINK;
                    urlForMatches = championship == Constants.MEN_REPRESENTATION_ENG || championship == Constants.MEN_REPRESENTATION_CRO ? Links.MEN_ALL_MATCHES_LINK : Links.WOMEN_ALL_MATCHES_LINK;

                    allTeams = await repoFetch.GetFromApi<NationalTeam>(urlForTeams);
                    allMatches = await repoFetch.GetFromApi<Match>(urlForMatches);
                }
                else if(methodForGetData == Constants.JSON_METHOD)
                {
                    urlForTeams = championship == Constants.MEN_REPRESENTATION_ENG || championship == Constants.MEN_REPRESENTATION_CRO ? Links.MEN_ALL_TEAMS_JSON : Links.WOMEN_ALL_TEAMS_JSON;
                    urlForMatches = championship == Constants.MEN_REPRESENTATION_ENG || championship == Constants.MEN_REPRESENTATION_CRO ? Links.MEN_ALL_MATCHES_JSON : Links.WOMEN_ALL_MATCHES_JSON;
                    
                    allTeams = repoFetch.GetFromJson<NationalTeam>(urlForTeams);
                    allMatches = repoFetch.GetFromJson<Match>(urlForMatches);
                }

                cmbFavouriteTeam.ItemsSource = allTeams;

                if (File.Exists(selectedTeamPath))
                    LoadSavedTeam();
                else
                    cmbFavouriteTeam.SelectedIndex = 0;
            }
            catch
            {
                MessageBox.Show("Unable to get data!");
                Application.Current.Shutdown();
            }
        }

        private void LoadSavedTeam()
        {
            var loadedTeam = selectedTeamRepo.LoadSingle();
            cmbFavouriteTeam.SelectedItem = loadedTeam.ToString();
        }

        private async void cmbFavouriteTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            favouriteTeam = allTeams.ToArray()[cmbFavouriteTeam.SelectedIndex];

            selectedTeamRepo.SaveSingle(favouriteTeam);

            string fifaCode = favouriteTeam.FifaCode;
            string matchesUrl = championship == Constants.MEN_REPRESENTATION_ENG || 
                championship == Constants.MEN_REPRESENTATION_CRO ? 
                Links.MEN_MATCHES_OPPONENTS : 
                Links.WOMEN_MATCHES_OPPONENTS;

            var allMatchesOfFavouriteTeam = await repoFetch.GetFromApi<Match>(matchesUrl + fifaCode);
            var opponents = allMatchesOfFavouriteTeam.Select(m => m.HomeTeam.Code == fifaCode ? $"{m.AwayTeam.Country} ({m.AwayTeam.Code})" : $"{m.HomeTeam.Country} ({m.HomeTeam.Code})");

            cmbOpponentTeam.ItemsSource = opponents;
        }
    }
}
