using System.ComponentModel;

using Android.Widget;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Xamarin.FormsBook.Platform.StepSlider),
                          typeof(Xamarin.FormsBook.Platform.Android.StepSliderRenderer))]

namespace Xamarin.FormsBook.Platform.Android
{
    public class StepSliderRenderer : ViewRenderer<StepSlider, SeekBar>, SeekBar.IOnSeekBarChangeListener
    {
        double minimum, maximum;

        protected override void OnElementChanged(ElementChangedEventArgs<StepSlider> args)
        {
            base.OnElementChanged(args);

            if (Control == null)
            {
                SetNativeControl(new SeekBar(Context));
            }
            if (args.NewElement != null)
            {
                SetMinimum();
                SetMaximum();
                SetSteps();
                SetValue();

                Control.SetOnSeekBarChangeListener(this);
            }
            else
            {
                Control.SetOnSeekBarChangeListener(null);
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
            minimum = Element.Minimum;
        }

        void SetMaximum()
        {
            maximum = Element.Maximum;
        }

        void SetSteps()
        {
            Control.Max = Element.Steps;
        }

        void SetValue()
        {
            double value = Element.Value;
            Control.Progress = (int)((value - minimum) / (maximum - minimum) * Element.Steps);
        }

        // Implementation of SeekBar.IOnSeekBarChangeListener
        public void OnProgressChanged(SeekBar seekBar, int progress, bool fromUser)
        {
            double value = minimum + (maximum - minimum) * Control.Progress / Control.Max;
            ((IElementController)Element).SetValueFromRenderer(StepSlider.ValueProperty, value);
        }

        public void OnStartTrackingTouch(SeekBar seekBar)
        {
        }

        public void OnStopTrackingTouch(SeekBar seekBar)
        {
        }
    }
}