namespace BlackCat

open System
open System.IO
open System.Reflection
open Xamarin.Forms

type BlackCatPage() = 
    inherit ContentPage(BackgroundColor = Color.White,
                        Padding = match Device.RuntimePlatform with 
                                        | Device.iOS -> Thickness(0.0, 20.0, 0.0, 0.0)
                                        | _ -> Thickness())

    // Create the two StackLayout's.
    let mainStack = StackLayout()
    let textStack = StackLayout(Padding = new Thickness(3.0),
                                Spacing = 10.0)

    // Get access to the text resource.
    let assembly = base.GetType().GetTypeInfo().Assembly
    let resource = "TheBlackCat.txt"

    // Get all the lines of the file.
    let lines = seq { use stream = assembly.GetManifestResourceStream(resource)
                      use reader = new StreamReader(stream)
                      while not reader.EndOfStream do
                          yield reader.ReadLine() }

    // Title line goes in mainStack.
    do mainStack.Children.Add(Label(Text = Seq.head lines,
                                    TextColor = Color.Black,    
                                    HorizontalOptions = LayoutOptions.Center,
                                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof<Label>),
                                    FontAttributes = FontAttributes.Bold))

    // Remaining lines go in textStack.
    do Seq.skip 1 lines
        |> Seq.iter (fun line -> textStack.Children.Add(Label(Text = line,
                                                              TextColor = Color.Black)))

    // Put ScrollView with textStack in mainstack.
    do mainStack.Children.Add(ScrollView(Content = textStack,
                                         VerticalOptions = LayoutOptions.FillAndExpand,
                                         Padding = Thickness(5.0, 0.0)))

    // Set mainStack to page content.
    do base.Content <- mainStack
