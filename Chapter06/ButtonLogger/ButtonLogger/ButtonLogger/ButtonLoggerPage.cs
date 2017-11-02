using System;
using Xamarin.Forms;

namespace ButtonLogger
{
    public class ButtonLoggerPage : ContentPage
    {
        StackLayout loggerLayout = new StackLayout();

        public ButtonLoggerPage()
        {
            // Create the Button and attach Clicked handler.
            Button button = new Button
            {
                Text = "Log the Click Time"
            };
            button.Clicked += OnButtonClicked;

            Padding = new Thickness(5, Device.RuntimePlatform == Device.iOS ? 20 : 0, 5, 0);

            // Assemble the page.
            Content = new StackLayout
            {
                Children =
                {
                    button,
                    new ScrollView
                    {
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        Content = loggerLayout
                    }
                }
            };
        }

        void OnButtonClicked(object sender, EventArgs args)
        {
            // Add Label to scrollable StackLayout.
            loggerLayout.Children.Add(new Label
            {
                Text = "Button clicked at " + DateTime.Now.ToString("T")
            });
        }
    }
}
