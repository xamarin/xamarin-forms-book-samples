using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace DataTransfer4
{
    public class App : Application
    {
        public App()
        {
            // Create the ObservableCollection for the Information items.
            InfoCollection = new ObservableCollection<Information>();

            MainPage = new NavigationPage(new DataTransfer4HomePage());
        }

        public IList<Information> InfoCollection { private set; get; }

        public Information CurrentInfoItem { set; get; }


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
