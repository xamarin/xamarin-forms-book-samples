using System;
using Xamarin.Forms;

namespace DynamicVsStatic
{
    public partial class DynamicVsStaticPage : ContentPage
    {
        public DynamicVsStaticPage()
        {
            InitializeComponent();

            Device.StartTimer(TimeSpan.FromSeconds(1),
                () =>
                {
                    Resources["currentDateTime"] = DateTime.Now.ToString();
                    return true;
                });
        }
    }
}

