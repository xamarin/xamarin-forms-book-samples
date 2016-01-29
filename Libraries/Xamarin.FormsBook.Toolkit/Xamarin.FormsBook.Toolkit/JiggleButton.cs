using System;
using Xamarin.Forms;

namespace Xamarin.FormsBook.Toolkit
{
    public class JiggleButton : Button
    {
        bool isJiggling;

        public JiggleButton()
        {
            Clicked += async (sender, args) =>
                {
                    if (isJiggling)
                        return;

                    isJiggling = true;

                    await this.RotateTo(15, 1000, new Easing(t =>
                                                    Math.Sin(Math.PI * t) *
                                                    Math.Sin(Math.PI * 20 * t)));
                    isJiggling = false;
                };
        }
    }
}
