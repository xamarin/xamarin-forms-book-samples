using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ImplicitStyle
{
    public partial class ImplicitStylePage : ContentPage
    {
        public ImplicitStylePage()
        {
            InitializeComponent();


            foreach (object key in Resources.Keys)
                System.Diagnostics.Debug.WriteLine(key);
        }
    }
}
