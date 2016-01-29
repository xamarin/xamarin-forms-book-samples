using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ButtonImage
{
    public partial class ButtonImagePage : ContentPage
    {
        public ButtonImagePage()
        {
            // Ensure link to Toolkit library.
            new Xamarin.FormsBook.Toolkit.ForPlatform<object>();

            InitializeComponent();
        }
    }
}
