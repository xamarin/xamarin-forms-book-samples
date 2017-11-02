using System;
using System.Globalization;
using System.Reflection;
using Xamarin.Forms;

namespace Xamarin.FormsBook.Toolkit
{
    public class EasingConverter : TypeConverter
    {
        public override bool CanConvertFrom(Type sourceType)
        {
            if (sourceType == null)
                throw new ArgumentNullException("EasingConverter.CanConvertFrom: sourceType");

            return (sourceType == typeof(string));
        }

        public override object ConvertFromInvariantString(string str)
        {
            if (String.IsNullOrWhiteSpace(str))
                return null;

            string name = str.Trim();

            if (name.StartsWith("Easing"))
            {
                name = name.Substring(7);
            }
            
            FieldInfo field = typeof(Easing).GetRuntimeField(name);

            if (field != null && field.IsStatic)
            {
                return (Easing)field.GetValue(null);
            }

            throw new InvalidOperationException(
                String.Format("Cannot convert \"{0}\" into Xamarin.Forms.Easing", str));
        }
    }
}
