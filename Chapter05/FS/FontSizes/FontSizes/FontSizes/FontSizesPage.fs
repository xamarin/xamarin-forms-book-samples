namespace FontSizes

open System
open Xamarin.Forms

type FontSizesPage() = 
    inherit ContentPage(BackgroundColor = Color.White)

    let stackLayout = StackLayout(HorizontalOptions = LayoutOptions.Center,
                                  VerticalOptions = LayoutOptions.Center)

    do [ NamedSize.Default; NamedSize.Micro; NamedSize.Small; NamedSize.Medium; NamedSize.Large ]
        |> List.iter (fun namedSize -> let fontSize = Device.GetNamedSize(namedSize, typeof<Label>)
                                       stackLayout.Children.Add(Label(Text = String.Format("Named Size = {0} ({1:F2})",
                                                                                           namedSize, fontSize),
                                                                      FontSize = fontSize,
                                                                      TextColor = Color.Black)))
    let resolution = 160.0 

    do stackLayout.Children.Add(BoxView(Color = Color.Accent,
                                        HeightRequest = resolution / 80.0))


    do [ 4.0; 6.0; 8.0; 10.0; 12.0 ]
        |> List.iter (fun pointSize -> let fontSize = resolution * pointSize / 72.0
                                       stackLayout.Children.Add(Label(Text = String.Format("Point Size = {0} ({1:F2})",
                                                                                           pointSize, fontSize),
                                                                      FontSize = fontSize,
                                                                      TextColor = Color.Black)))
    do base.Content <- stackLayout

