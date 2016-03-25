using Xamarin.Forms.Platform.WinRT;

using Windows.UI.Xaml.Controls;

[assembly: ExportRenderer(typeof(HelloRenderers.HelloView),
                          typeof(HelloRenderers.Windows.HelloViewRenderer))]

namespace HelloRenderers.Windows
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
                    Text = "Hello from Windows!",
                    FontSize = 24,
                });
            }
        }
    }
}
