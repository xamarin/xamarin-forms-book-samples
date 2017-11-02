namespace Baskervilles

open Xamarin.Forms

type BaskervillesPage() = 
    inherit ContentPage(Content = Label(Text = "Mr. Sherlock Holmes, who was usually very late in \
                                                the mornings, save upon those not infrequent \
                                                occasions when he was up all night, was seated at \
                                                the breakfast table. I stood upon the hearth-rug \
                                                and picked up the stick which our visitor had left \
                                                behind him the night before. It was a fine, thick \
                                                piece of wood, bulbous-headed, of the sort which \
                                                is known as a \u201CPenang lawyer.\u201D Just \
                                                under the head was a broad silver band, nearly an \
                                                inch across, \u201CTo James Mortimer, M.R.C.S., \
                                                from his friends of the C.C.H.,\u201D was engraved \
                                                upon it, with the date \u201C1884.\u201D It was \
                                                just such a stick as the old-fashioned family \
                                                practitioner used to carry\u2014dignified, solid, \
                                                and reassuring.",
                                        VerticalOptions = LayoutOptions.Center),
                        Padding = match Device.RuntimePlatform with 
                                        | Device.iOS -> Thickness(5.0, 20.0, 5.0, 5.0)
                                        | _ -> Thickness(5.0, 5.0, 5.0, 5.0))
    