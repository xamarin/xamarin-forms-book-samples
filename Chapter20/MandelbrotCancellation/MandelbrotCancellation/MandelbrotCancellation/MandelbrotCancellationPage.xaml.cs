using System;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.FormsBook.Toolkit;

namespace MandelbrotCancellation
{
    public partial class MandelbrotCancellationPage : ContentPage
    {
        static readonly Complex center = new Complex(-0.75, 0);
        static readonly Size size = new Size(2.5, 2.5);
        const int pixelWidth = 1000;
        const int pixelHeight = 1000;
        const int iterations = 100;

        Progress<double> progressReporter;
        CancellationTokenSource cancelTokenSource;

        public MandelbrotCancellationPage()
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
            cancelButton.IsEnabled = true;

            cancelTokenSource = new CancellationTokenSource();

            try
            {
                // Render the Mandelbrot set on a bitmap.
                BmpMaker bmpMaker = await CalculateMandelbrotAsync(progressReporter, 
                                                                   cancelTokenSource.Token);
                image.Source = bmpMaker.Generate();
            }
            catch (OperationCanceledException)
            {
                calculateButton.IsEnabled = true;
                progressBar.Progress = 0;
            }
            catch (Exception)
            {
                // Shouldn't occur in this case.
            }

            cancelButton.IsEnabled = false;
        }

        void OnCancelButtonClicked(object sender, EventArgs args)
        {
            cancelTokenSource.Cancel();
        }

        Task<BmpMaker> CalculateMandelbrotAsync(IProgress<double> progress, 
                                                CancellationToken cancelToken)
        {
            return Task.Run<BmpMaker>(() =>
            {
                BmpMaker bmpMaker = new BmpMaker(pixelWidth, pixelHeight);

                for (int row = 0; row < pixelHeight; row++)
                {
                    double y = center.Imaginary - size.Height / 2 + row * size.Height / pixelHeight;

                    // Report the progress.
                    progress.Report((double)row / pixelHeight);

                    // Possibly cancel.
                    cancelToken.ThrowIfCancellationRequested();

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
                        // http://www.reenigne.org/blog/algorithm-for-mandelbrot-cardioid/
                        else if (c.MagnitudeSquared * (8 * c.MagnitudeSquared - 3) < 
                                                                       3.0 / 32 - c.Real)
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
            }, cancelToken);
        }
    }
}


