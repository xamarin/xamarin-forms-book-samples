namespace FitToSizeClock

open System
open Xamarin.Forms

type FitToSizeClockPage() as self = 
    inherit ContentPage()

    let label = Label(HorizontalOptions = LayoutOptions.Center,
                      VerticalOptions = LayoutOptions.Center)

    do base.Content <- label

    do self.SizeChanged.Add(fun _ -> do label.FontSize <- self.Width / 6.0)

    do Device.StartTimer(TimeSpan.FromSeconds(1.0),
                         (fun _ -> do label.Text <- DateTime.Now.ToString("h:mm:ss tt")
                                   true))



