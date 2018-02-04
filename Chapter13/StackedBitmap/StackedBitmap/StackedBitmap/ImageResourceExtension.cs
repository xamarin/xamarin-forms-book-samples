using System;
using System.Reflection;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;

namespace StackedBitmap
{
    [ContentProperty ("Source")]
    public class ImageResourceExtension : IMarkupExtension
    {
        public string Source { get; set; }

        public object ProvideValue (IServiceProvider serviceProvider)
        {
            if (Source == null)
                return null;
                
            var assembly = typeof(ImageResourceExtension).GetTypeInfo().Assembly;

            if (assembly == null)
                return null;

            return ImageSource.FromResource(Source, assembly); 
        }
    }
}

