using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperTemplate.Core;

namespace SuperTemplate.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDoSomething _doSomething;

        public HomeController(
            IDoSomething doSomething
            )
        {
            _doSomething = doSomething;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = _doSomething.GiveMeAString();

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}