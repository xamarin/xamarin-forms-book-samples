using System;
using Xamarin.Forms;

namespace ConditionalSection
{
    public partial class ConditionalSectionPage : ContentPage
    {
        public ConditionalSectionPage()
        {
            InitializeComponent();

            // Set BindingContext of TableView.
            ProgrammerInformation programmerInfo = new ProgrammerInformation();
            tableView.BindingContext = programmerInfo;

            // Remove programmer-information section!
            tableView.Root.Remove(programmerInfoSection);

            // Watch for changes in IsProgrammer property in ProgrammerInformation.
            programmerInfo.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == "IsProgrammer")
                {
                    if (programmerInfo.IsProgrammer &&
                        tableView.Root.IndexOf(programmerInfoSection) == -1)
                    {
                        tableView.Root.Add(programmerInfoSection);
                    }
                    if (!programmerInfo.IsProgrammer &&
                        tableView.Root.IndexOf(programmerInfoSection) != -1)
                    {
                        tableView.Root.Remove(programmerInfoSection);
                    }
                }
            };
        }
    }
}
