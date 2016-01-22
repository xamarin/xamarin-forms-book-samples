namespace SizedBoxView

open Xamarin.Forms

type SizedBoxViewPage() = 
    inherit ContentPage(BackgroundColor = Color.Pink,
                        Content = BoxView(Color = Color.Navy,
                                          HorizontalOptions = LayoutOptions.Center,
                                          VerticalOptions = LayoutOptions.Center,
                                          WidthRequest = 200.0,
                                          HeightRequest = 100.0))

