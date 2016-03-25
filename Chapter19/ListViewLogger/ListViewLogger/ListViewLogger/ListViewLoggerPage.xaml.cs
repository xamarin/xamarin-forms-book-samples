using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ListViewLogger
{
    public partial class ListViewLoggerPage : ContentPage
    {
        public ListViewLoggerPage()
        {
            InitializeComponent();

            List<DateTime> list = new List<DateTime>();
            listView.ItemsSource = list;

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                list.Add(DateTime.Now);
                return true;
            });
        }
    }
}
