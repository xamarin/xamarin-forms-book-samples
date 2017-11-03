namespace EmpiricalFontSize

open Xamarin.Forms

type EmpiricalFontSizePage() = 
    inherit ContentPage(Padding = match Device.RuntimePlatform with 
                                        | Device.iOS -> Thickness(0.0, 20.0, 0.0, 0.0)
                                        | _ -> Thickness())
    let label = Label()
    let contentView = ContentView(Content = label)
    do base.Content <- contentView

    do contentView.SizeChanged.Add(fun args -> 
        if contentView.Width <> 0.0 && contentView.Height <> 0.0 then
            do label.Text <- "This is a paragraph of text displayed with \
                              a FontSize value of 00 that is empirically \
                              calculated with a recursive function within \
                              the SizeChanged handler of the Label's \
                              container. This technique can be tricky: You \
                              don't want to get into an infinite loop by \
                              triggering a layout pass with every \
                              calculation. Does it work?"

            // Define recursive function for finding the optimum font size.
            let rec FindOptimumSize lower upper =
                // Calculate two dimensions of the rendered text.
                let lowerFontCalc = FontCalc(label, lower, contentView.Width)
                let upperFontCalc = FontCalc(label, upper, contentView.Width)

                // Continue the recursion if we're not within a single pixel.
                if upperFontCalc.FontSize - lowerFontCalc.FontSize > 1.0 then

                    // Get the average font size of the upper and lower bounds.
                    let avgFontSize = (lowerFontCalc.FontSize + upperFontCalc.FontSize) / 2.0
                    let newFontCalc = FontCalc(label, avgFontSize, contentView.Width)

                    // Check the new text height against the constainer height,
                    //  and recursively call this function.
                    if (newFontCalc.TextHeight > contentView.Height) then
                        FindOptimumSize lower newFontCalc.FontSize

                    else FindOptimumSize newFontCalc.FontSize upper

                // Return the lower of the two values within one pixel.  
                else lowerFontCalc.FontSize

            // Call the recursive function to find the optimum font size.
            let fontSize = FindOptimumSize 10.0 100.0

            // Set the final font size and the text with the embedded value.
            do label.FontSize <- fontSize
            do label.Text <- label.Text.Replace("00", fontSize.ToString("F0"))
        )
                                                

