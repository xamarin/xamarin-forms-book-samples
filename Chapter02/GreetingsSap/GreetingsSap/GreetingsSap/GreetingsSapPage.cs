using System;
using Xamarin.Forms;

namespace GreetingsSap
{
    public class GreetingsSapPage : ContentPage
    {
        public GreetingsSapPage ()
        {
            Content = new Label
            {
                Text = "Greetings, Xamarin.Forms!"
            };

#if __IOS__

        Padding = new Thickness(0, 20, 0, 0);

#endif
        }
    }
}
