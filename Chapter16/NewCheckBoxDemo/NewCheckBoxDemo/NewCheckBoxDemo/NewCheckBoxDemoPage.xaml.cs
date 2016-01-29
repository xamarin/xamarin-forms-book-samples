using System;
using Xamarin.Forms;

namespace NewCheckBoxDemo
{
    public partial class NewCheckBoxDemoPage : ContentPage
    {
        public NewCheckBoxDemoPage()
        {
            // Ensure link to Toolkit library.
            new Xamarin.FormsBook.Toolkit.NewCheckBox();

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
