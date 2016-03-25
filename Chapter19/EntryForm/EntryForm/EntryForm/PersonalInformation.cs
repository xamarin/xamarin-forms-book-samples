using System;
using Xamarin.FormsBook.Toolkit;

namespace EntryForm
{
    class PersonalInformation : ViewModelBase
    {
        string name, emailAddress, phoneNumber;
        int age;
        bool isProgrammer;

        public string Name 
        {
            set { SetProperty(ref name, value); }
            get { return name; } 
        }

        public string EmailAddress 
        {
            set { SetProperty(ref emailAddress, value); }
            get { return emailAddress; } 
        }

        public string PhoneNumber 
        {
            set { SetProperty(ref phoneNumber, value); }
            get { return phoneNumber; } 
        }

        public int Age 
        {
            set { SetProperty(ref age, value); }
            get { return age; }
        }

        public bool IsProgrammer 
        {
            set { SetProperty(ref isProgrammer, value); }
            get { return isProgrammer; }
        }
    }
}
