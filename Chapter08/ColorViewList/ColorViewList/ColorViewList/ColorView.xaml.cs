using System;
using Xamarin.Forms;

namespace ColorViewList
{
    public partial class ColorView : ContentView
    {
        string colorName;
        ColorTypeConverter colorTypeConv = new ColorTypeConverter();

        public ColorView()
        {
            InitializeComponent();
        }

        public string ColorName
        {
            set
            {
                // Set the name.
                colorName = value;
                colorNameLabel.Text = value;

                // Get the actual Color and set the other views.
                Color color = (Color)colorTypeConv.ConvertFromInvariantString(colorName);
                boxView.Color = color;
                colorValueLabel.Text = String.Format("{0:X2}-{1:X2}-{2:X2}",
                                                     (int)(255 * color.R), 
                                                     (int)(255 * color.G), 
                                                     (int)(255 * color.B));
            }
            get
            {
                return colorName;
            }
        }
    }
}
