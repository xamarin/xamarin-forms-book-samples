---
name: 'Xamarin.Forms Book - BlackCat F#'
description: "Xamarin.Forms sample that loads text from a file, to show on the screen, written in F# for Android and iOS"
page_type: sample
languages:
- fsharp
products:
- xamarin
urlFragment: chapter04-fs-blackcat
---
# BlackCat file operations in F\# for Xamarin.Forms

[Xamarin.Forms docs](https://docs.microsoft.com/xamarin/xamarin-forms/) / [eBook](https://docs.microsoft.com/xamarin/xamarin-forms/creating-mobile-apps-xamarin-forms/) / [Related samples](https://docs.microsoft.com/samples/browse/?term=Xamarin.Forms%20Book)

Simple Xamarin.Forms application for Android and iOS, written in F#. The app demonstrates loading text from a file, and displaying it on the screen:

![iOS app showing text loaded from file](Screenshots/01.png)

```fsharp
// Get access to the text resource.
let assembly = base.GetType().GetTypeInfo().Assembly
let resource = "TheBlackCat.txt"

// Get all the lines of the file.
let lines = seq { use stream = assembly.GetManifestResourceStream(resource)
                    use reader = new StreamReader(stream)
                    while not reader.EndOfStream do
                        yield reader.ReadLine() }
```

> [!TIP]
> **BlackCatPage.fs** line 21 might need to be updated to:
>
> `let resource = "BlackCat.TheBlackCat.txt"`
>
> if you experience a null reference exception. This relates to the way the default name for the resource is generated. `TheBlackCat.txt` is likely to work on Windows and `BlackCat.TheBlackCat.txt` on Visual Studio for Mac.

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
