using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ToolbarDemo
{
    public partial class ToolbarDemoPage : ContentPage
    {
        public ToolbarDemoPage()
        {
            // Ensure link to Toolkit library.
            new Xamarin.FormsBook.Toolkit.ForPlatform<object>();

            InitializeComponent();
        }

        void OnToolbarItemClicked(object sender, EventArgs args)
        {
            ToolbarItem toolbarItem = (ToolbarItem)sender;
            label.Text = "ToolbarItem '" + toolbarItem.Text + "' clicked";
        }
    }
}
