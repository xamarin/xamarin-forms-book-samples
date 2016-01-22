using System;
using Xamarin.Forms;

namespace SharedStatics
{
    static class AppConstants
    {
        public static Color LightBackground = Color.Yellow; 
        public static Color DarkForeground = Color.Blue;

        public static double NormalFontSize = Device.OnPlatform(18, 18, 24);
        public static double TitleFontSize = 1.5 * NormalFontSize;
        public static double ParagraphSpacing = Device.OnPlatform(10, 10, 15);
 
        public const FontAttributes Emphasis = FontAttributes.Italic;
        public const FontAttributes TitleAttribute = FontAttributes.Bold;

        public const TextAlignment TitleAlignment = TextAlignment.Center;
    }
}
