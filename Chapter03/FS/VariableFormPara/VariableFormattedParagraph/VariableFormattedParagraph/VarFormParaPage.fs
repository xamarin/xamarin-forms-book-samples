namespace VariableFormattedParagraph

open Xamarin.Forms

type VariableFormattedParagraphPage() = 
    inherit ContentPage()
    let formattedString = FormattedString()
    do formattedString.Spans.Add(Span(Text = "\u2003There was nothing so "))
    do formattedString.Spans.Add(Span(Text = "very",
                                      FontAttributes = FontAttributes.Italic))
    do formattedString.Spans.Add(Span(Text = " remarkable in that; nor did Alice \
                                              think it so ")) 
    do formattedString.Spans.Add(Span(Text = "very",
                                      FontAttributes = FontAttributes.Italic))
    do formattedString.Spans.Add(Span(Text = " much out of the way to hear the \
                                              Rabbit say to itself \u201COh \
                                              dear! Oh dear! I shall be too late!\
                                              \u201D (when she thought it over \
                                              afterwards, it occurred to her that \
                                              she ought to have wondered at this, \
                                              but at the time it all seemed quite \
                                              natural); but, when the Rabbit actually "))
    do formattedString.Spans.Add(Span(Text = "took a watch out of its waistcoat-pocket",
                                      FontAttributes = FontAttributes.Italic))
    do formattedString.Spans.Add(Span(Text = ", and looked at it, and then hurried on, \
                                              Alice started to her feet, for it flashed \
                                              across her mind that she had never before \
                                              seen a rabbit with either a waistcoat-\
                                              pocket, or a watch to take out of it, \
                                              and, burning with curiosity, she ran \
                                              across the field after it, and was just \
                                              in time to see it pop down a large \
                                              rabbit-hold under the hedge."))

    do base.Content <- Label(FormattedText = formattedString,
                             VerticalOptions = LayoutOptions.Center,
                             HorizontalOptions = LayoutOptions.Center)


    