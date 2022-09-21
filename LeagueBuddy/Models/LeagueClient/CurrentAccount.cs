using System.Text.Json.Serialization;

namespace LeagueBuddy.Models.LeagueClient
{
    public class CurrentAccount
    {
        [JsonPropertyName("username")]
        public string Username { get; set; }

    }
}
