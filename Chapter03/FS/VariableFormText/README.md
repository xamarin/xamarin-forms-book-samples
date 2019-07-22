---
name: 'Xamarin.Forms Book - VariableFormattedText F#'
description: "Xamarin.Forms app with formatted text spans, written in F#"
page_type: sample
languages:
- fsharp
products:
- xamarin
urlFragment: chapter03-fs-variableformtext
---

# Greetings F\#

Simple Xamarin.Forms application written in F#, showing formatted text spans:

```fsharp
type VariableFormattedTextPage() =
    inherit ContentPage()
    let formattedString = FormattedString()
    let largeSize = Device.GetNamedSize(NamedSize.Large, typeof<Label>)

    do formattedString.Spans.Add(Span(Text = "I "))
    do formattedString.Spans.Add(Span(Text = "love",
                                      FontSize = largeSize,
                                      FontAttributes = FontAttributes.Bold))
    do formattedString.Spans.Add(Span(Text = " Xamarin.Forms"))

    do base.Content <- Label(FormattedText = formattedString,
                             VerticalOptions = LayoutOptions.Center,
                             HorizontalOptions = LayoutOptions.Center,
                             FontSize = largeSize)
```
