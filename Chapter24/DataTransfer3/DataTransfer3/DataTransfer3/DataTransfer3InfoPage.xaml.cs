using System;
using Xamarin.Forms;

namespace DataTransfer3
{
    public partial class DataTransfer3InfoPage : ContentPage
    {
        // Define a public event for transferring data.
        public event EventHandler<Information> InformationReady;

        // Instantiate an Information object for this page instance.
        Information info = new Information();

        public DataTransfer3InfoPage()
        {
            InitializeComponent();
        }

        public void InitializeInfo(Information info)
        {
            // Replace the instance.
            this.info = info;

            // Initialize the views.
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
            info.Name = nameEntry.Text;
            info.Email = emailEntry.Text;

            int index = languagePicker.SelectedIndex;
            info.Language = index == -1 ? null : languagePicker.Items[index];

            info.Date = datePicker.Date;

            // Raise the InformationReady event.
            InformationReady?.Invoke(this, info);
        }
    }
}
