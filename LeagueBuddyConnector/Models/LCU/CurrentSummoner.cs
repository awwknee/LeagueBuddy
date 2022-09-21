using System.Text.Json.Serialization;

namespace LeagueBuddyConnector.Models.LCU
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

        [JsonPropertyName("xpSinceLastLevel")]
        public int CurrentXP { get; set; }

        [JsonPropertyName("xpUntilNextLevel")]
        public int NextLevelXP { get; set; }
    }
}
