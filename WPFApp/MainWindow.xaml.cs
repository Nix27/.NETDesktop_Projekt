using DataAccessLayer.IRepositories;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using DataAccessLayer.Utilities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
using WPFApp.User_controls;
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
        private FileRepository<Player> playerRepo;
        private string championship;
        private IList<NationalTeam> allTeams;
        private IList<DataAccessLayer.Models.Match> allMatches;
        private static NationalTeam favouriteTeam;
        private IList<DataAccessLayer.Models.Match> allMatchesOfFavouriteTeam;
        private DataAccessLayer.Models.Match selectedMatch;
        string methodForGetData = ConfigUtility.ReadConfig();
        string urlForTeams = string.Empty;
        string urlForMatches = string.Empty;
        string selectedTeamPath;
        string language;

        private const string GOAL = "goal";
        private const string YELLOW_CARD = "yellow-card";

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

            language = appSettingsRepo.LoadSingle().Language;
            LanguageUtility.SetNewLanguage(language, SetCulture);
        }

        private void SetCulture(string culture)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(culture);

            ResourceManager rm = new ResourceManager("WPFApp.Languages.Resource", Assembly.GetExecutingAssembly());
            btnFavouriteTeamDetails.Content = rm.GetString("btnFavouriteTeamDetails");
            btnOpponentTeamDetails.Content = rm.GetString("btnOpponentTeamDetails");
            lbFavouriteTeam.Content = rm.GetString("lbFavouriteTeam");
            lbOpponentTeam.Content = rm.GetString("lbOpponentTeam");
            btnSettings.Content = rm.GetString("btnSettings");
            this.Title = rm.GetString("title");
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var loadedAppSettings = appSettingsRepo.LoadSingle();
                championship = loadedAppSettings.Championship;

                SetWindowSize(loadedAppSettings.WindowSize);

                selectedTeamPath = championship == Constants.MEN_REPRESENTATION_ENG || championship == Constants.MEN_REPRESENTATION_CRO ? FilePaths.SELECTED_MEN_TEAM_PATH : FilePaths.SELECTED_WOMEN_TEAM_PATH;
                selectedTeamRepo = new FileRepository<NationalTeam>(selectedTeamPath);

                await GetData();

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

        private async Task GetData()
        {
            if (methodForGetData == Constants.API_METHOD)
            {
                urlForTeams = championship == Constants.MEN_REPRESENTATION_ENG || championship == Constants.MEN_REPRESENTATION_CRO ? Links.MEN_ALL_TEAMS_LINK : Links.WOMEN_ALL_TEAMS_LINK;
                urlForMatches = championship == Constants.MEN_REPRESENTATION_ENG || championship == Constants.MEN_REPRESENTATION_CRO ? Links.MEN_ALL_MATCHES_LINK : Links.WOMEN_ALL_MATCHES_LINK;

                allTeams = await repoFetch.GetFromApi<NationalTeam>(urlForTeams);
                allMatches = await repoFetch.GetFromApi<DataAccessLayer.Models.Match>(urlForMatches);
            }
            else if (methodForGetData == Constants.JSON_METHOD)
            {
                urlForTeams = championship == Constants.MEN_REPRESENTATION_ENG || championship == Constants.MEN_REPRESENTATION_CRO ? Links.MEN_ALL_TEAMS_JSON : Links.WOMEN_ALL_TEAMS_JSON;
                urlForMatches = championship == Constants.MEN_REPRESENTATION_ENG || championship == Constants.MEN_REPRESENTATION_CRO ? Links.MEN_ALL_MATCHES_JSON : Links.WOMEN_ALL_MATCHES_JSON;

                allTeams = repoFetch.GetFromJson<NationalTeam>(urlForTeams);
                allMatches = repoFetch.GetFromJson<DataAccessLayer.Models.Match>(urlForMatches);
            }
        }

        private void SetWindowSize(WindowSize? windowSize)
        {
            if (windowSize == null)
                this.WindowState = WindowState.Maximized;
            else
            {
                this.WindowState = WindowState.Normal;
                this.Width = windowSize.Value.Width;
                this.Height = windowSize.Value.Height;
            }
        }

        private void LoadSavedTeam()
        {
            var loadedTeam = selectedTeamRepo.LoadSingle();
            var selectedTeam = allTeams.FirstOrDefault(t => t.FifaCode == loadedTeam.FifaCode);
            var indexOfSelectedTeam = allTeams.IndexOf(selectedTeam);
            cmbFavouriteTeam.SelectedIndex = indexOfSelectedTeam;
        }

        private async void cmbFavouriteTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbFavouriteTeam.SelectedIndex == -1)
            {
                if (File.Exists(selectedTeamPath))
                    LoadSavedTeam();
                else
                    cmbFavouriteTeam.SelectedIndex = 0; 
            }

            favouriteTeam = allTeams.ToArray()[cmbFavouriteTeam.SelectedIndex];

            selectedTeamRepo.SaveSingle(favouriteTeam);

            allMatchesOfFavouriteTeam = await GetOpponents(favouriteTeam, repoFetch, championship);

            var opponents = allMatchesOfFavouriteTeam.Select(m => m.HomeTeam.Code == favouriteTeam.FifaCode ? 
            $"{m.AwayTeam.Country} ({m.AwayTeam.Code})" : 
            $"{m.HomeTeam.Country} ({m.HomeTeam.Code})");

            cmbOpponentTeam.ItemsSource = opponents;
            cmbOpponentTeam.SelectedIndex = 0;
        }

        private async Task<IList<DataAccessLayer.Models.Match>> GetOpponents(NationalTeam favouriteTeam, IRepositoryFetch repoFetch, string championship)
        {
            string fifaCode = favouriteTeam.FifaCode;
            string matchesUrl = championship == Constants.MEN_REPRESENTATION_ENG ||
                championship == Constants.MEN_REPRESENTATION_CRO ?
                Links.MEN_MATCHES_OPPONENTS :
                Links.WOMEN_MATCHES_OPPONENTS;

            return await repoFetch.GetFromApi<DataAccessLayer.Models.Match>(matchesUrl + fifaCode);
        }

        private void cmbOpponentTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            grStartingEleven.Children.Clear();

            if (cmbOpponentTeam.SelectedIndex == -1) cmbOpponentTeam.SelectedIndex = 0;

            selectedMatch = allMatchesOfFavouriteTeam.ToArray()[cmbOpponentTeam.SelectedIndex];
            var fifaCode = favouriteTeam.FifaCode;

            bool isHomeTeam = fifaCode == selectedMatch.HomeTeam.Code;

            lbFavouriteTeamResult.Content = isHomeTeam ? selectedMatch.HomeTeam.Goals : selectedMatch.AwayTeam.Goals;
            lbOpponentTeamResult.Content = isHomeTeam ? selectedMatch.AwayTeam.Goals : selectedMatch.HomeTeam.Goals;

            //get favourite starting eleven
            var startingElevenOfFavouriteTeam = isHomeTeam ?
                selectedMatch.HomeTeamStatistics.StartingEleven.ToList() :
                selectedMatch.AwayTeamStatistics.StartingEleven.ToList();

            var selectedFavouriteTeam = isHomeTeam ? selectedMatch.HomeTeam : selectedMatch.AwayTeam;
            var loadedPlayers = LoadPlayers(selectedFavouriteTeam);

            if(loadedPlayers.Count() > 0)
            {
                startingElevenOfFavouriteTeam = loadedPlayers.Where(p => startingElevenOfFavouriteTeam.Contains(p)).ToList();
            }

            //get opponent starting eleven
            var opponentStartingEleven = isHomeTeam ?
                selectedMatch.AwayTeamStatistics.StartingEleven.ToList() :
                selectedMatch.HomeTeamStatistics.StartingEleven.ToList();

            var opponentTeam = isHomeTeam ? selectedMatch.AwayTeam : selectedMatch.HomeTeam;
            loadedPlayers = LoadPlayers(opponentTeam);

            if (loadedPlayers.Count() > 0)
            {
                opponentStartingEleven = loadedPlayers.Where(p => opponentStartingEleven.Contains(p)).ToList();
            }

            SetPlayersOnField(startingElevenOfFavouriteTeam, 0);
            SetPlayersOnField(opponentStartingEleven, 7);
        }

        private IList<Player> LoadPlayers(Team team)
        { 
            IList<Player> players = new List<Player>();
            string path;

            if (championship == Constants.MEN_REPRESENTATION_ENG || championship == Constants.MEN_REPRESENTATION_CRO)
                path = FilePaths.MEN_PLAYERS_PATH + team.Country + "Players.txt";
            else
                path = FilePaths.WOMEN_PLAYERS_PATH + team.Country + "Players.txt";

            playerRepo = new FileRepository<Player>(path);

            if (File.Exists(path))
                players = playerRepo.LoadMultiple();

            return players;
        }

        private void GetStartingValues(int numberOfPlayers, ref int start, ref int increase)
        {
            switch (numberOfPlayers)
            {
                case 1:
                    start = 2;
                    increase = 0;
                    break;
                case 2:
                    start = 2;
                    increase = 2;
                    break;
                case 3:
                    start = 1;
                    increase = 2;
                    break;
                case 4:
                    start = 1;
                    increase = 1;
                    break;
                case 5:
                    start = 0;
                    increase = 1;
                    break;
                case 6:
                    start = 0;
                    increase = 1;
                    break;
            }
        }

        private void SetPlayersOnField(IList<Player> players, int startRow)
        {
            int defenderStart = 0;
            int defenderIncrease = 0;

            int midfieldStart = 0;
            int midfieldIncrease = 0;

            int forwardStart = 0;
            int forwardIncrease = 0;

            int numberOfDefenders = players.Count(p => p.Position == "Defender");
            int numberOfMidfields = players.Count(p => p.Position == "Midfield");
            int numberOfForwards = players.Count(p => p.Position == "Forward");

            GetStartingValues(numberOfDefenders, ref defenderStart, ref defenderIncrease);
            GetStartingValues(numberOfMidfields, ref midfieldStart, ref midfieldIncrease);
            GetStartingValues(numberOfForwards, ref forwardStart, ref forwardIncrease);

            foreach (var player in players)
            {
                PlayerControl pc = CreatePlayerControl(player);

                switch (pc.Position)
                {
                    case "Goalie":
                        pc.SetValue(Grid.RowProperty, startRow < 4 ? startRow + 0 : startRow - 0);
                        pc.SetValue(Grid.ColumnProperty, 2);
                        pc.SetValue(Grid.ColumnSpanProperty, 2);
                        break;
                    case "Defender":
                        pc.SetValue(Grid.RowProperty, startRow < 4 ? startRow + 1 : startRow - 1);
                        pc.SetValue(Grid.ColumnProperty, defenderStart);
                        defenderStart += defenderIncrease;
                        break;
                    case "Midfield":
                        pc.SetValue(Grid.RowProperty, startRow < 4 ? startRow + 2 : startRow - 2);
                        pc.SetValue(Grid.ColumnProperty, midfieldStart);
                        midfieldStart += midfieldIncrease;
                        break;
                    case "Forward":
                        pc.SetValue(Grid.RowProperty, startRow < 4 ? startRow + 3 : startRow - 3);
                        pc.SetValue(Grid.ColumnProperty, forwardStart);
                        forwardStart += forwardIncrease;
                        break;
                }

                pc.MouseUp += playerControl_Click;
                grStartingEleven.Children.Add(pc);
            }
        }

        private PlayerControl CreatePlayerControl(Player player)
        {
            return new PlayerControl
            {
                ProfilePicture = player.ProfileUrl,
                PlayerName = player.Name,
                Number = player.ShirtNumber,
                Position = player.Position,
                Captain = player.Captain
            };
        }

        private void btnFavouriteTeamDetails_Click(object sender, RoutedEventArgs e)
        {
            TeamDetails teamDetails = new();
            teamDetails.DataContext = favouriteTeam;

            teamDetails.Show();
        }

        private void btnOpponentTeamDetails_Click(object sender, RoutedEventArgs e)
        {
            TeamDetails teamDetails = new();
            selectedMatch = allMatchesOfFavouriteTeam.ToArray()[cmbOpponentTeam.SelectedIndex];
            var opponentFifaCode = selectedMatch.HomeTeam.Code == favouriteTeam.FifaCode ? selectedMatch.AwayTeam.Code : selectedMatch.HomeTeam.Code;
            NationalTeam nationalTeam = allTeams.FirstOrDefault(t => t.FifaCode == opponentFifaCode);
            teamDetails.DataContext = nationalTeam;

            teamDetails.Show();
        }

        private void playerControl_Click(object sender, RoutedEventArgs e)
        {
            var pc = sender as PlayerControl;
            string playerName = pc.PlayerName;

            bool isHomePlayer = selectedMatch.HomeTeamStatistics.StartingEleven
                .ToList()
                .FirstOrDefault(p => p.Name == playerName) != null;

            int goals = GetNumberOfEventsForPlayer(playerName, isHomePlayer, GOAL);
            int yellowCards = GetNumberOfEventsForPlayer(playerName, isHomePlayer, YELLOW_CARD);

            PlayerDetails playerDetails = new();
            Player player = new()
            {
                Name = playerName,
                ShirtNumber = pc.Number,
                Position = pc.Position,
                Captain = pc.Captain
            };

            playerDetails.DataContext = player;
            playerDetails.Goals = goals;
            playerDetails.YellowCards = yellowCards;

            string currentDirectory = Environment.CurrentDirectory;
            string filePath = System.IO.Path.Combine(currentDirectory, pc.ProfilePicture);
            playerDetails.PlayerPicture = new BitmapImage(new Uri(filePath, UriKind.Absolute));

            playerDetails.Show();
        }

        private int GetNumberOfEventsForPlayer(string playerName, bool isHomePlayer, string eventType)
        {
             return isHomePlayer ? selectedMatch.HomeTeamEvents
                .Where(e => e.Player == playerName && e.TypeOfEvent == eventType)
                .Count()
                : selectedMatch.AwayTeamEvents
                .Where(e => e.Player == playerName && e.TypeOfEvent == eventType)
                .Count();
        }

        private async void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            Settings settings = new();

            if (settings.ShowDialog() == true)
            {
                var settingsForSave = settings.GetSettings();
                appSettingsRepo.SaveSingle(settingsForSave);

                championship = settingsForSave.Championship;

                selectedTeamPath = championship == Constants.MEN_REPRESENTATION_ENG || championship == Constants.MEN_REPRESENTATION_CRO ? FilePaths.SELECTED_MEN_TEAM_PATH : FilePaths.SELECTED_WOMEN_TEAM_PATH;
                selectedTeamRepo = new FileRepository<NationalTeam>(selectedTeamPath);

                await GetData();

                SetWindowSize(settingsForSave.WindowSize);

                language = appSettingsRepo.LoadSingle().Language;
                LanguageUtility.SetNewLanguage(language, SetCulture);

                cmbFavouriteTeam.ItemsSource = allTeams;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageDialog msd = new MessageDialog();

            if(language == Constants.CROATIAN_LANGUAGE_CRO || language == Constants.CROATIAN_LANGUAGE_ENG)
                msd.SetTitleAndMessage("Izlaz", "Jeste li sigurni da želite izaći?");
            else
                msd.SetTitleAndMessage("Exit", "Are you sure you want to exit?");

            if (msd.ShowDialog() == false)
                e.Cancel = true;
        }
    }
}
