using DataAccessLayer.IRepositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class NationalTeam : IFileFormattable<NationalTeam>
    {
        [JsonIgnore]
        private const char Del = ';';

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("alternate_name")]
        public string? AlternateName { get; set; }

        [JsonProperty("fifa_code")]
        public string FifaCode { get; set; }

        [JsonProperty("group_id")]
        public int GroupId { get; set; }

        [JsonProperty("group_letter")]
        public char GroupLetter { get; set; }

        [JsonProperty("wins")]
        public int Wins { get; set; }

        [JsonProperty("draws")]
        public int Draws { get; set; }

        [JsonProperty("losses")]
        public int Losses { get; set; }

        [JsonProperty("games_played")]
        public int GamesPlayed { get; set; }

        [JsonProperty("points")]
        public int Points { get; set; }

        [JsonProperty("goals_for")]
        public int GoalsFor { get; set; }

        [JsonProperty("goals_against")]
        public int GoalsAgainst { get; set; }

        [JsonProperty("goal_differential")]
        public int GoalDifferential { get; set; }

        public override string ToString() => $"{Country} ({FifaCode})";
        public string ForFileLine() => $"{Id}{Del}{Country}{Del}{AlternateName}{Del}{FifaCode}{Del}{GroupId}{Del}{GroupLetter}{Del}{Wins}{Del}{Draws}{Del}{Losses}{Del}{GamesPlayed}{Del}{Points}{Del}{GoalsFor}{Del}{GoalsAgainst}{Del}{GoalDifferential}";
        public NationalTeam FromFileLine(string line)
        {
            var details = line.Split(Del);
            return new NationalTeam
            {
                Id = int.Parse(details[0]),
                Country = details[1],
                AlternateName = details[2],
                FifaCode = details[3],
                GroupId = int.Parse(details[4]),
                GroupLetter = char.Parse(details[5]),
                Wins = int.Parse(details[6]),
                Draws = int.Parse(details[7]),
                Losses = int.Parse(details[8]),
                GamesPlayed = int.Parse(details[9]),
                Points = int.Parse(details[10]),
                GoalsFor = int.Parse(details[11]),
                GoalsAgainst = int.Parse(details[12]),
                GoalDifferential = int.Parse(details[13])
            };
        }
    }
}
