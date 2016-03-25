using System;
using Xamarin.Forms;

namespace ListViewArray
{
    public partial class ListViewArrayPage : ContentPage
    {
        public ListViewArrayPage()
        {
            InitializeComponent();

            Array.Sort<Color>((Color[])listView.ItemsSource,
                (Color color1, Color color2) =>
                {
                    if (color1.Hue == color2.Hue)
                        return Math.Sign(color1.Luminosity - color2.Luminosity);

                    return Math.Sign(color1.Hue - color2.Hue);
                });
        }
    }
}
