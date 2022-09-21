using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LeagueBuddyConnector
{
    public static class LeagueClientConnectorUtil
    {
        private static readonly Regex TOKEN_REGEX = new("\"--remoting-auth-token=(.+?)\"");
        private static readonly Regex PORT_REGEX = new("\"--app-port=(\\d+?)\"");

        private static readonly Regex RIOT_TOKEN_REGEX = new("--remoting-auth-token=(\\S+)");
        private static readonly Regex RIOT_PORT_REGEX = new("--app-port=(\\d+)");

        public static Tuple<string, string> GetStatus(bool riotClient)
        {
            Process process = new()
            {
                StartInfo = new ProcessStartInfo()
                {
                    WorkingDirectory = "C:\\Windows\\System32",
                    FileName = "C:\\Windows\\System32\\cmd.exe",
                    RedirectStandardOutput = true,
                    Arguments = CreateArguments(riotClient),
                    CreateNoWindow = true
                }
            };
            process.Start();
            process.WaitForExit();
            string end = process.StandardOutput.ReadToEnd();
            process.Dispose();
            if (end != null)
            {
                try
                {
                    var token = (riotClient == true ? RIOT_TOKEN_REGEX.Match(end) : TOKEN_REGEX.Match(end)).Groups[1].Value;
                    var port = (riotClient == true ? RIOT_PORT_REGEX.Match(end) : PORT_REGEX.Match(end)).Groups[1].Value;
                    return new Tuple<string, string>(token, port);
                }
                catch (Exception)
                {
                }
            }
            return null;
        }

        private static string CreateArguments(bool riotClient)
        {
            return riotClient ? "/c WMIC PROCESS WHERE name='RiotClientUx.exe' GET commandline && exit"
                : "/c WMIC PROCESS WHERE name='LeagueClientUx.exe' GET commandline && exit";
        }
    }
}
