using System;
using Xamarin.Forms;

namespace GridCodeDemo
{
    public class GridCodeDemoPage : ContentPage
    {
        public GridCodeDemoPage()
        {
            Grid grid = new Grid
            {
                RowDefinitions = 
                {
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = new GridLength(100) },
                    new RowDefinition { Height = new GridLength(2, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
                }
            };

            // First Label (row 0 and column 0).
            grid.Children.Add(new Label
            {
                Text = "Grid Demo",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.End
            });

            // Second Label.
            grid.Children.Add(new Label
                {
                    Text = "Demo the Grid",
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                    HorizontalOptions = LayoutOptions.End,
                    VerticalOptions = LayoutOptions.End
                }, 
                1,          // left
                0);         // top


            string imgSrc = null;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    imgSrc = "Icon-60.png";
                    break;

                case Device.Android:
                    imgSrc = "icon.png";
                    break;

                case Device.WinRT:
                case Device.WinPhone:
                case Device.UWP:
                    imgSrc = "Assets/StoreLogo.png";
                    break;
            }

            // Image element.
            grid.Children.Add(new Image
                {
                    BackgroundColor = Color.Gray,
                    Source = imgSrc
                },
                0,          // left
                2,          // right
                1,          // top
                2);         // bottom

            // Three BoxView elements.
            BoxView boxView1 = new BoxView { Color = Color.Green };
            Grid.SetRow(boxView1, 2);
            Grid.SetColumn(boxView1, 0);
            grid.Children.Add(boxView1);

            BoxView boxView2 = new BoxView { Color = Color.Red };
            Grid.SetRow(boxView2, 2);
            Grid.SetColumn(boxView2, 1);
            Grid.SetRowSpan(boxView2, 2);
            grid.Children.Add(boxView2);

            BoxView boxView3 = new BoxView 
            { 
                Color = Color.Blue, 
                Opacity = 0.5
            };
            Grid.SetRow(boxView3, 3);
            Grid.SetColumn(boxView3, 0);
            Grid.SetColumnSpan(boxView3, 2);
            grid.Children.Add(boxView3);

            Padding = new Thickness(0, Device.RuntimePlatform == Device.iOS ? 20 : 0, 0, 0);
            Content = grid;
        }
    }
}
