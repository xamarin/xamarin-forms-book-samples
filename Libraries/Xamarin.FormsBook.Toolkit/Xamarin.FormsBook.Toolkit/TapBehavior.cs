using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xamarin.FormsBook.Toolkit
{
    public class TapBehavior : Behavior<View>
    {
        TapGestureRecognizer tapGesture;

        static readonly BindablePropertyKey IsTriggeredKey =
            BindableProperty.CreateReadOnly("IsTriggered", typeof(bool), 
                                            typeof(TapBehavior), false);

        public static readonly BindableProperty IsTriggeredProperty =
                                            IsTriggeredKey.BindableProperty;

        public bool IsTriggered
        {
            private set { SetValue(IsTriggeredKey, value); }
            get { return (bool)GetValue(IsTriggeredProperty); }
        }

        protected override void OnAttachedTo(View view)
        {
            base.OnAttachedTo(view);

            tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += OnTapped;
            view.GestureRecognizers.Add(tapGesture);
        }

        protected override void OnDetachingFrom(View view)
        {
            base.OnDetachingFrom(view);

            view.GestureRecognizers.Remove(tapGesture);
            tapGesture.Tapped -= OnTapped;
        }

        async void OnTapped(object sender, EventArgs args)
        {
            IsTriggered = true;
            await Task.Delay(100);
            IsTriggered = false;
        }
    }
}
