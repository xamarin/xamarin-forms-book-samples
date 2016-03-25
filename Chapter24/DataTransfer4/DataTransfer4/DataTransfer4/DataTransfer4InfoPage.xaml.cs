using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace DataTransfer4
{
    public partial class DataTransfer4InfoPage : ContentPage
    {
        App app = (App)Application.Current;

        public DataTransfer4InfoPage()
        {
            InitializeComponent();

            // Initialize the views.
            Information info = app.CurrentInfoItem;

            nameEntry.Text = info.Name ?? "";
            emailEntry.Text = info.Email ?? "";

            if (!String.IsNullOrWhiteSpace(info.Language))
            {
                languagePicker.SelectedIndex = languagePicker.Items.IndexOf(info.Language);
            }
            datePicker.Date = info.Date;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            // Set properties of Information object.
            Information info = app.CurrentInfoItem;

            info.Name = nameEntry.Text;
            info.Email = emailEntry.Text;

            int index = languagePicker.SelectedIndex;
            info.Language = index == -1 ? null : languagePicker.Items[index];

            info.Date = datePicker.Date;

            // If the object has already been added to the collection, replace it.
            IList<Information> list = app.InfoCollection;

            index = list.IndexOf(info);

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
