using MaterialDesignExtensions.Controls;

namespace LeagueBuddy.Preload
{
    /// <summary>
    /// Interaction logic for PreloadWindow.xaml
    /// </summary>
    public partial class PreloadWindow : MaterialWindow
    {
        public PreloadWindow()
        {
            InitializeComponent();

            DataContext = new PreloadViewModel();
            (DataContext as PreloadViewModel).Preload(this);
        }
    }
}
