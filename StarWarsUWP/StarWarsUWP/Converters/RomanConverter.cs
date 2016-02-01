using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace StarWarsUWP.App.Converters
{
    public class RomanConverter : IValueConverter
    {
        const string PREFIX = "Episode ";
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string romanNumber;
            switch ((int)value)
            {
                case 1:
                    romanNumber = "I";
                    break;
                case 2:
                    romanNumber = "II";
                    break;
                case 3:
                    romanNumber = "III";
                    break;
                case 4:
                    romanNumber = "IV";
                    break;
                case 5:
                    romanNumber = "V";
                    break;
                case 6:
                    romanNumber = "VI";
                    break;
                case 7:
                    romanNumber = "VII";
                    break;
                case 8:
                    romanNumber = "VIII";
                    break;
                case 9:
                    romanNumber = "IX";
                    break;
                case 10:
                    romanNumber = "X";
                    break;
                case 11:
                    romanNumber = "XI";
                    break;
                default:
                    romanNumber = "I";
                    break;
            }

            return PREFIX + romanNumber;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
