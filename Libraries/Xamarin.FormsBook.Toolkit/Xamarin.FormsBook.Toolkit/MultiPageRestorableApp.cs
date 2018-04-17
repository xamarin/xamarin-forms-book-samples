using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xamarin.FormsBook.Toolkit
{
    // Derived classes must call Startup(typeof(YourStartPage));
    // Derived classes must call base.OnSleep() in override
    public class MultiPageRestorableApp : Application
    {
        protected void Startup(Type startPageType)
        {
            object value;

            if (Properties.TryGetValue("pageStack", out value))
            {
                MainPage = new NavigationPage();
                RestorePageStack((string)value);
            }
            else
            {
                // First time the program is run.
                Assembly assembly = this.GetType().GetTypeInfo().Assembly;
                Page page = (Page)Activator.CreateInstance(startPageType);
                MainPage = new NavigationPage(page);
            }
        }

        async void RestorePageStack(string pageStack)
        {
            Assembly assembly = GetType().GetTypeInfo().Assembly;
            StringReader reader = new StringReader(pageStack);
            string line = null;

            // Each line is a page in the navigation stack.
            while (null != (line = reader.ReadLine()))
            {
                string[] split = line.Split(' ');
                string pageTypeName = split[0];
                string prefix = split[1] + ' ';
                bool isModal = Boolean.Parse(split[2]);

                // Instantiate the page.
                Type pageType = assembly.GetType(pageTypeName);
                Page page = (Page)Activator.CreateInstance(pageType);

                // Call Restore on the page if it's available.
                if (page is IPersistentPage)
                {
                    ((IPersistentPage)page).Restore(prefix);
                }

                if (!isModal)
                {
                    // Navigate to the next modeless page.
                    await MainPage.Navigation.PushAsync(page, false);

                    // HACK: to allow page navigation to complete!
                    if ((Device.RuntimePlatform == Device.UWP) && 
                            Device.Idiom != TargetIdiom.Phone)
                        await Task.Delay(250);
                }
                else
                {
                    // Navigate to the next modal page.
                    await MainPage.Navigation.PushModalAsync(page, false);

                    // HACK: to allow page navigation to complete!
                    if (Device.RuntimePlatform == Device.iOS)
                        await Task.Delay(100);
                }
            }
        }

        protected override void OnSleep()
        {
            StringBuilder pageStack = new StringBuilder();
            int index = 0;

            // Accumulate the modeless pages in pageStack.
            IReadOnlyList<Page> stack = (MainPage as NavigationPage).Navigation.NavigationStack;
            LoopThroughStack(pageStack, stack, ref index, false);

            // Accumulate the modal pages in pageStack.
            stack = (MainPage as NavigationPage).Navigation.ModalStack;
            LoopThroughStack(pageStack, stack, ref index, true);

            // Save the list of pages.
            Properties["pageStack"] = pageStack.ToString();
        }

        void LoopThroughStack(StringBuilder pageStack, IReadOnlyList<Page> stack, 
                              ref int index, bool isModal)
        {
            foreach (Page page in stack)
            {
                // Skip the NavigationPage that's often at the bottom of the modal stack.
                if (page is NavigationPage)
                    continue;

                pageStack.AppendFormat("{0} {1} {2}", page.GetType().ToString(), index, isModal);
                pageStack.AppendLine();

                if (page is IPersistentPage)
                {
                    string prefix = index.ToString() + ' ';
                    ((IPersistentPage)page).Save(prefix);
                }
                index++;
            }
        }
    }
}
