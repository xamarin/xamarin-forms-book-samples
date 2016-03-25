using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace VerticalStackDemo
{
    public partial class VerticalStackDemoHomePage : ContentPage
    {
        public VerticalStackDemoHomePage()
        {
            InitializeComponent();
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            ((ListView)sender).SelectedItem = null;

            if (args.SelectedItem != null)
            {
                Page page = (Page)args.SelectedItem;
                await Navigation.PushAsync(page);
            }
        }
    }
}
