using System;
using Xamarin.Forms;

namespace MvvmClock
{
    public partial class MvvmClockPage : ContentPage
    {
        public MvvmClockPage()
        {
            // Ensure link to library.
            new Xamarin.FormsBook.Toolkit.DateTimeViewModel();

            InitializeComponent();
        }
    }
}
