using System;
using Xamarin.FormsBook.Toolkit;

namespace ConditionalCells
{
    class ProgrammerInformation : ViewModelBase
    {
        string name, emailAddress, phoneNumber, ageRange;
        bool isProgrammer;
        string language, platform;

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

        public string AgeRange
        {
            set { SetProperty(ref ageRange, value); }
            get { return ageRange; }
        }

        public bool IsProgrammer 
        {
            set { SetProperty(ref isProgrammer, value); }
            get { return isProgrammer; }
        }

        public string Language
        {
            set { SetProperty(ref language, value); }
            get { return language; }
        }

        public string Platform
        {
            set { SetProperty(ref platform, value); }
            get { return platform; }
        }
    }
}
