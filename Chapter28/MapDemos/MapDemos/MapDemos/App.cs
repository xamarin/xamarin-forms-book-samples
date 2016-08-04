using System;
using Xamarin.Forms;

namespace MapDemos
{
    public class App : Application
    {
        public App()
        {
            Xamarin.FormsBook.Toolkit.Toolkit.Init();
            Xamarin.FormsBook.Toolkit.Maps.Toolkit.Init();

            MainPage = new NavigationPage(new MapDemosHomePage());
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
