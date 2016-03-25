using System;
using Xamarin.Forms;

namespace OpacityBindingCode
{
    public class OpacityBindingCodePage : ContentPage
    {
        public OpacityBindingCodePage()
        {
            Label label = new Label
            {
                Text = "Opacity Binding Demo",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };

            Slider slider = new Slider
            {
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            // Set the binding context: target is Label; source is Slider.
            label.BindingContext = slider;

            // Bind the properties: target is Opacity; source is Value.
            label.SetBinding(Label.OpacityProperty, "Value");

            // Construct the page.
            Padding = new Thickness(10, 0);
            Content = new StackLayout
            {
                Children = { label, slider }
            };
        }
    }
}
