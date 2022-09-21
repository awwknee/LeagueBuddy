using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;


namespace LeagueBuddyConnector.Models.LCU.ChampionSelectSession
{
    public class Bans
    {
        [JsonPropertyName("myTeamBans")]
        public List<object> MyTeamBans { get; set; }

        [JsonPropertyName("numBans")]
        public long NumBans { get; set; }

        [JsonPropertyName("theirTeamBans")]
        public List<object> TheirTeamBans { get; set; }
    }
}
