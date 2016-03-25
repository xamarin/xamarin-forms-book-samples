using System;
using Xamarin.Forms;

namespace DataTransfer1
{
    public class App : Application
    {
        public App()
        {
            MainPage = new NavigationPage(new DataTransfer1HomePage());
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
