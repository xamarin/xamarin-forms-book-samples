namespace ReflectedColors

open System
open System.Reflection
open Xamarin.Forms

type ReflectedColorsPage() = 
    inherit ContentPage()

    let stackLayout = StackLayout()

    // Define function to add Label to StackLayout to display color.
    let AddToStack = fun color name ->
        let backgroundColor = 
            if color = Color.Default then Color.Default
            else 
                // Standard luminance calculation.
                let luminance = 0.30 * color.R +
                                0.59 * color.G +
                                0.11 * color.B 
                if luminance > 0.5 then Color.Black else Color.White

        // Create the Label and add to StackLayout.
        stackLayout.Children.Add(Label(Text = name,
                                       TextColor = color,
                                       FontSize = Device.GetNamedSize(NamedSize.Large, typeof<Label>),
                                       BackgroundColor = backgroundColor)) 

    // Loop through the Color structure fields.
    do for info in typeof<Color>.GetRuntimeFields() do
        if info.IsPublic && 
           info.IsStatic && 
           info.FieldType = typeof<Color> && 
           info.GetCustomAttribute<ObsoleteAttribute>() = null  // Skip the obsolete (i.e. misspelled) colors
        then AddToStack (info.GetValue(null) :?> Color) info.Name
        
    // Loop through the Color structure properties.
    do for info in typeof<Color>.GetRuntimeProperties() do
        let methodInfo = info.GetMethod
        if methodInfo.IsPublic &&
           methodInfo.IsStatic &&
           methodInfo.ReturnType = typeof<Color>
        then AddToStack (info.GetValue(null) :?> Color) info.Name

    do base.Padding <- match Device.RuntimePlatform with 
                            | Device.iOS -> Thickness(5.0, 20.0, 5.0, 5.0)
                            | _ -> Thickness(5.0, 5.0, 5.0, 5.0)

    // Put the StackLayout in a ScrollView.
    do base.Content <- ScrollView(Content = stackLayout)
