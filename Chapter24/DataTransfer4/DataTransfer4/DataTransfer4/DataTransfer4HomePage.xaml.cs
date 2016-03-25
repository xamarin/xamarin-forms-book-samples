using System;
using Xamarin.Forms;

namespace DataTransfer4
{
    public partial class DataTransfer4HomePage : ContentPage
    {
        App app = (App)Application.Current;

        public DataTransfer4HomePage()
        {
            InitializeComponent();

            // Set collection to ListView.
            listView.ItemsSource = app.InfoCollection;
        }

        // Button Clicked handler.
        async void OnGetInfoButtonClicked(object sender, EventArgs args)
        {
            // Create new Information item.
            app.CurrentInfoItem = new Information();

            // Navigate to info page.
            await Navigation.PushAsync(new DataTransfer4InfoPage());
        }

        // ListView ItemSelected handler.
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (args.SelectedItem != null)
            {
                // De-select the item.
                listView.SelectedItem = null;

                // Get existing Information item.
                app.CurrentInfoItem = (Information)args.SelectedItem;

                // Navigate to info page.
                await Navigation.PushAsync(new DataTransfer4InfoPage());
            }
        }
    }
}
