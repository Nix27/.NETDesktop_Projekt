using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace DataAccessLayer.Models
{
    public class Match
    {
        [JsonProperty("venue")]
        public string Venue { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("fifa_id")]
        public long FifaId { get; set; }

        [JsonProperty("weather")]
        public Weather Weather { get; set; }

        [JsonProperty("attendance")]
        public long Attendance { get; set; }

        [JsonProperty("officials")]
        public string[] Officials { get; set; }

        [JsonProperty("stage_name")]
        public string StageName { get; set; }

        [JsonProperty("home_team_country")]
        public string HomeTeamCountry { get; set; }

        [JsonProperty("away_team_country")]
        public string AwayTeamCountry { get; set; }

        [JsonProperty("datetime")]
        public DateTimeOffset Datetime { get; set; }

        [JsonProperty("winner")]
        public string Winner { get; set; }

        [JsonProperty("winner_code")]
        public string WinnerCode { get; set; }

        [JsonProperty("home_team")]
        public Team HomeTeam { get; set; }

        [JsonProperty("away_team")]
        public Team AwayTeam { get; set; }

        [JsonProperty("home_team_events")]
        public TeamEvent[] HomeTeamEvents { get; set; }

        [JsonProperty("away_team_events")]
        public TeamEvent[] AwayTeamEvents { get; set; }

        [JsonProperty("home_team_statistics")]
        public TeamStatistics HomeTeamStatistics { get; set; }

        [JsonProperty("away_team_statistics")]
        public TeamStatistics AwayTeamStatistics { get; set; }

        [JsonProperty("last_event_update_at")]
        public DateTimeOffset LastEventUpdateAt { get; set; }

        [JsonProperty("last_score_update_at")]
        public DateTimeOffset? LastScoreUpdateAt { get; set; }
    }

    public partial class Team
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("goals")]
        public long Goals { get; set; }

        [JsonProperty("penalties")]
        public long Penalties { get; set; }
    }

    public partial class TeamEvent
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("type_of_event")]
        public string TypeOfEvent { get; set; }

        [JsonProperty("player")]
        public string Player { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }
    }

    public partial class TeamStatistics
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("attempts_on_goal")]
        public long AttemptsOnGoal { get; set; }

        [JsonProperty("on_target")]
        public long OnTarget { get; set; }

        [JsonProperty("off_target")]
        public long OffTarget { get; set; }

        [JsonProperty("blocked")]
        public long Blocked { get; set; }

        [JsonProperty("woodwork")]
        public long Woodwork { get; set; }

        [JsonProperty("corners")]
        public long Corners { get; set; }

        [JsonProperty("offsides")]
        public long Offsides { get; set; }

        [JsonProperty("ball_possession")]
        public long BallPossession { get; set; }

        [JsonProperty("pass_accuracy")]
        public long PassAccuracy { get; set; }

        [JsonProperty("num_passes")]
        public long NumPasses { get; set; }

        [JsonProperty("passes_completed")]
        public long PassesCompleted { get; set; }

        [JsonProperty("distance_covered")]
        public long DistanceCovered { get; set; }

        [JsonProperty("balls_recovered")]
        public long BallsRecovered { get; set; }

        [JsonProperty("tackles")]
        public long Tackles { get; set; }

        [JsonProperty("clearances")]
        public long? Clearances { get; set; }

        [JsonProperty("yellow_cards")]
        public long? YellowCards { get; set; }

        [JsonProperty("red_cards")]
        public long RedCards { get; set; }

        [JsonProperty("fouls_committed")]
        public long? FoulsCommitted { get; set; }

        [JsonProperty("tactics")]
        public string Tactics { get; set; }

        [JsonProperty("starting_eleven")]
        public Player[] StartingEleven { get; set; }

        [JsonProperty("substitutes")]
        public Player[] Substitutes { get; set; }
    }

    public partial class Player
	{
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("captain")]
        public bool Captain { get; set; }

        [JsonProperty("shirt_number")]
        public int ShirtNumber { get; set; }

        [JsonProperty("position")]
        public string Position { get; set; }
        [JsonIgnore]
        public bool IsFavorite { get; set; }
        [JsonIgnore]
        public string profileUrl { get; set; } = @"C:\Users\Nix\Documents\.NET praktikum\Nikola_Zečić_Projekt\DataAccessLayer\images\defaultProfilePic.jpg";

		public override bool Equals(object? obj)
		{
			return obj is Player player &&
				   Name == player.Name;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Name);
		}
	}

    public partial class Weather
    {
        [JsonProperty("humidity")]
        public long Humidity { get; set; }

        [JsonProperty("temp_celsius")]
        public long TempCelsius { get; set; }

        [JsonProperty("temp_farenheit")]
        public long TempFarenheit { get; set; }

        [JsonProperty("wind_speed")]
        public long WindSpeed { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
