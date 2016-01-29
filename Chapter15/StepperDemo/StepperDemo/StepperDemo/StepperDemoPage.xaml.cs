using System;
using Xamarin.Forms;

namespace StepperDemo
{
    public partial class StepperDemoPage : ContentPage
    {
        public StepperDemoPage()
        {
            InitializeComponent();

            // Initialize display.
            OnStepperValueChanged(stepper, null);
        }

        void OnStepperValueChanged(object sender, ValueChangedEventArgs args)
        {
            Stepper stepper = (Stepper)sender;
            button.BorderWidth = stepper.Value;
            label.Text = stepper.Value.ToString("F0");
        }
    }
}
