using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace StarWarsUWP.App.Converters
{
    public class PosterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            BitmapImage img = new BitmapImage();
            var fileName = ((string)value).Replace(' ', '_').ToLower();
            img.UriSource = new Uri("ms-appx:///Images/Posters/" + fileName + ".jpg");
            return img;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
