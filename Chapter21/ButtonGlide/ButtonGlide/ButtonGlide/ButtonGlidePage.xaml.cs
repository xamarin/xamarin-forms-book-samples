using System;
using Xamarin.Forms;

namespace ButtonGlide
{
    public partial class ButtonGlidePage : ContentPage
    {
        static readonly TimeSpan duration = TimeSpan.FromSeconds(1);
        Random random = new Random();
        Point startPoint;
        Point animationVector;
        DateTime startTime;

        public ButtonGlidePage()
        {
            InitializeComponent();

            Device.StartTimer(TimeSpan.FromMilliseconds(16), OnTimerTick);
        }

        void OnButtonClicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            View container = (View)button.Parent;

            // The start of the animation is the current Translation properties.
            startPoint = new Point(button.TranslationX, button.TranslationY);
            
            // The end of the animation is a random point.
            double endX = (random.NextDouble() - 0.5) * (container.Width - button.Width);
            double endY = (random.NextDouble() - 0.5) * (container.Height - button.Height);

            // Create a vector from start point to end point.
            animationVector = new Point(endX - startPoint.X, endY - startPoint.Y);

            // Save the animation start time.
            startTime = DateTime.Now;
        }

        bool OnTimerTick()
        {
            // Get the elapsed time from the beginning of the animation.
            TimeSpan elapsedTime = DateTime.Now - startTime;

            // Normalize the elapsed time from 0 to 1.
            double t = Math.Max(0, Math.Min(1, elapsedTime.TotalMilliseconds / 
                                                    duration.TotalMilliseconds));

            // Calculate the new translation based on the animation vector.
            button.TranslationX = startPoint.X + t * animationVector.X;
            button.TranslationY = startPoint.Y + t * animationVector.Y;
            return true;
        }
    }
}
