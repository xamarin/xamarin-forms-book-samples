using System;
using Xamarin.Forms.Maps;

namespace Xamarin.FormsBook.Toolkit.Maps
{
    public static class PositionExtensions
    {
        public static string ToString(this Position self, string format)
        {
            if (String.IsNullOrWhiteSpace(format))
                throw new FormatException("Missing format specifier on ToString");

            string floatFormat = "F";

            if (format.Length > 1)
                floatFormat += format.Substring(1);

            char fmt = Char.ToUpper(format[0]);

            switch (fmt)
            {
                case 'F':       // 'float': raw numbers
                    return String.Format("{0} {1}", self.Latitude.ToString(floatFormat),
                                                    self.Longitude.ToString(floatFormat));

                case 'D':       // 'degrees'
                case 'M':       // 'minutes'
                case 'S':       // 'seconds'
                    return Composite(self, fmt, floatFormat);

                default:
                    throw new FormatException("ToString format must be F, D, M, or S");
            }
        }

        static string Composite(Position position, char fmt, string floatFmt)
        {
            return String.Format("{0}{1} {2}{3}", DMS(position.Latitude, fmt, floatFmt),
                                                  position.Latitude >= 0 ? 'N' : 'S',
                                                  DMS(position.Longitude, fmt, floatFmt),
                                                  position.Longitude >= 0 ? 'E' : 'W');
        }

        static string DMS(double value, char fmt, string floatFormat)
        {
            value = Math.Abs(value);

            if (fmt == 'D')
                return String.Format("{0}\u00B0", value.ToString(floatFormat));

            int degrees = (int)value;
            value = (value - degrees) * 60;

            if (fmt == 'M')
            {
                // Check for rounding issues.
                string strMins = value.ToString(floatFormat);
                if (strMins.StartsWith("60"))
                {
                    value -= 60;
                    degrees += 1;
                }
                return String.Format("{0}\u00B0{1}\u2032", degrees, 
                                     value.ToString(floatFormat));
            }

            int minutes = (int)value;
            value = (value - minutes) * 60;

            // Check for rounding issues.
            string strSecs = value.ToString(floatFormat);
            if (strSecs.StartsWith("60"))
            {
                value -= 60;
                minutes += 1;

                if (minutes == 60)
                {
                    minutes -= 60;
                    degrees += 1;
                }
            }

            return String.Format("{0}\u00B0{1}\u2032{2}\u2033", degrees, minutes, 
                                 value.ToString(floatFormat));
        }

        public static Distance DistanceTo(this Position self, Position other)
        {
            // Angle in radians along great circle.
            double radians = Math.Acos(
                Math.Sin(ToRadians(self.Latitude)) * Math.Sin(ToRadians(other.Latitude)) +
                Math.Cos(ToRadians(self.Latitude)) * Math.Cos(ToRadians(other.Latitude)) *
                    Math.Cos(ToRadians(self.Longitude - other.Longitude))
                );

            // Multiply by the Earth's radius to get the actual distance.
            return Distance.FromKilometers(6371 * radians);
        }

        static double ToRadians(double angle)
        {
            return Math.PI * angle / 180;
        }
    }
}
