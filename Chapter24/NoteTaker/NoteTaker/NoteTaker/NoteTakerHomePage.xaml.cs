using System;
using Xamarin.Forms;

namespace NoteTaker
{
    partial class NoteTakerHomePage : ContentPage
    {
        public NoteTakerHomePage()
        {
            InitializeComponent();
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (args.SelectedItem != null)
            {
                // Deselect the item.
                ListView listView = (ListView)sender;
                listView.SelectedItem = null;

                // Navigate to NotePage.
                await Navigation.PushAsync(new NoteTakerNotePage
                    {
                        Note = (Note)args.SelectedItem,
                        IsNoteEdit = true
                    });
            }
        }

        async void OnAddNoteClicked(object sender, EventArgs args)
        {
            // Create unique filename.
            DateTime dateTime = DateTime.UtcNow;
            string filename = dateTime.ToString("yyyyMMddHHmmssfff") + ".note";

            // Navigate to NotePage.
            await Navigation.PushAsync(new NoteTakerNotePage
                {
                    Note = new Note(filename),
                    IsNoteEdit = false
                });
        }
    }
}
