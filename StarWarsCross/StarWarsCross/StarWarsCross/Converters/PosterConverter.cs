using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StarWarsCross.Converters
{
    public class PosterConverter : IConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            UriImageSource img = new UriImageSource();
            var fileName = ((string)value).Replace(' ', '_').ToLower();
            img.Uri = new Uri("ms-appx:///Images/Posters/" + fileName + ".jpg");
            return img;
        }

      

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
