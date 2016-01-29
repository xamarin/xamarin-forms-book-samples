using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace StyleInheritance
{
    public partial class StyleInheritancePage : ContentPage
    {
        public StyleInheritancePage()
        {
            // Access external library to ensure linking.
            var x = new Xamarin.FormsBook.Toolkit.AltLabel();

            InitializeComponent();
        }
    }
}
