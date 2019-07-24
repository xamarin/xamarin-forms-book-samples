---
name: 'Xamarin.Forms Book - Greetings F#'
description: "Simple Xamarin.Forms app written in F# for Android and iOS"
page_type: sample
languages:
- fsharp
products:
- xamarin
urlFragment: chapter02-fs-greetings
---

# Greetings F\# in Xamarin.Forms

[Xamarin.Forms docs](https://docs.microsoft.com/xamarin/xamarin-forms/) / [eBook](https://docs.microsoft.com/xamarin/xamarin-forms/creating-mobile-apps-xamarin-forms/) / [Related samples](https://docs.microsoft.com/samples/browse/?term=Xamarin.Forms%20Book)

Simple Xamarin.Forms application for Android and iOS, written in F#:

```fsharp
type GreetingsPage() =
    inherit ContentPage(Content = Label(Text = "Greetings, F# Xamarin.Forms!",
                                        VerticalOptions = LayoutOptions.Center,
                                        HorizontalOptions = LayoutOptions.Center))
```

## Prerequisites

- [Visual Studio](https://visualstudio.microsoft.com/) on Mac or Windows.
  - _Mobile Development with .NET (Xamarin)_ workload installed.
  - F\#
- To test and deploy to iOS devices:  
  - Mac computer with the latest version of macOS.
  - Latest version of [Xcode](https://developer.apple.com/xcode/) from Apple on the Mac.
  - If you're using Windows, the Mac should be available on the network.

## Running the sample

1. Open the solution file (**.sln**) in Visual Studio.
1. Use the **Run** button or menu to start the app.
