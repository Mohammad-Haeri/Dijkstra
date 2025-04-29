using System.Windows.Data;
using System.Windows.Media;

namespace Dijkstra.Utility.XamelConverters
{
    class EnablityColorConverter: IValueConverter
    {
        public object? Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is bool && value is not true)
            {
                return new SolidColorBrush(Colors.Gray);
            }
            return new SolidColorBrush(Colors.Transparent);

        }

        public object? ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
