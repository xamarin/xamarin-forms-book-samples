using System;
using Xamarin.Forms;

namespace ToolbarDemo
{
    public partial class ToolbarDemoPage : ContentPage
    {
        public ToolbarDemoPage()
        {
            InitializeComponent();
        }

        void OnToolbarItemClicked(object sender, EventArgs args)
        {
            ToolbarItem toolbarItem = (ToolbarItem)sender;
            label.Text = "ToolbarItem '" + toolbarItem.Text + "' clicked";
        }
    }
}
