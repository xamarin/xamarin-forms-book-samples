namespace ColorLoop

open Xamarin.Forms

type ColorLoopPage() = 
    inherit ContentPage()

    let colors = 
        [
            (Color.White, "White")
            (Color.Silver, "Silver")
            (Color.Gray, "Gray")
            (Color.Black, "Black")
            (Color.Red, "Red")
            (Color.Maroon, "Maroon")
            (Color.Yellow, "Yellow")
            (Color.Olive, "Olive")
            (Color.Lime, "Lime")
            (Color.Green, "Green")
            (Color.Aqua, "Aqua")
            (Color.Teal, "Teal")
            (Color.Blue, "Blue")
            (Color.Navy, "Navy")
            (Color.Pink, "Pink")
            (Color.Fuchsia, "Fuchsia")
            (Color.Purple, "Purple")
        ]

    let stackLayout = StackLayout()

    do for color in colors
        do stackLayout.Children.Add(Label(Text = snd color,
                                          TextColor = fst color,
                                          FontSize = Device.GetNamedSize(NamedSize.Large, typeof<Label>)))

    do base.Padding <- match Device.RuntimePlatform with 
                            | Device.iOS -> Thickness(5.0, 20.0, 5.0, 5.0)
                            | _ -> Thickness(5.0, 5.0, 5.0, 5.0)

    do base.Content <- stackLayout
    