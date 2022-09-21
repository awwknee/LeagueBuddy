using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LeagueBuddyConnector.Models.LCU
{

    /**
 *   "{"dodgeData":{"dodgerId":0,"state":"Invalid"},"errors":[],"estimatedQueueTime":22.142000198364259,"isCurrentlyInQueue":true,"lobbyId":"","lowPriorityData":{"bustedLeaverAccessToken":"","penalizedSummonerIds":[],"penaltyTime":0.0,"penaltyTimeRemaining":0.0,"reason":""},"queueId":830,"readyCheck":{"declinerIds":[],"dodgeWarning":"None","playerResponse":"None","state":"Invalid","suppressUx":false,"timer":0.0},"searchState":"Searching","timeInQueue":0.0}"
 *   "{"dodgeData":{"dodgerId":0,"state":"Invalid"},"errors":[],"estimatedQueueTime":22.142000198364259,"isCurrentlyInQueue":true,"lobbyId":"","lowPriorityData":{"bustedLeaverAccessToken":"","penalizedSummonerIds":[],"penaltyTime":0.0,"penaltyTimeRemaining":0.0,"reason":""},"queueId":830,"readyCheck":{"declinerIds":[],"dodgeWarning":"None","playerResponse":"None","state":"InProgress","suppressUx":false,"timer":0.0},"searchState":"Found","timeInQueue":1.0}"
 */

    public class Search
    {
        [JsonPropertyName("searchState")]
        public string State { get; set; }
    }
}
