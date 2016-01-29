using System;
using Xamarin.Forms;

namespace Xamarin.FormsBook.Toolkit
{
    public class ShiverAction : TriggerAction<VisualElement>
    {
        public ShiverAction()
        {
            Length = 1000;
            Angle = 15;
            Vibrations = 10;
        }

        public int Length { set; get; }

        public double Angle { set; get; }

        public int Vibrations { set; get; }

        protected override void Invoke(VisualElement visual)
        {
            visual.AnchorX = 0.5;
            visual.AnchorY = 0.5;
            visual.Rotation = 0;
            visual.RotateTo(Angle, (uint)Length,
                new Easing(t => Math.Sin(Math.PI * t) *
                                Math.Sin(Math.PI * 2 * Vibrations * t)));
        }
    }
}
