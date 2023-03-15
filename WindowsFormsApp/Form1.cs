using DataAccessLayer.IRepositories;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using DataAccessLayer.Utilities;
using System.Net.WebSockets;

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

                    appSettingsFileRepo = new AppSettingsFileRepository(FileNames.appSettings);
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

		}
	}
}