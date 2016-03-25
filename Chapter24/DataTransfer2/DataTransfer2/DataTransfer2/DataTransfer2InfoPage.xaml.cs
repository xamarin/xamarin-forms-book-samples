using System;
using Xamarin.Forms;

namespace DataTransfer2
{
    public partial class DataTransfer2InfoPage : ContentPage
    {
        // Instantiate an Information object for this page instance.
        Information info = new Information();

        public DataTransfer2InfoPage()
        {
            InitializeComponent();

            // Subscribe to "InitializeInfo" message.
            MessagingCenter.Subscribe<DataTransfer2HomePage, Information>
                (this, "InitializeInfo", (sender, info) =>
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

                    // Don't need "InitializeInfo" any more so unsubscribe.
                    MessagingCenter.Unsubscribe<DataTransfer2HomePage, Information>
                        (this, "InitializeInfo");
                });
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

            // Send "InformationReady" message back to home page.
            MessagingCenter.Send<DataTransfer2InfoPage, Information>
                (this, "InformationReady", info);
        }
    }
}
