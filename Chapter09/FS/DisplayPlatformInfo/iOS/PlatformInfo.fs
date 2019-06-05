namespace DisplayPlatformInfo.iOS

open UIKit
open System
open DisplayPlatformInfo
open Foundation
open Xamarin.Forms
open Xamarin.Forms.Xaml

type PlatformInfo () =
    let device = new UIDevice()

    interface IPlatformInfo with
        member this.GetModel () = device.Model.ToString()

        member this.GetVersion () = sprintf "%s %s" device.SystemName device.SystemVersion

module DisplayPlatform =
    [<assembly: Dependency(typeof<PlatformInfo>)>]
    do()




