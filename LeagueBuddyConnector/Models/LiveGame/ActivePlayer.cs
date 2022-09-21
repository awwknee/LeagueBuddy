using LeagueBuddyConnector.Models.LiveGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LeagueBuddyConnector.Models.LiveGame
{
    public partial class ActivePlayer
    {
        [JsonPropertyName("abilities")]
        public Abilities Abilities { get; set; }

        [JsonPropertyName("championStats")]
        public ChampionStats ChampionStats { get; set; }

        [JsonPropertyName("currentGold")]
        public float CurrentGold { get; set; }

        [JsonPropertyName("fullRunes")]
        public FullRunes FullRunes { get; set; }

        [JsonPropertyName("level")]
        public int Level { get; set; }

        [JsonPropertyName("summonerName")]
        public string SummonerName { get; set; }
    }
}
