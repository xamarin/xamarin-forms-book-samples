using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Xamarin.Forms;

namespace ImageBrowser
{
    public partial class ImageBrowserPage : ContentPage
    {
        [DataContract]
        class ImageList
        {
            [DataMember(Name = "photos")]
            public List<string> Photos = null;
        }

        WebRequest request;
        ImageList imageList;
        int imageListIndex = 0;

        public ImageBrowserPage()
        {
            InitializeComponent();

            // Get list of stock photos.
            Uri uri = new Uri("http://developer.xamarin.com/demo/stock.json");
            request = WebRequest.Create(uri);
            request.BeginGetResponse(WebRequestCallback, null);
        }

        void WebRequestCallback(IAsyncResult result)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                try
                {
                    Stream stream = request.EndGetResponse(result).GetResponseStream();

                    // Deserialize the JSON into imageList;
                    var jsonSerializer = new DataContractJsonSerializer(typeof(ImageList));
                    imageList = (ImageList)jsonSerializer.ReadObject(stream);

                    if (imageList.Photos.Count > 0)
                        FetchPhoto();
                }
                catch (Exception exc)
                {
                    filenameLabel.Text = exc.Message;
                }
            });
        }

        void OnPreviousButtonClicked(object sender, EventArgs args)
        {
            imageListIndex--;
            FetchPhoto();
        }

        void OnNextButtonClicked(object sender, EventArgs args)
        {
            imageListIndex++;
            FetchPhoto();
        }

        void FetchPhoto()
        {
            // Prepare for new image.
            image.Source = null;
            string url = imageList.Photos[imageListIndex];

            // Set the filename.
            filenameLabel.Text = url.Substring(url.LastIndexOf('/') + 1);

            // Create the UriImageSource.
            UriImageSource imageSource = new UriImageSource
            {
                Uri = new Uri(url + "?Width=1080"),
                CacheValidity = TimeSpan.FromDays(30)
            };

            // Set the Image source.
            image.Source = imageSource;

            // Enable or disable buttons.
            prevButton.IsEnabled = imageListIndex > 0;
            nextButton.IsEnabled = imageListIndex < imageList.Photos.Count - 1;
        }

        void OnImagePropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "IsLoading")
            {
                activityIndicator.IsRunning = ((Image)sender).IsLoading;
            }
        }
    }
}

