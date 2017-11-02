namespace ColorList

open Xamarin.Forms

type ColorListPage() = 
    inherit ContentPage()

    let stackLayout = StackLayout()
    let fontSize = Device.GetNamedSize(NamedSize.Large, typeof<Label>);

    do stackLayout.Children.Add(Label(Text = "White",
                                      TextColor = Color.White,
                                      FontSize = fontSize))

    do stackLayout.Children.Add(Label(Text = "Silver",
                                      TextColor = Color.Silver,
                                      FontSize = fontSize))

    do stackLayout.Children.Add(Label(Text = "Gray",
                                      TextColor = Color.Gray,
                                      FontSize = fontSize))

    do stackLayout.Children.Add(Label(Text = "Black",
                                      TextColor = Color.Black,
                                       FontSize = fontSize))

    do stackLayout.Children.Add(Label(Text = "Red", 
                                      TextColor = Color.Red,
                                      FontSize = fontSize))

    do stackLayout.Children.Add(Label(Text = "Maroon",
                                      TextColor = Color.Maroon,
                                      FontSize = fontSize))

    do stackLayout.Children.Add(Label(Text = "Yellow",
                                      TextColor = Color.Yellow,
                                      FontSize = fontSize))

    do stackLayout.Children.Add(Label(Text = "Olive",
                                      TextColor = Color.Olive,
                                      FontSize = fontSize))

    do stackLayout.Children.Add(Label(Text = "Lime",
                                      TextColor = Color.Lime,
                                      FontSize = fontSize))

    do stackLayout.Children.Add(Label(Text = "Green",
                                      TextColor = Color.Green,
                                      FontSize = fontSize))

    do stackLayout.Children.Add(Label(Text = "Aqua",
                                      TextColor = Color.Aqua,
                                      FontSize = fontSize))

    do stackLayout.Children.Add(Label(Text = "Teal",
                                      TextColor = Color.Teal,
                                      FontSize = fontSize))

    do stackLayout.Children.Add(Label(Text = "Blue",
                                      TextColor = Color.Blue,
                                      FontSize = fontSize))

    do stackLayout.Children.Add(Label(Text = "Navy",
                                      TextColor = Color.Navy,
                                      FontSize = fontSize))

    do stackLayout.Children.Add(Label(Text = "Pink",
                                      TextColor = Color.Pink,
                                      FontSize = fontSize))

    do stackLayout.Children.Add(Label(Text = "Fuchsia",
                                      TextColor = Color.Fuchsia,
                                      FontSize = fontSize))

    do stackLayout.Children.Add(Label(Text = "Purple",
                                      TextColor = Color.Purple,
                                      FontSize = fontSize))

    do base.Padding <- match Device.RuntimePlatform with 
                            | Device.iOS -> Thickness(5.0, 20.0, 5.0, 5.0)
                            | _ -> Thickness(5.0, 5.0, 5.0, 5.0)

    do base.Content <- stackLayout
    