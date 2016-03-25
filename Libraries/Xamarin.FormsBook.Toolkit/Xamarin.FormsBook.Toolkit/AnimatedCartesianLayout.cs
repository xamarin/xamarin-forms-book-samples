using System;
using Xamarin.Forms;

namespace Xamarin.FormsBook.Toolkit
{
    public class AnimatedCartesianLayout : CartesianLayout
    {
        public static readonly BindableProperty AnimationDurationProperty =
            BindableProperty.Create(
                "AnimatedDuration",
                typeof(int),
                typeof(AnimatedCartesianLayout),
                1000);

        public int AnimationDuration
        {
            set { SetValue(AnimationDurationProperty, value); }
            get { return (int)GetValue(AnimationDurationProperty); }
        }

        public static readonly BindableProperty AnimateRotationProperty =
            BindableProperty.Create(
                "AnimateRotation",
                typeof(bool),
                typeof(AnimatedCartesianLayout),
                true);

        public bool AnimateRotation
        {
            set { SetValue(AnimateRotationProperty, value); }
            get { return (bool)GetValue(AnimateRotationProperty); }
        }

        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            foreach (View child in Children)
            {
                if (!child.IsVisible)
                    continue;

                double angle;
                Rectangle bounds = GetChildBounds(child, x, y, width, height, out angle);

                // Lay out the child.
                if (child.Bounds.Equals(new Rectangle(0, 0, -1, -1)))
                {
                    child.Layout(new Rectangle(x + width / 2, y + height / 2, 0, 0));
                }
                child.LayoutTo(bounds, (uint)AnimationDuration);

                // Rotate the child.
                if (AnimateRotation)
                {
                    child.RotateTo(angle, (uint)AnimationDuration);
                }
                else
                {
                    child.Rotation = angle;
                }
            }
        }
    }
}
