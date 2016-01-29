using System;
using Xamarin.Forms;

namespace BaskervillesCount
{
    public partial class BaskervillesCountPage : ContentPage
    {
        public BaskervillesCountPage()
        {
            InitializeComponent();

            int wordCount = countedLabel.WordCount;
            wordCountLabel.Text = wordCount + " words";
        }
    }
}
