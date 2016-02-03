using System;
using System.Globalization;

namespace StarWarsCross.Converters
{

    public interface IConverter
    {
         object Convert(object value, Type targetType, object parameter, CultureInfo culture);
    }
   
}
