using DataAccessLayer.IRepositories;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using DataAccessLayer.Utilities;
using Microsoft.Win32;
using System.Net.WebSockets;
using System.Numerics;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        private readonly IRepositoryFetch repoFetch = new RepositoryFetch();
        private Settings formSettings = new Settings();
		private IList<NationalTeam> allTeams;
        private static IList<Match> allMatches;
        private static IList<Player> players;
        private static string selectedRepresentation;
        private IList<PlayerControl> selectedPlayerControls = new List<PlayerControl>();
        private FileRepository<NationalTeam> ntRepo;
        private FileRepository<Player> playerRepo;
        private string championShip;

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            var fileRepo = new FileRepository<AppSettings>(FilePaths.appSettingsPath);

            if (!File.Exists(FilePaths.appSettingsPath))
            {
                var result = formSettings.ShowDialog();
                if (result == DialogResult.OK)
                {
                    var appSettingsForSave = formSettings.GetSettings();
                    fileRepo.SaveSingle(appSettingsForSave);
                } 
            }

            var loadedAppSettings = fileRepo.LoadSingle();
            championShip = loadedAppSettings.Championship;
            string language = loadedAppSettings.Language;

            string methodForGetData = Utility.ReadConfig();
            string urlForTeams = "";
            string urlForMatches = "";

            if(methodForGetData == "API")
            {
                urlForTeams = championShip == "Men" ? Links.menAllTeamsLink : Links.womenAllTeamsLink;
                urlForMatches = championShip == "Men" ? Links.menAllMatchesLink : Links.womenAllMatchesLink;

                allTeams = await repoFetch.GetFromApi<NationalTeam>(urlForTeams);
                allMatches = await repoFetch.GetFromApi<Match>(urlForMatches);
            }
            else if(methodForGetData == "JSON")
            {
                urlForTeams = championShip == "Men" ? Links.menAllTeamsJson : Links.womenAllTeamsJson;
                urlForMatches = championShip == "Men" ? Links.menAllMatchesJson : Links.womenAllMatchesJson;

                allTeams = repoFetch.GetFromJson<NationalTeam>(urlForTeams);
                allMatches = repoFetch.GetFromJson<Match>(urlForMatches);
            }
            
            cmbRepresentation.Items.AddRange(allTeams.Select(t => t.ToString()).ToArray());

            if (championShip == "Men")
            {
                ntRepo = new FileRepository<NationalTeam>(FilePaths.selectedMenTeamPath);
                if (File.Exists(FilePaths.selectedMenTeamPath))
                {
                    var loadedTeam = ntRepo.LoadSingle();
                    cmbRepresentation.SelectedItem = loadedTeam.ToString();
                }
            }
            else
            {
                ntRepo = new FileRepository<NationalTeam>(FilePaths.selectedWomenTeamPath);
                if (File.Exists(FilePaths.selectedWomenTeamPath))
                {
                    var loadedTeam = ntRepo.LoadSingle();
                    cmbRepresentation.SelectedItem = loadedTeam.ToString();
                }
            }
		}

		private void cmbRepresentation_SelectedIndexChanged(object sender, EventArgs e)
		{
            selectedPlayerControls.Clear();
            flpFavouritePlayers.Controls.Clear();

            selectedRepresentation = cmbRepresentation.SelectedItem.ToString();

            var selectedCountry = allTeams.ToArray()[cmbRepresentation.SelectedIndex];
            ntRepo.SaveSingle(selectedCountry);

            string country = GetSelectedCountry(selectedRepresentation);
            string path;

            if (championShip == "Men")
                path = FilePaths.menPlayersPath + country + "Players.txt";
            else
                path = FilePaths.womenPlayersPath + country + "Players.txt";

            playerRepo = new FileRepository<Player>(path);

            if(File.Exists(path))
                players = playerRepo.LoadMultiple();
            else
               players = Utility.GetPlayersBasedOnFifaCode(allMatches, selectedRepresentation);

            if(flpPlayers.Controls.Count > 0) flpPlayers.Controls.Clear();

            foreach(var player in players)
            {
                PlayerControl pc = new PlayerControl();
                pc.Profile = Image.FromFile(player.ProfileUrl);
                pc.PlayerName = player.Name;
                pc.Number = player.ShirtNumber;
                pc.Position = player.Position;
                pc.Captain = player.Captain;
                pc.MouseClick += playerControl_MouseClick;
                pc.MouseMove += playerControl_MouseMove;

                foreach(var pb in pc.Controls.OfType<PictureBox>())
                {
                    pb.MouseClick += pbPlayerProfile_MouseClick;
                }

                if (player.IsFavorite)
                    flpFavouritePlayers.Controls.Add(pc);
                else
                    flpPlayers.Controls.Add(pc);
            }
		}

        public IEnumerable<RankedPlayer> GetRankedPlayers()
        {
            return Utility.GetPlayersForRanking(allMatches, players);
        }

        public IEnumerable<RankedMatch> GetRankedMatches()
        {
            return Utility.GetRankedMatches(allMatches, selectedRepresentation);
        }

        private string GetSelectedCountry(string selectedItem)
        {
            return selectedItem.Split(' ')[0];
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