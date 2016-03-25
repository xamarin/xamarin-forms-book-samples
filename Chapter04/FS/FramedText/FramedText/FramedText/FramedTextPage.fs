namespace FramedText

open Xamarin.Forms

type FramedTextPage() = 
    inherit ContentPage(BackgroundColor = Color.Aqua,
                        Content = Frame(OutlineColor = Color.Black,
                                        BackgroundColor = Color.Yellow,
                                        HorizontalOptions = LayoutOptions.Center,
                                        VerticalOptions = LayoutOptions.Center,
                                        Content = Label(Text = "I've been framed!",
                                                        FontSize = Device.GetNamedSize(NamedSize.Large, typeof<Label>),
                                                        FontAttributes = FontAttributes.Italic,
                                                        TextColor = Color.Blue)))



