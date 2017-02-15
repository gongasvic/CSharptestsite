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
        // GET: /
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
        public JsonResult AddStudentsToSchool(string val1, string val2)
        {
            string[] teste;
            int age;
            int success = 0;
            teste = val2.Trim().Split();
            School escola = DataBase.GetSchool(int.Parse(val1.Trim()));
            for (int i = 0; i < teste.Length; i += 2)
                try { 
                if (int.TryParse(teste[i], out age))
                {
                    Student estudante = DataBase.AddStudent(teste[i + 1], age);
                    DataBase.AddStudentToSchool(escola, estudante);
                    success++;
                }
                }catch(Exception e) {
                    if (success > 0)
                        return Json("Success", JsonRequestBehavior.AllowGet);
                    else
                        return Json("Something went wrong", JsonRequestBehavior.AllowGet);
                }
            if (success > 0)
                return Json("Success", JsonRequestBehavior.AllowGet);
            return Json("Something went wrong", JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public JsonResult previous()
        {
            int page = --StudentsAndSchoolsBag.current_page;
            StudentsAndSchoolsBag.StdList = DataBase.GetStudents().Skip(page-1).Take(2).ToList();
            return Json("sussess", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult next()
        {
            int page =  ++StudentsAndSchoolsBag.current_page;
            StudentsAndSchoolsBag.StdList = DataBase.GetStudents().Skip(page).Take(2).ToList();
            return Json("sussess", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetSchool(int id)
        {
            School schools = DataBase.GetSchool(id);

            return Json(schools, JsonRequestBehavior.AllowGet);
        }
    }
}