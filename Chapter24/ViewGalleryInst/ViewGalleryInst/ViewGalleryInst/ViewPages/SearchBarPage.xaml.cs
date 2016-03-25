using System;
using System.Reflection;
using Xamarin.Forms;

namespace ViewGalleryInst
{
    public partial class SearchBarPage : ContentPage
    {
        public SearchBarPage()
        {
            InitializeComponent();
        }

        void OnSearchBarTextChanged(object sender, TextChangedEventArgs args)
        {
            resultsStack.Children.Clear();
        }

        void OnSearchBarButtonPressed(object sender, EventArgs args)
        {
            string name = "Xamarin.Forms." + searchBar.Text;
            Type type = null;

            try
            {
                type = typeof(View).GetTypeInfo().Assembly.GetType(name);
            }
            catch
            {
            }

            if (type == null)
            {
                resultsStack.Children.Add(new Label
                {
                    Text = name + " not found in the Xamarin.Forms assembly"
                });
            }
            else
            {
                foreach (PropertyInfo prop in type.GetRuntimeProperties())
                {
                    resultsStack.Children.Add(new Label
                    {
                        Text = String.Format("{0} of type {1}", prop.Name, prop.PropertyType.Name)
                    });
                }
            }
        }
    }
}
