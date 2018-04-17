using System.ComponentModel;

using Xamarin.Forms;

using Win = Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(Xamarin.FormsBook.Platform.StepSlider),
                          typeof(Xamarin.FormsBook.Platform.WinRT.StepSliderRenderer))]

namespace Xamarin.FormsBook.Platform.WinRT
{
    public class StepSliderRenderer : ViewRenderer<StepSlider, Win.Slider>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<StepSlider> args)
        {
            base.OnElementChanged(args);

            if (Control == null)
            {
                SetNativeControl(new Win.Slider());
            }

            if (args.NewElement != null)
            {
                SetMinimum();
                SetMaximum();
                SetSteps();
                SetValue();

                Control.ValueChanged += OnWinSliderValueChanged;
            }
            else
            {
                Control.ValueChanged -= OnWinSliderValueChanged;
            }
        }

        protected override void OnElementPropertyChanged(object sender, 
                                                         PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(sender, args);

            if (args.PropertyName == StepSlider.MinimumProperty.PropertyName)
            {
                SetMinimum();
            }
            else if (args.PropertyName == StepSlider.MaximumProperty.PropertyName)
            {
                SetMaximum();
            }
            else if (args.PropertyName == StepSlider.StepsProperty.PropertyName)
            {
                SetSteps();
            }
            else if (args.PropertyName == StepSlider.ValueProperty.PropertyName)
            {
                SetValue();
            }
        }

        void SetMinimum()
        {
            Control.Minimum = Element.Minimum;
        }

        void SetMaximum()
        {
            Control.Maximum = Element.Maximum;
        }

        void SetSteps()
        {
            Control.StepFrequency = (Element.Maximum - Element.Minimum) / Element.Steps;
        }

        void SetValue()
        {
            Control.Value = Element.Value;
        }

        void OnWinSliderValueChanged(object sender, RangeBaseValueChangedEventArgs args)
        {
            ((IElementController)Element).SetValueFromRenderer(StepSlider.ValueProperty, 
                                                               args.NewValue);
        }
    }
}


