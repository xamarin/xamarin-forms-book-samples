namespace VerticalOptionsDemo

open System
open System.Reflection
open Xamarin.Forms

type VerticalOptionsDemoPage() = 
    inherit ContentPage()

    let stackLayout = StackLayout()
    let colors = [| Color.Yellow; Color.Blue |]

    do typeof<LayoutOptions>.GetRuntimeFields()
        |> Seq.filter (fun field -> field.IsPublic && field.IsStatic)
        |> Seq.sortBy (fun field -> (field.GetValue(null) :?> LayoutOptions).Alignment)
        |> Seq.map (fun field -> Label(Text = "VerticalOptions = " + field.Name,
                                       VerticalOptions = (field.GetValue(null) :?> LayoutOptions),
                                       HorizontalTextAlignment = TextAlignment.Center,
                                       FontSize = Device.GetNamedSize(NamedSize.Medium, typeof<Label>),
                                       TextColor = colors.[stackLayout.Children.Count % 2],
                                       BackgroundColor = colors.[1 - stackLayout.Children.Count % 2]))
        |> Seq.iter (fun label -> stackLayout.Children.Add(label))

    do base.Padding <- match Device.RuntimePlatform with 
                            | Device.iOS -> Thickness(0.0, 20.0, 0.0, 0.0)
                            | _ -> Thickness()

    do base.Content <- stackLayout
