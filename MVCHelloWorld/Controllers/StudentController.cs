using MVCHelloWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCHelloWorld.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            var bag = new StudentsAndSchoolsBag()
            {
                Schools = DataBase.GetSchools(),
                Students = DataBase.GetStudents(),


            };

            return View(bag);
        }

    }
}