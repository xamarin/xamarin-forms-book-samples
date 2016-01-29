using System;
using Xamarin.Forms;

namespace ButtonEnabler
{
    public partial class ButtonEnablerPage : ContentPage
    {
        public ButtonEnablerPage()
        {
            // Ensure that Toolkit library is linked.
            new Xamarin.FormsBook.Toolkit.IntToBoolConverter();

            InitializeComponent();
        }
    }
}
