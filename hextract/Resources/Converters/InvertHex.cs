using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Data;
using System.Windows;

namespace hextract.Resources.Converters
{
    class InvertHex : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string hex = string.Empty;

            if(value != null)
            {
                hex = value.ToString();
            }

            if(hex.Length > 0 && hex.Substring(0,1) == "#")
            {
                int max = 16777215;
                hex = hex.Substring(1, hex.Length - 1); // Remove the # from the beginning of the string
                
                if (hex.Length == 8)
                {
                    hex = hex.Substring(2, 6);
                }

                int dec = int.Parse(hex, NumberStyles.HexNumber);
                int inverted = 0xFFFFFF ^ dec;
                string result = "#" + inverted.ToString("X");
                return result;
            }

            return "#000000";

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
