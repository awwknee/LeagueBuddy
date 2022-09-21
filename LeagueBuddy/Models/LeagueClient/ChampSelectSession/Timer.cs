using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;


namespace LeagueBuddy.Models.ChampionSelectSession
{
    public class Timer
    {
        [JsonPropertyName("adjustedTimeLeftInPhase")]
        public long AdjustedTimeLeftInPhase { get; set; }

        [JsonPropertyName("internalNowInEpochMs")]
        public long InternalNowInEpochMs { get; set; }

        [JsonPropertyName("isInfinite")]
        public bool IsInfinite { get; set; }

        [JsonPropertyName("phase")]
        public string Phase { get; set; }

        [JsonPropertyName("totalTimeInPhase")]
        public long TotalTimeInPhase { get; set; }
    }
}
