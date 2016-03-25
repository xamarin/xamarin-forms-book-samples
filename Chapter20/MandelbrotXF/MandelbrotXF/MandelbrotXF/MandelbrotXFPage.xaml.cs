using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.FormsBook.Toolkit;

namespace MandelbrotXF
{
    public partial class MandelbrotXFPage : ContentPage
    {
        MandelbrotViewModel mandelbrotViewModel;
        double pixelsPerUnit = 1;

        public MandelbrotXFPage()
        {
            InitializeComponent();

            // Instantiate ViewModel and get saved values.
            mandelbrotViewModel = new MandelbrotViewModel(2.5, 2.5)
            {
                PixelWidth = 1000,
                PixelHeight = 1000,
                CurrentCenter = new Complex(GetProperty("CenterReal", -0.75),
                                            GetProperty("CenterImaginary", 0.0)),
                CurrentMagnification = GetProperty("Magnification", 1.0),
                TargetMagnification = GetProperty("Magnification", 1.0),
                Iterations = GetProperty("Iterations", 8),
                RealOffset = 0.5,
                ImaginaryOffset = 0.5
            };

            // Set BindingContext on page.
            BindingContext = mandelbrotViewModel;

            // Set PropertyChanged handler on ViewModel for "manual" processing.
            mandelbrotViewModel.PropertyChanged += OnMandelbrotViewModelPropertyChanged;

            // Create test image to obtain pixels per device-independent unit.
            BmpMaker bmpMaker = new BmpMaker(120, 120);

            testImage.SizeChanged += (sender, args) =>
                {
                    pixelsPerUnit = bmpMaker.Width / testImage.Width;
                    SetPixelWidthAndHeight();
                };
            testImage.Source = bmpMaker.Generate();

            // Gradually reduce opacity of cross-hairs.
            Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
                {
                    realCrossHair.Opacity -= 0.01;
                    imagCrossHair.Opacity -= 0.01;
                    return true;
                });
        }

        // Method for accessing Properties dictionary if key is not yet present.
        T GetProperty<T>(string key, T defaultValue)
        {
            IDictionary<string, object> properties = Application.Current.Properties;

            if (properties.ContainsKey(key))
            {
                return (T)properties[key];
            }
            return defaultValue;
        }

        // Switch between portrait and landscape mode.
        void OnPageSizeChanged(object sender, EventArgs args)
        {
            if (Width == -1 || Height == -1)
                return;

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

        void OnImageSizeChanged(object sender, EventArgs args)
        {
            // Assure that cross-hair layout is same size as Image.
            double size = Math.Min(image.Width, image.Height);
            crossHairLayout.WidthRequest = size;
            crossHairLayout.HeightRequest = size;

            // Calculate the pixel size of the Image element.
            SetPixelWidthAndHeight();
        }

        // Sets the Mandelbrot bitmap to optimum pixel width and height.
        void SetPixelWidthAndHeight()
        {
            int pixels = (int)(pixelsPerUnit * Math.Min(image.Width, image.Height));
            mandelbrotViewModel.PixelWidth = pixels;
            mandelbrotViewModel.PixelHeight = pixels;
        }


        // Redraw cross hairs if the cross-hair layout changes size.
        void OnCrossHairLayoutSizeChanged(object sender, EventArgs args)
        {
            SetCrossHairs();
        }

        async void OnMandelbrotViewModelPropertyChanged(object sender, 
                                                        PropertyChangedEventArgs args)
        {
            // Set opacity back to 1.
            realCrossHair.Opacity = 1;
            imagCrossHair.Opacity = 1;

            switch (args.PropertyName)
            {
                case "RealOffset":
                case "ImaginaryOffset":
                case "CurrentMagnification":
                case "TargetMagnification":
                    // Redraw cross-hairs if these properties change
                    SetCrossHairs();
                    break;

                case "BitmapInfo":
                    // Create bitmap based on the iteration counts.
                    DisplayNewBitmap(mandelbrotViewModel.BitmapInfo);

                    // Save properties for the next time program is run.
                    IDictionary<string, object> properties = Application.Current.Properties;
                    properties["CenterReal"] = mandelbrotViewModel.TargetCenter.Real;
                    properties["CenterImaginary"] = mandelbrotViewModel.TargetCenter.Imaginary;
                    properties["Magnification"] = mandelbrotViewModel.TargetMagnification;
                    properties["Iterations"] = mandelbrotViewModel.Iterations;
                    await Application.Current.SavePropertiesAsync();
                    break;
            }
        }

        void SetCrossHairs()
        {
            // Size of the layout for the crosshairs and zoom box.
            Size layoutSize = new Size(crossHairLayout.Width, crossHairLayout.Height);

            // Fractional position of center of crosshair.
            double xCenter = mandelbrotViewModel.RealOffset; 
            double yCenter = 1 - mandelbrotViewModel.ImaginaryOffset; 

            // Calculate dimension of zoom box.
            double boxSize = mandelbrotViewModel.CurrentMagnification / 
                             mandelbrotViewModel.TargetMagnification;

            // Fractional positions of zoom box corners.
            double xLeft = xCenter - boxSize / 2;
            double xRight = xCenter + boxSize / 2;
            double yTop = yCenter - boxSize / 2;
            double yBottom = yCenter + boxSize / 2;

            // Set all the layout bounds.
            SetLayoutBounds(realCrossHair, 
                            new Rectangle(xCenter, yTop, 0, boxSize), 
                            layoutSize);
            SetLayoutBounds(imagCrossHair, 
                            new Rectangle(xLeft, yCenter, boxSize, 0), 
                            layoutSize);
            SetLayoutBounds(topBox, new Rectangle(xLeft, yTop, boxSize, 0), layoutSize);
            SetLayoutBounds(bottomBox, new Rectangle(xLeft, yBottom, boxSize, 0), layoutSize);
            SetLayoutBounds(leftBox, new Rectangle(xLeft, yTop, 0, boxSize), layoutSize);
            SetLayoutBounds(rightBox, new Rectangle(xRight, yTop, 0, boxSize), layoutSize);
        }

        void SetLayoutBounds(View view, Rectangle fractionalRect, Size layoutSize)
        {
            if (layoutSize.Width == -1 || layoutSize.Height == -1)
            {
                AbsoluteLayout.SetLayoutBounds(view, new Rectangle());
                return;
            }

            const double thickness = 1;
            Rectangle absoluteRect = new Rectangle();

            // Horizontal lines.
            if (fractionalRect.Height == 0 && fractionalRect.Y > 0 && fractionalRect.Y < 1)
            {
                double xLeft = Math.Max(0, fractionalRect.Left);
                double xRight = Math.Min(1, fractionalRect.Right);
                absoluteRect = new Rectangle(layoutSize.Width * xLeft,
                                             layoutSize.Height * fractionalRect.Y,
                                             layoutSize.Width * (xRight - xLeft),
                                             thickness);
            }
            // Vertical lines.
            else if (fractionalRect.Width == 0 && fractionalRect.X > 0 && fractionalRect.X < 1)
            {
                double yTop = Math.Max(0, fractionalRect.Top);
                double yBottom = Math.Min(1, fractionalRect.Bottom);
                absoluteRect = new Rectangle(layoutSize.Width * fractionalRect.X,
                                             layoutSize.Height * yTop,
                                             thickness,
                                             layoutSize.Height * (yBottom - yTop));
            }
            AbsoluteLayout.SetLayoutBounds(view, absoluteRect);
        }

        void DisplayNewBitmap(BitmapInfo bitmapInfo)
        {
            // Create the bitmap.
            BmpMaker bmpMaker = new BmpMaker(bitmapInfo.PixelWidth, bitmapInfo.PixelHeight);

            // Set the colors.
            int index = 0;
            for (int row = 0; row < bitmapInfo.PixelHeight; row++)
            {
                for (int col = 0; col < bitmapInfo.PixelWidth; col++)
                {
                    int iterationCount = bitmapInfo.IterationCounts[index++];

                    // In the Mandelbrot set: Color black.
                    if (iterationCount == -1)
                    {
                        bmpMaker.SetPixel(row, col, 0, 0, 0);
                    }
                    // Not in the Mandelbrot set: Pick a color based on count.
                    else
                    {
                        double proportion = (iterationCount / 32.0) % 1;

                        if (proportion < 0.5)
                        {
                            bmpMaker.SetPixel(row, col, (int)(255 * (1 - 2 * proportion)),
                                                        0,
                                                        (int)(255 * 2 * proportion));
                        }
                        else
                        {
                            proportion = 2 * (proportion - 0.5);
                            bmpMaker.SetPixel(row, col, 0,
                                                        (int)(255 * proportion),
                                                        (int)(255 * (1 - proportion)));
                        }
                    }
                }
            }
            image.Source = bmpMaker.Generate();
        }
    }
}
