using System;
using Xamarin.Forms;

namespace ColorsDetails
{
    public partial class ColorDetailsPage : MasterDetailPage
    {
        public ColorDetailsPage()
        {
            InitializeComponent();

            IsGestureEnabled = false;

            // Special processing for iPads.
            if (Device.RuntimePlatform == Device.iOS &&
                Device.Idiom == TargetIdiom.Tablet)
            {
                SizeChanged += (sender, args) =>
                {
                    // Enable button for portrait mode.
                    returnButton.IsVisible = Height > Width;
                };
            }
        }

        public override bool ShouldShowToolbarButton()
        {
            // Only works for Windows and Windows Phone platforms.
            returnButton.IsVisible = base.ShouldShowToolbarButton();

            return false;
        }

        void OnListViewItemTapped(object sender, ItemTappedEventArgs args)
        {
            IsPresented = false;
        }

        void OnReturnButtonClicked(object sender, EventArgs args)
        {
            IsPresented = true;
        }
    }
}
