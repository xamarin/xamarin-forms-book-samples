namespace EstimatedFontSize

open System
open Xamarin.Forms

type EstimatedFontSizePage() = 
    inherit ContentPage(Padding = match Device.RuntimePlatform with 
                                        | Device.iOS -> Thickness(0.0, 20.0, 0.0, 0.0)
                                        | _ -> Thickness())

    let label = Label()
    let contentView = ContentView(Content = label)
    do base.Content <- contentView

    do contentView.SizeChanged.Add(fun args -> 
        let text = "A default system font with a font size of S \
                    has a line height of about ({0:F1} * S) and an \
                    average character width of about ({1:F1} * S). \
                    On this page, which has a width of {2:F0} and a \
                    height of {3:F0}, a font size of ?1 should \
                    comfortably render the ??2 characters in this \
                    paragraph with ?3 lines and about ?4 characters \
                    per line. Does it work?"

        // Define two values as multiples of font size.
        let lineHeight = match Device.RuntimePlatform with
                                | Device.iOS -> 1.2
                                | Device.Android -> 1.2
                                | _ -> 1.3
        let charWidth = 0.5

        // Format the text and get its character length.
        let text = String.Format(text, lineHeight, charWidth, contentView.Width, contentView.Height)
        let charCount = text.Length
        
        // Because:
        //   lineCount = contentView.Height / (lineHeight * fontSize)
        //   charsPerLine = contentView.Width / (charWidth * fontSize)
        //   charCount = lineCount * charsPerLine
        // Hence, solving for fontSize:
        let fontSize = int (Math.Sqrt(contentView.Width * contentView.Height / 
                                      (float charCount * lineHeight * charWidth)))

        // Now these values can be calculated.
        let lineCount = int (contentView.Height / (lineHeight * float fontSize))
        let charsPerLine = int (contentView.Width / (charWidth * float fontSize))

        // Replace the placeholders with the values.
        let text = text.Replace("?1", fontSize.ToString())
        let text = text.Replace("??2", charCount.ToString())
        let text = text.Replace("?3", lineCount.ToString())
        let text = text.Replace("?4", charsPerLine.ToString())

        // Set the Label properties.
        do label.Text <- text
        do label.FontSize <- float fontSize
        )

