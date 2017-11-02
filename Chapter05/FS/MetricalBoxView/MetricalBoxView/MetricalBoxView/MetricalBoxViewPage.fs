namespace MetricalBoxView

open Xamarin.Forms

type MetricalBoxViewPage() = 
    inherit ContentPage(Content = BoxView(Color = Color.Accent,
                                          WidthRequest = 64.0,
                                          HeightRequest = 160.0,
                                          HorizontalOptions = LayoutOptions.Center,
                                          VerticalOptions = LayoutOptions.Center))

