using System;
using Windows.UI.Xaml.Data;

namespace MycoViewer.Converters
{
    public class InverseBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return false.Equals(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return false.Equals(value);
        }
    }
}
