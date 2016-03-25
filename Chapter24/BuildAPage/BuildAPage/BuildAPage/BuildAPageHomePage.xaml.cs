using System;
using System.Collections.ObjectModel;
using System.Reflection;
using Xamarin.Forms;

namespace BuildAPage
{
    public partial class BuildAPageHomePage : ContentPage
    {
        ObservableCollection<string> viewCollection = new ObservableCollection<string>();
        Assembly xamarinForms = typeof(Label).GetTypeInfo().Assembly;

        public BuildAPageHomePage()
        {
            InitializeComponent();

            pageList.ItemsSource = viewCollection;
        }

        void OnViewListItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (args.SelectedItem != null)
            {
                viewList.SelectedItem = null;
                int number = 1;
                string item = null;

                while (-1 != viewCollection.IndexOf(
                    item = ((string)args.SelectedItem) + ' ' + number))
                {
                    number++;
                }

                viewCollection.Add(item);
                generateButton.IsEnabled = true;
            }
        }

        void OnPageListItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (args.SelectedItem != null)
            {
                pageList.SelectedItem = null;
                viewCollection.Remove((string)args.SelectedItem);
                generateButton.IsEnabled = viewCollection.Count > 0;
            }
        }

        async void OnGenerateButtonClicked(object sender, EventArgs args)
        {
            ContentPage contentPage = new ContentPage
            {
                Title = titleEntry.Text,
                Padding = new Thickness(10, 0)
            };
            StackLayout stackLayout = new StackLayout();
            contentPage.Content = stackLayout;

            foreach (string item in viewCollection)
            {
                string viewString = item.Substring(0, item.IndexOf(' '));
                Type viewType = xamarinForms.GetType("Xamarin.Forms." + viewString);
                View view = (View)Activator.CreateInstance(viewType);
                view.VerticalOptions = LayoutOptions.CenterAndExpand;

                switch (viewString)
                {
                    case "BoxView":
                        ((BoxView)view).Color = Color.Accent;
                        goto case "Stepper";

                    case "Button":
                        ((Button)view).Text = item;
                        goto case "Stepper";

                    case "Stepper":
                    case "Switch":
                        view.HorizontalOptions = LayoutOptions.Center;
                        break;
                }
                stackLayout.Children.Add(view);
            }
            await Navigation.PushAsync(contentPage);
        }
    }
}
