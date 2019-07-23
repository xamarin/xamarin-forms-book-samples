---
name: 'Xamarin.Forms Book - ColorBlocks F#'
description: "Xamarin.Forms sample that renders blocks of color, written in F#"
page_type: sample
languages:
- fsharp
products:
- xamarin
urlFragment: chapter04-fs-colorblocks
---
# Greetings F\# in Xamarin.Forms

Simple Xamarin.Forms application written in F#, rendering blocks of color:

```fsharp
let vertStack = StackLayout(HorizontalOptions = LayoutOptions.End)
vertStack.Children.Add(Label(Text = String.Format("{0:X2}-{1:X2}-{2:X2}",
                                                    int (255.0 * color.R),
                                                    int (255.0 * color.G),
                                                    int (255.0 * color.B)),
                                VerticalOptions = LayoutOptions.CenterAndExpand,
                                IsVisible = (color <> Color.Default)))
vertStack.Children.Add(Label(Text = String.Format("{0:F2}-{1:F2}-{2:F2}",
                                                    color.Hue,
                                                    color.Saturation,
                                                    color.Luminosity),
                                VerticalOptions = LayoutOptions.CenterAndExpand,
                                IsVisible = (color <> Color.Default)))
horzStack.Children.Add(vertStack)
```
