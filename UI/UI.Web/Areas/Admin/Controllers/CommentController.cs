using BLL.Service.Interface;
using DAL.Entity.Entities;
using System;
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
    public class CommentController : Controller
    {
        [Import]
        private ICommentService commentService;
        [Import]
        private IBlogService blogService;

        public ActionResult Index()
        {
            ViewData["result"] = GetCommentList();
            return View();
        }

        [HttpGet]
        public IEnumerable<Comment> GetCommentList()
        {
            var result = commentService.FindList();
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public ActionResult DeleteComment()
        {
            return View();
        }

        [HttpPost]
        public JsonResult DeleteComment(int id)
        {
            var result = commentService.Delete(id);
            return Json(id, JsonRequestBehavior.AllowGet);
        }
    }
}