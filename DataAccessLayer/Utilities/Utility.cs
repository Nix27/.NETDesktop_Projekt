using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Utilities
{
    public class Utility
    {
        public static string ReadConfig()
        {
            return File.ReadAllText(FilePaths.configPath);
        }

        public static IList<Player> GetPlayersBasedOnFifaCode(IList<Match> matches, string selectedRepresentation)
        {
            string fifaCode = GetFifaCode(selectedRepresentation);

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

        private static string GetFifaCode(string s)
        {
            string code = s.Split('(')[1];
            return s.Split('(')[1].Substring(0, code.Length - 1);
        }

        public static IEnumerable<RankedPlayer> GetPlayersForGoalRanking(IList<Match> matches, IList<Player> players)
        {
            IList<TeamEvent> teamEvents = new List<TeamEvent>();
            matches.ToList().ForEach(m => m.HomeTeamEvents.ToList()
                            .ForEach(hte => teamEvents.Add(hte)));

            matches.ToList().ForEach(m => m.AwayTeamEvents.ToList()
                            .ForEach(ate => teamEvents.Add(ate)));

            var goals = teamEvents.Where(te => te.TypeOfEvent == "goal")
                                  .GroupBy(te => te.Player)
                                  .Select(g => new {PlayerName = g.Key, Goals = g.Count()});

            IEnumerable<RankedPlayer> playersRankedByGoals = players.Join(
                goals, 
                p => p.Name, g => g.PlayerName,
                (p, g) => new RankedPlayer { ProfileURL = p.ProfileUrl, PlayerName = p.Name, Amount = g.Goals });

            return playersRankedByGoals;
        }
    }
}
