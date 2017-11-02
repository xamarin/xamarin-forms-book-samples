namespace ColorBlocks

open System
open System.Reflection
open Xamarin.Forms

type ColorBlocksPage() = 
    inherit ContentPage(Padding = match Device.RuntimePlatform with 
                                        | Device.iOS -> Thickness(5.0, 20.0, 5.0, 5.0)
                                        | _ -> Thickness(5.0, 5.0, 5.0, 5.0))

    let stackLayout = StackLayout()

                    // Color fields to (color, name) tuples.
    do Seq.append   (typeof<Color>.GetRuntimeFields()
                        |> Seq.filter (fun field -> field.IsPublic && 
                                                    field.IsStatic && 
                                                    field.FieldType = typeof<Color> &&
                                                    field.GetCustomAttribute<ObsoleteAttribute>() = null)  // Skip the obsolete (i.e. misspelled) colors)
                        |> Seq.map (fun field -> (field.GetValue(null) :?> Color, field.Name)))

                    // Color properties to (color, name) tuples.
                    (typeof<Color>.GetRuntimeProperties()
                        |> Seq.filter (fun prop -> let methodInfo = prop.GetMethod
                                                   methodInfo.IsPublic && 
                                                   methodInfo.IsStatic && 
                                                   methodInfo.ReturnType = typeof<Color>)
                        |> Seq.map (fun prop -> (prop.GetValue(null) :?> Color, prop.Name)))

        // (color, name) tuples to Frame objects.
        |> Seq.map (fun info -> let color = fst(info)
                                let name = snd(info)

                                let horzStack = StackLayout(Orientation = StackOrientation.Horizontal,
                                                            Spacing = 15.0)
                                horzStack.Children.Add(BoxView(Color = color))
                                horzStack.Children.Add(Label(Text = name,
                                                             FontSize = Device.GetNamedSize(NamedSize.Large, typeof<Label>),
                                                             FontAttributes = FontAttributes.Bold,
                                                             VerticalOptions = LayoutOptions.Center,
                                                             HorizontalOptions = LayoutOptions.StartAndExpand))

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

                                Frame(Content = horzStack,
                                      OutlineColor = Color.Accent,
                                      Padding = Thickness(5.0)))

        // Put each Frame in the main StackLayout.
        |> Seq.iter (fun frame -> stackLayout.Children.Add(frame))      
      
    // Put the StackLayout in a ScrollView.
    do base.Content <- ScrollView(Content = stackLayout)
