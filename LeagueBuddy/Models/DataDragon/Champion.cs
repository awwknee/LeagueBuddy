using System.Text.Json.Serialization;

namespace LeagueBuddy.Models.DataDragon
{
    public class Champion
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("key")]
        public string? Key { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }
    }
}
