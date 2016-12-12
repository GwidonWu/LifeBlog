using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Love.Controllers
{
    public class LoveController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Boy()
        {
            return View();
        }

        public ActionResult Girl()
        {
            return View();
        }
    }
}