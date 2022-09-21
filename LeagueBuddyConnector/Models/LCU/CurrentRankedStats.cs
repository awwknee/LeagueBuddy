using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LeagueBuddyConnector.Models.LCU
{
    public class CurrentRankedStats
    {
        [JsonPropertyName("queueMap")]
        public Queues? Queues { get; set; }
    }

    public class Queues
    {
        [JsonPropertyName("RANKED_SOLO_5x5")]
        public RankedStats? SoloQueue { get; set; }
    }

    public class RankedStats
    {
        [JsonPropertyName("division")]
        public string? Division { get; set; }

        [JsonPropertyName("leaguePoints")]
        public int LP { get; set; }

        [JsonPropertyName("tier")]
        public string? Tier { get; set; }
    }
}
