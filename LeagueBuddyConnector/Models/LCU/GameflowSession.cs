using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LeagueBuddyConnector.Models.LCU
{
    public partial class GameflowSession
    {
        [JsonPropertyName("gameData")]
        public GameData GameData { get; set; }

        [JsonPropertyName("phase")]
        public string Phase { get; set; }
    }

    public partial class GameData
    {
        [JsonPropertyName("gameId")]
        public long GameID { get; set; }
    }
}
