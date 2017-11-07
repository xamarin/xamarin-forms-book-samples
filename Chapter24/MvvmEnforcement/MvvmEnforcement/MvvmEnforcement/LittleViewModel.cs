using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MvvmEnforcement
{
    public class LittleViewModel : INotifyPropertyChanged
    {
        string name, email;
        string[] languages = { "C#", "F#", "Objective C", "Swift", "Java" };
        int languageIndex = -1;
        bool isValid;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                    TestIfValid();
                }
            }
            get { return name; }
        }

        public string Email
        {
            set
            {
                if (email != value)
                {
                    email = value;
                    OnPropertyChanged("Email");
                    TestIfValid();
                }
            }
            get { return email; }
        }

        public IEnumerable<string> Languages
        {
            get { return languages; }
        }

        public int LanguageIndex
        {
            set
            {
                if (languageIndex != value)
                {
                    languageIndex = value;
                    OnPropertyChanged("LanguageIndex");

                    if (languageIndex >= 0 && languageIndex < languages.Length)
                    {
                        Language = languages[languageIndex];
                        OnPropertyChanged("Language");
                    }
                    TestIfValid();
                }
            }
            get { return languageIndex; }
        }

        public string Language { private set; get; }

        public bool IsValid
        {
            private set
            {
                if (isValid != value)
                {
                    isValid = value;
                    OnPropertyChanged("IsValid");
                }
            }
            get { return isValid; }
        }

        void TestIfValid()
        {
            IsValid = !String.IsNullOrWhiteSpace(Name) &&
                      !String.IsNullOrWhiteSpace(Email) &&
                      !String.IsNullOrWhiteSpace(Language);
        }

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
