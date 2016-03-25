using System;
using Xamarin.Forms;

namespace DynamicVsStaticCode
{
    public class DynamicVsStaticCodePage : ContentPage
    {
        public DynamicVsStaticCodePage()
        {
            Padding = new Thickness(5, 0);

            // Create resource dictionary and add item.
            Resources = new ResourceDictionary
            {
                { "currentDateTime", "Not actually a DateTime" }
            };

            Content = new StackLayout
            {
                Children = 
                {
                    new Label
                    {
                        Text = "StaticResource on Label.Text:",
                        VerticalOptions = LayoutOptions.EndAndExpand,
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
                    },

                    new Label
                    {
                        Text = (string)Resources["currentDateTime"],
                        VerticalOptions = LayoutOptions.StartAndExpand,
                        HorizontalTextAlignment = TextAlignment.Center,
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
                    },

                    new Label
                    {
                        Text = "DynamicResource on Label.Text:",
                        VerticalOptions = LayoutOptions.EndAndExpand,
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
                    }
                }
            };

            // Create the final label with the dynamic resource.
            Label label = new Label
            {
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
            };

            label.SetDynamicResource(Label.TextProperty, "currentDateTime");

            ((StackLayout)Content).Children.Add(label);

            // Start the timer going.
            Device.StartTimer(TimeSpan.FromSeconds(1),
                () =>
                {
                    Resources["currentDateTime"] = DateTime.Now.ToString();
                    return true;
                });
        }
    }
}
