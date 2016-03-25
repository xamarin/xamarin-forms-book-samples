using System;
using Xamarin.Forms;

namespace MasterDetailTaps
{
    public partial class MasterDetailTapsPage : MasterDetailPage
    {
        public MasterDetailTapsPage()
        {
            InitializeComponent();

            // Disable swipe interface.
            IsGestureEnabled = false;
        }

        public override bool ShouldShowToolbarButton()
        {
            // Hide toolbar button on Windows platforms.
            return false;
        }

        void OnMasterTapped(object sender, EventArgs args)
        {
            // Catch exceptions when setting IsPresented in split mode.
            try 
            {
                IsPresented = false;
            }
            catch
            {
            }
        }

        void OnDetailTapped(object sender, EventArgs args)
        {
            IsPresented = true;
        }
    }
}

