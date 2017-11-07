using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace Xamarin.FormsBook.Toolkit
{
    public class ToggleBase : ContentView
    {
        public event EventHandler<ToggledEventArgs> Toggled;

        public static readonly BindableProperty IsToggledProperty =
            BindableProperty.Create("IsToggled", typeof(bool), typeof(ToggleBase), false,
                                    BindingMode.TwoWay,
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    ((ToggleBase)bindable).Toggled?.Invoke(bindable, new ToggledEventArgs((bool)newValue));
                });

        public ToggleBase()
        {
            ToggleBehavior toggleBehavior = new ToggleBehavior();
            toggleBehavior.PropertyChanged += OnToggleBehaviorPropertyChanged;
            Behaviors.Add(toggleBehavior);
        }

        public bool IsToggled
        {
            set { SetValue(IsToggledProperty, value); }
            get { return (bool)GetValue(IsToggledProperty); }
        }

        protected void OnToggleBehaviorPropertyChanged(object sender, 
                                                       PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "IsToggled")
            {
                IsToggled = ((ToggleBehavior)sender).IsToggled;
            }
        }
    }
}
