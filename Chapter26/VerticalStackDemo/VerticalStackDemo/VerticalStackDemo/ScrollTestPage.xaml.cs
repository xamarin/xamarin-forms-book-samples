using System;
using Xamarin.Forms;

namespace VerticalStackDemo
{
    public partial class ScrollTestPage : ContentPage
    {
        public ScrollTestPage()
        {
            InitializeComponent();

            for (double r = 0; r <= 1.0; r += 0.25)
                for (double g = 0; g <= 1.0; g += 0.25)
                    for (double b = 0; b <= 1.0; b += 0.25)
                    {
                        stack.Children.Add(new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            Padding = 6,
                            Children =
                            {
                                new BoxView
                                {
                                    Color = Color.FromRgb(r, g, b),
                                    WidthRequest = 100,
                                    HeightRequest = 100
                                },

                                new VerticalStack
                                {
                                    VerticalOptions = LayoutOptions.Center,
                                    Children =
                                    {
                                        new Label { Text = "Red = " + r.ToString("F2") },
                                        new Label { Text = "Green = " + g.ToString("F2") },
                                        new Label { Text = "Blue = " + b.ToString("F2") }
                                    }
                                }
                            }
                        });
                    }
        }
    }
}
