using System;
using Xamarin.Forms;
using SchoolOfFineArt;

namespace StudentNotes
{
    public class App : Application
    {
        public App()
        {
            ViewModel = new SchoolViewModel(Properties);

            MainPage = new NavigationPage(new StudentNotesHomePage());
        }

        public SchoolViewModel ViewModel
        {
            private set; get;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            ViewModel.SaveNotes(Properties);
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
