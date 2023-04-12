using DataAccessLayer.IRepositories;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Utilities
{
    public class PlayersUtility
    {
        public static IList<Player> GetPlayersBasedOnFifaCode(IList<Match> matches, string fifaCode)
        {
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

        public static IEnumerable<RankedPlayer> GetPlayersForRanking(IList<Match> matches, IList<Player> players)
        {
            IList<TeamEvent> teamEvents = new List<TeamEvent>();
            matches.ToList().ForEach(m => m.HomeTeamEvents.ToList()
                            .ForEach(hte => teamEvents.Add(hte)));

            matches.ToList().ForEach(m => m.AwayTeamEvents.ToList()
                            .ForEach(ate => teamEvents.Add(ate)));

            var goalEvents = teamEvents.Where(te => te.TypeOfEvent == "goal")
                                  .GroupBy(te => te.Player)
                                  .Select(ev => new { PlayerName = ev.Key, Goals = ev.Count() });

            var yellowCardsEvents = teamEvents.Where(te => te.TypeOfEvent == "yellow-card")
                                  .GroupBy(te => te.Player)
                                  .Select(ev => new { PlayerName = ev.Key, YellowCards = ev.Count() });

            var events = goalEvents.GroupJoin(
                yellowCardsEvents,
                g => g.PlayerName, y => y.PlayerName,
                (g, y) => new { Player = g.PlayerName, evGoals = g.Goals, evYellowCards = y.Select(ye => ye.YellowCards).DefaultIfEmpty(0).FirstOrDefault() });

            IEnumerable<RankedPlayer> rankedPlayers = players.GroupJoin(
                events,
                p => p.Name, ev => ev.Player,
                (p, ev) => new RankedPlayer
                {
                    ProfileURL = p.ProfileUrl,
                    PlayerName = p.Name,
                    Goals = ev.Select(g => g.evGoals).DefaultIfEmpty(0).FirstOrDefault(),
                    YellowCards = ev.Select(y => y.evYellowCards).DefaultIfEmpty(0).FirstOrDefault()
                });

            return rankedPlayers.OrderByDescending(r => r.Goals);
        }

        public static IEnumerable<RankedMatch> GetRankedMatches(IList<Match> matches, string fifaCode)
        {
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
