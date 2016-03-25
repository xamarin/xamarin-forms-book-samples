using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

using UIKit;

using HelloRenderers;
using HelloRenderers.iOS;

[assembly: ExportRenderer(typeof(HelloView), typeof(HelloViewRenderer))]

namespace HelloRenderers.iOS
{
    public class HelloViewRenderer : ViewRenderer<HelloView, UILabel>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<HelloView> args)
        {
            base.OnElementChanged(args);

            if (Control == null)
            {
                UILabel label = new UILabel
                {
                    Text = "Hello from iOS!",
                    Font = UIFont.SystemFontOfSize(24)
                };

                SetNativeControl(label);
            }
        }
    }
}
