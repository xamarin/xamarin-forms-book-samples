using System;
using System.ComponentModel;
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

        void OnCountedLabelPropertyChanged(object sender, 
                                           PropertyChangedEventArgs args)
        {
            wordCountLabel.Text = countedLabel.WordCount + " words";
        }
    }
}
