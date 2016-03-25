using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SaveProgramSettings
{
    public partial class SaveProgramSettingsPage : ContentPage
    {
        bool isInitialized = false;

        public SaveProgramSettingsPage()
        {
            InitializeComponent();

            // Retrieve settings.
            IDictionary<string, object> properties = Application.Current.Properties;

            for (int index = 0; index < 4; index++)
            {
                Switch switcher = (Switch)(switchGrid.Children[index]);
                string key = index.ToString();

                if (properties.ContainsKey(key))
                    switcher.IsToggled = (bool)(properties[key]);
            }
            isInitialized = true;
        }

        async void OnSwitchToggled(object sender, EventArgs args)
        {
            if (!isInitialized)
                return;

            Switch switcher = (Switch)sender;
            string key = switchGrid.Children.IndexOf(switcher).ToString();
            Application.Current.Properties[key] = switcher.IsToggled;

            // Save settings.
            foreach (View view in switchGrid.Children)
                view.IsEnabled = false;

            await Application.Current.SavePropertiesAsync();

            foreach (View view in switchGrid.Children)
                view.IsEnabled = true;
        }
    }
}
