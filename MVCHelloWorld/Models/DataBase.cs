using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCHelloWorld.Models
{
    public class DataBase
    {
        private static int school_id { get; set; } = 1;
        private static int student_id { get; set; } = 1;
        

        // static initializers
        private static List<School> Schools = new List<School>();
        private static List<Student> Students = new List<Student>();
        private static List<StudentSchool> StudentsAndSchools = new List<StudentSchool>();


        static DataBase()
        {
            
            Student joao = new Student() { ID = student_id++, Age = 14, Name = "João" };
            Student maria = new Student() { ID = student_id++, Age = 12, Name = "Maria" };
            Student francisco = new Student() { ID = student_id++, Age = 16, Name = "Francisco" };
            Student joana = new Student() { ID = student_id++, Age = 14, Name = "Joana" };

            Students.Add(joao);
            Students.Add(maria);
            Students.Add(francisco);
            Students.Add(joana);

            School escolaA = new School() { ID = school_id++, Name = "Escola D. Afonso Henriques" };
            School escolaB = new School() { ID = school_id++, Name = "Escola D. Sebastião" };

            Schools.Add(escolaA);
            Schools.Add(escolaB);

            StudentSchool ss1 = new StudentSchool(joao, escolaA);
            StudentSchool ss2 = new StudentSchool(maria, escolaA);
            StudentSchool ss3 = new StudentSchool(francisco, escolaB);
            StudentSchool ss4 = new StudentSchool(joana, escolaB);

            StudentsAndSchools.Add(ss1);
            StudentsAndSchools.Add(ss2);
            StudentsAndSchools.Add(ss3);
            StudentsAndSchools.Add(ss4);
        }


        public static void AddStudentToSchool(School escola, Student estudante) {
            StudentsAndSchools.Add(new StudentSchool(estudante, escola));
        }

        public static Student AddStudent(string name, int age){
            Student estudante = new Student() { ID = student_id++, Age = age, Name = name };
            Students.Add(estudante);
            return estudante;
        }

        public static School AddSchool(string name) {
            School escola = new School() { ID = school_id++, Name = name };
            Schools.Add(escola);
            return escola;
        }



        public static List<Student> GetStudentsFromSchool(int schoolId )
        {
            return StudentsAndSchools
                .Where(x => x.TheSchool.ID == schoolId)
                .Select(x => x.Student).ToList();
        }

        public static School GetSchool(int schoolId)
        {
            return Schools
                .Where(x => x.ID == schoolId)
                .Select(x => x).ToList().First();
        }

        public static List<School> GetSchools()
        {
            return Schools;
        }

        public static List<Student> GetStudents()
        {
            return Students;
        }
    }
}