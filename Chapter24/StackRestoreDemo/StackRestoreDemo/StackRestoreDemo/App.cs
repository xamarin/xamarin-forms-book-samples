using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace StackRestoreDemo
{
    // Notice that App is derived from MultiPageRestorableApp.
    public class App : Xamarin.FormsBook.Toolkit.MultiPageRestorableApp
    {
        public App()
        {
            // Must call Startup with type of start page!
            Startup(typeof(DemoMainPage));
        }

        protected override void OnSleep()
        {
            // Must call base implementation!
            base.OnSleep();
        }
    }
}
