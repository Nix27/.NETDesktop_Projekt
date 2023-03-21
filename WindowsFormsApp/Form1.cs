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
        private AppSettingsFileRepository appSettingsFileRepo = new AppSettingsFileRepository(FileNames.appSettings);
        private Settings formSettings = new Settings();
		private IList<NationalTeam> allTeams;
        private IList<Match> allMatches;
        private IList<Player> players;
        private IList<PlayerControl> selectedPlayerControls = new List<PlayerControl>();
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
            selectedPlayerControls.Clear();
            flpFavouritePlayers.Controls.Clear();
            players = repoFetch.GetPlayersBasedOnFifaCode(allMatches, cmbRepresentation.SelectedItem.ToString());

            if(flpPlayers.Controls.Count > 0) flpPlayers.Controls.Clear();

            foreach(var player in players)
            {
                PlayerControl pc = new PlayerControl();
                pc.Profile = Image.FromFile(player.profileUrl);
                pc.PlayerName = player.Name;
                pc.Number = player.ShirtNumber;
                pc.Position = player.Position;
                pc.Captain = player.Captain;
                pc.MouseClick += playerControl_MouseClick;
                pc.MouseMove += playerControl_MouseMove;

                flpPlayers.Controls.Add(pc);
            }
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
        }
    }
}