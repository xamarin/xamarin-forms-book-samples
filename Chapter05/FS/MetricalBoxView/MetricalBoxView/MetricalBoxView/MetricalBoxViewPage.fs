namespace MetricalBoxView

open Xamarin.Forms

type MetricalBoxViewPage() = 
    inherit ContentPage(Content = BoxView(Color = Color.Accent,
                                          WidthRequest = Device.OnPlatform(64.0, 64.0, 96.0),
                                          HeightRequest = Device.OnPlatform(160.0, 160.0, 240.0),
                                          HorizontalOptions = LayoutOptions.Center,
                                          VerticalOptions = LayoutOptions.Center))

