using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace LeagueBuddy.Util.Converters
{
    [TypeConverter(typeof(StringConverter))]
    public class SquareConverter : IValueConverter
    {
        private static string BaseFilePath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "LeagueBuddy");

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;
            string path = Path.Combine(BaseFilePath, "assets", "squares", string.Format("{0}.png", value));
            BitmapImage bitmapImage = new();
            using (FileStream fileStream = File.OpenRead(path))
            {
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = fileStream;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
            }
            return bitmapImage;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
