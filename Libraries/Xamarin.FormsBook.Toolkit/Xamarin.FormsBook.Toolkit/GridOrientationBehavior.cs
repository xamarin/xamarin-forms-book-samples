using System;
using Xamarin.Forms;

namespace Xamarin.FormsBook.Toolkit
{
    // Assumes Grid with two children without any 
    //      row or column definitions set.
    public class GridOrientationBehavior : Behavior<Grid>
    {
        protected override void OnAttachedTo(Grid grid)
        {
            base.OnAttachedTo(grid);

            // Add row and column definitions.
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());

            grid.SizeChanged += OnGridSizeChanged;
        }
        protected override void OnDetachingFrom(Grid grid)
        {
            base.OnDetachingFrom(grid);
            grid.SizeChanged -= OnGridSizeChanged;
        }

        private void OnGridSizeChanged(object sender, EventArgs args)
        {
            Grid grid = (Grid)sender;

            if (grid.Width <= 0 || grid.Height <= 0)
                return;

            // Portrait mode
            if (grid.Height > grid.Width)
            {
                // Set row definitions.
                grid.RowDefinitions[0].Height = new GridLength(1, GridUnitType.Star);
                grid.RowDefinitions[1].Height = GridLength.Auto;

                // Set column definitions.
                grid.ColumnDefinitions[0].Width = new GridLength(1, GridUnitType.Star);
                grid.ColumnDefinitions[1].Width = new GridLength(0);

                //Position first child.
                Grid.SetRow(grid.Children[0], 0);
                Grid.SetColumn(grid.Children[0], 0);

                // Position second child.
                Grid.SetRow(grid.Children[1], 1);
                Grid.SetColumn(grid.Children[1], 0);
            }
            // Landscape mode
            else
            {
                // Set row definitions.
                grid.RowDefinitions[0].Height = new GridLength(1, GridUnitType.Star);
                grid.RowDefinitions[1].Height = new GridLength(0);

                // Set column definitions.
                grid.ColumnDefinitions[0].Width = new GridLength(1, GridUnitType.Star);
                grid.ColumnDefinitions[1].Width = new GridLength(1, GridUnitType.Star);

                //Position first child.
                Grid.SetRow(grid.Children[0], 0);
                Grid.SetColumn(grid.Children[0], 0);

                // Position second child.
                Grid.SetRow(grid.Children[1], 0);
                Grid.SetColumn(grid.Children[1], 1);
            }
        }
    }
}
