using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;


namespace LeagueBuddyConnector.Models.LCU.ChampionSelectSession
{
    public class ChatDetails
    {
        [JsonPropertyName("chatRoomName")]
        public string ChatRoomName { get; set; }

        [JsonPropertyName("chatRoomPassword")]
        public object ChatRoomPassword { get; set; }
    }
}
