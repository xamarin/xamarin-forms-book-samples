using System;
using System.Linq;
using Xamarin.Forms;

namespace DataTransfer5
{
    public class App : Application
    {
        public App()
        {
            Xamarin.FormsBook.Toolkit.Toolkit.Init();

            // Instantiate AppData and set property.
            AppData = new AppData();

            // Go to the home page.
            MainPage = new NavigationPage(new DataTransfer5HomePage());
        }

        public AppData AppData { private set; get; }

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
