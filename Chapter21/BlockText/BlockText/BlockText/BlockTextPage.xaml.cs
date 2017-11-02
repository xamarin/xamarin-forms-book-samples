using System;
using Xamarin.Forms;

namespace BlockText
{
    public partial class BlockTextPage : ContentPage
    {
        public BlockTextPage()
        {
            InitializeComponent();

            for (int i = 0; i < 12; i++)
            {
                grid.Children.Insert(0, new Label
                    {
                        TranslationX = i,
                        TranslationY = -i
                    });
            }
        }
    }
}
