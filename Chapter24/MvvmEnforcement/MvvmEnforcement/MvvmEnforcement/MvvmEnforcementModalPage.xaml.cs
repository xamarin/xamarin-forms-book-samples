using System;
using Xamarin.Forms;

namespace MvvmEnforcement
{
    public partial class MvvmEnforcementModalPage : ContentPage
    {
        public MvvmEnforcementModalPage()
        {
            InitializeComponent();

            LittleViewModel viewModel = new LittleViewModel();
            BindingContext = viewModel;

            // Populate Picker Items list.
            foreach (string language in viewModel.Languages)
            {
                picker.Items.Add(language);
            }
        }

        protected override bool OnBackButtonPressed()
        {
            LittleViewModel viewModel = (LittleViewModel)BindingContext;
            return viewModel.IsValid ? base.OnBackButtonPressed() : true;
        }

        async void OnDoneButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PopModalAsync();
        }
    }
}

