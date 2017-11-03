using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace PhotoGrid
{
    public partial class PhotoGridPage : ContentPage
    {
        [DataContract]
        class ImageList
        {
            [DataMember(Name = "photos")]
            public List<string> Photos = null;
        }

        WebRequest request;
        static readonly int imageDimension = Device.RuntimePlatform == Device.iOS || 
                                             Device.RuntimePlatform == Device.Android ? 240 : 180;
        static readonly string urlSuffix =
            String.Format("?width={0}&height={0}&mode=max", imageDimension);

        public PhotoGridPage()
        {
            InitializeComponent();

            // Get list of stock photos.
            Uri uri = new Uri("http://docs.xamarin.com/demo/stock.json");
            request = WebRequest.Create(uri);
            request.BeginGetResponse(WebRequestCallback, null);
        }

        void WebRequestCallback(IAsyncResult result)
        {
            try
            {
                Stream stream = request.EndGetResponse(result).GetResponseStream();

                // Deserialize the JSON into imageList.
                var jsonSerializer = new DataContractJsonSerializer(typeof(ImageList));
                ImageList imageList = (ImageList)jsonSerializer.ReadObject(stream);

                Device.BeginInvokeOnMainThread(() =>
                {
                    foreach (string filepath in imageList.Photos)
                    {
                        Image image = new Image
                        {
                            Source = ImageSource.FromUri(new Uri(filepath + "?width=100"))
                        };
                        uniformGridLayout.Children.Add(image);
                    }
                });
            }
            catch (Exception)
            {
            }
        }
    }
}

