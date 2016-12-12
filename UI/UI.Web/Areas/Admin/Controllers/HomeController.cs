using BLL.Service.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Infrastructures;
using UI.Web.Infrastructure;

namespace UI.Web.Areas.Admin.Controllers
{
    [Export]
    [AdminAuthor]
    public class HomeController : Controller
    {
        [Import]
        private ISysLogService sysLogService;

        public ActionResult Index()
        {
            return View();
        }
    }
}