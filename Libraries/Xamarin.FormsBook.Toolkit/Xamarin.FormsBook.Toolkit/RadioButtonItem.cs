using System;
using System.Windows.Input;

namespace Xamarin.FormsBook.Toolkit
{
    public class RadioButtonItem<T> : ViewModelBase where T : struct
    {
        bool isSelected;

        internal RadioButtonItem(string name, T value, ICommand command, bool isSelected)
        {
            Name = name;
            Value = value;
            Command = command;
            IsSelected = isSelected;
        }

        public string Name { private set; get; }

        public T Value { private set; get; }

        public ICommand Command { private set; get; }

        public bool IsSelected
        {
            internal set { SetProperty(ref isSelected, value); }
            get { return isSelected; }
        }
    }
}
