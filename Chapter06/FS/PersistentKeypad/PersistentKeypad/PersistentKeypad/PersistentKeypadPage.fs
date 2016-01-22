namespace PersistentKeypad

open System
open Xamarin.Forms

type PersistentKeypadPage() = 
    inherit ContentPage()

    // Create a vertical stack for the entire keypad.
    let mainStack = StackLayout(VerticalOptions = LayoutOptions.Center,
                                HorizontalOptions = LayoutOptions.Center)

    // First row is the display Label.
    let displayLabel = Label(FontSize = Device.GetNamedSize(NamedSize.Large, typeof<Label>),
                             VerticalOptions = LayoutOptions.Center,
                             HorizontalTextAlignment = TextAlignment.End)

    do mainStack.Children.Add displayLabel

    // Second row is the backspace button.
    let backspaceButton = Button(Text = "\u21E6",
                                 FontSize = Device.GetNamedSize(NamedSize.Large, typeof<Button>),
                                 IsEnabled = false)

    do backspaceButton.Clicked.Add(fun _ -> 
        let text = displayLabel.Text
        do displayLabel.Text <- text.Substring(0, text.Length - 1)
        do backspaceButton.IsEnabled <- displayLabel.Text.Length > 0

        // Save keypad text.
        let app = Application.Current :?> App
        do app.DisplayLabelText <- displayLabel.Text
        )

    do mainStack.Children.Add backspaceButton

    // Define Clicked handler for digit buttons.                                            
    let OnDigitButtonClicked = EventHandler(fun sender args ->
        let button = sender :?> Button
        do displayLabel.Text <- displayLabel.Text + button.StyleId
        do backspaceButton.IsEnabled <- true

        // Save keypad text.
        let app = Application.Current :?> App
        do app.DisplayLabelText <- displayLabel.Text
        )

    // Now do the 10 number keys.
    let largeFont = Device.GetNamedSize(NamedSize.Large, typeof<Button>)

    do [ [1; 2; 3]; [4; 5; 6]; [7; 8; 9]; [0] ]
        |> List.iter (fun digits -> 
            // Create the StackLayout for the row of each group of digits.
            let rowStack = StackLayout(Orientation = StackOrientation.Horizontal)
            do mainStack.Children.Add(rowStack)
            digits 
            |> List.iter (fun digit -> 
                // Create the Button for each digit.
                let digitButton = new Button(Text = digit.ToString(),
                                             FontSize = largeFont,
                                             StyleId = digit.ToString())

                // For the zero button, expand to fill horizontally.
                do if digit = 0 then do digitButton.HorizontalOptions <- LayoutOptions.FillAndExpand

                do digitButton.Clicked.AddHandler OnDigitButtonClicked
                do rowStack.Children.Add(digitButton)))

    do base.Content <- mainStack

    // New code for loading previous keypad text.
    let app = Application.Current :?> App
    do displayLabel.Text <- app.DisplayLabelText
    do backspaceButton.IsEnabled <- not (String.IsNullOrEmpty displayLabel.Text)

and App() = 
    inherit Application()

    let displayLabelKey = "displayLabelText"
    let mutable displayLabelText : string = ""

    do if base.Properties.ContainsKey(displayLabelKey) then
        do displayLabelText <- base.Properties.[displayLabelKey] :?> string

    do base.MainPage <- PersistentKeypadPage()

    member this.DisplayLabelText
        with set(value) = displayLabelText <- value
        and get() = displayLabelText

    override this.OnSleep() = 
        do base.Properties.[displayLabelKey] <- this.DisplayLabelText
