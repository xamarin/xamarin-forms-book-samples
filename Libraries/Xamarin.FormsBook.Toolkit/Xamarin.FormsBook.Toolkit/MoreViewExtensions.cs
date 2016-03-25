using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xamarin.FormsBook.Toolkit
{
    public static class MoreViewExtensions
    {
        public static Task<bool> TranslateXTo(this VisualElement view, double x, 
                                              uint length = 250, Easing easing = null) 
        { 
            easing = easing ?? Easing.Linear; 
 	        TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>();
            WeakReference<VisualElement> weakViewRef = new WeakReference<VisualElement>(view);

            Animation animation = new Animation(
                (value) => 
                    {
                        VisualElement viewRef;
                        if (weakViewRef.TryGetTarget(out viewRef))
                        {
                            viewRef.TranslationX = value;
                        }
                    },              // callback
                view.TranslationX,  // start
                x,                  // end
                easing);            // easing

            animation.Commit(
                view,               // owner
                "TranslateXTo",     // name
                16,                 // rate
                length,             // length
                null,               // easing 
                (finalValue, cancelled) => 
                        taskCompletionSource.SetResult(cancelled)); // finished
 			 
 	        return taskCompletionSource.Task; 
        } 

        public static void CancelTranslateXTo(VisualElement view)
        {
            view.AbortAnimation("TranslateXTo");
        }

        public static Task<bool> TranslateYTo(this VisualElement view, double y,
                                              uint length = 250, Easing easing = null)
        {
            easing = easing ?? Easing.Linear;
            TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>();
            WeakReference<VisualElement> weakViewRef = new WeakReference<VisualElement>(view);

            Animation animation = new Animation((value) =>
                {
                    VisualElement viewRef;
                    if (weakViewRef.TryGetTarget(out viewRef))
                    {
                        viewRef.TranslationY = value;
                    }
                }, view.TranslationY, y, easing);

            animation.Commit(view, "TranslateYTo", 16, length, null,
                             (v, c) => taskCompletionSource.SetResult(c));

            return taskCompletionSource.Task;
        }

        public static void CancelTranslateYTo(VisualElement view)
        {
            view.AbortAnimation("TranslateYTo");
        }

        public static Task<bool> TranslateXYTo(this VisualElement view, double x, double y,
                                               uint length = 250, Easing easing = null)
        {
            easing = easing ?? Easing.Linear;
            TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>();
            WeakReference<VisualElement> weakViewRef = new WeakReference<VisualElement>(view);

            Action<double> callbackX = value =>
                {
                    VisualElement viewRef;
                    if (weakViewRef.TryGetTarget(out viewRef))
                    {
                        viewRef.TranslationX = value;
                    }
                };

            Action<double> callbackY = value =>
                {
                    VisualElement viewRef;
                    if (weakViewRef.TryGetTarget(out viewRef))
                    {
                        viewRef.TranslationY = value;
                    }
                };

            Animation animation = new Animation
            {
                { 0, 1, new Animation(callbackX, view.TranslationX, x, easing) },
                { 0, 1, new Animation(callbackY, view.TranslationY, y, easing) }
            };

            animation.Commit(view, "TranslateXYTo", 16, length, null,
                             (v, c) => taskCompletionSource.SetResult(c));

            return taskCompletionSource.Task;
        }

        public static void CancelTranslateXYTo(VisualElement view)
        {
            view.AbortAnimation("TranslateXYTo");
        }

        public static Task<bool> BezierPathTo(this VisualElement view, 
                                              Point pt1, Point pt2, Point pt3, 
                                              uint length = 250, 
                                              BezierTangent bezierTangent = BezierTangent.None,
                                              Easing easing = null)
        {
            easing = easing ?? Easing.Linear;
            TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>();
            WeakReference<VisualElement> weakViewRef = new WeakReference<VisualElement>(view);

            Rectangle bounds = view.Bounds;
            BezierSpline bezierSpline = new BezierSpline(bounds.Center, pt1, pt2, pt3);

            Action<double> callback = t =>
                {
                    VisualElement viewRef;
                    if (weakViewRef.TryGetTarget(out viewRef))
                    {
                        Point tangent;
                        Point point = bezierSpline.GetPointAtFractionLength(t, out tangent);
                        double x = point.X - bounds.Width / 2;
                        double y = point.Y - bounds.Height / 2;
                        viewRef.Layout(new Rectangle(new Point(x, y), bounds.Size));

                        if (bezierTangent != BezierTangent.None)
                        {
                            viewRef.Rotation = 180 * Math.Atan2(tangent.Y, tangent.X) / Math.PI;

                            if (bezierTangent == BezierTangent.Reversed)
                            {
                                viewRef.Rotation += 180;
                            }
                        }
                    }
                };

            Animation animation = new Animation(callback, 0, 1, easing);
            animation.Commit(view, "BezierPathTo", 16, length, 
                finished: (value, cancelled) => taskCompletionSource.SetResult(cancelled));

            return taskCompletionSource.Task;
        }

        public static void CancelBezierPathTo(VisualElement view)
        {
            view.AbortAnimation("BezierPathTo");
        }

        public static Task<bool> RgbColorAnimation(this VisualElement view, 
                                                   Color fromColor, Color toColor,
                                                   Action<Color> callback,
                                                   uint length = 250, 
                                                   Easing easing = null)
        {
            Func<double, Color> transform = (t) =>
                {
                    return Color.FromRgba(fromColor.R + t * (toColor.R - fromColor.R),
                                          fromColor.G + t * (toColor.G - fromColor.G),
                                          fromColor.B + t * (toColor.B - fromColor.B),
                                          fromColor.A + t * (toColor.A - fromColor.A));
                };

            return ColorAnimation(view, "RgbColorAnimation", transform, callback, length, easing);
        }

        public static void CancelRgbColorAnimation(VisualElement view)
        {
            view.AbortAnimation("RgbColorAnimation");
        }

        public static Task<bool> HslColorAnimation(this VisualElement view, 
                                                   Color fromColor, Color toColor,
                                                   Action<Color> callback,
                                                   uint length = 250, 
                                                   Easing easing = null)
        {
            Func<double, Color> transform = (t) =>
            {
                return Color.FromHsla(
                    fromColor.Hue + t * (toColor.Hue - fromColor.Hue),
                    fromColor.Saturation + t * (toColor.Saturation - fromColor.Saturation),
                    fromColor.Luminosity + t * (toColor.Luminosity - fromColor.Luminosity),
                    fromColor.A + t * (toColor.A - fromColor.A));
            };

            return ColorAnimation(view, "HslColorAnimation", transform, callback, length, easing);
        }

        public static void CancelHslColorAnimation(VisualElement view)
        {
            view.AbortAnimation("HslColorAnimation");
        }

        static Task<bool> ColorAnimation(VisualElement view,
                                         string name,
                                         Func<double, Color> transform,
                                         Action<Color> callback,
                                         uint length,
                                         Easing easing)
        {
            easing = easing ?? Easing.Linear;
            TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>();

            view.Animate<Color>(name, transform, callback, 16, length, easing, (value, canceled) =>
                {
                    taskCompletionSource.SetResult(canceled);
                });

            return taskCompletionSource.Task;
        }
    }
}
