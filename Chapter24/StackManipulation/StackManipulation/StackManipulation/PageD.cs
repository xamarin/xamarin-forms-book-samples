using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace StackManipulation
{
    public class PageD : ContentPage
    {
        public PageD()
        {
            // Create Button to go directly to PageA.
            Button homeButton = new Button
            {
                Text = "Go Directly to Home",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            homeButton.Clicked += async (sender, args) =>
            {
                await Navigation.PopToRootAsync();
            };

            // Create Button to swap pages.
            Button swapButton = new Button
            {
                Text = "Swap B and Alt B",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            swapButton.Clicked += (sender, args) =>
            {
                IReadOnlyList<Page> navStack = Navigation.NavigationStack;
                Page pageC = navStack[navStack.Count - 2];
                Page existingPageB = navStack[navStack.Count - 3];
                bool isOriginal = existingPageB is PageB;
                Page newPageB = isOriginal ? (Page)new PageBAlternative() : new PageB();

                // Swap the pages.
                Navigation.RemovePage(existingPageB);
                Navigation.InsertPageBefore(newPageB, pageC);

                // Finished: Disable the Button.
                swapButton.IsEnabled = false;
            };

            Title = "Page D";
            Content = new StackLayout
            {
                Children =
                {
                    homeButton,
                    swapButton
                }
            };
        }
    }
}
