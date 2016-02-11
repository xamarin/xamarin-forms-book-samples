using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PalindromeAnimation
{
    public partial class PalindromeAnimationPage : ContentPage
    {
        string text = "NEVER ODD OR EVEN";
        double[] anchorX = { 0.5, 0.5, 0.5, 0.5, 1, 0,
                             0.5, 1, 1, -1,
                             0.5, 1, 0,
                             0.5, 0.5, 0.5, 0.5 };

        public PalindromeAnimationPage()
        {
            InitializeComponent();

            // Add a Label to the StackLayout for each character.
            for (int i = 0; i < text.Length; i++)
            {
                Label label = new Label
                {
                    Text = text[i].ToString(),
                    HorizontalTextAlignment = TextAlignment.Center
                };
                stackLayout.Children.Add(label);
            }

            // Start the animation.
            AnimationLoop();
        }

        void OnPageSizeChanged(object sender, EventArgs args)
        {
            // Adjust the size and font based on the display width.
            double width = 0.8 * this.Width / stackLayout.Children.Count;

            foreach (Label label in stackLayout.Children.OfType<Label>())
            {
                label.FontSize = 1.4 * width;
                label.WidthRequest = width;
            }
        }

        async void AnimationLoop()
        {
            bool backwards = false;

            while (true)
            {
                // Let's just sit here a second.
                await Task.Delay(1000);

                // Prepare for overlapping rotations.
                Label previousLabel = null;

                // Loop through all the labels.
                IEnumerable<Label> labels = stackLayout.Children.OfType<Label>();

                foreach (Label label in backwards ? labels.Reverse() : labels)
                {
                    uint flipTime = 250;

                    // Set the AnchorX and AnchorY properties.
                    int index = stackLayout.Children.IndexOf(label);
                    label.AnchorX = anchorX[index];
                    label.AnchorY = 1;

                    if (previousLabel == null)
                    {
                        // For the first Label in the sequence, rotate it 90 degrees.
                        await label.RelRotateTo(90, flipTime / 2);
                    }
                    else
                    {
                        // For the second and subsequent, also finish the previous flip.
                        await Task.WhenAll(label.RelRotateTo(90, flipTime / 2),
                                           previousLabel.RelRotateTo(90, flipTime / 2));
                    }

                    // If it's the last one, finish the flip.
                    if (label == (backwards ? labels.First() : labels.Last()))
                    {
                        await label.RelRotateTo(90, flipTime / 2);
                    }

                    previousLabel = label;
                }

                // Rotate the entire stack.
                stackLayout.AnchorY = 1; 
                await stackLayout.RelRotateTo(180, 1000);

                // Flip the backwards flag.
                backwards ^= true;
            }
        }
    }
}
