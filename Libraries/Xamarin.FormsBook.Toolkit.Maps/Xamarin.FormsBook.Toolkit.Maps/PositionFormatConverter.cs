using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Xamarin.FormsBook.Toolkit.Maps
{
    public class PositionFormatConverter : IValueConverter
    {
        public string Format { set; get; }

        public object Convert(object value, Type targetType, 
                              object parameter, CultureInfo culture)
        {
            if (value == null)
                return "{null}";

            Position position = (Position)value;
            return position.ToString(Format ?? "S");
        }

        public object ConvertBack(object value, Type targetType, 
                                  object parameter, CultureInfo culture)
        {
            return new Position();
        }
    }
}
