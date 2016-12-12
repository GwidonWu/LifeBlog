using BLL.Contract;
using BLL.Service.Interface;
using DAL.Entity.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Web.Utility;

namespace UI.Web.Areas.Web.Controllers
{
    [Export]
    public class PhotoController : Controller
    {
        [Import]
        private IPhotoService photoService;
        [Import]
        private IFileLibraryService fileLibraryService;

        public ActionResult Index(int? pageindex, int id = -1)
        {
            Paging<Photo> page = new Paging<Photo>();
            page.PageIndex = pageindex == null ? 1 : pageindex.Value;
            page.PageSize = 9;
            page.Items = photoService.GetList(page, "").ToList();

            #region 构造分页
            //构造标签
            int PageCount = page.TotalNumber;
            int PageSize = page.PageSize;
            int totalPage = (PageCount + PageSize - 1) / PageSize;
            string urlhead = "/Web/Photo/Index/" + id + ".html" + "?pageindex=";
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

            var model = page.Items.ToList();
            return View(model);
        }


        public ActionResult ViewUploadPhoto(int? pageindex, int id = -1)
        {
            Paging<FileLibrary> page = new Paging<FileLibrary>();
            page.PageIndex = pageindex == null ? 1 : pageindex.Value;
            page.PageSize = 1000;
            page.Items = fileLibraryService.GetList(page, "").ToList();

            #region 构造分页
            //构造标签
            int PageCount = page.TotalNumber;
            int PageSize = page.PageSize;
            int totalPage = (PageCount + PageSize - 1) / PageSize;
            string urlhead = "/Web/Photo/ViewUploadPhoto/" + id + ".html" + "?pageindex=";
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

            var model = page.Items.ToList();
            return View(model);
        }

        public JsonResult GetAllUploadFile(int? pageindex, int id = -1)
        {
            //var model = fileLibraryService.FindList();
            //return Json(model, JsonRequestBehavior.AllowGet);

            Paging<FileLibrary> page = new Paging<FileLibrary>();
            page.PageIndex = pageindex == null ? 1 : pageindex.Value;
            page.PageSize = 1000;
            page.Items = fileLibraryService.GetList(page, "").ToList();

            #region 构造分页
            //构造标签
            int PageCount = page.TotalNumber;
            int PageSize = page.PageSize;
            int totalPage = (PageCount + PageSize - 1) / PageSize;
            string urlhead = "/Web/Photo/ViewUploadPhoto/" + id + ".html" + "?pageindex=";
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

            var model = page.Items.ToList();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetUploadFileByPrimaryKey(FileLibrary fileLibrary)
        {
            var model = fileLibraryService.FindList(t => t.ID == fileLibrary.ID);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取缩略图
        /// </summary>
        /// <param name="fileLibrary"></param>
        /// <returns></returns>
        public ContentResult GetThumbnailImage(FileLibrary fileLibrary)
        {
            string oImgUrl = "~/src/Images/UploadFiles/" + fileLibrary.NewFileName;

            string extName = Path.GetExtension(fileLibrary.NewFileName);
            string newName = Guid.NewGuid().ToString() + extName;
            string nImgUrl = "~/src/Images/Temp/" + newName;

            Thumbnail.GenerateThumbnail(Server.MapPath(oImgUrl), Server.MapPath(nImgUrl), 320, 240);

            string htmltag = "<img id=\"img1\" src=\"/src/Images/Temp/" + newName + "\"/>";
            return Content(htmltag);
        }

        /// <summary>
        /// 获取大图
        /// </summary>
        /// <param name="fileLibrary"></param>
        /// <returns></returns>
        public ContentResult GetImage(FileLibrary fileLibrary)
        {
            string htmltag = "<img id=\"img1\" src=\"/src/Images/UploadFiles/" + fileLibrary.NewFileName + "\">";
            return Content(htmltag);
        }
    }
}