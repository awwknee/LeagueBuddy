using LeagueBuddy.Models.LeagueClient;
using LeagueBuddy.ViewModels;
using System.Text.Json;
using System.Windows.Controls;
using System.Linq;
using System;
using LeagueBuddy.Models;
using System.Reflection;
using System.Collections.Generic;
using System.Security.Principal;
using LeagueBuddyConnector;

namespace LeagueBuddy.Views
{
    /// <summary>
    /// Interaction logic for Accounts.xaml
    /// </summary>
    public partial class AccountsView : UserControl
    {
        private readonly LeagueClientConnector Client;

        public AccountsViewModel Context { get => DataContext as AccountsViewModel; }

        public AccountsView(LeagueClientConnector client)
        {
            InitializeComponent();
            Client = client;

            Client.Observe("/lol-login/v1/session", LoginSession);
        }

        public void LoginSession(object data)
        {
            if (data == null) return;

            var account = JsonSerializer.Deserialize<CurrentAccount>(data.ToString());

            if (account == null) return;

            UpdateAccount(account);
        }

        private void UpdateAccount(CurrentAccount account)
        {
            Dispatcher.BeginInvoke(async () =>
            {
                var accounts = Context.Accounts;

                if (accounts.Count == 0) return;

                Account current = accounts.SingleOrDefault(acc => acc.Username.ToLower() == account.Username.ToLower());
                List<Account> others = accounts.Where(acc => acc.Username.ToLower() != account.Username.ToLower()).ToList();


                if (current != null)
                {
                    var ranked = JsonSerializer.Deserialize<CurrentRankedStats>(await Client.Get("/lol-ranked/v1/current-ranked-stats"));
                    var profile = JsonSerializer.Deserialize<CurrentSummoner>(await Client.Get("/lol-summoner/v1/current-summoner"));

                    var index = accounts.IndexOf(current);

                    var newAccount = new Account()
                    {
                        Username = current.Username,
                        Password = current.Password,
                        DisplayName = profile.DisplayName,
                        Level = profile.Level,
                        SummonerId = profile.SummonerId,
                    };

                    if (ranked?.Queues?.SoloQueue?.Tier != "NONE")
                    {
                        var solo = ranked?.Queues?.SoloQueue;

                        newAccount.Division = solo.Division;
                        newAccount.Tier = solo.Tier;
                        newAccount.LP = solo.LP;
                    }

                    accounts[index] = newAccount;
                }

                if (others.Count > 0)
                {
                    for (var i = 0; i < others.Count; i++)
                    {
                        var acc = others[i];
                        var index = accounts.IndexOf(acc);

                        if (acc.DisplayName == null) continue;

                        var profile = JsonSerializer.Deserialize<CurrentSummoner>(await Client.Get($"/lol-summoner/v1/summoners?name={Uri.EscapeDataString(acc.DisplayName)}"));

                        if (profile == null) continue;

                        var newAccount = new Account()
                        {
                            DisplayName = acc.DisplayName,
                            Username = acc.Username,
                            Password = acc.Password,
                            SummonerId = profile.SummonerId,
                            Level = profile.Level
                        };

                        acc.SummonerId = profile.SummonerId;
                        acc.Level = profile.Level;
                        var ranked = JsonSerializer.Deserialize<CurrentRankedStats>(await Client.Get($"/lol-ranked/v1/ranked-stats/{profile.Puuid}"));

                        if (ranked?.Queues?.SoloQueue?.Tier != "NONE")
                        {
                            var solo = ranked?.Queues?.SoloQueue;

                            newAccount.Division = solo.Division;
                            newAccount.Tier = solo.Tier;
                            newAccount.LP = solo.LP;
                        }

                        accounts[index] = newAccount;
                    }
                }

                await Context.SaveAccounts();
            });
        }

        private void HideData_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            var check = HideData.IsChecked;
            var columns = AccountDataGrid.Columns.Where(c => c.Header.ToString() == "Username" || c.Header.ToString() == "Password").ToList();

            if (check == true)
            {

                for (var i = 0; i < columns.Count(); i++)
                {
                    columns[i].Visibility = System.Windows.Visibility.Visible;
                }
            }
            else
            {
                for (var i = 0; i < columns.Count(); i++)
                {
                    columns[i].Visibility = System.Windows.Visibility.Hidden;
                }
            }
        }
    }
}
