using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace ObservableLogger
{
    public partial class ObservableLoggerPage : ContentPage
    {
        public ObservableLoggerPage()
        {
            InitializeComponent();

            ObservableCollection<DateTime> list = new ObservableCollection<DateTime>();
            listView.ItemsSource = list;

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                list.Add(DateTime.Now);
                return true;
            });
        }
    }
}
