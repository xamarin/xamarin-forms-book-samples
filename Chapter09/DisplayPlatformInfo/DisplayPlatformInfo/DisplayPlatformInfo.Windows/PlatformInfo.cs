using System;
using Windows.Security.ExchangeActiveSyncProvisioning;
using Xamarin.Forms;

[assembly: Dependency(typeof(DisplayPlatformInfo.Windows.PlatformInfo))]

namespace DisplayPlatformInfo.Windows
{
    public class PlatformInfo : IPlatformInfo
    {
        EasClientDeviceInformation devInfo = new EasClientDeviceInformation();

        public string GetModel()
        {
            return String.Format("{0} {1}", devInfo.SystemManufacturer, 
                                            devInfo.SystemProductName);
        }

        public string GetVersion()
        {
            return devInfo.OperatingSystem;
        }
    }
}
