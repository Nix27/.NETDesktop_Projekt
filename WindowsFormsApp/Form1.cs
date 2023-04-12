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
    public partial class Form1 : Form
    {
        private readonly IRepositoryFetch repoFetch = new RepositoryFetch();
		private IList<NationalTeam> allTeams;
        private static IList<Match> allMatches;
        private static IList<Player> players;
        private IList<PlayerControl> selectedPlayerControls = new List<PlayerControl>();
        private FileRepository<NationalTeam> ntRepo;
        private FileRepository<Player> playerRepo;
        private string championShip;
        private static NationalTeam selectedCountry;
        private FileRepository<AppSettings> appSettingsRepo = new FileRepository<AppSettings>(FilePaths.appSettingsPath);

        public Form1()
        {
            string language = appSettingsRepo.LoadSingle().Language;
            if (language == "Croatian" || language == "Hrvatski")
            {
                SetLanguage("hr");
            }
            else
            {
                SetLanguage("en");
            }
        }

        private void SetLanguage(string culture)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(culture);

            Controls.Clear();
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            var loadedAppSettings = appSettingsRepo.LoadSingle();
            championShip = loadedAppSettings.Championship;

            string methodForGetData = ConfigUtility.ReadConfig();
            string urlForTeams = "";
            string urlForMatches = "";

            if(methodForGetData == "API")
            {
                urlForTeams = championShip == "Men" || championShip == "Muško" ? Links.menAllTeamsLink : Links.womenAllTeamsLink;
                urlForMatches = championShip == "Men" || championShip == "Muško" ? Links.menAllMatchesLink : Links.womenAllMatchesLink;

                pbLoader.Visible = true;
                allTeams = await repoFetch.GetFromApi<NationalTeam>(urlForTeams);
                allMatches = await repoFetch.GetFromApi<Match>(urlForMatches);
                pbLoader.Visible = false;
            }
            else if(methodForGetData == "JSON")
            {
                urlForTeams = championShip == "Men" || championShip == "Muško" ? Links.menAllTeamsJson : Links.womenAllTeamsJson;
                urlForMatches = championShip == "Men" || championShip == "Muško" ? Links.menAllMatchesJson : Links.womenAllMatchesJson;

                allTeams = repoFetch.GetFromJson<NationalTeam>(urlForTeams);
                allMatches = repoFetch.GetFromJson<Match>(urlForMatches);
            }
            
            cmbRepresentation.Items.AddRange(allTeams.Select(t => t.ToString()).ToArray());

            if (championShip == "Men" || championShip == "Muško")
            {
                LoadSavedTeam(FilePaths.selectedMenTeamPath);
            }
            else
            {
                LoadSavedTeam(FilePaths.selectedWomenTeamPath);
            }
		}

        private void LoadSavedTeam(string path)
        {
            ntRepo = new FileRepository<NationalTeam>(path);
            if (File.Exists(path))
            {
                var loadedTeam = ntRepo.LoadSingle();
                cmbRepresentation.SelectedItem = loadedTeam.ToString();
            }
        }

		private void cmbRepresentation_SelectedIndexChanged(object sender, EventArgs e)
		{
            selectedPlayerControls.Clear();
            flpPlayers.Controls.Clear();
            flpFavouritePlayers.Controls.Clear();

            selectedCountry = allTeams.ToArray()[cmbRepresentation.SelectedIndex];
            ntRepo.SaveSingle(selectedCountry);

            string country = selectedCountry.Country;
            string path;

            if (championShip == "Men" || championShip == "Muško")
                path = FilePaths.menPlayersPath + country + "Players.txt";
            else
                path = FilePaths.womenPlayersPath + country + "Players.txt";

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
                playerControl.BackColor = Color.FromArgb(162, 222, 243);
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

                if (flp != pc.Parent)
                {
                    flp.Controls.Add(pc);
                    pc.BackColor = SystemColors.Control;
                }
                    
            }

            selectedPlayerControls.ToList().ForEach(pc => pc.BackColor = SystemColors.Control);
            selectedPlayerControls.Clear();
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

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                string fileName = ofd.SafeFileName;
                string filePath = Path.Combine(FilePaths.imagesPath, fileName);

                pb.Image = Image.FromFile(ofd.FileName);
                if(!File.Exists(filePath))
                    File.Copy(ofd.FileName, filePath, true);

                player.ProfileUrl = filePath;
                playerRepo.SaveMultiple(players);
            }
        }
    }
}