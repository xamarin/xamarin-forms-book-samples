using System;
using Xamarin.Forms;

namespace StudentNotes
{
    public partial class StudentNotesHomePage : ContentPage
    {
        public StudentNotesHomePage()
        {
            InitializeComponent();
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (args.SelectedItem != null)
            {
                listView.SelectedItem = null;

                await Navigation.PushAsync(new StudentNotesDataPage
                {
                    BindingContext = args.SelectedItem
                });
            }
        }
    }
}
