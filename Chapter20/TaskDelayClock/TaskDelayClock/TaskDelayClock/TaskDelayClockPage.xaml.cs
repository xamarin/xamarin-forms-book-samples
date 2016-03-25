using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TaskDelayClock
{
    public partial class TaskDelayClockPage : ContentPage
    {
        Random random = new Random();

        public TaskDelayClockPage()
        {
            InitializeComponent();

            InfiniteLoop();
        }

        async void InfiniteLoop()
        {
            while (true)
            {
                label.Text = DateTime.Now.ToString("T");
                label.FontSize = random.Next(12, 49);
                AbsoluteLayout.SetLayoutBounds(label, new Rectangle(random.NextDouble(), 
                                                                    random.NextDouble(), 
                                                                    AbsoluteLayout.AutoSize, 
                                                                    AbsoluteLayout.AutoSize));
                await Task.Delay(250);
            }
        }
    }
}
