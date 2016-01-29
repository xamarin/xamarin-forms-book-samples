using System;
using Xamarin.Forms;

namespace SliderDemo
{
    public partial class SliderDemoPage : ContentPage
    {
        public SliderDemoPage()
        {
            InitializeComponent();
        }

        void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            label.Text = String.Format("Slider = {0}", args.NewValue);
        }
    }
}
