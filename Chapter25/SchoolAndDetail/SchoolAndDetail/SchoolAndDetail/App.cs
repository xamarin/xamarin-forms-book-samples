using System;
using Xamarin.Forms;

namespace SchoolAndDetail
{
    public class App : Application
    {
        public App()
        {
            SchoolOfFineArt.Library.Init();

            MainPage = new SchoolAndDetailPage();
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
