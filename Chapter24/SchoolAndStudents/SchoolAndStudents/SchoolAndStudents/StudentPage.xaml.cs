using System;
using Xamarin.Forms;
using SchoolOfFineArt;

namespace SchoolAndStudents
{
    public partial class StudentPage : ContentPage
    {
        public StudentPage(Student student)
        {
            InitializeComponent();
            BindingContext = student;
        }
    }
}
