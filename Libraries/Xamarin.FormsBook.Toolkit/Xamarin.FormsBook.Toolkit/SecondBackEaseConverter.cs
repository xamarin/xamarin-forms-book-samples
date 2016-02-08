using System;
using System.Globalization;
using Xamarin.Forms;

namespace Xamarin.FormsBook.Toolkit
{
    public class SecondBackEaseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
                              object parameter, CultureInfo culture)
        {
            int seconds = (int)((double)value / 6);     // 0, 1, 2, ... 60
            double t = (double)value / 6 % 1;           // 0 --> 1
            double v = 0;                               // 0 --> 1

            // Back-ease in and out functions from http://robertpenner.com/easing/
            if (t < 0.5)
            {
                t *= 2;
                v = 0.5 * t * t * ((1.7 + 1) * t - 1.7);
            }
            else
            {
                t = 2 * (t - 0.5);
                v = 0.5 * (1 + ((t - 1) * (t - 1) * ((1.7 + 1) * (t - 1) + 1.7) + 1));
            }

            return 6 * (seconds + v);
        }

        public object ConvertBack(object value, Type targetType, 
                                  object parameter, CultureInfo culture)
        {
            return (double)value;
        }
    }
}
