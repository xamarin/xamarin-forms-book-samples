using System;
using System.ComponentModel;

using UIKit;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Xamarin.FormsBook.Platform.StepSlider),
                          typeof(Xamarin.FormsBook.Platform.iOS.StepSliderRenderer))]

namespace Xamarin.FormsBook.Platform.iOS
{
    public class StepSliderRenderer : ViewRenderer<StepSlider, UISlider>
    {
        int steps;

        protected override void OnElementChanged(ElementChangedEventArgs<StepSlider> args)
        {
            base.OnElementChanged(args);

            if (Control == null)
            {
                SetNativeControl(new UISlider());
            }

            if (args.NewElement != null)
            {
                SetMinimum();
                SetMaximum();
                SetSteps();
                SetValue();

                Control.ValueChanged += OnUISliderValueChanged;
            }
            else
            {
                Control.ValueChanged -= OnUISliderValueChanged;
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
            Control.MinValue = (float)Element.Minimum;
        }

        void SetMaximum()
        {
            Control.MaxValue = (float)Element.Maximum;
        }

        void SetSteps()
        {
            steps = Element.Steps;
        }

        void SetValue()
        {
            Control.Value = (float)Element.Value;
        }

        void OnUISliderValueChanged(object sender, EventArgs args)
        {
            double increment = (Element.Maximum - Element.Minimum) / Element.Steps;
            double value = increment * Math.Round(Control.Value / increment);
            ((IElementController)Element).SetValueFromRenderer(StepSlider.ValueProperty, value);
        }
    }
}


