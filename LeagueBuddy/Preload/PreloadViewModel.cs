// using HtmlAgilityPack;
using LeagueBuddy.Interface;
using LeagueBuddy.Models.DataDragon;
using MaterialDesignExtensions.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace LeagueBuddy.Preload
{
    public class PreloadViewModel : ViewModelBase
    {
        private string _notification = "Preloading...";

        public string Notification
        {
            get => _notification;
            set => SetProperty(ref _notification, value);
        }

        private static string BaseFilePath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "LeagueBuddy");
        private static string SplashesPath => Path.Combine(BaseFilePath, "assets", "splashes");
        private static string SquaresPath => Path.Combine(BaseFilePath, "assets", "squares");
        private static string PerksPath => Path.Combine(BaseFilePath, "assets", "runes", "perks");
        private static string ItemsPath => Path.Combine(BaseFilePath, "assets", "items");


        public async Task Preload(MaterialWindow window)
        {
            Settings settings = Settings.Default;

            Directory.CreateDirectory(BaseFilePath);
            Directory.CreateDirectory(SplashesPath);
            Directory.CreateDirectory(SquaresPath);
            Directory.CreateDirectory(PerksPath);
            Directory.CreateDirectory(ItemsPath);

            string currentPatch = await Helper.GetLatestPatch();

            if (currentPatch != settings.PATCH)
            {
                List<Champion> champions = await Helper.GetChampionInfo(currentPatch);
                // ItemsFullData items = await Helper.GetItemInfo(currentPatch);
                await File.WriteAllTextAsync(Path.Combine(BaseFilePath, "champions.json"), JsonSerializer.Serialize(champions));
                // await File.WriteAllTextAsync(Path.Combine(BaseFilePath, "items.json"), JsonSerializer.Serialize(items));
                Task[] taskArray = new Task[champions.Count];
                Task[] missingIcons = new Task[champions.Count];
                // Task[] missingItems = new Task[items.Data.Count];
                for (int index = 0; index < champions.Count; ++index)
                {
                    taskArray[index] = DownloadIfMissingSplash(champions[index]);
                    missingIcons[index] = DownloadIfMissingIcon(champions[index], currentPatch);
                }
                // List<Item> list = items.Data.Values.ToList();
                
                /*for (int index = 0; index < items.Data.Count; ++index)
                    missingItems[index] = DownloadIfMissingIcon(list[index], currentPatch);
                */
                Notification = "Downloading missing splashes";
                await Task.WhenAll(taskArray);
                Notification = "Downloading missing icons";
                await Task.WhenAll(missingIcons);
                // Notification = "Downloading missing items";
                // await Task.WhenAll(missingItems);

                settings.PATCH = currentPatch;
            }

            Notification = "Creating accounts file...";

            /*if (!File.Exists(Path.Combine(BaseFilePath, "schedule.json")))
            {
                HtmlWeb web = new();
                HtmlDocument doc = await web.LoadFromWebAsync("https://support-leagueoflegends.riotgames.com/hc/en-us/articles/360018987893-Patch-Schedule-League-of-Legends");

                var schedule = doc.DocumentNode.SelectNodes("//*[@id='top']/table/tbody/tr/td");

                List<string[]> patchSchedule = new();
                
                for (var i = 0; i < schedule.Count; i += 2)
                {
                    string[] patch = new string[2];
                    patch[0] = schedule[i].InnerText;
                    patch[1] = schedule[i + 1].InnerText;
                    patchSchedule.Add(patch);
                }

                await File.WriteAllTextAsync(Path.Combine(BaseFilePath, "schedule.json"), JsonConvert.SerializeObject(patchSchedule));
            }*/

            settings.Save();
            window.Close();

        }

        private static Task DownloadIfMissingSplash(Champion champion)
        {
            string str = Path.Combine(SplashesPath, champion.Id + ".jpg");
            return File.Exists(str) ? Task.CompletedTask : Helper.DownloadFile("http://ddragon.leagueoflegends.com/cdn/img/champion/loading/" + champion.Id + "_0.jpg", str);
        }

        private static Task DownloadIfMissingIcon(Champion champion, string patch)
        {
            string str = Path.Combine(BaseFilePath, "assets", "squares", champion.Id + ".png");
            return File.Exists(str) ? Task.CompletedTask : Helper.DownloadFile("http://ddragon.leagueoflegends.com/cdn/" + patch + "/img/champion/" + champion.Id + ".png", str);
        }

        /*private static Task DownloadIfMissingIcon(Item item, string patch)
        {
            string str = Path.Combine(BaseFilePath, "assets", "items", item.Image.Full);
            return File.Exists(str) ? Task.CompletedTask : Helper.DownloadFile("http://ddragon.leagueoflegends.com/cdn/" + patch + "/img/item/" + item.Image.Full, str);
        }
        */

    }
}
