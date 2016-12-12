using AutoMapper;
using BLL.Service.Interface;
using DAL.Entity.Entities;
using DAL.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Web;
using System.Web.Mvc;
using UI.Web.Areas.Admin.Models;
using UI.Web.Infrastructure;

namespace UI.Web.Areas.Admin.Controllers
{
    [Export]
    [AdminAuthor]
    public class BlogController : Controller
    {
        [Import]
        private IBlogService blogService;

        [Import]
        private ICategoryService categoryService;

        public ActionResult Index()
        {
            ViewData["result"] = GetBlogList();
            return View();
        }

        [HttpGet]
        public IEnumerable<Blog> GetBlogList()
        {
            var result = blogService.FindList();
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public ActionResult AddBlog()
        {
            List<SelectListItem> categoryItems = new List<SelectListItem>();
            var result = categoryService.FindList();
            foreach (var item in result)
            {
                categoryItems.Add(new SelectListItem() { Value = item.ID.ToString(), Text = item.Name });
            }
            ViewData["CategoryID"] = categoryItems;
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult AddBlog(BlogViewModel model)
        {
            List<SelectListItem> categoryItems = new List<SelectListItem>();
            var result = categoryService.FindList();
            foreach (var item in result)
            {
                categoryItems.Add(new SelectListItem() { Value = item.ID.ToString(), Text = item.Name });
            }
            ViewData["CategoryID"] = categoryItems;

            Blog blog = Mapper.Map<Blog>(model);
            var category = categoryService.Find(model.CategoryID);
            blog.Category = category;
            blogService.AddBlog(blog);
            category.Count = category.Count + 1;
            categoryService.Update(category);
            return RedirectToAction("/AddBlog");
        }

        public ActionResult DeleteBlog()
        {
            return View();
        }

        [HttpPost]
        public JsonResult DeleteBlog(int id)
        {
            var result = blogService.Delete(id);
            return Json(id,JsonRequestBehavior.AllowGet);
        }

        public ActionResult ModifyBlog(int id)
        {
            Session["id"] = id;
            var blogViewModel = new BlogViewModel();
            var blog= blogService.Find(id);
            blogViewModel.Title = blog.Title;
            blogViewModel.Author = blog.Author;
            blogViewModel.Description = blog.Description;
            blogViewModel.Content = blog.Content;
            return View(blogViewModel);
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult ModifyBlog(BlogViewModel model)
        {
            int id = Convert.ToInt32(Session["id"]);
            var blog = blogService.Find(id);
            blog.Title = model.Title;
            blog.Author = model.Author;
            blog.Description = model.Description;
            blog.Content = model.Content;
            blogService.Update(blog);
            return RedirectToAction("/ModifyBlog");
        }

        /// <summary>
        /// ckeditor上传图片
        /// </summary>
        /// <param name="upload"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase upload)
        {
            var fileName = System.IO.Path.GetFileName(upload.FileName);
            var filePhysicalPath = Server.MapPath("~/src/Images/Imgs/" + fileName);//我把它保存在网站根目录的 Images 文件夹

            upload.SaveAs(filePhysicalPath);

            var url = "/src/Images/Imgs/" + fileName;
            var CKEditorFuncNum = System.Web.HttpContext.Current.Request["CKEditorFuncNum"];

            //上传成功后，我们还需要通过以下的一个脚本把图片返回到第一个tab选项
            return Content("<script>window.parent.CKEDITOR.tools.callFunction(" + CKEditorFuncNum + ", \"" + url + "\");</script>");
        }
    }
}