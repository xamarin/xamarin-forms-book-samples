using System;
using Xamarin.Forms;

namespace ModalEnforcement
{
    public partial class ModalEnforcementHomePage : ContentPage
    {
        public ModalEnforcementHomePage()
        {
            InitializeComponent();
        }

        async void OnGoToButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new ModalEnforcementModalPage());
        }
    }
}
