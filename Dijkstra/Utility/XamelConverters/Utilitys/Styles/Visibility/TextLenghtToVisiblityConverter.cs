using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Dijkstra.Utility.XamelConverters
{
    /// <summary>
    /// Detect if the textBox is not empty , then hide the the textblock and vice versa
    /// </summary>
    /// <seealso cref="IValueConverter" />
    public class TextLenghtToVisiblityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value is string)
            {
                if (parameter != null)
                {
                    if (parameter.ToString().ToLower() == "true")
                    {
                        if (((string)value).Length > 0)
                        {
                            return Visibility.Visible;
                        }
                        else { return Visibility.Hidden; }
                    }
                }
                else
                {
                    if (((string)value).Length > 0)
                    {
                        return Visibility.Hidden;
                    }
                }
            }

            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}






//optionsBuilder.UseSqlite(string.Format("DataSource={0}\\DB.db", System.Environment.CurrentDirectory));