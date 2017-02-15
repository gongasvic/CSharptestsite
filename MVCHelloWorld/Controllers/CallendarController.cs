using MVCHelloWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCHelloWorld.Controllers
{
    public class CallendarController : Controller
    {
        // GET: Callendar
        public ActionResult Index()
        {
            var bag = new CallendarBag()
            {



            };

            return View(bag);
        }
    }
}