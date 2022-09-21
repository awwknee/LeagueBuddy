using LeagueBuddy.Interface;
using LeagueBuddy.Models;
using LeagueBuddy.Views;
using LeagueBuddyConnector;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LeagueBuddy.ViewModels
{
    public class AccountsViewModel : ViewModelBase
    {
        private string BaseFilePath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "LeagueBuddy");

        public LeagueClientState State { get; set; }

        public ObservableCollection<Account> Accounts { get; set; }

        public ICommand AddAccount => new Command(AddAccountToList);
        public ICommand RemoveAccount => new Command(RemoveAccountFromList);

        public AccountsViewModel(LeagueClientState state)
        {
            State = state;
            Accounts = new();

            List<Account> accounts = JsonSerializer.Deserialize<List<Account>>(File.ReadAllText(Path.Combine(BaseFilePath, "accounts.json")));

            if (accounts != null && accounts.Count > 0)
            {
                for (var i = 0; i < accounts.Count; i++)
                {
                    Accounts.Add(accounts[i]);
                }
            }
        }


        public async Task SaveAccounts()
        {
            await File.WriteAllTextAsync(Path.Combine(BaseFilePath, "accounts.json"), JsonSerializer.Serialize(Accounts));
        }

        private async void AddAccountToList(object? _)
        {
            var view = new AddAccountDiaglog()
            {
                DataContext = new AccountDialogViewModel()
            };

            var result = await DialogHost.Show(view, "RootDialog");

            if ((bool)result == true)
            {
                var context = view.DataContext as AccountDialogViewModel;

                if (context.Name == null || context.Password == null || context.Name.Length < 1 || context.Password.Length < 1) return;

                if (Accounts.Count > 0)
                {
                    Account exists = Accounts.SingleOrDefault(acc => acc.Username.ToLower() == context.Name.ToLower());

                    if (exists != null)
                    {
                        var index = Accounts.IndexOf(exists);

                        var newAccount = new Account()
                        {
                            Username = context.Name,
                            Password = context.Password,
                            DisplayName = context.DisplayName ?? exists.DisplayName ?? null,
                            Division = exists.Division,
                            Level = exists.Level,
                            LP = exists.LP,
                            SummonerId = exists.SummonerId,
                            Tier = exists.Tier
                        };

                        Accounts[index] = newAccount;
                        await SaveAccounts();
                        return;
                    }
                }

                var freshAccount = new Account()
                {
                    Username = context.Name,
                    Password = context.Password,
                    DisplayName = context.DisplayName
                };

                Accounts.Add(freshAccount);
                await SaveAccounts();
            }
        }

        private async void RemoveAccountFromList(object? _selectedItem)
        {
            if (_selectedItem == null || _selectedItem is not Account) return;
            Accounts.Remove(_selectedItem as Account);
            await SaveAccounts();
            MessageBox.Show("Removed the account " + (_selectedItem as Account).Username);
        }
    }
}
