using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ScaleToSize
{
    public partial class ScaleToSizePage : ContentPage
    {
        public ScaleToSizePage()
        {
            InitializeComponent();
            UpdateLoop();
        }

        async void UpdateLoop()
        {
            while (true)
            {
                label.Text = DateTime.Now.ToString("T");
                await Task.Delay(1000);
            }
        }

        void OnSizeChanged(object sender, EventArgs args)
        {
            label.Scale = Math.Min(Width / label.Width, Height / label.Height);
        }
    }
}
