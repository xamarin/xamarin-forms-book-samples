namespace WhatSize

open System
open Xamarin.Forms

type WhatSizePage() as self = 
    inherit ContentPage()

    let label = Label(FontSize = Device.GetNamedSize(NamedSize.Large, typeof<Label>),
                                 HorizontalOptions = LayoutOptions.Center,
                                 VerticalOptions = LayoutOptions.Center)

    do base.Content <- label

    do self.SizeChanged.Add(fun _ -> label.Text <- String.Format("{0} \u00D7 {1}",
                                                                 self.Width,
                                                                 self.Height))

