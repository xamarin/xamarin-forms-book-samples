using System;
using Xamarin.Forms;

namespace Xamarin.FormsBook.Toolkit
{
    public class TranslateAction : TriggerAction<VisualElement>
    {
        public TranslateAction()
        {
            // Set defaults.
            Length = 250;
            Easing = Easing.Linear;
        }

        public double X { set; get; }

        public double Y { set; get; }

        public int Length { set; get; }

        [TypeConverter(typeof(EasingConverter))]
        public Easing Easing { set; get; }

        protected override void Invoke(VisualElement visual)
        {
            visual.TranslateXYTo(X, Y, (uint)Length, Easing);
        }
    }
}
