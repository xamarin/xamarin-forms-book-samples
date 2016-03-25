using System;
using Xamarin.Forms;

namespace JustNotes
{
    public class App : Application
    {
        public App()
        {
            MainPage = new NavigationPage(new JustNotesPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            ((JustNotesPage)(((NavigationPage)MainPage).CurrentPage)).OnSleep();
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
