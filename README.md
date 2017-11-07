# xamarin-forms-book-samples

Sample code for the book *Creating Mobile Apps with Xamarin.Forms*. The book can be downloaded from http://developer.xamarin.com/guides/cross-platform/xamarin-forms/creating-mobile-apps-xamarin-forms/.

## Notes

### Loading the NuGet Packages

The Xamarin.Forms NuGet packages are not part of these projects. They must be downloaded for each project.

To avoid hassles, download the NuGet packages for the solutions in the **Libraries** directory first. You'll want to load each library solutions into Visual Studio, right-click the solution name in the **Solution List** and select **Manage NuGet Packages for Solution**. A notice should appear at the top of the **Manage NuGet Packages** dialog that says "Some NuGet packages are missing from this solution. Click to restore from you online package sources." Click the **Restore** button and then the **Close** button. Build the library.

Do the same thing with the other library solutions in the **Libraries** directory.

You can then load any of the application projects. For each project, again right-click the solution name, select **Manage NuGet Packages for Solution** and go through the same process.

### The Branches

The **original-code-from-book** branch of this repository contains the code as it appeared in the *Creating Mobile Apps with Xamarin.Forms* book. The only change is that the projects have been updated to the latest Xamarin.Forms version.

The projects in the **master** branch reflect changes in C# and Xamarin.Forms since the writing of the book. These changes are:

- In code files, the deprecated `Device.OnPlatform` calls have been replaced with logic using the `Device.RuntimePlatform` property.
- In XAML files, deprecated properties of the `OnPlatform` class have been replaced with `On` objects.
- The use of the deprecated `Device.TargetPlatform` property have been replaced with `Device.RuntimePlatform`.
- Calls to the deprecated `VisualElement.GetSizeRequest` method have been replaced with calls to `Measure`.
- Overrides of the deprecated `VisualElement.OnSizeRequest` method have been replaced with overrides of `OnMeasure`.
- Calls to and implementations of the deprecated `TypeConverter.ConvertFrom` method have been replaced with `ConvertFromInvariantString`.
- The `NamedColor` class is now based on the `Color` structure rather than its own static fields.
- The Android projects have been upgraded to use AppCompat and Material Design. This is consistent with recent Xamarin.Forms project templates.
- The blank bitmaps in the **Assets** folder of the UWP projects have been replaced with Xamagon images. 
- Event firing uses the null-conditional operator (`?.`) and the `Invoke` method.

### The Projects

These solutions contain five application projects:

- **iOS**: iPhone and iPads
- **Droid**: Android phones and tablets
- **UWP**: The Universal Windows Platform, targeting Windows 10 tablets and desktop computers, and Windows 10 Mobile
- **Windows**: Windows 8.1 tablets and desktop computers using the Windows Runtime API
- **WinPhone**: Windows Phone 8.1 devices using the Windows Phone API.

You can deploy the **UWP** project to devices or emulators. 
However, you must select the correct platform for the deployment target. 
You generally do this by selecting a platform for the solution in the **Solution Platform** dropdown on the **Standard** toolbar.
Or, you can invoke the **Configuration Manager** dialog form the **Build | Configuration Manager** menu item, and select an item from the **Active solution platform** dropdown at the top right.

The six possible **Solution Platform** options are listed below. 
Each is associated with a particular platform for the **UWP** project. 
This platform refers to processor architectures:

- Any CPU: UWP platform is x86
- ARM: UWP platform is ARM
- iPhone: UWP platform is x86
- iPhone Simulator: UWP platform is x86
- x86: UWP platform is x86
- x64: UWP platform is x64

These reflect the only three possibilities for the **UWP** project. 
As you can see, x86 (32-bit Intel architecture) is considered to be the default.

Currently, you can deploy the **UWP** project in several different ways based on a selection in the dropdown on the **Standard** toolbar.

- Select **Local Machine** to deploy directly to the Windows 10 desktop. The **UWP** platform must be x86 or x64.

- Select **Simulator** to deploy to a Windows 10 simulator window. The **UWP** platform must be x86.

- Select one of the items beginning with the words **Mobile Emulator 10.0** to deploy to a Windows 10 Mobile emulator. The **UWP** platform must be x86.

- Select **Device** to deploy to a Windows 10 Mobile device. The **UWP** platform must be ARM.

### Version upgrades

As of August 12, 2016, all sample code has been upgraded to Xamarin.Forms version 2.3.1.114.

As of November 23, 2016, all sample code has been upgraded to Xamarin.Forms version 2.3.3.168.

As of May 2, 2017, all sample code has been upgraded to Xamarin.Forms version 2.3.4.231.

As of November 3, 2017, all sample code has been upgraded to Xamarin.Forms version 2.4.0.38779.


