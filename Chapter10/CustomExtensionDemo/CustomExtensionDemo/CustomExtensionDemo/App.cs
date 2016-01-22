using System;
using Xamarin.Forms;

namespace CustomExtensionDemo
{
    public class App : Application
    {
        public App()
        {
            new Xamarin.FormsBook.Toolkit.HslColorExtension();

            MainPage = new CustomExtensionDemoPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
