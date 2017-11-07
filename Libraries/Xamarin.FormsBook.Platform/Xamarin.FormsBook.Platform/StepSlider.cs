using System;
using Xamarin.Forms;

namespace Xamarin.FormsBook.Platform
{
    public class StepSlider : View
    {
        public event EventHandler<ValueChangedEventArgs> ValueChanged;

        public static readonly BindableProperty MinimumProperty =
            BindableProperty.Create(
                "Minimum",
                typeof(double),
                typeof(StepSlider),
                0.0,
                validateValue: (obj, min) => (double)min < ((StepSlider)obj).Maximum,
                coerceValue: (obj, min) =>
                {
                    StepSlider stepSlider = (StepSlider)obj;
                    stepSlider.Value = stepSlider.Coerce(stepSlider.Value, 
                                                         (double)min, 
                                                         stepSlider.Maximum);
                    return min;
                });

        public static readonly BindableProperty MaximumProperty =
            BindableProperty.Create(
                "Maximum",
                typeof(double),
                typeof(StepSlider),
                100.0,
                validateValue: (obj, max) => (double)max > ((StepSlider)obj).Minimum,
                coerceValue: (obj, max) =>
                {
                    StepSlider stepSlider = (StepSlider)obj;
                    stepSlider.Value = stepSlider.Coerce(stepSlider.Value, 
                                                         stepSlider.Minimum, 
                                                         (double)max);
                    return max;
                });

        public static readonly BindableProperty StepsProperty =
            BindableProperty.Create(
                "Steps",
                typeof(int),
                typeof(StepSlider),
                100,
                validateValue: (obj, steps) => (int)steps > 1);

        public static readonly BindableProperty ValueProperty =
            BindableProperty.Create(
                "Value",
                typeof(double),
                typeof(StepSlider),
                0.0,
                BindingMode.TwoWay,
                coerceValue: (obj, value) =>
                {
                    StepSlider stepSlider = (StepSlider)obj;
                    return stepSlider.Coerce((double)value, 
                                             stepSlider.Minimum, 
                                             stepSlider.Maximum);
                },
                propertyChanged: (obj, oldValue, newValue) =>
                {
                    StepSlider stepSlider = (StepSlider)obj;
                    stepSlider.ValueChanged?.Invoke(obj, new ValueChangedEventArgs((double)oldValue, (double)newValue));
                });

        public double Minimum
        {
            set { SetValue(MinimumProperty, value); }
            get { return (double)GetValue(MinimumProperty); }
        }

        public double Maximum
        {
            set { SetValue(MaximumProperty, value); }
            get { return (double)GetValue(MaximumProperty); }
        }

        public int Steps
        {
            set { SetValue(StepsProperty, value); }
            get { return (int)GetValue(StepsProperty); }
        }

        public double Value
        {
            set { SetValue(ValueProperty, value); }
            get { return (double)GetValue(ValueProperty); }
        }

        double Coerce(double value, double min, double max)
        {
            return Math.Max(min, Math.Min(value, max));
        }
    }
}


