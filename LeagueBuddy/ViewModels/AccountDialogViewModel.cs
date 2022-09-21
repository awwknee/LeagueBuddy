using LeagueBuddy.Interface;
using MaterialDesignThemes.Wpf;
using System.Windows.Input;

namespace LeagueBuddy.ViewModels
{
    public class AccountDialogViewModel : ViewModelBase
    {
        private string? _name;
        public string? Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string? _password;

        public string? Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        private string? _displayName;

        public string? DisplayName
        {
            get => _displayName;
            set => SetProperty(ref _displayName, value);
        }
    }
}
