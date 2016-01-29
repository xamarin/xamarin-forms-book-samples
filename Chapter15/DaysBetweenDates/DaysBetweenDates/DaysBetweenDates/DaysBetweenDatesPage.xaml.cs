using System;
using Xamarin.Forms;

namespace DaysBetweenDates
{
    public partial class DaysBetweenDatesPage : ContentPage
    {
        public DaysBetweenDatesPage()
        {
            InitializeComponent();

            // Initialize.
            OnDateSelected(null, null);
        }

        void OnDateSelected(object sender, DateChangedEventArgs args)
        {
            int days = (toDatePicker.Date - fromDatePicker.Date).Days;
            resultLabel.Text = String.Format("{0} day{1} between dates",
                                             days, days == 1 ? "" : "s");
        }
    }
}
