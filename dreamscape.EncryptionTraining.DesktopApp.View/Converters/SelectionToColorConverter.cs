using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace dreamscape.EncryptionTraining.DesktopApp.View.Converters
{
    [ValueConversion(typeof(bool), typeof(Brush))]
    public class SelectionToColorConverter : IValueConverter
    {
        public static SelectionToColorConverter Instance = new SelectionToColorConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? Brushes.Yellow : Brushes.LightYellow;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
