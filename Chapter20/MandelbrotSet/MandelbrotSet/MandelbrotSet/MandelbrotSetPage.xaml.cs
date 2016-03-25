using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.FormsBook.Toolkit;

namespace MandelbrotSet
{
    public partial class MandelbrotSetPage : ContentPage
    {
        static readonly Complex center = new Complex(-0.75, 0);
        static readonly Size size = new Size(2.5, 2.5);
        const int pixelWidth = 1000;
        const int pixelHeight = 1000;
        const int iterations = 100;

        public MandelbrotSetPage()
        {
            InitializeComponent();
        }

        async void OnCalculateButtonClicked(object sender, EventArgs args)
        {
            // Configure the UI for a background process.
            calculateButton.IsEnabled = false;
            activityIndicator.IsRunning = true;

            // Render the Mandelbrot set on a bitmap.
            BmpMaker bmpMaker = new BmpMaker(pixelWidth, pixelHeight);
            await CalculateMandelbrotAsync(bmpMaker);
            image.Source = bmpMaker.Generate();

            // Configure the UI for the completed background process.
            activityIndicator.IsRunning = false;
        }

        Task CalculateMandelbrotAsync(BmpMaker bmpMaker)
        {
            return Task.Run(() =>
            {
                for (int row = 0; row < pixelHeight; row++)
                {
                    double y = center.Imaginary - size.Height / 2 + row * size.Height / pixelHeight;

                    for (int col = 0; col < pixelWidth; col++)
                    {
                        double x = center.Real - size.Width / 2 + col * size.Width / pixelWidth;
                        Complex c = new Complex(x, y);
                        Complex z = 0;
                        int iteration = 0;

                        do
                        {
                            z = z * z + c;
                            iteration++;
                        }
                        while (iteration < iterations && z.MagnitudeSquared < 4);

                        bool isMandelbrotSet = iteration == iterations;
                        bmpMaker.SetPixel(row, col, isMandelbrotSet ? Color.Black : Color.White);
                    }
                }
            });
        }
    }
}
