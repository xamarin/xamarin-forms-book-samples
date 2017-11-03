using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace JustNotes
{
    public partial class JustNotesPage : ContentPage
    {
        public JustNotesPage()
        {
            InitializeComponent();

            // Retrieve last saved Editor text.
            IDictionary<string, object> properties = Application.Current.Properties;

            if (properties.ContainsKey("text"))
            {
                editor.Text = (string)properties["text"];
            }
        }

        void OnEditorFocused(object sender, FocusEventArgs args)
        {
            if (Device.RuntimePlatform == Device.iOS)
            {
                AbsoluteLayout.SetLayoutBounds(editor, new Rectangle(0, 0, 1, 0.5));
            }
        }

        void OnEditorUnfocused(object sender, FocusEventArgs args)
        {
            if (Device.RuntimePlatform == Device.iOS)
            {
                AbsoluteLayout.SetLayoutBounds(editor, new Rectangle(0, 0, 1, 1));
            }
        }

        public void OnSleep()
        {
            // Save Editor text.
            Application.Current.Properties["text"] = editor.Text;
        }
    }
}
