using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Dijkstra.Utility.XamelConverters
{
    public class ColorToBrushConverter : IValueConverter
    {
        public object? Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (targetType != typeof(Color))
                return new SolidColorBrush(Colors.Transparent);
            //(Color)ColorConverter.ConvertFromString("#FFDFD991");

            return (Color)ColorConverter.ConvertFromString(value.ToString());

        }

        public object? ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
            //if (value is not SolidColorBrush)
            //    return new Color() { A = 0, R = 0, G = 0, B = 0 }; ;
            //return new Color()
            //{
            //    A = ((SolidColorBrush)value).Color.A,
            //    R = ((SolidColorBrush)value).Color.R,
            //    G = ((SolidColorBrush)value).Color.G,
            //    B = ((SolidColorBrush)value).Color.B
            //};
        }
    }
}
