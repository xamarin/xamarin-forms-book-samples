using System;
using Xamarin.Forms;

namespace CheckBoxDemo
{
    public partial class CheckBoxDemoPage : ContentPage
    {
        public CheckBoxDemoPage()
        {
            // Ensure link to library.
            new Xamarin.FormsBook.Toolkit.CheckBox();

            InitializeComponent();
        }

        void OnItalicCheckBoxChanged(object sender, bool isChecked)
        {
            if (isChecked)
            {
                label.FontAttributes |= FontAttributes.Italic;
            }
            else
            {
                label.FontAttributes &= ~FontAttributes.Italic;
            }
        }

        void OnBoldCheckBoxChanged(object sender, bool isChecked)
        {
            if (isChecked)
            {
                label.FontAttributes |= FontAttributes.Bold;
            }
            else
            {
                label.FontAttributes &= ~FontAttributes.Bold;
            }
        }
    }
}
