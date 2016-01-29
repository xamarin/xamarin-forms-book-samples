using System;
using System.IO;
using System.Net;
using System.Xml.Serialization;
using Xamarin.Forms;

namespace ElPasoHighSchool
{
    public class SchoolViewModel : ViewModelBase
    {
        StudentBody studentBody;
        Random rand = new Random();

        public SchoolViewModel()
        {
            string uri = "http://xamarin.github.io/xamarin-forms-book-preview-2" +
                             "/ElPasoHighSchool/students.xml";
            HttpWebRequest request = WebRequest.CreateHttp(uri);

            request.BeginGetResponse((arg) =>
            {
                // Deserialize XML file.
                Stream stream = request.EndGetResponse(arg).GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                XmlSerializer xml = new XmlSerializer(typeof(StudentBody));
                StudentBody = xml.Deserialize(reader) as StudentBody;

                // Set StudentBody property in each Student object.
                foreach (Student student in StudentBody.Students)
                {
                    student.StudentBody = StudentBody;
                }
            }, null);

            // Adjust GradePointAverage randomly.
            Device.StartTimer(TimeSpan.FromSeconds(0.1),
                () =>
                {
                    if (studentBody != null)
                    {
                        int index = rand.Next(studentBody.Students.Count);
                        Student student = studentBody.Students[index];
                        double factor = 1 + (rand.NextDouble() - 0.5) / 5;
                        student.GradePointAverage = Math.Round(
                            Math.Max(0, Math.Min(5, factor * student.GradePointAverage)), 2);
                    }
                    return true;
                });
        }

        public StudentBody StudentBody
        {
            protected set { SetProperty(ref studentBody, value); }
            get { return studentBody; }
        }
    }
}
