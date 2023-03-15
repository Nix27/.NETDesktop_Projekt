using DataAccessLayer.IRepositories;
using DataAccessLayer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class RepositoryFetch : IRepositoryFetch
    {
        public async Task<IList<T>> GetAll<T>(string url)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(url);
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<T>>(responseContent);

            return result;
        }

		public IList<Player> GetPlayersBasedOnFifaCode(IList<Match> matches, string selectedRepresentation)
		{
            string fifaCode = GetFifaCode(selectedRepresentation);

            //dovrsiti dohvacanje playera!
			ISet<Player> players = new HashSet<Player>();
            matches.Where(m => m.HomeTeam.Code == fifaCode).ToList()
                   .ForEach(ma => ma.HomeTeamStatistics.StartingEleven.ToList()
                   .ForEach(p => players.Add(p)));

			matches.Where(m => m.AwayTeam.Code == fifaCode).ToList()
				   .ForEach(ma => ma.AwayTeamStatistics.StartingEleven.ToList()
				   .ForEach(p => players.Add(p)));

			matches.Where(m => m.HomeTeam.Code == fifaCode).ToList()
				   .ForEach(ma => ma.HomeTeamStatistics.Substitutes.ToList()
				   .ForEach(p => players.Add(p)));

			matches.Where(m => m.AwayTeam.Code == fifaCode).ToList()
				   .ForEach(ma => ma.AwayTeamStatistics.Substitutes.ToList()
				   .ForEach(p => players.Add(p)));

			return players.ToList();
		}

        private string GetFifaCode(string s)
        {
			string code = s.Split('(')[1];
			return s.Split('(')[1].Substring(0, code.Length - 1);
		}
	}
}
