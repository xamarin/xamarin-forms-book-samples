namespace Greetings

open Xamarin.Forms

//type GreetingsPage() = 
//    inherit ContentPage()
//    let label = new Label()
//    do label.Text <- "Greetings, F# Xamarin.Forms!"
//    do label.VerticalOptions <- LayoutOptions.Center
//    do label.HorizontalOptions <- LayoutOptions.Center
//    do base.Content <- label

// ----- OR -----

//type GreetingsPage() = 
//    inherit ContentPage()
//    let label = Label(Text = "Greetings, F# Xamarin.Forms!",
//                      VerticalOptions = LayoutOptions.Center,
//                      HorizontalOptions = LayoutOptions.Center)
//    do base.Content <- label

// ----- OR -----

type GreetingsPage() = 
    inherit ContentPage(Content = Label(Text = "Greetings, F# Xamarin.Forms!",
                                        VerticalOptions = LayoutOptions.Center,
                                        HorizontalOptions = LayoutOptions.Center))
    