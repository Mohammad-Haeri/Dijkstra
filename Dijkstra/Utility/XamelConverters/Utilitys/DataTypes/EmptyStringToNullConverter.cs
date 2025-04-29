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
  public class EmptyStringToNullConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (value is not null and string)
      {
        if (((string)value).Length <= 0)
        {
          return null;
        }
        else
        {
          return value;
        }
      }

      return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (value is not null and string)
      {
        if (((string)value).Length <= 0)
        {
          return null;
        }
        else
        {
          return value;
        }
      }

      return null;
    }
  }
}






//optionsBuilder.UseSqlite(string.Format("DataSource={0}\\DB.db", System.Environment.CurrentDirectory));