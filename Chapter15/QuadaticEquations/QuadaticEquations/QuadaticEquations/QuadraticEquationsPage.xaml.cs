using System;
using Xamarin.Forms;

namespace QuadaticEquations
{
    public partial class QuadraticEquationsPage : ContentPage
    {
        public QuadraticEquationsPage()
        {
            InitializeComponent();

            // Initialize Entry views.
            entryA.Text = "1";
            entryB.Text = "-1";
            entryC.Text = "-1";
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            // Clear out solutions.
            solution1Label.Text = " ";
            solution2Label.Text = " ";

            // Color current entry text based on validity.
            Entry entry = (Entry)sender;
            double result;
            entry.TextColor = Double.TryParse(entry.Text, out result) ? Color.Default : Color.Red;

            // Enable the button based on validity.
            solveButton.IsEnabled = Double.TryParse(entryA.Text, out result) &&
                                    Double.TryParse(entryB.Text, out result) &&
                                    Double.TryParse(entryC.Text, out result);
        }

        void OnEntryCompleted(object sender, EventArgs args)
        {
            if (solveButton.IsEnabled)
            {
                Solve();
            }
        }

        void OnSolveButtonClicked(object sender, EventArgs args)
        {
            Solve();
        }

        void Solve()
        {
            double a = Double.Parse(entryA.Text);
            double b = Double.Parse(entryB.Text);
            double c = Double.Parse(entryC.Text);
            double solution1Real = 0;
            double solution1Imag = 0;
            double solution2Real = Double.NaN;
            double solution2Imag = 0;
            string str1 = " ";
            string str2 = " ";
            
            if (a == 0 && b == 0 && c == 0)
            {
                str1 = "x = anything";
            }
            else if (a == 0 && b == 0)
            {
                str1 = "x = nothing";
            }
            else
            {
                if (a == 0)
                {
                    solution1Real = -c / b;
                }
                else
                {
                    double discriminant = b * b - 4 * a * c;

                    if (discriminant == 0)
                    {
                        solution1Real = -b / (2 * a);
                    }
                    else if (discriminant > 0)
                    {
                        solution1Real = (-b + Math.Sqrt(discriminant)) / (2 * a);
                        solution2Real = (-b - Math.Sqrt(discriminant)) / (2 * a);
                    }
                    else
                    {
                        solution1Real = -b / (2 * a);
                        solution2Real = solution1Real;

                        solution1Imag = Math.Sqrt(-discriminant) / (2 * a);
                        solution2Imag = -solution1Imag;
                    }
                }
                str1 = Format(solution1Real, solution1Imag);
                str2 = Format(solution2Real, solution2Imag);
            }
            solution1Label.Text = str1;
            solution2Label.Text = str2;
        }

        string Format(double real, double imag)
        {
            string str = " ";

            if (!Double.IsNaN(real))
            {
                str = String.Format("x = {0:F5}", real);

                if (imag != 0)
                {
                    str += String.Format(" {0} {1:F5} i", 
                                         Math.Sign(imag) == 1 ? "+" : "\u2013", 
                                         Math.Abs(imag));
                }
            }
            return str;
        }
    }
}
