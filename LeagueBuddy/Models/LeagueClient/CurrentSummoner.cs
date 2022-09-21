using System.Text.Json.Serialization;

namespace LeagueBuddy.Models.LeagueClient
{
    public class CurrentSummoner
    {
        [JsonPropertyName("accountId")]
        public long AccountId { get; set; }

        [JsonPropertyName("summonerId")]
        public long SummonerId { get; set; }

        [JsonPropertyName("puuid")]
        public string Puuid { get; set; }

        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }

        [JsonPropertyName("summonerLevel")]
        public int Level { get; set; }
    }
}
