namespace CodePlusXaml

open System
open Xamarin.Forms
open Xamarin.Forms.Xaml

type CodePlusXamlPage() =
    inherit ContentPage()

    // Experimental code only! 
    // This is not the way XAML will be processed ultimately!
    // ------------------------------------------------------
    do base.LoadFromXaml(typeof<CodePlusXamlPage>) |> ignore

    let label = Label(Text = "Hello from Code!",
                      IsVisible = true,
                      Opacity = 0.75,
                      HorizontalTextAlignment = TextAlignment.Center,
                      VerticalOptions = LayoutOptions.CenterAndExpand,
                      TextColor = Color.Blue,
                      BackgroundColor = Color.FromRgb(255, 128, 128),
                      FontSize = Device.GetNamedSize(NamedSize.Large, typeof<Label>),
                      FontAttributes = (FontAttributes.Bold ||| Xamarin.Forms.FontAttributes.Italic))

    do (base.Content :?> StackLayout).Children.Add(label)

type App() = 
    inherit Application()

    do base.MainPage <- CodePlusXamlPage()




