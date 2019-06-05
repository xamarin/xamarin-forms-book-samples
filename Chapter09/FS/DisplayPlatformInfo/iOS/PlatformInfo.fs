namespace DisplayPlatformInfo.iOS

open UIKit
open System
open DisplayPlatformInfo
open Foundation
open Xamarin.Forms
open Xamarin.Forms.Xaml

type PlatformInfo () =
    interface IPlatformInfo with
        member this.GetModel () = 
            let device = new UIDevice()
            device.Model.ToString()
        member this.GetVersion () = 
            let device = new UIDevice()
            String.Format("{0} {1}", device.SystemName, device.SystemVersion)

module DisplayPlatform =
    [<assembly: Dependency(typeof<PlatformInfo>)>]
    do()




