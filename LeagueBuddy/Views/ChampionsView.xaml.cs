using LeagueBuddy.Models.DataDragon;
using LeagueBuddy.Models.LeagueClient;
using LeagueBuddy.ViewModels;
using LeagueBuddyConnector;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace LeagueBuddy.Views
{
    /// <summary>
    /// Interaction logic for Champions.xaml
    /// </summary>
    public partial class ChampionsView : UserControl
    {
        private readonly LeagueClientConnector Client;
        private readonly ObservableCollection<Champion> OwnedChampions;

        public ChampionsView(LeagueClientConnector client)
        {
            InitializeComponent();
            OwnedChampions = new ObservableCollection<Champion>();
            Client = client;
        }

        private async void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var State = (DataContext as MainWindowViewModel).State;

            List<MinimalChampion> champions = JsonSerializer.Deserialize<List<MinimalChampion>>(await Client.Get("/lol-champions/v1/owned-champions-minimal"));

            for (var i = 0; i < champions.Count; i++)
            {
                OwnedChampions.Add(State.ChampionsFull.Where(c => c.Key == champions[i].Id.ToString()).First());
            }

            Champions.ItemsSource = OwnedChampions.OrderBy(c => c.Name);
        }

        private void RadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
            OwnedChampions?.Clear();
            Champions.ItemsSource = (DataContext as MainWindowViewModel).State.ChampionsFull;
        }

        private void StackPanel_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            bool value = (bool)e.NewValue;

            if (value == false)
            {
                OwnedChampions?.Clear();
                Champions.ItemsSource = (DataContext as MainWindowViewModel).State.ChampionsFull;
                RadioShowAll.IsChecked = true;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is null) return;

            TextBox? box = sender as TextBox;

            if (string.IsNullOrEmpty(box.Text))
            {
                Champions.ItemsSource = (DataContext as MainWindowViewModel).State.ChampionsFull;
            } else
            {
                var filtered = (DataContext as MainWindowViewModel).State.ChampionsFull.Where(c => c.Name.ToLower().StartsWith(box.Text.ToLower()) || c.Key.ToLower().StartsWith(box.Text.ToLower()));
                Champions.ItemsSource = filtered;
            }
        }
    }
}
