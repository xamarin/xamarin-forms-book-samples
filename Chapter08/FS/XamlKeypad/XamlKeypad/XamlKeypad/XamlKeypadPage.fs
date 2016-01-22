namespace XamlKeypad

open System
open Xamarin.Forms
open Xamarin.Forms.Xaml

type XamlKeypadPage() = 
    inherit ContentPage()

    // Experimental code only! 
    // This is not the way XAML will be processed ultimately!
    // ------------------------------------------------------
    do base.LoadFromXaml(typeof<XamlKeypadPage>) |> ignore
    let displayLabel = base.FindByName<Label>("displayLabel")
    let backspaceButton = base.FindByName<Button>("backspaceButton")

    // Get text content the last time the program went to sleep.
    let app = Application.Current :?> App
    do displayLabel.Text <- app.DisplayLabelText
    do backspaceButton.IsEnabled <- displayLabel.Text <> null && 
                                    displayLabel.Text.Length > 0

    member this.OnDigitButtonClicked(sender : Object, args : EventArgs) = 
        let button = sender :?> Button
        do displayLabel.Text <- displayLabel.Text + button.StyleId
        do backspaceButton.IsEnabled <- true
        do app.DisplayLabelText <- displayLabel.Text
        
    member this.OnBackspaceButtonClicked(sender : Object, args : EventArgs) =
        let text = displayLabel.Text
        do displayLabel.Text <- text.Substring(0, text.Length - 1)
        do backspaceButton.IsEnabled <- displayLabel.Text.Length > 0
        do app.DisplayLabelText <- displayLabel.Text

and App() = 
    inherit Application()

    let displayLabelKey = "displayLabelText"
    let mutable displayLabelText : string = ""

    do if base.Properties.ContainsKey(displayLabelKey) then
        do displayLabelText <- base.Properties.[displayLabelKey] :?> string

    do base.MainPage <- XamlKeypadPage()

    member this.DisplayLabelText
        with set(value) = displayLabelText <- value
        and get() = displayLabelText

    override this.OnSleep() = 
        do base.Properties.[displayLabelKey] <- this.DisplayLabelText
