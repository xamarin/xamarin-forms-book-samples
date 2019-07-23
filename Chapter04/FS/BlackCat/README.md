---
name: 'Xamarin.Forms Book - BlackCat F#'
description: "Xamarin.Forms sample that loads text from a file, to show on the screen, written in F#"
page_type: sample
languages:
- fsharp
products:
- xamarin
urlFragment: chapter04-fs-blackcat
---
# Greetings F\#

Simple Xamarin.Forms application written in F#, that loads text from a file, to show on the screen:

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

> [!NOTE]
> **BlackCatPage.fs** line 21 might need to be updated to:
>
> `let resource = "BlackCat.TheBlackCat.txt"`
>
> If you experience a null reference exception.
