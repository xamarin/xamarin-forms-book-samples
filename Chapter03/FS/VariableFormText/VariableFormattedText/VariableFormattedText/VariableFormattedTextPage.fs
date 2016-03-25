namespace VariableFormattedText

open Xamarin.Forms

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


    