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

        public enum EventType
        {
            Goals,
            YellowCards
        }

        public static IEnumerable<RankedPlayer> GetPlayersForRanking(IList<Match> matches, IList<Player> players, EventType eventType)
        {
            string evType = eventType == EventType.Goals ? "goal" : "yellow-card";

            IList<TeamEvent> teamEvents = new List<TeamEvent>();
            matches.ToList().ForEach(m => m.HomeTeamEvents.ToList()
                            .ForEach(hte => teamEvents.Add(hte)));

            matches.ToList().ForEach(m => m.AwayTeamEvents.ToList()
                            .ForEach(ate => teamEvents.Add(ate)));

            var events = teamEvents.Where(te => te.TypeOfEvent == evType)
                                  .GroupBy(te => te.Player)
                                  .Select(ev => new {PlayerName = ev.Key, Goals = ev.Count()});

            IEnumerable<RankedPlayer> rankedPlayers = players.Join(
                events, 
                p => p.Name, ev => ev.PlayerName,
                (p, ev) => new RankedPlayer { ProfileURL = p.ProfileUrl, PlayerName = p.Name, Amount = ev.Goals });

            return rankedPlayers.OrderByDescending(r => r.Amount);
        }

        public static IEnumerable<RankedMatch> GetRankedMatches(IList<Match> matches, string selectedRepresentation)
        {
            string fifaCode = GetFifaCode(selectedRepresentation);

            var rankedMatches = matches.Where(m => m.HomeTeam.Code == fifaCode || m.AwayTeam.Code == fifaCode)
                   .Select(ma => new RankedMatch
                   {
                       Location = ma.Location,
                       Attendance = ma.Attendance,
                       HomeCountry = ma.HomeTeamCountry,
                       AwayCountry = ma.AwayTeamCountry
                   }); 

            return rankedMatches.OrderByDescending(rm => rm.Attendance);
        }
    }
}
