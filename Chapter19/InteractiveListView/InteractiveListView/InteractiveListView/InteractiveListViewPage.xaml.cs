using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.FormsBook.Toolkit;

namespace InteractiveListView
{
    public partial class InteractiveListViewPage : ContentPage
    {
        public InteractiveListViewPage()
        {
            InitializeComponent();

            const int count = 100;
            List<ColorViewModel> colorList = new List<ColorViewModel>(count);
            Random random = new Random();

            for (int i = 0; i < count; i++)
            {
                ColorViewModel colorViewModel = new ColorViewModel();
                colorViewModel.Color = new Color(random.NextDouble(),
                                                 random.NextDouble(),
                                                 random.NextDouble());
                colorList.Add(colorViewModel);
            }
            listView.ItemsSource = colorList;
        }
    }
}
