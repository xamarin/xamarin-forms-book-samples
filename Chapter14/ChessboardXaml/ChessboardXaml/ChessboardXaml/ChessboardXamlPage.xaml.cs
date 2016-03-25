using System;
using Xamarin.Forms;

namespace ChessboardXaml
{
    public partial class ChessboardXamlPage : ContentPage
    {
        public ChessboardXamlPage()
        {
            InitializeComponent();
        }

        void OnContentViewSizeChanged(object sender, EventArgs args)
        {
            ContentView contentView = (ContentView)sender;
            double boardSize = Math.Min(contentView.Width, contentView.Height);
            absoluteLayout.WidthRequest = boardSize;
            absoluteLayout.HeightRequest = boardSize;
        }
    }
}
