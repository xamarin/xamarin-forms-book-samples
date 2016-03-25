using System;
using Xamarin.Forms;

namespace BindingSourceCode
{
    public class BindingSourceCodePage : ContentPage
    {
        public BindingSourceCodePage()
        {
            Label label = new Label
            {
                Text = "Binding Source Demo",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };

            Slider slider = new Slider
            {
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            // Define Binding object with source object and property.
            Binding binding = new Binding
            {
                Source = slider,
                Path = "Value"
            };

            // Bind the Opacity property of the Label to the source.
            label.SetBinding(Label.OpacityProperty, binding);

            // Construct the page.
            Padding = new Thickness(10, 0);
            Content = new StackLayout
            {
                Children = { label, slider }
            };
        }
    }
}
