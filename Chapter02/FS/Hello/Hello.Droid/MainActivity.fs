namespace Hello.Droid

open System

open Android.App
open Android.Content
open Android.OS
open Android.Runtime
open Android.Views
open Android.Widget

[<Activity (Label = "Hello.Droid", Theme = "@style/MainTheme", MainLauncher = true)>]
type MainActivity () =
    inherit Xamarin.Forms.Platform.Android.FormsAppCompatActivity ()

    override this.OnCreate (bundle) =
        TabLayoutResource = Resource.Layout.Tabbar
        ToolbarResource = Resource.Layout.Toolbar

        base.OnCreate (bundle)

        Xamarin.Forms.Forms.Init(this, bundle)
        this.LoadApplication(Hello.App())



