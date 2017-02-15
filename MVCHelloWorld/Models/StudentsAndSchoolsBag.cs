using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCHelloWorld.Models
{
    public class StudentsAndSchoolsBag
    {
        public static int current_page = 1;

        public List<School> Schools { get; set; }
        public List<Student> Students { get; set; }

        public static List<Student> StdList = DataBase.GetStudents();


        public List<Student> GetStudentList()
        {
            return StdList;
        }

        public int GetPage()
        {
            return current_page;
        }
        public int GetMaxStudents()
        {
            return Students.Count; 
        }
    }
}