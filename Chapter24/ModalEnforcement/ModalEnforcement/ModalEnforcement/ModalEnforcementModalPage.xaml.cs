using System;
using Xamarin.Forms;

namespace ModalEnforcement
{
    public partial class ModalEnforcementModalPage : ContentPage
    {
        public ModalEnforcementModalPage()
        {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            if (doneButton.IsEnabled)
            {
                return base.OnBackButtonPressed();
            }
            return true;
        }

        async void OnDoneButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PopModalAsync();
        }
    }
}
