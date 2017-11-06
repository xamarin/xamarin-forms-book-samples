using System;
using Xamarin.Forms;

namespace ExploreChildSizes
{
    class OpenBoxView : BoxView
    {
        static readonly BindablePropertyKey ConstraintKey =
            BindableProperty.CreateReadOnly(
                "Constraint",
                typeof(Size),
                typeof(OpenBoxView),
                new Size());

        public static readonly BindableProperty ConstraintProperty = 
            ConstraintKey.BindableProperty;

        static readonly BindablePropertyKey SizeRequestKey =
            BindableProperty.CreateReadOnly(
                "SizeRequest",
                typeof(SizeRequest),
                typeof(OpenBoxView),
                new SizeRequest());

        public static readonly BindableProperty SizeRequestProperty = 
            SizeRequestKey.BindableProperty;

        static readonly BindablePropertyKey ElementBoundsKey =
            BindableProperty.CreateReadOnly(
                "ElementBounds",
                typeof(Rectangle),
                typeof(OpenBoxView),
                new Rectangle());

        public static readonly BindableProperty ElementBoundsProperty = 
            ElementBoundsKey.BindableProperty;

        public OpenBoxView()
        {
            Device.StartTimer(TimeSpan.FromSeconds(0.1), () =>
            {
                ElementBounds = Bounds;
                return true;
            });
        }

        public Size Constraint
        {
            private set { SetValue(ConstraintKey, value); }
            get { return (Size)GetValue(ConstraintProperty); }
        }

        public SizeRequest SizeRequest
        {
            private set { SetValue(SizeRequestKey, value); }
            get { return (SizeRequest)GetValue(SizeRequestProperty); }
        }
        public Rectangle ElementBounds
        {
            private set { SetValue(ElementBoundsKey, value); }
            get { return (Rectangle)GetValue(ElementBoundsProperty); }
        }

        protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
        {
            Constraint = new Size(widthConstraint, heightConstraint);
            SizeRequest sizeRequest = base.OnMeasure(widthConstraint, heightConstraint);
            SizeRequest = sizeRequest;
            return sizeRequest;
        }
    }
}
