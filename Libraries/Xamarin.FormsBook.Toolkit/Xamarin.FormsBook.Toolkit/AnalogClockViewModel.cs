using System;
using System.Threading.Tasks;

namespace Xamarin.FormsBook.Toolkit
{
    public class AnalogClockViewModel : ViewModelBase
    {
        double hourAngle, minuteAngle, secondAngle;

        public AnalogClockViewModel()
        {
            UpdateLoop();
        }

        async void UpdateLoop()
        {
            while (true)
            {
                DateTime dateTime = DateTime.Now;
                HourAngle = 30 * (dateTime.Hour % 12) + 0.5 * dateTime.Minute;
                MinuteAngle = 6 * dateTime.Minute + 0.1 * dateTime.Second;
                SecondAngle = 6 * dateTime.Second + 0.006 * dateTime.Millisecond;

                await Task.Delay(16);
            }
        }

        public double HourAngle
        {
            private set { SetProperty(ref hourAngle, value); }
            get { return hourAngle; }
        }

        public double MinuteAngle
        {
            private set { SetProperty(ref minuteAngle, value); }
            get { return minuteAngle; }
        }

        public double SecondAngle
        {
            private set { SetProperty(ref secondAngle, value); }
            get { return secondAngle; }
        }
    }
}
