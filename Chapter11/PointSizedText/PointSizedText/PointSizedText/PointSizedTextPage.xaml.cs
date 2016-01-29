using System;
using Xamarin.Forms;

namespace PointSizedText
{
    public partial class PointSizedTextPage : ContentPage
    {
        public PointSizedTextPage()
        {
            // Instantiate sometehing in library so it can be used in XAML.
            var unused = new Xamarin.FormsBook.Toolkit.AltLabel();

            InitializeComponent();
        }
    }
}
