using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;


namespace LeagueBuddyConnector.Models.LCU.ChampionSelectSession
{
    public class Team
    {
        [JsonPropertyName("assignedPosition")]
        public string? AssignedPosition { get; set; }

        [JsonPropertyName("cellId")]
        public long CellId { get; set; }

        [JsonPropertyName("championId")]
        public int ChampionId { get; set; }

        [JsonPropertyName("championPickIntent")]
        public int ChampionPickIntent { get; set; }

        [JsonPropertyName("entitledFeatureType")]
        public string? EntitledFeatureType { get; set; }

        [JsonPropertyName("selectedSkinId")]
        public int SelectedSkinId { get; set; }

        [JsonPropertyName("spell1Id")]
        public long Spell1Id { get; set; }

        [JsonPropertyName("spell2Id")]
        public long Spell2Id { get; set; }

        [JsonPropertyName("summonerId")]
        public long SummonerId { get; set; }

        [JsonPropertyName("team")]
        public int TeamTeam { get; set; }

        [JsonPropertyName("wardSkinId")]
        public long WardSkinId { get; set; }
    }
}
