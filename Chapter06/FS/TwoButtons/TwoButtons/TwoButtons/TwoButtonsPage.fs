namespace TwoButtons

open System
open Xamarin.Forms

type TwoButtonsPage() = 
    inherit ContentPage(Padding = Thickness(5.0, Device.OnPlatform(20.0, 0.0, 0.0), 5.0, 0.0))

    let mainStack = StackLayout()
    let buttonStack = StackLayout(Orientation = StackOrientation.Horizontal)
    let loggerLayout = StackLayout()

    // Create Button views and add to buttonStack.
    let addButton = Button(Text = "Add",
                           HorizontalOptions = LayoutOptions.CenterAndExpand)
    do buttonStack.Children.Add(addButton)
    
    let removeButton = Button(Text = "Remove",
                              HorizontalOptions = LayoutOptions.CenterAndExpand,
                              IsEnabled = false)
    do buttonStack.Children.Add(removeButton)

    // Clicked handler for both buttons.
    let OnButtonClicked = EventHandler(fun sender args -> 
        let button = sender :?> Button
        if (button = addButton) then
            // Add Label to scrollable StackLayout.
            do loggerLayout.Children.Add(Label(Text = "Button clicked at " + DateTime.Now.ToString("T")))
        else
            // Remove topmost Label from StackLayout.
            do loggerLayout.Children.RemoveAt(0)

        // Enable "Remove" button only if children are present.
        do removeButton.IsEnabled <- loggerLayout.Children.Count > 0)

    // Attach Clicked handler to both buttons
    do addButton.Clicked.AddHandler OnButtonClicked
    do removeButton.Clicked.AddHandler OnButtonClicked

    // Assemble the page.
    do mainStack.Children.Add(buttonStack)
    do mainStack.Children.Add(ScrollView(VerticalOptions = LayoutOptions.FillAndExpand,
                                         Content = loggerLayout))
    do base.Content <- mainStack


