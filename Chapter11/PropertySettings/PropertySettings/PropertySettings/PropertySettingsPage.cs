using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace PropertySettings
{
    public class PropertySettingsPage : ContentPage
    {
        public PropertySettingsPage()
        {
            Label label1 = new Label();
            label1.Text = "Text with CLR properties";
            label1.IsVisible = true;
            label1.Opacity = 0.75;
            label1.HorizontalTextAlignment = TextAlignment.Center;
            label1.VerticalOptions = LayoutOptions.CenterAndExpand;
            label1.TextColor = Color.Blue;
            label1.BackgroundColor = Color.FromRgb(255, 128, 128);
            label1.FontSize = Device.GetNamedSize(NamedSize.Medium, new Label());
            label1.FontAttributes = FontAttributes.Bold | FontAttributes.Italic;

            Label label2 = new Label();
            label2.SetValue(Label.TextProperty, "Text with bindable properties");
            label2.SetValue(Label.IsVisibleProperty, true);
            label2.SetValue(Label.OpacityProperty, 0.75);
            label2.SetValue(Label.HorizontalTextAlignmentProperty, TextAlignment.Center);
            label2.SetValue(Label.VerticalOptionsProperty, LayoutOptions.CenterAndExpand);
            label2.SetValue(Label.TextColorProperty, Color.Blue);
            label2.SetValue(Label.BackgroundColorProperty, Color.FromRgb(255, 128, 128));
            label2.SetValue(Label.FontSizeProperty, 
                            Device.GetNamedSize(NamedSize.Medium, new Label()));
            label2.SetValue(Label.FontAttributesProperty, 
                            FontAttributes.Bold | FontAttributes.Italic);

            Content = new StackLayout
            {
                Children = 
                {
                    label1,
                    label2
                }
            };
        }
    }
}
