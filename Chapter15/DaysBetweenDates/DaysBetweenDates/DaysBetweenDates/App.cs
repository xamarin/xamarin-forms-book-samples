using System;
using Xamarin.Forms;

namespace DaysBetweenDates
{
    public class App : Application
    {
        public App()
        {
            MainPage = new DaysBetweenDatesPage();
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
