namespace EmpiricalFontSize

open System
open Xamarin.Forms

type FontCalc(label : Label, fontSize : float, containerWidth : float) =

    // Recalculate the size of the Label with the specified font size
    do label.FontSize <- fontSize
    let sizeRequest = label.Measure(containerWidth, Double.PositiveInfinity)

    // Save the font size and the resultant Label height in public properties.
    member val FontSize = fontSize

    member val TextHeight = sizeRequest.Request.Height






