using System;
using Xamarin.Forms;

namespace VariableFormattedText
{
    public class VariableFormattedTextPage : ContentPage
    {
        public VariableFormattedTextPage()
        {
            Content = new Label
            {
                FormattedText = new FormattedString
                {
                    Spans =
                    {
                        new Span
                        {
                            Text = "I "
                        },
                        new Span
                        {
                            Text = "love",
                            FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                            FontAttributes = FontAttributes.Bold
                        },
                        new Span
                        {
                            Text = " Xamarin.Forms!"
                        }
                    }
                },

                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };
        }
    }
}
