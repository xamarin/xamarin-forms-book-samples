using System;
using Xamarin.Forms;

namespace EntryForm
{
    public partial class EntryFormPage : ContentPage
    {
        public EntryFormPage()
        {
            InitializeComponent();
        }

        void OnSubmitButtonClicked(object sender, EventArgs args)
        {
            PersonalInformation personalInfo = (PersonalInformation)tableView.BindingContext;

            summaryLabel.Text = String.Format(
                "{0} is {1} years old, and has an email address " +
                "of {2}, and a phone number of {3}, and is {4}" +
                "a programmer.",
                personalInfo.Name, personalInfo.Age,
                personalInfo.EmailAddress, personalInfo.PhoneNumber,
                personalInfo.IsProgrammer ? "" : "not ");
        }
    }
}
