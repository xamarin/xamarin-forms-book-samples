using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace SinglePageNavigation
{
    public partial class SinglePageNavigationPage : ContentPage
    {
        static int count = 0;
        static bool firstPageAppeared = false;
        static readonly string separator = new string('-', 20);

        public SinglePageNavigationPage()
        {
            InitializeComponent();

            // Set Title to zero-based instance of this class.
            Title = "Page " + count++;
        }

        async void OnGoToModelessClicked(object sender, EventArgs args)
        {
            SinglePageNavigationPage newPage = new SinglePageNavigationPage();
            Debug.WriteLine(separator);
            Debug.WriteLine("Calling PushAsync from {0} to {1}", this, newPage);
            await Navigation.PushAsync(newPage);
            Debug.WriteLine("PushAsync completed");

            // Display the page stack information on this page.
            newPage.DisplayInfo();
        }

        async void OnGoToModalClicked(object sender, EventArgs args)
        {
            SinglePageNavigationPage newPage = new SinglePageNavigationPage();
            Debug.WriteLine(separator);
            Debug.WriteLine("Calling PushModalAsync from {0} to {1}", this, newPage);
            await Navigation.PushModalAsync(newPage);
            Debug.WriteLine("PushModalAsync completed");

            // Display the page stack information on this page.
            newPage.DisplayInfo();
        }

        async void OnGoBackModelessClicked(object sender, EventArgs args)
        {
            Debug.WriteLine(separator);
            Debug.WriteLine("Calling PopAsync from {0}", this);
            Page page = await Navigation.PopAsync();
            Debug.WriteLine("PopAsync completed and returned {0}", page);

            // Display the page stack information on the page being returned to.
            NavigationPage navPage = (NavigationPage)App.Current.MainPage;
            ((SinglePageNavigationPage)navPage.CurrentPage).DisplayInfo();
        }

        async void OnGoBackModalClicked(object sender, EventArgs args)
        {
            Debug.WriteLine(separator);
            Debug.WriteLine("Calling PopModalAsync from {0}", this);
            Page page = await Navigation.PopModalAsync();
            Debug.WriteLine("PopModalAsync completed and returned {0}", page);

            // Display the page stack information on the page being returned to.
            NavigationPage navPage = (NavigationPage)App.Current.MainPage;
            ((SinglePageNavigationPage)navPage.CurrentPage).DisplayInfo();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Debug.WriteLine("{0} OnAppearing", Title);

            if (!firstPageAppeared)
            {
                DisplayInfo();
                firstPageAppeared = true;
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Debug.WriteLine("{0} OnDisappearing", Title);
        }

        // Identify each instance by its Title.
        public override string ToString()
        {
            return Title;
        }

        public void DisplayInfo()
        {
            // Get the NavigationPage and display its CurrentPage property.
            NavigationPage navPage = (NavigationPage)App.Current.MainPage;

            currentPageLabel.Text = String.Format("NavigationPage.CurrentPage = {0}",
                                                  navPage.CurrentPage);

            // Get the navigation stacks from the NavigationPage.
            IReadOnlyList<Page> navStack = navPage.Navigation.NavigationStack;
            IReadOnlyList<Page> modStack = navPage.Navigation.ModalStack;

            // Display the counts and contents of these stack.
            int modelessCount = navStack.Count;
            int modalCount = modStack.Count;

            modelessStackLabel.Text = String.Format("NavigationStack has {0} page{1}{2}",
                                                    modelessCount,
                                                    modelessCount == 1 ? "" : "s",
                                                    ShowStack(navStack));

            modalStackLabel.Text = String.Format("ModalStack has {0} page{1}{2}",
                                                 modalCount,
                                                 modalCount == 1 ? "" : "s",
                                                 ShowStack(modStack));

            // Enable and disable buttons based on the counts.
            bool noModals = modalCount == 0 || (modalCount == 1 && modStack[0] is NavigationPage);

            modelessGoToButton.IsEnabled = noModals;
            modelessBackButton.IsEnabled = modelessCount > 1 && noModals;
            modalBackButton.IsEnabled = !noModals;
        }

        string ShowStack(IReadOnlyList<Page> pageStack)
        {
            if (pageStack.Count == 0)
                return "";

            StringBuilder builder = new StringBuilder();

            foreach (Page page in pageStack)
            {
                builder.Append(builder.Length == 0 ? " (" : ", ");
                builder.Append(StripNamespace(page));
            }

            builder.Append(")");
            return builder.ToString();
        }

        string StripNamespace(Page page)
        {
            string pageString = page.ToString();

            if (pageString.Contains("."))
                pageString = pageString.Substring(pageString.LastIndexOf('.') + 1);

            return pageString;
        }
    }
}