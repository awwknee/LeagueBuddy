using LeagueBuddy.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueBuddy.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public LeagueClientState State { get; private set; }

        public MainWindowViewModel(LeagueClientState state)
        {
            State = state;
        }
    }
}
