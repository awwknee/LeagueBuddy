using LeagueBuddy.Models.ChampionSelectSession;
using LeagueBuddy.Models.LeagueClient;
using LeagueBuddy.ViewModels;
using LeagueBuddy.Views;
using LeagueBuddyConnector;
using MaterialDesignExtensions.Controls;
using MaterialDesignExtensions.Model;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LeagueBuddy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MaterialWindow
    {
        private readonly LeagueClientConnector LeagueClient;
        private readonly LeagueClientState LeagueClientState;

        private readonly UserControl Champions;
        private readonly UserControl AccountsView;

        public MainWindow()
        {
            InitializeComponent();
            LeagueClient = new LeagueClientConnector(false);
            LeagueClientState = new();

            DataContext = new MainWindowViewModel(LeagueClientState);

            Champions = new ChampionsView(LeagueClient) { DataContext = new MainWindowViewModel(LeagueClientState) };
            AccountsView = new AccountsView(LeagueClient) { DataContext = new AccountsViewModel(LeagueClientState) };

            LeagueClient.OnConnected += () =>
            {
                LeagueClientState.Connected = true;
            };

            LeagueClient.OnDisconnected += () =>
            {
                LeagueClientState.Connected = false;
                LeagueClientState.Summoner = null;
            };

            LeagueClient.Observe("/lol-summoner/v1/current-summoner", (data) =>
            {
                if (data == null) return;

                LeagueClientState.Summoner = JsonSerializer.Deserialize<CurrentSummoner>(data.ToString());
            });

            LeagueClient.Observe("/lol-login/v1/session", (data) =>
            {
                if (data == null) return;

                LeagueClientState.Account = JsonSerializer.Deserialize<CurrentAccount>(data.ToString());
            });

            LeagueClient.Observe("/lol-honor-v2/v1/ballot", data =>
            {
                if (data == null) return;
                Console.WriteLine(data);
            });

            /*LeagueClient.Observe("/lol-champ-select/v1/session", async (data) =>
            {
                if (data == null) return;

                var session = JsonSerializer.Deserialize<ChampionSelectSession>(data.ToString());

                long cellId = -1;

                for (var i = 0; i < session.MyTeam.Count; i++)
                {
                    if (session.MyTeam[i].SummonerId == LeagueClientState.Summoner.SummonerId)
                    {
                        cellId = session.MyTeam[i].CellId;
                    }
                }

                if (cellId == -1) return;

                for (var i = 0; i < session.Actions.Count; i++)
                {
                    var actions = session.Actions[i];
                    for (var j = 0; j < actions.Count; j++)
                    {
                        if (actions[j].ActorCellId != cellId) return;
                        var type = actions[j].Type;
                        if (type == "pick")
                        {
                            if (actions[j].Completed == false)
                            {
                                await LeagueClient.LockInChampion(actions[j].Id, "895");
                            }
                        }
                    }
                }

            });*/
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DisplayedContent.Content = Champions;
        }

        private void AccountClick(object sender, RoutedEventArgs e)
        {
            DisplayedContent.Content = AccountsView;
        }
    }
}
