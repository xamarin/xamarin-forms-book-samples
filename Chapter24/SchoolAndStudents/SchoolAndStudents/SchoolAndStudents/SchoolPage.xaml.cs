using System;
using Xamarin.Forms;
using SchoolOfFineArt;

namespace SchoolAndStudents
{
    public partial class SchoolPage : ContentPage
    {
        public SchoolPage()
        {
            InitializeComponent();

            // Set BindingContext.
            BindingContext = new SchoolViewModel();
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            // The selected item is null or of type Student.
            Student student = args.SelectedItem as Student;

            // Make sure that an item is actually selected.
            if (student != null)
            {
                // Deselect the item.
                listView.SelectedItem = null;

                // Navigate to StudentPage with Student argument.
                await Navigation.PushAsync(new StudentPage(student));
            }
        }
    }
}
