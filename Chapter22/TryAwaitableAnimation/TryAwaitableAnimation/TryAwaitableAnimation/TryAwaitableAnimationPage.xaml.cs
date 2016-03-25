using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TryAwaitableAnimation
{
    public partial class TryAwaitableAnimationPage : ContentPage
    {
        public TryAwaitableAnimationPage()
        {
            InitializeComponent();
        }

        async void OnButtonClicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            uint milliseconds = UInt32.Parse((string)button.StyleId);
            await MyRotate(button, 0, 360, milliseconds);
        }

        Task MyRotate(VisualElement visual, double fromValue, double toValue, uint duration)
        {
            TaskCompletionSource<object> taskCompletionSource = new TaskCompletionSource<object>();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Device.StartTimer(TimeSpan.FromMilliseconds(16), () =>
                {
                    double t = Math.Min(1, stopwatch.ElapsedMilliseconds / (double)duration);
                    double value = fromValue + t * (toValue - fromValue);
                    visual.Rotation = value;
                    bool completed = t == 1;
                    
                    if (completed)
                    {
                        taskCompletionSource.SetResult(null);
                    }
                    return !completed; 
                });

            return taskCompletionSource.Task;
        }
    }
}
