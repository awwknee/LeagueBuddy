using LeagueBuddy.Interface;
using LeagueBuddy.Models.DataDragon;
using LeagueBuddy.Models.LeagueClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LeagueBuddy.ViewModels
{
    public class LeagueClientState : ViewModelBase
    {
        private bool _connected = false;
        public bool Connected
        {
            get => _connected;
            set => SetProperty(ref _connected, value);
        }

        private CurrentSummoner _summoner;
        public CurrentSummoner Summoner
        {
            get => _summoner;
            set => SetProperty(ref _summoner, value);
        }

        private CurrentAccount _account;

        public CurrentAccount Account
        {
            get => _account;
            set => SetProperty(ref _account, value);
        }

        public ObservableCollection<Champion> ChampionsFull { get; private set; }

        public LeagueClientState()
        {
            ChampionsFull = new();

            List<Champion> championList = JsonSerializer.Deserialize<List<Champion>>(File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "LeagueBuddy", "champions.json")));
            for (int index = 0; index < championList.Count; ++index)
                ChampionsFull.Add(championList[index]);

        }
    }
}
