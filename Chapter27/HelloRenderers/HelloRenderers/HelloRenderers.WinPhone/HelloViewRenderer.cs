using Xamarin.Forms.Platform.WinRT;

using Windows.UI.Xaml.Controls;

[assembly: ExportRenderer (typeof(HelloRenderers.HelloView), 
                           typeof(HelloRenderers.WinPhone.HelloViewRenderer))]

namespace HelloRenderers.WinPhone
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
                    Text = "Hello from Windows Phone!",
                    FontSize = 24,
                });
            }
        }
    }
}
