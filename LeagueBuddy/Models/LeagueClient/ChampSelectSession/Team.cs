using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;


namespace LeagueBuddy.Models.ChampionSelectSession
{
    public class Team
    {
        [JsonPropertyName("assignedPosition")]
        public string AssignedPosition { get; set; }

        [JsonPropertyName("cellId")]
        public long CellId { get; set; }

        [JsonPropertyName("championId")]
        public long ChampionId { get; set; }

        [JsonPropertyName("championPickIntent")]
        public long ChampionPickIntent { get; set; }

        [JsonPropertyName("entitledFeatureType")]
        public string EntitledFeatureType { get; set; }

        [JsonPropertyName("selectedSkinId")]
        public long SelectedSkinId { get; set; }

        [JsonPropertyName("spell1Id")]
        public long Spell1Id { get; set; }

        [JsonPropertyName("spell2Id")]
        public long Spell2Id { get; set; }

        [JsonPropertyName("summonerId")]
        public long SummonerId { get; set; }

        [JsonPropertyName("team")]
        public long TeamTeam { get; set; }

        [JsonPropertyName("wardSkinId")]
        public long WardSkinId { get; set; }
    }
}
