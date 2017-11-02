namespace ButtonLogger

open System
open Xamarin.Forms

type ButtonLoggerPage() = 
    inherit ContentPage(Padding = match Device.RuntimePlatform with 
                                        | Device.iOS -> Thickness(5.0, 20.0, 5.0, 0.0)
                                        | _ -> Thickness(5.0, 0.0))

    let mainStack = StackLayout()
    let loggerLayout = StackLayout()

    // Define Button Clicked handler.
    let OnButtonClicked args = 
        // Add Label to scrollable StackLayout.
        loggerLayout.Children.Add(
            Label(Text = "Button clicked at " + DateTime.Now.ToString("T")))

    // Create Button and add to main StackLayout.
    let button = Button(Text = "Log the Click Time")
    do button.Clicked.Add OnButtonClicked
    do mainStack.Children.Add button

    // Assemble the page.
    do mainStack.Children.Add(ScrollView(VerticalOptions = LayoutOptions.FillAndExpand,
                                         Content = loggerLayout))
    do base.Content <- mainStack


