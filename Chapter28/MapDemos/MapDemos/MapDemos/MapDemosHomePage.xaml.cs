using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace MapDemos
{
    public partial class MapDemosHomePage : ContentPage
    {
        public MapDemosHomePage()
        {
            InitializeComponent();

            NavigateCommand = new Command<Type>(async (Type pageType) =>
            {
                Page page = (Page)Activator.CreateInstance(pageType);
                await Navigation.PushAsync(page);
            });

            BindingContext = this;
        }

        public ICommand NavigateCommand { private set; get; }
    }
}
