using Xamarin.Forms.Platform.UWP;

using Windows.UI.Xaml.Controls;

[assembly: ExportRenderer (typeof(HelloRenderers.HelloView), 
                           typeof(HelloRenderers.UWP.HelloViewRenderer))]

namespace HelloRenderers.UWP
{
    public class HelloViewRenderer : ViewRenderer<HelloView, TextBlock>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<HelloView> args)
        {
            base.OnElementChanged(args);

            if (Control == null)
            {
                SetNativeControl(new TextBlock
                {
                    Text = "Hello from the UWP!",
                    FontSize = 24,
                });
            }
        }
    }
}

