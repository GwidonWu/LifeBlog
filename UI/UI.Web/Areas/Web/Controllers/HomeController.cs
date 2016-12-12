using BLL.Contract;
using BLL.Service.Interface;
using DAL.Entity.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Web.Areas.Web.Models;

namespace UI.Web.Areas.Web.Controllers
{
    [Export]
    public class HomeController : Controller
    {
        [Import]
        private IBlogService blogService;

        [Import]
        private ICategoryService categoryService;

        [Import]
        private ICommentService commentService;

        [Import]
        private ISysLogService sysLogService;

        public ActionResult Index(int? pageindex, int id = -1)
        {
            Paging<Blog> page = new Paging<Blog>();
            page.PageIndex = pageindex == null ? 1 : pageindex.Value;
            page.PageSize = 10;
            page.Items = blogService.GetList(page, id).ToList();

            #region 构造分页
            //构造标签
            int PageCount = page.TotalNumber;
            int PageSize = page.PageSize;
            int totalPage = (PageCount + PageSize - 1) / PageSize;
            string urlhead = "/Web/Home/Index/" + id + ".html" + "?pageindex=";
            string pages = "<li><a href='" + urlhead + "1" + "'>首页</a></li>"; ;
            if (page.PageIndex == 1)
            {
                pages += "<li class='disabled'><a href='#'>上一页</a></li>";
            }
            else
            {
                pages += "<li ><a href='" + urlhead + (page.PageIndex - 1) + "'>上一页</a></li>";
            }
            if (page.PageIndex == totalPage)
            {
                pages += "<li class='disabled'><a href='#'>下一页</a></li>";
            }
            else
            {
                pages += "<li ><a href='" + urlhead + (page.PageIndex + 1) + "'>下一页</a></li>";
            }
            pages += "<li ><a href='" + urlhead + totalPage + "'>最后一页</a></li>";
            ViewBag.Page = pages;
            ViewBag.PageIndex = page.PageIndex;
            ViewBag.PageCount = totalPage;
            #endregion

            var model = new ListModel();
            model.blogModel = page.Items.ToList();
            model.categoryModel = categoryService.FindList().ToList();
            model.commentModel2 = commentService.FindList().OrderByDescending(b => b.CommentTime);
            model.blogModel2 = blogService.FindList().OrderByDescending(t => t.BrowseNum).ToList();
            model.blogModel3 = blogService.FindList().OrderByDescending(t => t.Comment).ToList();

            var sysLog = new SysLog();
            sysLog.DATES = DateTime.Now;
            sysLog.CLIENTIP = Request.UserHostAddress;
            sysLog.CLIENTUSER = Request.UserHostName;
            sysLogService.Add(sysLog);
            return View(model);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult AnniversaryDay()
        {
            return View();
        }

        public ActionResult Love()
        {
            return View();
        }
    }
}