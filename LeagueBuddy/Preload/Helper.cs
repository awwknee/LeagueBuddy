using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using System.Text.Json;
using LeagueBuddy.Models.DataDragon;

namespace LeagueBuddy.Preload
{
    public static class Helper
    {
        private static readonly HttpClient Client = new HttpClient();
        private static readonly Uri VersionURI = new("https://ddragon.leagueoflegends.com/api/versions.json");

        public static async Task<string> GetLatestPatch() => JsonSerializer.Deserialize<List<string>>(await Client.GetStringAsync(VersionURI)).First();

        public static async Task<List<Champion>> GetChampionInfo(string patch) => JsonSerializer.Deserialize<ChampionsFull>(await Client.GetStringAsync("https://ddragon.leagueoflegends.com/cdn/" + patch + "/data/en_US/champion.json")).Champions.Values.ToList();

        // public static async Task<ItemsFullData> GetItemInfo(string patch) => JsonConvert.DeserializeObject<ItemsFullData>(await Client.GetStringAsync("http://ddragon.leagueoflegends.com/cdn/" + patch + "/data/en_US/item.json"));


        public static async Task DownloadFile(string address, string location)
        {
            var response = await Client.GetAsync(address);
            response.EnsureSuccessStatusCode();
            var stream = await response.Content.ReadAsStreamAsync();
            var file = File.Create(location);
            await stream.CopyToAsync(file);
        }

        public static void CleanUp() => Client.Dispose();
    }
}
