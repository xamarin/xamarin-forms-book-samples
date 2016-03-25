using System;
using Xamarin.Forms;

namespace Xamarin.FormsBook.Toolkit
{
    public class FadeEnableAction : TriggerAction<VisualElement>
    {
        public FadeEnableAction()
        {
            Length = 500;
        }

        public bool Enable { set; get; }

        public int Length { set; get; }

        async protected override void Invoke(VisualElement view)
        {
            if (Enable)
            {
                // Transition to visible and enabled.
                view.IsVisible = true;
                view.Opacity = 0;
                await view.FadeTo(0.5, (uint)Length / 2);
                view.IsEnabled = true;
                await view.FadeTo(1, (uint)Length / 2);
            }
            else
            {
                // Transition to invisible and disabled.
                view.Opacity = 1;
                await view.FadeTo(0.5, (uint)Length / 2);
                view.IsEnabled = false;
                await view.FadeTo(0, (uint)Length / 2);
                view.IsVisible = false;
            }
        }
    }
}
