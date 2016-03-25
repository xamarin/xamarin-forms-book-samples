using System;
using Xamarin.Forms;

namespace SchoolAndDetail
{
    public partial class SchoolAndDetailPage : MasterDetailPage
    {
        public SchoolAndDetailPage()
        {
            InitializeComponent();
        }

        void OnListViewItemTapped(object sender, ItemTappedEventArgs args)
        {
            // Show the detail page.
            IsPresented = false;
        }
    }
}
