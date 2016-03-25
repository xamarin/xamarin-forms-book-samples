using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.FormsBook.Toolkit;

namespace BouncingBall
{
    public partial class BouncingBallPage : ContentPage
    {
        public BouncingBallPage()
        {
            InitializeComponent();

            // Color animation: cycle through rainbow every 10 seconds.
            new Animation(callback: v => ball.Color = Color.FromHsla(v, 1, 0.5),
                          start: 0,
                          end: 1
                          ).Commit(owner: this,
                                   name: "ColorAnimation",
                                   length: 10000,
                                   repeat: () => true);

            BounceAnimationLoop();
        }

        async void BounceAnimationLoop()
        {
            // Wait until the dimensions are good.
            while (Width == -1 && Height == -1)
            {
                await Task.Delay(100);
            }

            // Initialize points and vectors.
            Point center = new Point();
            Random rand = new Random();
            Vector2 vector = new Vector2(rand.NextDouble(), rand.NextDouble());
            vector = vector.Normalized;
            Vector2[] walls = { new Vector2(1, 0), new Vector2(0, 1),       // left, top
                                new Vector2(-1, 0), new Vector2(0, -1) };   // right, bottom

            while (true)
            {
                // The locations of the four "walls" (taking ball size into account).
                double right = Width / 2 - ball.Width / 2;
                double left = -right;
                double bottom = Height / 2 - ball.Height / 2;
                double top = -bottom;

                // Find the number of steps till a wall is hit.
                double nX = Math.Abs(((vector.X > 0 ? right : left) - center.X) / vector.X);
                double nY = Math.Abs(((vector.Y > 0 ? bottom : top) - center.Y) / vector.Y);
                double n = Math.Min(nX, nY);

                // Find the wall that's being hit.
                Vector2 wall = walls[nX < nY ? (vector.X > 0 ? 2 : 0) : (vector.Y > 0 ? 3 : 1)]; 

                // New center and vector after animation.
                center += n * vector;
                vector -= 2 * Vector2.DotProduct(vector, wall) * wall;

                // Animate at 3 msec per unit.
                await ball.TranslateTo(center.X, center.Y, (uint)(3 * n));
            }
        }
    }
}
