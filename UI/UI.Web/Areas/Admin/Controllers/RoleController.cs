﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Web.Infrastructure;

namespace UI.Web.Areas.Admin.Controllers
{
    [Export]
    [AdminAuthor]
    public class RoleController : Controller
    {
        // GET: Admin/Role
        public ActionResult Index()
        {
            return View();
        }
    }
}