using System;
using Xamarin.FormsBook.Toolkit;

namespace DataTransfer5
{
    public class InformationViewModel : ViewModelBase
    {
        string name, email, language;
        DateTime date = DateTime.Today;

        public string Name
        {
            set { SetProperty(ref name, value); }
            get { return name; }
        }

        public string Email
        {
            set { SetProperty(ref email, value); }
            get { return email; }
        }

        public string Language
        {
            set { SetProperty(ref language, value); }
            get { return language; }
        }

        public DateTime Date
        {
            set { SetProperty(ref date, value); }
            get { return date; }
        }
    }
}
