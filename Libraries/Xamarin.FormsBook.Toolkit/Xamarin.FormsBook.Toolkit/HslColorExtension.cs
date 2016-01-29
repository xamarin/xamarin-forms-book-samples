using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin.FormsBook.Toolkit
{
    public class HslColorExtension : IMarkupExtension
    {
        public HslColorExtension()
        {
            A = 1;
        }

        public double H { set; get; }

        public double S { set; get; }

        public double L { set; get; }

        public double A { set; get; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return Color.FromHsla(H, S, L, A);
        }
    }
}
