using System;
using Xamarin.Forms;
using Xamarin.FormsBook.Toolkit;

namespace DiyGradientBitmap
{
    public partial class DiyGradientBitmapPage : ContentPage
    {
        public DiyGradientBitmapPage()
        {
            InitializeComponent();

            int rows = 128;
            int cols = 64;
            BmpMaker bmpMaker = new BmpMaker(cols, rows);

            for (int row = 0; row < rows; row++)
                for (int col = 0; col < cols; col++)
                {
                    bmpMaker.SetPixel(row, col, 2 * row, 0, 2 * (128 - row));
                }

            ImageSource imageSource = bmpMaker.Generate();
            image.Source = imageSource;
        }
    }
}
