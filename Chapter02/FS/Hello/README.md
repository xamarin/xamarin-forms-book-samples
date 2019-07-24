---
name: 'Xamarin.Forms Book - Hello F#'
description: "Simple Xamarin.Forms app written in F# for Android and iOS"
page_type: sample
languages:
- fsharp
products:
- xamarin
urlFragment: chapter02-fs-hello
---
# Hello F\# in Xamarin.Forms

[Xamarin.Forms docs](https://docs.microsoft.com/xamarin/xamarin-forms/) / [eBook](https://docs.microsoft.com/xamarin/xamarin-forms/creating-mobile-apps-xamarin-forms/) / [Related samples](https://docs.microsoft.com/samples/browse/?term=Xamarin.Forms%20Book)

Simple Xamarin.Forms application for Android and iOS, written in F#:

```fsharp
type App() =
    inherit Application()

    let stack = StackLayout(VerticalOptions = LayoutOptions.Center)
    let label = Label(HorizontalTextAlignment = TextAlignment.Center,
                      Text = "Welcome to F# Xamarin.Forms!")
    do stack.Children.Add(label)
    do base.MainPage <- ContentPage(Content = stack)
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
