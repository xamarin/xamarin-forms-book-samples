using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace ViewGalleryType
{
    public partial class ViewGalleryTypePage : ContentPage
    {
        public ViewGalleryTypePage()
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

