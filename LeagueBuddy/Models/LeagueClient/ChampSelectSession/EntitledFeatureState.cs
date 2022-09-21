using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;


namespace LeagueBuddy.Models.ChampionSelectSession
{
    public class EntitledFeatureState
    {
        [JsonPropertyName("additionalRerolls")]
        public long AdditionalRerolls { get; set; }

        [JsonPropertyName("unlockedSkinIds")]
        public List<object> UnlockedSkinIds { get; set; }
    }
}
