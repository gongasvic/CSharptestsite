using MVCHelloWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCHelloWorld.Controllers
{
    public class SchoolController : Controller
    {
        // GET: School
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
        public JsonResult CreateSchool(string val1)
        {
            if (val1 != null && val1 != "")
            {
                DataBase.AddSchool(val1);
                return Json("sussess", JsonRequestBehavior.AllowGet);
            }
            else
                return Json("Empty Name", JsonRequestBehavior.DenyGet);
        }
    }

   

}