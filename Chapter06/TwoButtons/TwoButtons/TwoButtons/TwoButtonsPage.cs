using System;
using Xamarin.Forms;

namespace TwoButtons
{
    public class TwoButtonsPage : ContentPage
    {
        Button addButton, removeButton;
        StackLayout loggerLayout = new StackLayout();

        public TwoButtonsPage()
        {
            // Create the Button views and attach Clicked handlers.
            addButton = new Button
            {
                Text = "Add",
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            addButton.Clicked += OnButtonClicked;

            removeButton = new Button
            {
                Text = "Remove",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                IsEnabled = false
            };
            removeButton.Clicked += OnButtonClicked;

            Padding = new Thickness(5, Device.RuntimePlatform == Device.iOS ? 20 : 0, 5, 0);

            // Assemble the page.
            Content = new StackLayout
            {
                Children =
                {
                    new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        Children =
                        {
                            addButton,
                            removeButton
                        }
                    },

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
            Button button = (Button)sender;

            if (button == addButton)
            {
                // Add Label to scrollable StackLayout.
                loggerLayout.Children.Add(new Label
                {
                    Text = "Button clicked at " + DateTime.Now.ToString("T")
                });
            }
            else
            {
                // Remove topmost Label from StackLayout
                loggerLayout.Children.RemoveAt(0);
            }

            // Enable "Remove" button only if children are present.
            removeButton.IsEnabled = loggerLayout.Children.Count > 0;
        }
    }
}
