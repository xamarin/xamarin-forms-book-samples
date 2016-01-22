using System;
using Xamarin.Forms;

namespace ButtonLambdas
{
    public class ButtonLambdasPage : ContentPage
    {
        public ButtonLambdasPage()
        {
            // Number to manipulate.
            double number = 1;

            // Create the Label for display.
            Label label = new Label
            {
                Text = number.ToString(),
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            // Create the first Button and attach Clicked handler.
            Button timesButton = new Button
            {
                Text = "Double",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            timesButton.Clicked += (sender, args) =>
            {
                number *= 2;
                label.Text = number.ToString();
            };

            // Create the second Button and attach Clicked handler.
            Button divideButton = new Button
            {
                Text = "Half",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            divideButton.Clicked += (sender, args) =>
            {
                number /= 2;
                label.Text = number.ToString();
            };

            // Assemble the page.
            this.Content = new StackLayout
            {
                Children =
                {
                    label,
                    new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        Children =
                        {
                            timesButton,
                            divideButton
                        }
                    }
                }
            };
        }
    }
}
