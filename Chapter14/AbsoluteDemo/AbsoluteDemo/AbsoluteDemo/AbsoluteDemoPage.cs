using System;
using Xamarin.Forms;

namespace AbsoluteDemo
{
    public class AbsoluteDemoPage : ContentPage
    {
        public AbsoluteDemoPage()
        {
            AbsoluteLayout absoluteLayout = new AbsoluteLayout
            {
                Padding = new Thickness(50)
            };

            absoluteLayout.Children.Add(
                new BoxView
                {
                    Color = Color.Accent
                },
                new Rectangle(0, 10, 200, 5));

            absoluteLayout.Children.Add(
                new BoxView
                {
                    Color = Color.Accent
                },
                new Rectangle(0, 20, 200, 5));

            absoluteLayout.Children.Add(
                new BoxView
                {
                    Color = Color.Accent
                },
                new Rectangle(10, 0, 5, 65));

            absoluteLayout.Children.Add(
                new BoxView
                {
                    Color = Color.Accent
                },
                new Rectangle(20, 0, 5, 65));

            absoluteLayout.Children.Add(
                new Label
                {
                    Text = "Stylish Header",
                    FontSize = 24
                },
                new Point(30, 25));

            absoluteLayout.Children.Add(
                new Label
                {
                    FormattedText = new FormattedString
                    {
                        Spans = 
                    {
                        new Span
                        {
                            Text = "Although the "
                        },
                        new Span
                        {
                            Text = "AbsoluteLayout",
                            FontAttributes = FontAttributes.Italic
                        },
                        new Span
                        {
                            Text = " is usually employed for purposes other " +
                                    "than the display of text using "
                        },
                        new Span
                        {
                            Text = "Label",
                            FontAttributes = FontAttributes.Italic
                        },
                        new Span
                        {
                            Text = ", obviously it can be used in that way. " +
                                    "The text continues to wrap nicely " +
                                    "within the bounds of the container " +
                                    "and any padding that might be applied."
                        }
                    }
                    }
                },
                new Point(0, 80));

            this.Content = absoluteLayout;
        }
    }
}
