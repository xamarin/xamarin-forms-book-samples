namespace ButtonLambdas

open Xamarin.Forms

type ButtonLambdasPage() = 
    inherit ContentPage()

    // Number to manipulate.
    let mutable number = 1.0

    // Create the Label for display.
    let label = Label(Text = number.ToString(),
                      FontSize = Device.GetNamedSize(NamedSize.Large, typeof<Label>),
                      HorizontalOptions = LayoutOptions.Center,
                      VerticalOptions = LayoutOptions.CenterAndExpand)

    // Create the first Button and attach Clicked handler.
    let timesButton = Button(Text = "Double",
                             FontSize = Device.GetNamedSize(NamedSize.Large, typeof<Button>),
                             HorizontalOptions = LayoutOptions.CenterAndExpand)

    do timesButton.Clicked.Add(fun _ -> number <- number * 2.0
                                        do label.Text <- number.ToString())

    // Create the second Button and attach Clicked handler.
    let divideButton = Button(Text = "Half",
                              FontSize = Device.GetNamedSize(NamedSize.Large, typeof<Button>),
                              HorizontalOptions = LayoutOptions.CenterAndExpand)

    do divideButton.Clicked.Add(fun _ -> number <- number / 2.0
                                         do label.Text <- number.ToString())

    // Assemble the page.
    let buttonStack = StackLayout(Orientation = StackOrientation.Horizontal,
                                  VerticalOptions = LayoutOptions.CenterAndExpand)
    do buttonStack.Children.Add timesButton
    do buttonStack.Children.Add divideButton

    let mainStack = StackLayout()
    do mainStack.Children.Add label
    do mainStack.Children.Add buttonStack

    do base.Content <- mainStack

