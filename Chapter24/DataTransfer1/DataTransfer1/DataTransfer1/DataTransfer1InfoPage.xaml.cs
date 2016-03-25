using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace DataTransfer1
{
    public partial class DataTransfer1InfoPage : ContentPage
    {
        // Instantiate an Information object for this page instance.
        Information info = new Information();

        public DataTransfer1InfoPage()
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

            // Get the DataTransfer1HomePage that invoked this page.
            NavigationPage navPage = (NavigationPage)Application.Current.MainPage;
            IReadOnlyList<Page> navStack = navPage.Navigation.NavigationStack;
            int lastIndex = navStack.Count - 1;
            DataTransfer1HomePage homePage = navStack[lastIndex] as DataTransfer1HomePage;

            if (homePage == null)
            {
                homePage = navStack[lastIndex - 1] as DataTransfer1HomePage;
            }
            // Transfer Information object to DataTransfer1HomePage.
            homePage.InformationReady(info);
        }
    }
}
