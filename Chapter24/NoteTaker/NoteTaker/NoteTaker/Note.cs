using System;
using System.Threading.Tasks;
using Xamarin.FormsBook.Platform;
using Xamarin.FormsBook.Toolkit;

namespace NoteTaker
{
    public class Note : ViewModelBase, IEquatable<Note>
    {
        string title, text, identifier;
        FileHelper fileHelper = new FileHelper();

        public Note(string filename)
        {
            Filename = filename;
        }

        public string Filename { private set; get; }

        public string Title
        {
            set 
            { 
                if (SetProperty(ref title, value))
                {
                    Identifier = MakeIdentifier();
                }
            }
            get { return title; }
        }

        public string Text
        {
            set 
            { 
                if (SetProperty(ref text, value) && String.IsNullOrWhiteSpace(Title))
                {
                    Identifier = MakeIdentifier();
                }
            }
            get { return text; }
        }

        public string Identifier
        {
            private set { SetProperty(ref identifier, value); }
            get { return identifier; }
        }

        string MakeIdentifier()
        {
            if (!String.IsNullOrWhiteSpace(this.Title))
                return Title;

            int truncationLength = 30;

            if (Text == null || Text.Length <= truncationLength)
            {
                return Text;
            }

            string truncated = Text.Substring(0, truncationLength);

            int index = truncated.LastIndexOf(' ');

            if (index != -1)
                truncated = truncated.Substring(0, index);

            return truncated;
        }

        public Task SaveAsync()
        {
            string text = Title + Environment.NewLine + Text;
            return fileHelper.WriteTextAsync(Filename, text);
        }

        public async Task LoadAsync()
        {
            string text = await fileHelper.ReadTextAsync(Filename);

            // Break string into Title and Text.
            int index = text.IndexOf(Environment.NewLine);
            Title = text.Substring(0, index);
            Text = text.Substring(index + Environment.NewLine.Length);
        }

        public async Task DeleteAsync()
        {
            await fileHelper.DeleteAsync(Filename);
        }

        public bool Equals(Note other)
        {
            return other == null ? false : Filename == other.Filename;
        }
    }
}
