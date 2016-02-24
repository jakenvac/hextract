using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Data;
using System.Windows;

namespace hextract.Resources.Converters
{
    public class listPopToVisible : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ObservableCollection<string> colors = value as ObservableCollection<string>;

            if(parameter as string == "txt")
            {
                return colors.Count > 0 ? Visibility.Collapsed : Visibility.Visible;
            }

            if (parameter as string == "hidden")
            {
                return colors.Count > 0 ? Visibility.Visible : Visibility.Hidden;
            }

            return colors.Count > 0 ? Visibility.Visible : Visibility.Collapsed; 
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
