using System;
using Xamarin.Forms;
using Xamarin.FormsBook.Toolkit;

namespace StackRestoreDemo
{
    public partial class DemoModalPage : ContentPage, IPersistentPage
    {
        public DemoModalPage()
        {
            InitializeComponent();
        }

        async void OnGoBackClicked(object sender, EventArgs args)
        {
            await Navigation.PopModalAsync();
        }

        async void OnGoToModalPageClicked(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new DemoModalPage());
        }

        public void Save(string prefix)
        {
            App.Current.Properties[prefix + "stepperValue"] = stepper.Value;
        }

        public void Restore(string prefix)
        {
            object value;
            if (App.Current.Properties.TryGetValue(prefix + "stepperValue", out value))
                stepper.Value = (double)value;
        }
    }
}
