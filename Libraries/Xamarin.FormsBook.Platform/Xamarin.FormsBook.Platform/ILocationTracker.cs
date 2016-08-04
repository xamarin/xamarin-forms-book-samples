using System;

namespace Xamarin.FormsBook.Platform
{
    public interface ILocationTracker
    {
        event EventHandler<GeographicLocation> LocationChanged;

        void StartTracking();

        void PauseTracking();
    }
}
