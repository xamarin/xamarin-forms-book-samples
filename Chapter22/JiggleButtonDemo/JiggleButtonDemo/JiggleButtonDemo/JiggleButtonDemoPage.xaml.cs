using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace JiggleButtonDemo
{
    public partial class JiggleButtonDemoPage : ContentPage
    {
        public JiggleButtonDemoPage()
        {
            // Ensure link to Toolkit library.
            new Xamarin.FormsBook.Toolkit.JiggleButton();

            InitializeComponent();
        }
    }
}
