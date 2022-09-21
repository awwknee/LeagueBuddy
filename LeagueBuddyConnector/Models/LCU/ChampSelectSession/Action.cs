using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LeagueBuddyConnector.Models.LCU.ChampionSelectSession
{
    public class Action
    {
        [JsonPropertyName("actorCellId")]
        public long ActorCellId { get; set; }

        [JsonPropertyName("championId")]
        public long ChampionId { get; set; }

        [JsonPropertyName("completed")]
        public bool Completed { get; set; }

        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("isAllyAction")]
        public bool IsAllyAction { get; set; }

        [JsonPropertyName("isInProgress")]
        public bool IsInProgress { get; set; }

        [JsonPropertyName("pickTurn")]
        public long PickTurn { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
