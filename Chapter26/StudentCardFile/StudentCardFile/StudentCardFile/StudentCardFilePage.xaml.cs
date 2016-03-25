using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.FormsBook.Toolkit;
using SchoolOfFineArt;

namespace StudentCardFile
{
    public partial class StudentCardFilePage : ContentPage
    {
        View exposedChild = null;

        public StudentCardFilePage()
        {
            InitializeComponent();

            // Set a platform-specific Offset on the OverlapLayout.
            overlapLayout.Offset = 2 * Device.GetNamedSize(NamedSize.Large, typeof(Label));

            SchoolViewModel viewModel = new SchoolViewModel();

            viewModel.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == "StudentBody")
                {
                    // Sort the students by last name.
                    var students = 
                        viewModel.StudentBody.Students.OrderBy(student => student.LastName);

                    Device.BeginInvokeOnMainThread(() =>
                    {
                        int index = 0;

                        // Loop through the students.
                        foreach (Student student in students)
                        {
                            // Create a StudentView for each.
                            StudentView studentView = new StudentView
                            {
                                BindingContext = student
                            };

                            // Set the Order attached bindable property.
                            OverlapLayout.SetRenderOrder(studentView, index++);

                            // Attach a Tap gesture handler.
                            TapGestureRecognizer tapGesture = new TapGestureRecognizer();
                            tapGesture.Tapped += OnStudentViewTapped;
                            studentView.GestureRecognizers.Add(tapGesture);

                            // Add it to the OverlapLayout.
                            overlapLayout.Children.Add(studentView);
                        }
                    });
                }
            };
        }

        void OnStudentViewTapped(object sender, EventArgs args)
        {
            View tappedChild = (View)sender;
            bool retractOnly = tappedChild == exposedChild;

            // Retract the exposed child.
            if (exposedChild != null)
            {
                overlapLayout.Children.Remove(exposedChild);
                overlapLayout.Children.Insert(
                    OverlapLayout.GetRenderOrder(exposedChild), exposedChild);
                exposedChild = null;
            }
            // Expose a new child.
            if (!retractOnly)
            {
                // Raise child.
                overlapLayout.Children.Remove(tappedChild);
                overlapLayout.Children.Add(tappedChild);

                exposedChild = tappedChild;
            }
        }
    }
}
