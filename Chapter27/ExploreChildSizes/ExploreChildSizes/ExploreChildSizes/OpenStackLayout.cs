using System;
using Xamarin.Forms;

namespace ExploreChildSizes
{
    class OpenStackLayout : StackLayout
    {
        static readonly BindablePropertyKey ConstraintKey =
            BindableProperty.CreateReadOnly<OpenStackLayout, Size>
                (openLabel => openLabel.Constraint,
                new Size());

        public static readonly BindableProperty ConstraintProperty = 
            ConstraintKey.BindableProperty;

        static readonly BindablePropertyKey SizeRequestKey =
            BindableProperty.CreateReadOnly<OpenStackLayout, SizeRequest>
                (openLabel => openLabel.SizeRequest,
                new SizeRequest());

        public static readonly BindableProperty SizeRequestProperty = 
            SizeRequestKey.BindableProperty;

        static readonly BindablePropertyKey ElementBoundsKey =
            BindableProperty.CreateReadOnly<OpenStackLayout, Rectangle>
                (openLabel => openLabel.ElementBounds,
                new Rectangle());

        public static readonly BindableProperty ElementBoundsProperty = 
            ElementBoundsKey.BindableProperty;

        static readonly BindablePropertyKey LayoutBoundsKey =
            BindableProperty.CreateReadOnly<OpenStackLayout, Rectangle>
                (openLabel => openLabel.LayoutBounds,
                new Rectangle());

        public static readonly BindableProperty LayoutBoundsProperty = 
            LayoutBoundsKey.BindableProperty;

        public OpenStackLayout()
        {
            SizeChanged += (sender, args) =>
            {
                ElementBounds = Bounds;
            };
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

        public Rectangle LayoutBounds
        {
            private set { SetValue(LayoutBoundsKey, value); }
            get { return (Rectangle)GetValue(LayoutBoundsProperty); }
        }

        protected override SizeRequest OnSizeRequest(double widthConstraint, double heightConstraint)
        {
            Constraint = new Size(widthConstraint, heightConstraint);
            SizeRequest sizeRequest = base.OnSizeRequest(widthConstraint, heightConstraint);
            SizeRequest = sizeRequest;
            return sizeRequest;
        }

        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            LayoutBounds = new Rectangle(x, y, width, height); 
            base.LayoutChildren(x, y, width, height);
        }
    }
}
