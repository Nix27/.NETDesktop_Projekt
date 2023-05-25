using DataAccessLayer.IRepositories;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using DataAccessLayer.Utilities;
using iText.Kernel.Pdf.Layer;
using Microsoft.Win32;
using System.Net.WebSockets;
using System.Numerics;
using System.Runtime.InteropServices.ObjectiveC;

namespace WindowsFormsApp
{
    public partial class StartForm : Form
    {
        private readonly IRepositoryFetch repoFetch = new RepositoryFetch();
        private FileRepository<AppSettings> appSettingsRepo = new FileRepository<AppSettings>(FilePaths.APP_SETTINGS_PATH);
        private FileRepository<NationalTeam> selectedTeamRepo;
        private FileRepository<Player> playerRepo;
        private IList<NationalTeam> allTeams;
        private static IList<Match> allMatches;
        private static IList<Player> players;
        private IList<PlayerControl> selectedPlayerControls = new List<PlayerControl>();
        private string championShip;
        private static NationalTeam selectedCountry;

        public StartForm()
        {
            string language = appSettingsRepo.LoadSingle().Language;
            LanguageUtility.SetNewLanguage(language, SetCulture);
        }

        private void SetCulture(string culture)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(culture);

            Controls.Clear();
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                var loadedAppSettings = appSettingsRepo.LoadSingle();
                championShip = loadedAppSettings.Championship;
                string selectedTeamPath = championShip == Constants.MEN_REPRESENTATION_ENG || championShip == Constants.MEN_REPRESENTATION_CRO ? FilePaths.SELECTED_MEN_TEAM_PATH : FilePaths.SELECTED_WOMEN_TEAM_PATH;
                selectedTeamRepo = new FileRepository<NationalTeam>(selectedTeamPath);

                string methodForGetData = ConfigUtility.ReadConfig();
                string urlForTeams = "";
                string urlForMatches = "";

                if (methodForGetData == Constants.API_METHOD)
                {
                    urlForTeams = championShip == Constants.MEN_REPRESENTATION_ENG || championShip == Constants.MEN_REPRESENTATION_CRO ? Links.MEN_ALL_TEAMS_LINK : Links.WOMEN_ALL_TEAMS_LINK;
                    urlForMatches = championShip == Constants.MEN_REPRESENTATION_ENG || championShip == Constants.MEN_REPRESENTATION_CRO ? Links.MEN_ALL_MATCHES_LINK : Links.WOMEN_ALL_MATCHES_LINK;

                    pbLoader.Visible = true;
                    allTeams = await repoFetch.GetFromApi<NationalTeam>(urlForTeams);
                    allMatches = await repoFetch.GetFromApi<Match>(urlForMatches);
                    pbLoader.Visible = false;
                }
                else if (methodForGetData == Constants.JSON_METHOD)
                {
                    urlForTeams = championShip == Constants.MEN_REPRESENTATION_ENG || championShip == Constants.MEN_REPRESENTATION_CRO ? Links.MEN_ALL_TEAMS_JSON : Links.WOMEN_ALL_TEAMS_JSON;
                    urlForMatches = championShip == Constants.MEN_REPRESENTATION_ENG || championShip == Constants.MEN_REPRESENTATION_CRO ? Links.MEN_ALL_MATCHES_JSON : Links.WOMEN_ALL_MATCHES_JSON;

                    allTeams = repoFetch.GetFromJson<NationalTeam>(urlForTeams);
                    allMatches = repoFetch.GetFromJson<Match>(urlForMatches);
                }

                cmbRepresentation.Items.AddRange(allTeams.Select(t => t.ToString()).ToArray());

                if(File.Exists(selectedTeamPath))
                    LoadSavedTeam();
                else
                    cmbRepresentation.SelectedIndex = 0;
            }
            catch
            {
                MessageBox.Show("Unable to get data");
                Application.ExitThread();
                return;
            }
		}

        private void LoadSavedTeam()
        {
            var loadedTeam = selectedTeamRepo.LoadSingle();
            cmbRepresentation.SelectedItem = loadedTeam.ToString();
        }

		private void cmbRepresentation_SelectedIndexChanged(object sender, EventArgs e)
		{
            selectedPlayerControls.Clear();
            flpPlayers.Controls.Clear();
            flpFavouritePlayers.Controls.Clear();

            selectedCountry = allTeams.ToArray()[cmbRepresentation.SelectedIndex];
            selectedTeamRepo.SaveSingle(selectedCountry);

            string country = selectedCountry.Country;
            string path;

            if (championShip == Constants.MEN_REPRESENTATION_ENG || championShip == Constants.MEN_REPRESENTATION_CRO)
                path = FilePaths.MEN_PLAYERS_PATH + country + "Players.txt";
            else
                path = FilePaths.WOMEN_PLAYERS_PATH + country + "Players.txt";

            playerRepo = new FileRepository<Player>(path);

            if(File.Exists(path))
                players = playerRepo.LoadMultiple();
            else
               players = PlayersUtility.GetPlayersBasedOnFifaCode(allMatches, selectedCountry.FifaCode);

            foreach(var player in players)
            {
                PlayerControl pc = CreatePlayerControl(player);

                pc.Controls.OfType<PictureBox>().ToList().ForEach(pb => pb.MouseClick += pbPlayerProfile_MouseClick);

                if (player.IsFavorite)
                    flpFavouritePlayers.Controls.Add(pc);
                else
                    flpPlayers.Controls.Add(pc);
            }
		}

        private PlayerControl CreatePlayerControl(Player player)
        {
            PlayerControl pc = new PlayerControl();
            pc.Profile = Image.FromFile(player.ProfileUrl);
            pc.PlayerName = player.Name;
            pc.Number = player.ShirtNumber;
            pc.Position = player.Position;
            pc.Captain = player.Captain;
            pc.MouseClick += playerControl_MouseClick;
            pc.MouseMove += playerControl_MouseMove;

            return pc;
        }

        public IEnumerable<RankedPlayer> GetRankedPlayers()
        {
            return PlayersUtility.GetPlayersForRanking(allMatches, players);
        }

        public IEnumerable<RankedMatch> GetRankedMatches()
        {
            return PlayersUtility.GetRankedMatches(allMatches, selectedCountry.FifaCode);
        }

        private void playerControl_MouseClick(object sender, MouseEventArgs e)
        {
            var playerControl = sender as PlayerControl;

            if (!selectedPlayerControls.Contains(playerControl))
            {
                playerControl.BackColor = Color.FromArgb(169, 211, 226);
                selectedPlayerControls.Add(playerControl);
            }
            else
            {
                playerControl.BackColor = SystemColors.Control;
                selectedPlayerControls.Remove(playerControl);
            }
        }

        private void playerControl_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left && selectedPlayerControls.Count > 0) 
            {
                PlayerControl pc = sender as PlayerControl;
                pc.Parent.AllowDrop = false;
                pc.DoDragDrop(selectedPlayerControls, DragDropEffects.Move);
            }
        }

        private void flp_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(List<PlayerControl>)))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void flp_DragDrop(object sender, DragEventArgs e)
        {
            FlowLayoutPanel flp = sender as FlowLayoutPanel;
            var playerControls = e.Data.GetData(typeof(List<PlayerControl>)) as List<PlayerControl>;
            
            foreach (var pc in playerControls)
            {
                var player = players.FirstOrDefault(p => p.ShirtNumber == pc.Number);

                if(flp.Name == flpFavouritePlayers.Name)
                    player.IsFavorite = true;
                else
                    player.IsFavorite = false;

                pc.PlayerName = player.IsFavorite ? player.Name + " ⭐" : player.Name;

                flp.Controls.Add(pc);
                pc.BackColor = SystemColors.Control;
                    
            }

            selectedPlayerControls.ToList().ForEach(pc => pc.BackColor = SystemColors.Control);
            selectedPlayerControls.Clear();
            flpPlayers.AllowDrop = true;
            flpFavouritePlayers.AllowDrop = true;

            playerRepo.SaveMultiple(players);
        }

        private void pbPlayerProfile_MouseClick(object sender, MouseEventArgs e)
        {
            var pb = sender as PictureBox;
            var playerControl = pb.Parent as PlayerControl;
            var player = players.FirstOrDefault(p => p.ShirtNumber == playerControl.Number);

            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Title = "Choose profile image for player";
            ofd.Filter = "Image files (*.png;*.jpg;*.jpeg;*.jfif)|*.png;*.jpg;*.jpeg;*.jfif;";

            try
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string fileName = ofd.SafeFileName;
                    string filePath = Path.Combine(FilePaths.IMAGES_PATH, fileName);

                    if (!File.Exists(filePath))
                        File.Copy(ofd.FileName, filePath, true);

                    pb.Image = Image.FromFile(ofd.FileName);
                    player.ProfileUrl = filePath;
                    playerRepo.SaveMultiple(players);
                }
            }
            catch
            {
                MessageBox.Show("Unable to save or set picture");
            }
        }
    }
}