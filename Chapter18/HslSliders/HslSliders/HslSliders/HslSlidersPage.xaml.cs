using System;
using Xamarin.Forms;

namespace HslSliders
{
    public partial class HslSlidersPage : ContentPage
    {
        public HslSlidersPage()
        {
            InitializeComponent();
        }

        void OnPageSizeChanged(object sender, EventArgs args)
        {
            // Portrait mode.
            if (Width < Height)
            {
                mainGrid.RowDefinitions[1].Height = GridLength.Auto;
                mainGrid.ColumnDefinitions[1].Width = new GridLength(0, GridUnitType.Absolute);

                Grid.SetRow(controlPanelStack, 1);
                Grid.SetColumn(controlPanelStack, 0);
            }
            // Landscape mode.
            else
            {
                mainGrid.RowDefinitions[1].Height = new GridLength(0, GridUnitType.Absolute);
                mainGrid.ColumnDefinitions[1].Width = new GridLength(1, GridUnitType.Star);

                Grid.SetRow(controlPanelStack, 0);
                Grid.SetColumn(controlPanelStack, 1);
            }
        }
    }
}


