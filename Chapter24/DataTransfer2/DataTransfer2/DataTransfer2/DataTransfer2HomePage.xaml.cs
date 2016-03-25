using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace DataTransfer2
{
    public partial class DataTransfer2HomePage : ContentPage
    {
        ObservableCollection<Information> list = new ObservableCollection<Information>();

        public DataTransfer2HomePage()
        {
            InitializeComponent();

            // Set collection to ListView.
            listView.ItemsSource = list;

            // Subscribe to "InformationReady" message.
            MessagingCenter.Subscribe<DataTransfer2InfoPage, Information>
                (this, "InformationReady", (sender, info) =>
                {
                    // If the object has already been added, replace it.
                    int index = list.IndexOf(info);

                    if (index != -1)
                    {
                        list[index] = info;
                    }
                    // Otherwise, add it.
                    else
                    {
                        list.Add(info);
                    }
                });
        }

        // Button Clicked handler.
        async void OnGetInfoButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new DataTransfer2InfoPage());
        }

        // ListView ItemSelected handler.
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (args.SelectedItem != null)
            {
                // De-select the item.
                listView.SelectedItem = null;

                DataTransfer2InfoPage infoPage = new DataTransfer2InfoPage();
                await Navigation.PushAsync(infoPage);

                // Send "InitializeInfo" message to info page.
                MessagingCenter.Send<DataTransfer2HomePage, Information>
                    (this, "InitializeInfo", (Information)args.SelectedItem);
            }
        }
    }
}
