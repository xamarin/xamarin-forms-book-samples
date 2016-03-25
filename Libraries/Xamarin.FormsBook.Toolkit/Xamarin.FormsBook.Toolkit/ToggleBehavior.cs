using System;
using Xamarin.Forms;

namespace Xamarin.FormsBook.Toolkit
{
    public class ToggleBehavior : Behavior<View>
    {
        TapGestureRecognizer tapRecognizer;

        public static readonly BindableProperty IsToggledProperty =
            BindableProperty.Create(
                "IsToggled", typeof(bool), typeof(ToggleBehavior), false);

        public bool IsToggled
        {
            set { SetValue(IsToggledProperty, value); }
            get { return (bool)GetValue(IsToggledProperty); }
        }

        protected override void OnAttachedTo(View view)
        {
            base.OnAttachedTo(view);

            tapRecognizer = new TapGestureRecognizer ();
            tapRecognizer.Tapped += OnTapped;
            view.GestureRecognizers.Add(tapRecognizer);
        }

        protected override void OnDetachingFrom(View view)
        {
            base.OnDetachingFrom(view);

            view.GestureRecognizers.Remove(tapRecognizer);
            tapRecognizer.Tapped -= OnTapped;
        }

        void OnTapped(object sender, EventArgs args)
        {
            IsToggled = !IsToggled;
        }
    }
}
