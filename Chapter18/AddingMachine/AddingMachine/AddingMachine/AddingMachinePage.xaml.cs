using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.FormsBook.Toolkit;

namespace AddingMachine
{
    public partial class AddingMachinePage : ContentPage
    {
        public AddingMachinePage(AdderViewModel viewModel)
        {
            InitializeComponent();

            // Set ViewModel as BindingContext.
            BindingContext = viewModel;
        }

        void OnPageSizeChanged(object sender, EventArgs args)
        {
            // Portrait mode.
            if (Width < Height)
            {
                mainGrid.RowDefinitions[1].Height = GridLength.Auto;
                mainGrid.ColumnDefinitions[1].Width = new GridLength(0, GridUnitType.Absolute);

                Grid.SetRow(keypadGrid, 1);
                Grid.SetColumn(keypadGrid, 0);
            }
            // Landscape mode.
            else
            {
                mainGrid.RowDefinitions[1].Height = new GridLength(0, GridUnitType.Absolute);
                mainGrid.ColumnDefinitions[1].Width = GridLength.Auto;

                Grid.SetRow(keypadGrid, 0);
                Grid.SetColumn(keypadGrid, 1);
            }
        }
    }
}
