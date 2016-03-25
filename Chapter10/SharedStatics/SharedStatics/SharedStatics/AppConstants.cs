using System;
using Xamarin.Forms;

namespace SharedStatics
{
    static class AppConstants
    {
        public static Color LightBackground = Color.Yellow; 
        public static Color DarkForeground = Color.Blue;

        public static double NormalFontSize = 18;
        public static double TitleFontSize = 1.4 * NormalFontSize;
        public static double ParagraphSpacing = 10;
 
        public const FontAttributes Emphasis = FontAttributes.Italic;
        public const FontAttributes TitleAttribute = FontAttributes.Bold;

        public const TextAlignment TitleAlignment = TextAlignment.Center;
    }
}
