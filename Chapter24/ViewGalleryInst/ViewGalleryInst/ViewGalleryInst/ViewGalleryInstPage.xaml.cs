using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace ViewGalleryInst
{
    public partial class ViewGalleryInstPage : ContentPage
    {
        public ViewGalleryInstPage()
        {
            InitializeComponent();

            NavigateCommand = new Command<Page>(async (Page page) =>
            {
                await Navigation.PushAsync(page);
            });

            BindingContext = this;
        }

        public ICommand NavigateCommand { private set; get; }
    }
}

