using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCHelloWorld.Models
{
    public class StudentSchool
    {
        public string ID { get; set; }

        public Student Student { get; set; }
        public School TheSchool { get; set; }

        public StudentSchool(Student student, School school)
        {
            this.ID = string.Format("{0}:{1}", student.ID, school.ID);
            this.Student = student;
            this.TheSchool = school;
        }
    }
}