using System;
using Xamarin.Forms;
using Xamarin.FormsBook.Toolkit;

namespace NoteTaker
{
    public class App : MultiPageRestorableApp
    {
        public App()
        {
            Xamarin.FormsBook.Platform.Toolkit.Init();

            // This loads all the existing .note files.
            NoteFolder = new NoteFolder();

            // Make call to method in MultiPageRestorableApp.
            Startup(typeof(NoteTakerHomePage));
        }

        public NoteFolder NoteFolder { private set; get; }

        protected override void OnSleep()
        {
            // Required call when deriving from MultiPageRestorableApp.
            base.OnSleep();
        }

        // Special processing for iOS.
        protected override void OnResume()
        {
            NoteTakerNotePage notePage = 
                ((NavigationPage)MainPage).CurrentPage as NoteTakerNotePage;

            if (notePage != null)
                notePage.OnResume();
        }
    }
}
