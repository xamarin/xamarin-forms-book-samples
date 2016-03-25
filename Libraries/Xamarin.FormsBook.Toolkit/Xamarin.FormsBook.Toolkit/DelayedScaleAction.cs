using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xamarin.FormsBook.Toolkit
{
    public class DelayedScaleAction : ScaleAction
    {
        public DelayedScaleAction() : base()
        {
            // Set defaults.
            Delay = 0;
        }

        public int Delay { set; get; }

        async protected override void Invoke(VisualElement visual)
        {
            visual.AnchorX = Anchor.X;
            visual.AnchorY = Anchor.Y;
            await Task.Delay(Delay);
            await visual.ScaleTo(Scale, (uint)Length, Easing);
        }
    }
}
