using System;
using Xamarin.Forms;

namespace Xamarin.FormsBook.Toolkit
{
    public class ScaleUpAndDownAction : TriggerAction<VisualElement>
    {
        public ScaleUpAndDownAction()
        {
            Anchor = new Point(0.5, 0.5);
            Scale = 2;
            Length = 500;
        }

        public Point Anchor { set; get; }

        public double Scale { set; get; }

        public int Length { set; get; }

        protected override async void Invoke(VisualElement visual)
        {
            visual.AnchorX = Anchor.X;
            visual.AnchorY = Anchor.Y;
            await visual.ScaleTo(Scale, (uint)Length / 2, Easing.SinOut);
            await visual.ScaleTo(1, (uint)Length / 2, Easing.SinIn);
        }
    }
}
