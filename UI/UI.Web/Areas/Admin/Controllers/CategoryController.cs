using BLL.Service.Interface;
using DAL.Entity.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Web.Areas.Admin.Models;
using UI.Web.Infrastructure;

namespace UI.Web.Areas.Admin.Controllers
{
    [Export]
    [AdminAuthor]
    public class CategoryController : Controller
    {
        [Import]
        private ICategoryService categoryService;

        public ActionResult Index()
        {
            ViewData["result"] = GetCategoryList();
            return View();
        }

        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpGet]
        public IEnumerable<Category> GetCategoryList()
        {
            var result = categoryService.FindList();
            if (result == null)
            {
                return null;
            }
            return result;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCategory(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                Category category = new Category();
                category.Name = model.Name;
                category.Order = model.Order;
                category.Description = model.Description;
                category.Type = CategoryType.常规栏目;
                categoryService.Add(category);
            }
            return RedirectToAction("/AddCategory");
        }

        public ActionResult DeleteCategory()
        {
            return View();
        }

        [HttpPost]
        public JsonResult DeleteCategory(int id)
        {
            var result = categoryService.Delete(id);
            return Json(id, JsonRequestBehavior.AllowGet);
        }
    }
}