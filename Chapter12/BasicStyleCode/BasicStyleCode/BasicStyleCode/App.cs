using System;
using Xamarin.Forms;

namespace BasicStyleCode
{
    public class App : Application
    {
        public App()
        {
            MainPage = new BasicStyleCodePage();
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
