using System.Text.Json.Serialization;

namespace LeagueBuddyConnector.Models.LCU
{
    public class CurrentAccount
    {
        [JsonPropertyName("username")]
        public string Username { get; set; }

    }
}
