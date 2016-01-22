namespace Hello

open Xamarin.Forms

type App() = 
    inherit Application()

    let stack = StackLayout(VerticalOptions = LayoutOptions.Center)
    let label = Label(HorizontalTextAlignment = TextAlignment.Center,
                      Text = "Welcome to F# Xamarin.Forms!")
    do stack.Children.Add(label)
    do base.MainPage <- ContentPage(Content = stack)
    
