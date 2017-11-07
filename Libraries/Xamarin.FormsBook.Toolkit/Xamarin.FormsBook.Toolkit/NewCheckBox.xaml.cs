using System;
using Xamarin.Forms;

namespace Xamarin.FormsBook.Toolkit
{
    public partial class NewCheckBox : ContentView
    {
        public event EventHandler<bool> CheckedChanged;

        public NewCheckBox()
        {
            InitializeComponent();
        }

        // Text property.
        public static readonly BindableProperty TextProperty = 
            BindableProperty.Create(
                "Text",
                typeof(string),
                typeof(NewCheckBox),
                null);

        public string Text
        {
            set { SetValue(TextProperty, value); }
            get { return (string)GetValue(TextProperty); }
        }

        // TextColor property.
        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(
                "TextColor",
                typeof(Color),
                typeof(NewCheckBox),
                Color.Default);

        public Color TextColor
        {
            set { SetValue(TextColorProperty, value); }
            get { return (Color)GetValue(TextColorProperty); }
        }

        // FontSize property.
        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create(
                "FontSize",
                typeof(double),
                typeof(NewCheckBox),
                Device.GetNamedSize(NamedSize.Default, typeof(Label)));

        [TypeConverter(typeof(FontSizeConverter))]
        public double FontSize
        {
            set { SetValue(FontSizeProperty, value); }
            get { return (double)GetValue(FontSizeProperty); }
        }

        // FontAttributes property.
        public static readonly BindableProperty FontAttributesProperty =
            BindableProperty.Create(
                "FontAttributes",
                typeof(FontAttributes),
                typeof(NewCheckBox),
                FontAttributes.None);

        public FontAttributes FontAttributes
        {
            set { SetValue(FontAttributesProperty, value); }
            get { return (FontAttributes)GetValue(FontAttributesProperty); }
        }

        // IsChecked property.
        public static readonly BindableProperty IsCheckedProperty =
            BindableProperty.Create(
                "IsChecked",
                typeof(bool),
                typeof(NewCheckBox),
                false,
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    // Fire the event.
                    NewCheckBox checkbox = (NewCheckBox)bindable;
                    checkbox.CheckedChanged?.Invoke(checkbox, (bool)newValue);
                });

        public bool IsChecked
        {
            set { SetValue(IsCheckedProperty, value); }
            get { return (bool)GetValue(IsCheckedProperty); }
        }

        // TapGestureRecognizer handler.
        void OnCheckBoxTapped(object sender, EventArgs args)
        {
            IsChecked = !IsChecked;
        }
    }
}

