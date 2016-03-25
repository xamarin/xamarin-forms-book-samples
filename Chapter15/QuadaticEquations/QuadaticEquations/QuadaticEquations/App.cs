using System;
using Xamarin.Forms;

namespace QuadaticEquations
{
    public class App : Application
    {
        public App()
        {
            MainPage = new QuadraticEquationsPage();
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
