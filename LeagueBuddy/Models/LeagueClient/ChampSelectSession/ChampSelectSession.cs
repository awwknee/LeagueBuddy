using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;


namespace LeagueBuddy.Models.ChampionSelectSession
{
    public class ChampionSelectSession
    {
        [JsonPropertyName("actions")]
        public List<List<Action>> Actions { get; set; }

        [JsonPropertyName("allowBattleBoost")]
        public bool AllowBattleBoost { get; set; }

        [JsonPropertyName("allowDuplicatePicks")]
        public bool AllowDuplicatePicks { get; set; }

        [JsonPropertyName("allowLockedEvents")]
        public bool AllowLockedEvents { get; set; }

        [JsonPropertyName("allowRerolling")]
        public bool AllowRerolling { get; set; }

        [JsonPropertyName("allowSkinSelection")]
        public bool AllowSkinSelection { get; set; }

        [JsonPropertyName("bans")]
        public Bans Bans { get; set; }

        [JsonPropertyName("benchChampionIds")]
        public List<object> BenchChampionIds { get; set; }

        [JsonPropertyName("benchEnabled")]
        public bool BenchEnabled { get; set; }

        [JsonPropertyName("boostableSkinCount")]
        public long BoostableSkinCount { get; set; }

        [JsonPropertyName("chatDetails")]
        public ChatDetails ChatDetails { get; set; }

        [JsonPropertyName("counter")]
        public long Counter { get; set; }

        [JsonPropertyName("entitledFeatureState")]
        public EntitledFeatureState EntitledFeatureState { get; set; }

        [JsonPropertyName("gameId")]
        public long GameId { get; set; }

        [JsonPropertyName("hasSimultaneousBans")]
        public bool HasSimultaneousBans { get; set; }

        [JsonPropertyName("hasSimultaneousPicks")]
        public bool HasSimultaneousPicks { get; set; }

        [JsonPropertyName("isCustomGame")]
        public bool IsCustomGame { get; set; }

        [JsonPropertyName("isSpectating")]
        public bool IsSpectating { get; set; }

        [JsonPropertyName("localPlayerCellId")]
        public long LocalPlayerCellId { get; set; }

        [JsonPropertyName("lockedEventIndex")]
        public long LockedEventIndex { get; set; }

        [JsonPropertyName("myTeam")]
        public List<Team> MyTeam { get; set; }

        [JsonPropertyName("rerollsRemaining")]
        public long RerollsRemaining { get; set; }

        [JsonPropertyName("skipChampionSelect")]
        public bool SkipChampionSelect { get; set; }

        [JsonPropertyName("theirTeam")]
        public List<Team> TheirTeam { get; set; }

        [JsonPropertyName("timer")]
        public Timer Timer { get; set; }

        [JsonPropertyName("trades")]
        public List<object> Trades { get; set; }
    }
}
