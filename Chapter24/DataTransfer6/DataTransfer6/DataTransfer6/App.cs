using System;
using System.Linq;
using Xamarin.Forms;

namespace DataTransfer6
{
    public class App : Application
    {
        public App()
        {
            Xamarin.FormsBook.Toolkit.Toolkit.Init();

            // Load previous AppData if it exists.
            if (Properties.ContainsKey("appData"))
            {
                AppData = AppData.Deserialize((string)Properties["appData"]);
            }
            else
            {
                AppData = new AppData();
            }

            // Launch home page.
            Page homePage = new DataTransfer6HomePage();
            MainPage = new NavigationPage(homePage);

            // Possibly navigate to info page.
            if (Properties.ContainsKey("isInfoPageActive") &&
                (bool)Properties["isInfoPageActive"])
            {
                homePage.Navigation.PushAsync(new DataTransfer6InfoPage(), false);
            }
        }

        public AppData AppData { private set; get; }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Save AppData serialized into string.
            Properties["appData"] = AppData.Serialize();

            // Save Boolean for info page active.
            Properties["isInfoPageActive"] =
                MainPage.Navigation.NavigationStack.Last() is DataTransfer6InfoPage;
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
