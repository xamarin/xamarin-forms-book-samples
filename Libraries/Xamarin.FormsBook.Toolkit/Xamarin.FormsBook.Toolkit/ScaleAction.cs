using System;
using Xamarin.Forms;

namespace Xamarin.FormsBook.Toolkit
{
    public class ScaleAction : TriggerAction<VisualElement>
    {
        public ScaleAction()
        {
            // Set defaults.
            Anchor = new Point (0.5, 0.5);
            Scale = 1;
            Length = 250;
            Easing = Easing.Linear;
        }

        public Point Anchor { set; get; } 

        public double Scale { set; get; }

        public int Length { set; get; }

        [TypeConverter(typeof(EasingConverter))]
        public Easing Easing { set; get; }

        protected override void Invoke(VisualElement visual)
        {
            visual.AnchorX = Anchor.X;
            visual.AnchorY = Anchor.Y;
            visual.ScaleTo(Scale, (uint)Length, Easing);
        }
    }
}
