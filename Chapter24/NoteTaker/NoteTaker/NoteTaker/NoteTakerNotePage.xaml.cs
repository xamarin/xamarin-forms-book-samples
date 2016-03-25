using System;
using Xamarin.Forms;
using Xamarin.FormsBook.Toolkit;

namespace NoteTaker
{
    public partial class NoteTakerNotePage : ContentPage, IPersistentPage
    {
        Note note;
        bool isNoteEdit;

        // Special field for iOS.
        bool isInSleepState;

        public NoteTakerNotePage()
        {
            InitializeComponent();
        }

        public Note Note
        {
            set
            {
                note = value;
                BindingContext = note;
            }
            get { return note; }
        }

        public bool IsNoteEdit
        {
            set
            {
                isNoteEdit = value;
                Title = IsNoteEdit ? "Edit Note" : "New Note";

                // No toolbar items if it's a new Note!
                if (!IsNoteEdit)
                {
                    ToolbarItems.Clear();
                }
            }
            get { return isNoteEdit; }
        }

        // IPersistant implementation
        public void Save(string prefix)
        {
            // Special code for iOS.
            isInSleepState = true;

            Application app = Application.Current;
            app.Properties["fileName"] = Note.Filename;
            app.Properties["title"] = Note.Title;
            app.Properties["text"] = Note.Text;
            app.Properties["isNoteEdit"] = IsNoteEdit;
        }

        public void Restore(string prefix)
        {
            Application app = Application.Current;

            // Create a new Note object.
            Note note = new Note((string)app.Properties["fileName"])
            {
                Title = (string)app.Properties["title"],
                Text = (string)app.Properties["text"]
            };

            // Set the properties of this class.
            Note = note;
            IsNoteEdit = (bool)app.Properties["isNoteEdit"];
        }

        // Special code for iOS.
        public void OnResume()
        {
            isInSleepState = false;
        }

        async protected override void OnDisappearing()
        {
            base.OnDisappearing();

            // Special code for iOS:
            //      Do not save note when program is terminating.
            if (isInSleepState)
                return;

            // Only save the note if there's some text somewhere.
            if (!String.IsNullOrWhiteSpace(Note.Title) ||
                !String.IsNullOrWhiteSpace(Note.Text))
            {
                // Save the note to a file.
                await Note.SaveAsync();

                // Add it to the collection if it's a new note.
                NoteFolder noteFolder = ((App)App.Current).NoteFolder;

                // IndexOf method finds match based on Filename property
                //      based on implementation of IEquatable in Note.
                int index = noteFolder.Notes.IndexOf(note);
                if (index == -1)
                {
                    // No match -- add it.
                    noteFolder.Notes.Add(note);
                }
                else
                {
                    // Match -- replace it.
                    noteFolder.Notes[index] = note;
                }
            }
        }

        async void OnCancelClicked(object sender, EventArgs args)
        {
            if (await DisplayAlert("Note Taker", "Cancel note edit?",
                                                 "Yes", "No"))
            {
                // Reload note.
                await Note.LoadAsync();

                // Return to home page.
                await Navigation.PopAsync();
            }
        }

        async void OnDeleteClicked(object sender, EventArgs args)
        {
            if (await DisplayAlert("Note Taker", "Delete this note?",
                                                 "Yes", "No"))
            {
                // Delete Note file and remove from collection.
                await Note.DeleteAsync();
                ((App)App.Current).NoteFolder.Notes.Remove(Note);

                // Wipe out Entry and Editor so the Note  
                //  won't be saved during OnDisappearing.
                Note.Title = "";
                Note.Text = "";

                // Return to home page.
                await Navigation.PopAsync();
            }
        }
    }
}
