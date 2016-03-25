using System;
using Xamarin.Forms;

namespace TextFileTryout
{
    public partial class TextFileTryoutPage : ContentPage
    {
        FileHelper fileHelper = new FileHelper();

        public TextFileTryoutPage()
        {
            InitializeComponent();

            RefreshListView();
        }

        async void OnSaveButtonClicked(object sender, EventArgs args)
        {
            string filename = filenameEntry.Text;

            if (fileHelper.Exists(filename))
            {
                bool okResponse = await DisplayAlert("TextFileTryout",
                                                     "File " + filename +
                                                     " already exists. Replace it?",
                                                     "Yes", "No");
                if (!okResponse)
                    return;
            }

            string errorMessage = null;

            try
            {
                fileHelper.WriteText(filenameEntry.Text, fileEditor.Text);
            }
            catch (Exception exc)
            {
                errorMessage = exc.Message;
            }

            if (errorMessage == null)
            {
                filenameEntry.Text = "";
                fileEditor.Text = "";
                RefreshListView();
            }
            else
            {
                await DisplayAlert("TextFileTryout", errorMessage, "OK");
            }
        }

        async void OnFileListViewItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (args.SelectedItem == null)
                return;

            string filename = (string)args.SelectedItem;
            string errorMessage = null;

            try
            {
                fileEditor.Text = fileHelper.ReadText((string)args.SelectedItem);
                filenameEntry.Text = filename;
            }
            catch (Exception exc)
            {
                errorMessage = exc.Message;
            }

            if (errorMessage != null)
            {
                await DisplayAlert("TextFileTryout", errorMessage, "OK");
            }
        }

        void OnDeleteMenuItemClicked(object sender, EventArgs args)
        {
            string filename = (string)((MenuItem)sender).BindingContext;
            fileHelper.Delete(filename);
            RefreshListView();
        }

        void RefreshListView()
        {
            fileListView.ItemsSource = fileHelper.GetFiles();
            fileListView.SelectedItem = null;
        }
    }
}
