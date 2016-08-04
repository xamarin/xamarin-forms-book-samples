using System;
using Xamarin.Forms;

namespace MapDemos
{
    public partial class MyLocationButton : ContentView
    {
        public event EventHandler Clicked;

        public MyLocationButton()
        {
            InitializeComponent();
        }

        void OnTapped(object sender, EventArgs args)
        {
            Clicked?.Invoke(sender, args);
        }
    }
}
