using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace DataTransfer3
{
    public partial class DataTransfer3HomePage : ContentPage
    {
        ObservableCollection<Information> list = new ObservableCollection<Information>();

        public DataTransfer3HomePage()
        {
            InitializeComponent();

            // Set collection to ListView.
            listView.ItemsSource = list;
        }

        // Button Clicked handler.
        async void OnGetInfoButtonClicked(object sender, EventArgs args)
        {
            DataTransfer3InfoPage infoPage = new DataTransfer3InfoPage();
            await Navigation.PushAsync(infoPage);

            // Set event handler for obtaining information.
            infoPage.InformationReady += OnInfoPageInformationReady;
        }

        // ListView ItemSelected handler.
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (args.SelectedItem != null)
            {
                // De-select the item.
                listView.SelectedItem = null;

                DataTransfer3InfoPage infoPage = new DataTransfer3InfoPage();
                await Navigation.PushAsync(infoPage);
                infoPage.InitializeInfo((Information)args.SelectedItem);

                // Set event handler for obtaining information.
                infoPage.InformationReady += OnInfoPageInformationReady;
            }
        }

        void OnInfoPageInformationReady(object sender, Information info)
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
        }
    }
}
