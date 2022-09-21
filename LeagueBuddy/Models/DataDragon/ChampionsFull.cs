using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LeagueBuddy.Models.DataDragon
{
    public class ChampionsFull
    {
        [JsonPropertyName("data")]
        public Dictionary<string, Champion>? Champions { get; set; }
    }
}
