namespace NamedFontSizes

open System
open Xamarin.Forms

type NamedFontSizesPage() = 
    inherit ContentPage()
    let formattedString = FormattedString()
    let namedSizes = 
        [| 
            NamedSize.Default
            NamedSize.Micro
            NamedSize.Small
            NamedSize.Medium
            NamedSize.Large 
        |]

    do for namedSize in namedSizes do
        let fontSize = Device.GetNamedSize(namedSize, typeof<Label>)
        do formattedString.Spans.Add(Span(Text = String.Format("Named Size = {0} ({1:F2})",
                                                               namedSize,
                                                               fontSize),
                                          FontSize = fontSize))
        if namedSize <> Array.last(namedSizes)
            then formattedString.Spans.Add(Span(Text = Environment.NewLine + Environment.NewLine))

    do base.Content <- Label(FormattedText = formattedString,
                             VerticalOptions = LayoutOptions.Center,
                             HorizontalOptions = LayoutOptions.Center)


    