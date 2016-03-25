using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.FormsBook.Toolkit;

namespace MandelbrotProgress
{
    public partial class MandelbrotProgressPage : ContentPage
    {
        static readonly Complex center = new Complex(-0.75, 0);
        static readonly Size size = new Size(2.5, 2.5);
        const int pixelWidth = 1000;
        const int pixelHeight = 1000;
        const int iterations = 100;

        Progress<double> progressReporter;

        public MandelbrotProgressPage()
        {
            InitializeComponent();

            progressReporter = new Progress<double>((double value) =>
                {
                    progressBar.Progress = value;
                });
        }

        async void OnCalculateButtonClicked(object sender, EventArgs args)
        {
            // Configure the UI for a background process.
            calculateButton.IsEnabled = false;

            // Render the Mandelbrot set on a bitmap.
            BmpMaker bmpMaker = await CalculateMandelbrotAsync(progressReporter);
            image.Source = bmpMaker.Generate();
        }

        Task<BmpMaker> CalculateMandelbrotAsync(IProgress<double> progress)
        {
            return Task.Run<BmpMaker>(() =>
            {
                BmpMaker bmpMaker = new BmpMaker(pixelWidth, pixelHeight);

                for (int row = 0; row < pixelHeight; row++)
                {
                    double y = center.Imaginary - size.Height / 2 + row * size.Height / pixelHeight;

                    // Report the progress.
                    progress.Report((double)row / pixelHeight);

                    for (int col = 0; col < pixelWidth; col++)
                    {
                        double x = center.Real - size.Width / 2 + col * size.Width / pixelWidth;
                        Complex c = new Complex(x, y);
                        Complex z = 0;
                        int iteration = 0;
                        bool isMandelbrotSet = false;

                        if ((c - new Complex(-1, 0)).MagnitudeSquared < 1.0 / 16)
                        {
                            isMandelbrotSet = true;
                        }
                        else
                        {
                            do
                            {
                                z = z * z + c;
                                iteration++;
                            }
                            while (iteration < iterations && z.MagnitudeSquared < 4);

                            isMandelbrotSet = iteration == iterations;
                        }
                        bmpMaker.SetPixel(row, col, isMandelbrotSet ? Color.Black : Color.White);
                    }
                }
                return bmpMaker;
            });
        }
    }
}

