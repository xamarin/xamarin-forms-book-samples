using System;
using System.IO;
using System.Reflection;
using Xamarin.Forms;

namespace SearchBarDemo
{
    public partial class SearchBarDemoPage : ContentPage
    {
        const double MaxMatches = 100;
        string bookText;

        public SearchBarDemoPage()
        {
            InitializeComponent();

            // Load embedded resource bitmap.
            string resourceID = "SearchBarDemo.Texts.MobyDick.txt";
            Assembly assembly = GetType().GetTypeInfo().Assembly;

            using (Stream stream = assembly.GetManifestResourceStream(resourceID))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    bookText = reader.ReadToEnd();
                }
            }
        }

        void OnSearchBarTextChanged(object sender, TextChangedEventArgs args)
        {
            resultsStack.Children.Clear();
        }

        void OnSearchBarButtonPressed(object sender, EventArgs args)
        {
            // Detach resultsStack from layout.
            resultsScroll.Content = null;

            resultsStack.Children.Clear();
            SearchBookForText(searchBar.Text);

            // Reattach resultsStack to layout.
            resultsScroll.Content = resultsStack;
        }

        void SearchBookForText(string searchText)
        {
            int count = 0;
            bool isTruncated = false;

            using (StringReader reader = new StringReader(bookText))
            {
                int lineNumber = 0;
                string line;

                while (null != (line = reader.ReadLine()))
                {
                    lineNumber++;
                    int index = 0;

                    while (-1 != (index = (line.IndexOf(searchText, index, 
                                                        StringComparison.OrdinalIgnoreCase))))
                    {
                        if (count == MaxMatches)
                        {
                            isTruncated = true;
                            break;
                        }
                        index += 1;

                        // Add the information to the StackLayout.
                        resultsStack.Children.Add(
                            new Label
                            {
                                Text = String.Format("Found at line {0}, offset {1}", 
                                                     lineNumber, index)
                            });

                        count++;
                    }

                    if (isTruncated)
                    {
                        break;
                    }
                }
            }

            // Add final count to the StackLayout.
            resultsStack.Children.Add(
                new Label
                {
                    Text = String.Format("{0} match{1} found{2}", 
                                         count, 
                                         count == 1 ? "" : "es", 
                                         isTruncated ? " - stopped" : "")
                });
        }
    }
}
