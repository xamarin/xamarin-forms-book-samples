namespace Hello.iOS

open System
open UIKit
open Foundation

[<Register ("AppDelegate")>]
type AppDelegate () =
    inherit Xamarin.Forms.Platform.iOS.FormsApplicationDelegate()

    // This method is invoked when the application is ready to run.
    override this.FinishedLaunching (app, options) =
        Xamarin.Forms.Forms.Init()
        this.LoadApplication(Hello.App())
        base.FinishedLaunching(app, options)

module Main =
    [<EntryPoint>]
    let main args =
        UIApplication.Main (args, null, "AppDelegate")
        0

