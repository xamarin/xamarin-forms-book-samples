using System;
using Xamarin.Forms;
using Xamarin.FormsBook.Platform;

namespace StepSliderDemo
{
    public partial class StepSliderDemoPage : ContentPage
    {
        public StepSliderDemoPage()
        {
            InitializeComponent();
        }

        void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            StepSlider stepSlider = (StepSlider)sender;

            if (stepSlider == stepSlider2)
            {
                label2.Text = stepSlider2.Value.ToString();
            }
            else if (stepSlider == stepSlider4)
            {
                label4.Text = stepSlider4.Value.ToString();
            }
        }
    }
}
