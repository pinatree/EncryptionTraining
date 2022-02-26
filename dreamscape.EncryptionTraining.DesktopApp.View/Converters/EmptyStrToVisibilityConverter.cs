using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace dreamscape.EncryptionTraining.DesktopApp.View.Converters
{
    [ValueConversion(typeof(string), typeof(Visibility))]
    public class EmptyStrToVisibilityConverter : IValueConverter
    {
        public static EmptyStrToVisibilityConverter Instance = new EmptyStrToVisibilityConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return Visibility.Collapsed;

            string val = (string)value;

            if (val == string.Empty)
                return Visibility.Collapsed;

            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
