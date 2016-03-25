using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace SetTimer
{
    public partial class SetTimerPage : ContentPage
    {
        DateTime triggerTime;

        public SetTimerPage()
        {
            InitializeComponent();

            Device.StartTimer(TimeSpan.FromSeconds(1), OnTimerTick);
        }

        bool OnTimerTick()
        {
            if (@switch.IsToggled && DateTime.Now >= triggerTime)
            {
                @switch.IsToggled = false;
                DisplayAlert("Timer Alert",
                             "The '" + entry.Text + "' timer has elapsed", 
                             "OK");
            }
            return true;
        }

        void OnTimePickerPropertyChanged(object obj, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "Time")
            {
                SetTriggerTime();
            }
        }

        void OnSwitchToggled(object obj, ToggledEventArgs args)
        {
            SetTriggerTime();
        }

        void SetTriggerTime()
        {
            if (@switch.IsToggled)
            {
                triggerTime = DateTime.Today + timePicker.Time;

                if (triggerTime < DateTime.Now)
                {
                    triggerTime += TimeSpan.FromDays(1);
                }
            }
        }
    }
}
