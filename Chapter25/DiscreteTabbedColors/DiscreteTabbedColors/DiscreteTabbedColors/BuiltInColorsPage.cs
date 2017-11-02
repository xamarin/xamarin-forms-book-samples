using System;
using Xamarin.Forms;

namespace DiscreteTabbedColors
{
    class BuiltInColorsPage : ContentPage
    {
        public BuiltInColorsPage()
        {
            Title = "Built-in";
            Icon = Device.RuntimePlatform == Device.iOS ? "ic_action_computer.png" : null;
            Padding = new Thickness(5, Device.RuntimePlatform == Device.iOS ? 20 : 5, 5, 5);
            double fontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));
            Content = new ScrollView
            {
                Content = new StackLayout
                {
                    Spacing = 0,
                    Children =
                    {
                        new Label
                        {
                            Text = "White",
                            TextColor = Color.White,
                            FontSize = fontSize
                        },
                        new Label
                        {
                            Text = "Silver",
                            TextColor = Color.Silver,
                            FontSize = fontSize
                        },
                        new Label
                        {
                            Text = "Gray",
                            TextColor = Color.Gray,
                            FontSize = fontSize
                        },
                        new Label
                        {
                            Text = "Black",
                            TextColor = Color.Black,
                            FontSize = fontSize
                        },
                        new Label
                        {
                            Text = "Red",
                            TextColor = Color.Red,
                            FontSize = fontSize
                        },
                        new Label
                        {
                            Text = "Maroon",
                            TextColor = Color.Maroon,
                            FontSize = fontSize
                        },
                        new Label
                        {
                            Text = "Yellow",
                            TextColor = Color.Yellow,
                            FontSize = fontSize
                        },
                        new Label
                        {
                            Text = "Olive",
                            TextColor = Color.Olive,
                            FontSize = fontSize
                        },
                        new Label
                        {
                            Text = "Lime",
                            TextColor = Color.Lime,
                            FontSize = fontSize
                        },
                        new Label
                        {
                            Text = "Green",
                            TextColor = Color.Green,
                            FontSize = fontSize
                        },
                        new Label
                        {
                            Text = "Aqua",
                            TextColor = Color.Aqua,
                            FontSize = fontSize
                        },
                        new Label
                        {
                            Text = "Teal",
                            TextColor = Color.Teal,
                            FontSize = fontSize
                        },
                        new Label
                        {
                            Text = "Blue",
                            TextColor = Color.Blue,
                            FontSize = fontSize
                        },
                        new Label
                        {
                            Text = "Navy",
                            TextColor = Color.Navy,
                            FontSize = fontSize
                        },
                        new Label
                        {
                            Text = "Pink",
                            TextColor = Color.Pink,
                            FontSize = fontSize
                        },
                        new Label
                        {
                            Text = "Fuchsia",
                            TextColor = Color.Fuchsia,
                            FontSize = fontSize
                        },
                        new Label
                        {
                            Text = "Purple",
                            TextColor = Color.Purple,
                            FontSize = fontSize
                        }
                    }
                }
            };
        }
    }
}