using System;
using System.Windows.Input;
using System.Xml.Serialization;
using Xamarin.Forms;

namespace SchoolOfFineArt
{
    public class Student : ViewModelBase
    {
        string fullName, firstName, middleName;
        string lastName, sex, photoFilename;
        double gradePointAverage;
        string notes;

        public Student()
        {
            ResetGpaCommand = new Command(() => GradePointAverage = 2.5);
            MoveToTopCommand = new Command(() => StudentBody.MoveStudentToTop(this));
            MoveToBottomCommand = new Command(() => StudentBody.MoveStudentToBottom(this));
            RemoveCommand = new Command(() => StudentBody.RemoveStudent(this));
        }

        public string FullName
        {
            set { SetProperty(ref fullName, value); }
            get { return fullName; }
        }

        public string FirstName
        {
            set { SetProperty(ref firstName, value); }
            get { return firstName; }
        }

        public string MiddleName
        {
            set { SetProperty(ref middleName, value); }
            get { return middleName; }
        }

        public string LastName
        {
            set { SetProperty(ref lastName, value); }
            get { return lastName; }
        }

        public string Sex
        {
            set { SetProperty(ref sex, value); }
            get { return sex; }
        }

        public string PhotoFilename
        {
            set { SetProperty(ref photoFilename, value); }
            get { return photoFilename; }
        }

        public double GradePointAverage
        {
            set { SetProperty(ref gradePointAverage, value); }
            get { return gradePointAverage; }
        }

        // For program in Chapter 25.
        public string Notes
        {
            set { SetProperty(ref notes, value); }
            get { return notes; }
        }

        // Properties for implementing commands.
        [XmlIgnore]
        public ICommand ResetGpaCommand { private set; get; }

        [XmlIgnore]
        public ICommand MoveToTopCommand { private set; get; }

        [XmlIgnore]
        public ICommand MoveToBottomCommand { private set; get; }

        [XmlIgnore]
        public ICommand RemoveCommand { private set; get; }

        [XmlIgnore]
        public StudentBody StudentBody { set; get; }
    }
}
