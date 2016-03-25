using System;
using Xamarin.Forms;

namespace CellContextMenu
{
    public class App : Application
    {
        public App()
        {
            SchoolOfFineArt.Library.Init();
 
            MainPage = new CellContextMenuPage();
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
