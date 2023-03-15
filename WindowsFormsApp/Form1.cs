using DataAccessLayer.IRepositories;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using DataAccessLayer.Utilities;
using System.Net.WebSockets;
using System.Numerics;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        private readonly IRepositoryFetch repoFetch = new RepositoryFetch();
        private AppSettingsFileRepository appSettingsFileRepo = new AppSettingsFileRepository(FileNames.appSettings);
        private Settings formSettings = new Settings();
		IList<NationalTeam> allTeams;
        IList<Match> allMatches;
        IList<Player> players;
		public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists(FileNames.appSettings))
            {
                var result = formSettings.ShowDialog();
                if (result == DialogResult.OK)
                {
                    var appSettingsForSave = formSettings.GetSettings();
                    appSettingsFileRepo.Save(appSettingsForSave);
                } 
            }

            var loadedAppSettings = appSettingsFileRepo.Load();
            string championShip = loadedAppSettings.Championship;
            string language = loadedAppSettings.Language;

            string urlForTeams = championShip == "Men" ? Links.menAllTeamsLink : Links.womenAllTeamsLink;
            string urlForMatches = championShip == "Men" ? Links.menAllMatchesLink : Links.womenAllMatchesLink;

            allTeams = await repoFetch.GetAll<NationalTeam>(urlForTeams);
            cmbRepresentation.Items.AddRange(allTeams.Select(t => $"{t.Country} ({t.FifaCode})").ToArray());

			allMatches = await repoFetch.GetAll<Match>(urlForMatches);
		}

		private void cmbRepresentation_SelectedIndexChanged(object sender, EventArgs e)
		{
            flpFavouritePlayers.Controls.Clear();
            players = repoFetch.GetPlayersBasedOnFifaCode(allMatches, cmbRepresentation.SelectedItem.ToString());

            if(flpPlayers.Controls.Count > 0) flpPlayers.Controls.Clear();

            foreach(var player in players)
            {
                PlayerControl pc = new PlayerControl();
                pc.Profile = Image.FromFile(player.profileUrl);
                pc.PlayerName = player.IsFavorite ? player.Name + " ⭐" : player.Name;
                pc.Number = player.ShirtNumber;
                pc.Position = player.Position;
                pc.Captain = player.Captain;
                pc.MouseDown += playerControl_MouseDown;

                flpPlayers.Controls.Add(pc);
            }
		}

        private void playerControl_MouseDown(object sender, MouseEventArgs e)
        {
            var playerControl = sender as PlayerControl;
            playerControl.DoDragDrop(playerControl, DragDropEffects.Move);
        }

        private void flp_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(PlayerControl)))
                e.Effect = DragDropEffects.Move; 
        }

        private void flp_DragDrop(object sender, DragEventArgs e)
        {
            var playerControl = e.Data.GetData(typeof(PlayerControl)) as PlayerControl;
            var player = players.FirstOrDefault(p => p.ShirtNumber == playerControl.Number);

            var flp = sender as FlowLayoutPanel;
            if (flp.Name == flpFavouritePlayers.Name)
            {
                player.IsFavorite = true;
                playerControl.PlayerName = player.IsFavorite ? player.Name + " ⭐" : player.Name;
            }
            else
            {
                player.IsFavorite = false;
                playerControl.PlayerName = player.IsFavorite ? player.Name + " ⭐" : player.Name;
            }

            flp.Controls.Add(playerControl);
        }
	}
}