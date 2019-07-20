---
name: 'Xamarin.Forms Book - Hello F#'
description: "Simple Xamarin.Forms app written in F# #getstarted"
page_type: sample
languages:
- fsharp
products:
- xamarin
urlFragment: chapter02-fs-hello
---
# Greetings F\#

Simple Xamarin.Forms application written in F#:

```fsharp
type App() =
    inherit Application()

    let stack = StackLayout(VerticalOptions = LayoutOptions.Center)
    let label = Label(HorizontalTextAlignment = TextAlignment.Center,
                      Text = "Welcome to F# Xamarin.Forms!")
    do stack.Children.Add(label)
    do base.MainPage <- ContentPage(Content = stack)
```
