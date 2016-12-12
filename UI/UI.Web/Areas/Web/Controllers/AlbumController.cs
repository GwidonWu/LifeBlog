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
    public class AlbumController : Controller
    {
        [Import]
        private IAlbumService albumService;

        [Import]
        private IFileLibraryService filebraryService;

        public ActionResult Index(int? pageindex, int id = -1)
        {
            Paging<Album> page = new Paging<Album>();
            page.PageIndex = pageindex == null ? 1 : pageindex.Value;
            page.PageSize = 10;
            page.Items = albumService.GetList(page, "").ToList();

            #region 构造分页
            //构造标签
            int PageCount = page.TotalNumber;
            int PageSize = page.PageSize;
            int totalPage = (PageCount + PageSize - 1) / PageSize;
            string urlhead = "/Web/Album/Index/" + id + ".html" + "?pageindex=";
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

            return View(page.Items);
        }

        public ActionResult AlbumDetail(int id)
        {
            Session["id"] = id;
            return RedirectToAction("/AlbumDetail2/" + id);
        }

        public ActionResult AlbumDetail2(int? pageindex, int id = -1)
        {
            var id2 = Convert.ToInt32(Session["id"]);
            Paging<FileLibrary> page = new Paging<FileLibrary>();
            page.PageIndex = pageindex == null ? 1 : pageindex.Value;
            page.PageSize = 10;
            page.Items = filebraryService.GetList(page, id).Where(t => t.AlbumID == id2).ToList();

            #region 构造分页
            //构造标签
            int PageCount = page.TotalNumber;
            int PageSize = page.PageSize;
            int totalPage = (PageCount + PageSize - 1) / PageSize;
            string urlhead = "/Web/Album/AlbumDetail/" + id + ".html" + "?pageindex=";
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

            return View(page.Items);
        }
    }
}