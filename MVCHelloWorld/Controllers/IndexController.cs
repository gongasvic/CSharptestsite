using MVCHelloWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;

namespace MVCHelloWorld.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            var bag = new StudentsAndSchoolsBag()
            {
                Schools = DataBase.GetSchools(),
                Students = DataBase.GetStudents(),
                
                
            };

            return View(bag);
        }

        [HttpGet]
        public JsonResult GetStudentsFromSchool(int id)
        {
            List<Student> students = new List<Student>();

            students = DataBase.GetStudentsFromSchool(id);

            return Json(students, JsonRequestBehavior.AllowGet);
        }

        [WebMethod]
        public JsonResult AddStudentsToSchool(string foo, string zoo)
        {

            return Json(foo + " " + zoo, JsonRequestBehavior.AllowGet);
            string val1 = foo;
            string val2 = zoo;
            string[] teste;
            int age;
            teste = val2.Trim().Split();
            School escola = DataBase.GetSchool(int.Parse(val1.Trim()));
            for (int i = 1; i < (teste.Length) / 2; i += 2)
                if (int.TryParse(teste[0], out age)) {
                    Student estudante = DataBase.AddStudent(teste[1],age);
                    DataBase.AddStudentToSchool(escola, estudante);
                }

            return Json("success", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetSchool(int id)
        {
            School schools = DataBase.GetSchool(id);

            return Json(schools, JsonRequestBehavior.AllowGet);
        }
    }
}