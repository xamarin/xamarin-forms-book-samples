using System;
using Xamarin.Forms;

namespace Xamarin.FormsBook.Toolkit
{
    public class RotateAction : TriggerAction<VisualElement>
    {
        public RotateAction()
        {
            // Set defaults.
            Anchor = new Point (0.5, 0.5);
            Rotation = 0;
            Length = 250;
            Easing = Easing.Linear;
        }

        public Point Anchor { set; get; } 

        public double Rotation { set; get; }

        public int Length { set; get; }

        [TypeConverter(typeof(EasingConverter))]
        public Easing Easing { set; get; }

        protected override void Invoke(VisualElement visual)
        {
            visual.AnchorX = Anchor.X;
            visual.AnchorY = Anchor.Y;
            visual.RotateTo(Rotation, (uint)Length, Easing);
        }
    }
}
