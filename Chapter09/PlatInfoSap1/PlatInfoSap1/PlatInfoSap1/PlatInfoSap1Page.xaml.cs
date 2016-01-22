using System;
using Xamarin.Forms;

#if __IOS__
using UIKit;

#elif __ANDROID__
using Android.OS;

#elif WINDOWS_PHONE
using Microsoft.Phone.Info;

#elif WINDOWS_APP || WINDOWS_PHONE_APP
using Windows.Security.ExchangeActiveSyncProvisioning;

#elif WINDOWS_UWP
using Windows.Security.ExchangeActiveSyncProvisioning;

#endif

namespace PlatInfoSap1
{
	public partial class PlatInfoSap1Page : ContentPage
    {
		public PlatInfoSap1Page ()
        {
            InitializeComponent ();

#if __IOS__

            UIDevice device = new UIDevice();
            modelLabel.Text = device.Model.ToString();
            versionLabel.Text = String.Format("{0} {1}", device.SystemName, 
                                                         device.SystemVersion);

#elif __ANDROID__

            modelLabel.Text = String.Format("{0} {1}", Build.Manufacturer, 
                                                       Build.Model);
            versionLabel.Text = Build.VERSION.Release.ToString();

#elif WINDOWS_PHONE

            modelLabel.Text = String.Format("{0} {1}", DeviceStatus.DeviceManufacturer, 
                                                       DeviceStatus.DeviceName);
            versionLabel.Text = Environment.OSVersion.ToString();

#elif WINDOWS_APP || WINDOWS_PHONE_APP

            EasClientDeviceInformation devInfo = new EasClientDeviceInformation();
            modelLabel.Text = String.Format("{0} {1}", devInfo.SystemManufacturer, 
                                                       devInfo.SystemProductName);
            versionLabel.Text = devInfo.OperatingSystem;

#elif WINDOWS_UWP

            EasClientDeviceInformation devInfo = new EasClientDeviceInformation();
            modelLabel.Text = String.Format("{0} {1}", devInfo.SystemManufacturer, 
                                                       devInfo.SystemProductName);
            versionLabel.Text = devInfo.OperatingSystem;
#endif

        }
    }
}
