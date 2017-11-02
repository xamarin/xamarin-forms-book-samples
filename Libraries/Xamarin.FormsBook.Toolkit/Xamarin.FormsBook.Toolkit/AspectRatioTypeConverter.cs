using System;
using System.Globalization;
using Xamarin.Forms;

namespace Xamarin.FormsBook.Toolkit
{
    public class AspectRatioTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(Type sourceType)
        {
            return sourceType == typeof(string);
        }

        public override object ConvertFromInvariantString(string str)
        {
            if (String.IsNullOrWhiteSpace(str))
                return null;

            str = str.Trim();
            double aspectValue;

            if (String.Compare(str, "auto", StringComparison.OrdinalIgnoreCase) == 0)
                return AspectRatio.Auto;

            if (Double.TryParse(str, NumberStyles.Number, 
                                CultureInfo.InvariantCulture, out aspectValue))
                return new AspectRatio(aspectValue);

            throw new FormatException("AspectRatio must be Auto or numeric");
        }
    }
}
