using System;
using Xamarin.Forms;
using Xamarin.FormsBook.Toolkit;

namespace TextCellListCode
{
    public class TextCellListCodePage : ContentPage
    {
        public TextCellListCodePage()
        {
            // Define the DataTemplate.
            DataTemplate dataTemplate = new DataTemplate(typeof(TextCell));
            dataTemplate.SetBinding(TextCell.TextProperty, "FriendlyName");
            dataTemplate.SetBinding(TextCell.DetailProperty, 
                new Binding(path: "RgbDisplay", stringFormat: "RGB = {0}"));

            // Build the page.
            Padding = new Thickness(10, Device.RuntimePlatform == Device.iOS ? 20 : 0, 10, 0);

            Content = new ListView
            {
                ItemsSource = NamedColor.All,
                ItemTemplate = dataTemplate
            };
        }
    }
}
