using System;
using Xamarin.Forms;

namespace EstimatedFontSize
{
    public class EstimatedFontSizePage : ContentPage
    {
        Label label;

        public EstimatedFontSizePage()
        {
            label = new Label();

            Padding = new Thickness(0, Device.RuntimePlatform == Device.iOS ? 20 : 0, 0, 0);
            ContentView contentView = new ContentView
            {
                Content = label
            };
            contentView.SizeChanged += OnContentViewSizeChanged;
            Content = contentView;
        }

        void OnContentViewSizeChanged(object sender, EventArgs args)
        {
            string text =
                "A default system font with a font size of S " +
                "has a line height of about ({0:F1} * S) and an " +
                "average character width of about ({1:F1} * S). " +
                "On this page, which has a width of {2:F0} and a " +
                "height of {3:F0}, a font size of ?1 should " +
                "comfortably render the ??2 characters in this " +
                "paragraph with ?3 lines and about ?4 characters " +
                "per line. Does it work?";

            // Get View whose size is changing.
            View view = (View)sender;

            // Define two values as multiples of font size.
            double lineHeight = Device.RuntimePlatform == Device.iOS || 
                                Device.RuntimePlatform == Device.Android ? 1.2 : 1.3;

            double charWidth = 0.5;

            // Format the text and get its character length.
            text = String.Format(text, lineHeight, charWidth, view.Width, view.Height);
            int charCount = text.Length;

            // Because:
            //   lineCount = view.Height / (lineHeight * fontSize)
            //   charsPerLine = view.Width / (charWidth * fontSize)
            //   charCount = lineCount * charsPerLine
            // Hence, solving for fontSize:
            int fontSize = (int)Math.Sqrt(view.Width * view.Height /
                            (charCount * lineHeight * charWidth));

            // Now these values can be calculated.
            int lineCount = (int)(view.Height / (lineHeight * fontSize));
            int charsPerLine = (int)(view.Width / (charWidth * fontSize));

            // Replace the placeholders with the values.
            text = text.Replace("?1", fontSize.ToString());
            text = text.Replace("??2", charCount.ToString());
            text = text.Replace("?3", lineCount.ToString());
            text = text.Replace("?4", charsPerLine.ToString());

            // Set the Label properties.
            label.Text = text;
            label.FontSize = fontSize;
        }
    }
}
