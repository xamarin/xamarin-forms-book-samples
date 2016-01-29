using System;
using Xamarin.Forms;

namespace Xamarin.FormsBook.Toolkit
{
    public class ForPlatform<T>
    {
        public T iOS { get; set; }

        public T Android { get; set; }

        public T WinPhone { get; set; }

        public T WindowsStore { set; get; }

        public T WindowsPhoneStore { set; get; }

        public static implicit operator T(ForPlatform<T> forPlatform)
        {
            switch (Device.OS)
            {
                case TargetPlatform.iOS:
                    return forPlatform.iOS;

                case TargetPlatform.Android:
                    return forPlatform.Android;

                case TargetPlatform.WinPhone:
                    return forPlatform.WinPhone;

                case TargetPlatform.Windows:
                    switch (Device.Idiom)
                    {
                        case TargetIdiom.Desktop:
                        case TargetIdiom.Tablet:
                            return forPlatform.WindowsStore;

                        case TargetIdiom.Phone:
                            return forPlatform.WindowsPhoneStore;
                    }
                    break;
            }
            return forPlatform.iOS;
        }
    }
}
