namespace DisplayPlatformInfo.Droid

open DisplayPlatformInfo
open Android.OS
open Xamarin.Forms

type PlatformInfo () =
    interface IPlatformInfo with
        member this.GetModel () = sprintf "%s %s" Build.Manufacturer Build.Model

        member this.GetVersion () = Build.VERSION.Release.ToString()

module DisplayPlatform =
    [<assembly: Dependency(typeof<PlatformInfo>)>]
    do()
