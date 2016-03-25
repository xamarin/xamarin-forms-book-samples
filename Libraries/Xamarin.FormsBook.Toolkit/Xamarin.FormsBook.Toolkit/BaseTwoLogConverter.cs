using System;
using System.Globalization;
using Xamarin.Forms;

namespace Xamarin.FormsBook.Toolkit
{
    public class BaseTwoLogConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, 
                              object parameter, CultureInfo culture)
        {
            if (value is int)
            {
                return Math.Log((int)value) / Math.Log(2);
            }
            return Math.Log((double)value) / Math.Log(2);
        }

        public object ConvertBack(object value, Type targetType, 
                                  object parameter, CultureInfo culture)
        {
            double returnValue = Math.Pow(2, (double)value);

            if (targetType == typeof(int))
            {
                return (int) returnValue;
            }
            return returnValue;
        }
    }
}
