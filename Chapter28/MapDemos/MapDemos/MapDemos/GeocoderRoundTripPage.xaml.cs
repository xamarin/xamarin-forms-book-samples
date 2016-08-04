using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MapDemos
{
    public partial class GeocoderRoundTripPage : ContentPage
    {
        Geocoder geocoder = new Geocoder();

        public GeocoderRoundTripPage()
        {
            InitializeComponent();
        }

        async void OnSearchButtonPressed(object sender, EventArgs args)
        {
            string address = ((SearchBar)sender).Text;
            IEnumerable<Position> positions = await geocoder.GetPositionsForAddressAsync(address);
            positionsListView.ItemsSource = positions;

            // And clear out the list of addresses.
            addressesStack.Children.Clear();
        }

        async void OnPositionItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            Position position = (Position)args.SelectedItem;
            IEnumerable<string> addresses = await geocoder.GetAddressesForPositionAsync(position);

            addressesStack.Children.Clear();

            foreach (string address in addresses)
            {
                addressesStack.Children.Add(
                    new Label
                    {
                        Text = address
                    });
                addressesStack.Children.Add(
                    new BoxView
                    {
                        HeightRequest = 3,
                        Color = Color.Accent
                    });
            }
        }
    }
}
