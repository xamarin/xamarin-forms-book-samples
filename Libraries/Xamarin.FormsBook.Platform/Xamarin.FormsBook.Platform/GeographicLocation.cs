using System;

namespace Xamarin.FormsBook.Platform
{
    public struct GeographicLocation
    {
        public GeographicLocation(double latitude, double longitude) : this()
        {
            // Normalize values.
            Latitude = latitude % 90;
            Longitude = longitude % 180;
        }

        public double Latitude { private set; get; }

        public double Longitude { private set; get; }

        public override string ToString()
        {
            return String.Format("{0}{1} {2}{3}", DMS(Math.Abs(Latitude)),
                                                  Latitude >= 0 ? "N" : "S",
                                                  DMS(Math.Abs(Longitude)),
                                                  Longitude >= 0 ? "E" : "W"); 
        }

        string DMS(double decimalDegrees)
        {
            int degrees = (int)decimalDegrees;
            decimalDegrees -= degrees;
            decimalDegrees *= 60;
            int minutes = (int)decimalDegrees;
            decimalDegrees -= minutes;
            decimalDegrees *= 60;
            int seconds = (int)Math.Round(decimalDegrees);

            // Fix rounding issues.
            if (seconds == 60)
            {
                seconds = 0;
                minutes += 1;

                if (minutes == 60)
                {
                    minutes = 0;
                    degrees += 1;
                }
            }

            return String.Format("{0}°{1}′{2}″", degrees, minutes, seconds);
        }
    }
}
