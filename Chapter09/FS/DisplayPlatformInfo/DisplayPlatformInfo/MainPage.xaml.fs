namespace DisplayPlatformInfo

open Xamarin.Forms
open Xamarin.Forms.Xaml

type MainPage() =
    inherit ContentPage()
    let _ = base.LoadFromXaml(typeof<MainPage>)
    let platformInfo = DependencyService.Get<IPlatformInfo>()
    let baseStack = base.Content :?> StackLayout
    let stack0 = baseStack.Children.[0] :?> StackLayout
    let stack1 = baseStack.Children.[1] :?> StackLayout
    let contentView0 = stack0.Children.[1] :?> ContentView
    let contentView1 = stack1.Children.[1] :?> ContentView
    let label0 = contentView0.Children.[0] :?> Label
    let label1 = contentView1.Children.[0] :?> Label

    do
        label0.Text <- platformInfo.GetModel()
        label1.Text <- platformInfo.GetVersion();




   
