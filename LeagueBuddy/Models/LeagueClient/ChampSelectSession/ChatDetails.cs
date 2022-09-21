using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;


namespace LeagueBuddy.Models.ChampionSelectSession
{
    public class ChatDetails
    {
        [JsonPropertyName("chatRoomName")]
        public string ChatRoomName { get; set; }

        [JsonPropertyName("chatRoomPassword")]
        public object ChatRoomPassword { get; set; }
    }
}
