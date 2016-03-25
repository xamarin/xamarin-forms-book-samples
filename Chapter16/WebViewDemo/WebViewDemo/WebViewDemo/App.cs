using System;
using Xamarin.Forms;

namespace WebViewDemo
{
    public class App : Application
    {
        public App()
        {
            MainPage = new WebViewDemoPage();
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
