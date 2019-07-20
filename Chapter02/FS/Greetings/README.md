---
name: 'Xamarin.Forms Book - Greetings F#'
description: "Simple Xamarin.Forms app written in F# #getstarted"
page_type: sample
languages:
- fsharp
products:
- xamarin
urlFragment: chapter02-fs-greetings
---
# Greetings F\#

Simple Xamarin.Forms application written in F#:

```fsharp
type GreetingsPage() =
    inherit ContentPage(Content = Label(Text = "Greetings, F# Xamarin.Forms!",
                                        VerticalOptions = LayoutOptions.Center,
                                        HorizontalOptions = LayoutOptions.Center))
```
