using System;
using Xamarin.Forms;

namespace Xamarin.FormsBook.Toolkit
{
    public class AltLabel : Label
    {
        public static readonly BindableProperty PointSizeProperty =
            BindableProperty.Create("PointSize",        // propertyName
                                    typeof(double),     // returnType
                                    typeof(AltLabel),   // declaringType
                                    8.0,                // defaultValue
                                    propertyChanged: OnPointSizeChanged);

        public AltLabel()
        {
            SetLabelFontSize((double)PointSizeProperty.DefaultValue);
        }

        public double PointSize
        {
            set { SetValue(PointSizeProperty, value); }
            get { return (double)GetValue(PointSizeProperty); }
        }

        static void OnPointSizeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((AltLabel)bindable).OnPointSizeChanged((double)oldValue, (double)newValue);
        }

        void OnPointSizeChanged(double oldValue, double newValue)
        {
            SetLabelFontSize(newValue);
        }

        void SetLabelFontSize(double pointSize)
        {
            FontSize = 160 * pointSize / 72;
        }
    }
}
