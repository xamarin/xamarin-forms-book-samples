using System;
using Xamarin.Forms;

namespace WebViewDemo
{
    public partial class WebViewDemoPage : ContentPage
    {
        public WebViewDemoPage()
        {
            InitializeComponent();
        }

        void OnEntryCompleted(object sender, EventArgs args)
        {
            webView.Source = ((Entry)sender).Text;
        }

        void OnGoBackClicked(object sender, EventArgs args)
        {
            webView.GoBack();
        }

        void OnGoForwardClicked(object sender, EventArgs args)
        {
            webView.GoForward();
        }
    }
}
