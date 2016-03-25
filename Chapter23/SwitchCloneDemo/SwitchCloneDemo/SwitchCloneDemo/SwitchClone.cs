using System;
using Xamarin.Forms;
using Xamarin.FormsBook.Toolkit;

namespace SwitchCloneDemo
{
    class SwitchClone : ToggleBase
    {
        const double height = 20;
        const double width = 50;
        const double halfWidth = 25;

        public SwitchClone()
        {
            BoxView boxView = new BoxView
            {
                Color = Color.Accent,
                WidthRequest = halfWidth,
                HeightRequest = height
            };

            DataTrigger dataTrigger = new DataTrigger(typeof(BoxView))
            {
                Binding = new Binding("IsToggled", source: this),
                Value = true,
            };

            dataTrigger.EnterActions.Add(new TranslateAction
            {
                X = halfWidth,
                Length = 100
            });

            dataTrigger.ExitActions.Add(new TranslateAction
            {
                Length = 100
            });

            boxView.Triggers.Add(dataTrigger);

            Content = new Frame
            {
                Padding = 2,
                OutlineColor = Color.Accent,
                BackgroundColor = Color.Transparent,
                Content = new AbsoluteLayout
                {
                    WidthRequest = width,
                    Children =
                    {
                        boxView
                    }
                }
            };
        }
    }
}
