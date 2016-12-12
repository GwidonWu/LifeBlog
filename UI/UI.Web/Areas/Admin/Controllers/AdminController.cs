using BLL.Service.AdminService;
using System;
using System.ComponentModel.Composition;
using System.Web.Mvc;
using UI.Infrastructures;
using UI.Web.Areas.Admin.Models;
using UI.Web.Infrastructure;

namespace UI.Web.Areas.Admin.Controllers
{
    [Export]
    [AdminAuthor]
    public class AdminController : Controller
    {
        [Import]
        private IAdminService adminService;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DeleteAdmin()
        {
            return View();
        }

        [HttpPost]
        public JsonResult DeleteAdmin(int id)
        {
            var result = adminService.Delete(id);
            return Json(id, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = adminService.Login(model.AdminName, model.Password);

                if (result.Code == 1)
                {
                    var admin = adminService.Find(model.AdminName);
                    CurrUser.Serialize(admin.ID, admin.AdminName, "admin");
                    admin.LoginTime = DateTime.Now;
                    admin.LoginIP = Request.UserHostAddress;
                    adminService.Update(admin);
                    return RedirectToAction("Index", "Home", new { Areas = "Admin" });
                }
                else if (result.Code == 2) ModelState.AddModelError("AdminName", result.Message);
                else if (result.Code == 3) ModelState.AddModelError("Password", result.Message);
                else ModelState.AddModelError("", result.Message);
            }
            return View(model);
        }

        /// <summary>
        /// 登出
        /// </summary>
        /// <returns></returns>
        public ActionResult OutLogin()
        {
            CurrUser.Exit();
            return RedirectToAction("Login", "Admin", new { Areas = "Admin" });
        }

    }
}