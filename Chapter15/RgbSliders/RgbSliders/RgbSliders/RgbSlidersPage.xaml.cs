using System;
using Xamarin.Forms;

namespace RgbSliders
{
    public partial class RgbSlidersPage : ContentPage
    {
        public RgbSlidersPage()
        {
            InitializeComponent();

            redSlider.Value = 128;
            greenSlider.Value = 128;
            blueSlider.Value = 128;
        }

        void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            if (sender == redSlider)
            {
                redLabel.Text = String.Format("Red = {0:X2}", (int)redSlider.Value);
            }
            else if (sender == greenSlider)
            {
                greenLabel.Text = String.Format("Green = {0:X2}", (int)greenSlider.Value);
            }
            else if (sender == blueSlider)
            {
                blueLabel.Text = String.Format("Blue = {0:X2}", (int)blueSlider.Value);
            }

            boxView.Color = Color.FromRgb((int)redSlider.Value,
                                          (int)greenSlider.Value,
                                          (int)blueSlider.Value);
        }
    }
}
