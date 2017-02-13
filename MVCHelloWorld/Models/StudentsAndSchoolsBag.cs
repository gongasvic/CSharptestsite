using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCHelloWorld.Models
{
    public class StudentsAndSchoolsBag
    {
        public int current_page = 1;

        public List<School> Schools { get; set; }
        public List<Student> Students { get; set; }


    }
}