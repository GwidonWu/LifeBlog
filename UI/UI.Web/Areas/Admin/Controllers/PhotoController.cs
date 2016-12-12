using BLL.Service.Interface;
using DAL.Entity.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Web.Areas.Admin.Models;
using UI.Web.Infrastructure;
using UI.Web.Utility;

namespace UI.Web.Areas.Admin.Controllers
{
    [Export]
    [AdminAuthor]
    public class PhotoController : Controller
    {
        [Import]
        private IPhotoService photoService;

        [Import]
        private IFileLibraryService fileLibraryService;

        [Import]
        private IAlbumService albumService;

        public ActionResult Index()
        {
            var model = photoService.FindList();
            return View(model);
        }

        public ActionResult Index2()
        {
            var model = fileLibraryService.FindList();
            return View(model);
        }

        public ActionResult PhotoUpload()
        {
            return View();
        }

        public ActionResult Album()
        {
            ViewData["result"] = albumService.FindList();
            return View();
        }

        public ActionResult AddAlbum()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAlbum(AlbumViewModel model)
        {
            Album album = new Album();
            album.Name = model.Name;
            album.Description = model.Description;
            album.CreateTime = DateTime.Now;
            albumService.Add(album);
            return RedirectToAction("/AddAlbum");
        }

        [HttpPost]
        public JsonResult DeleteAlbum(int id)
        {
            var result = albumService.Delete(id);
            return Json(id, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult PhotoUpload(IEnumerable<HttpPostedFileBase> fileName)
        {
            foreach (var file in fileName)
            {
                Photo photo = new Photo();
                photo.Name = Path.GetFileName(file.FileName);
                photo.MimeType = file.ContentType;

                using (Stream inputStream = file.InputStream)
                {
                    MemoryStream memoryStream = inputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        inputStream.CopyTo(memoryStream);
                    }
                    photo.Content = memoryStream.ToArray();
                    photo.CreateTime = DateTime.Now;
                }
                photoService.Add(photo);
            }
            return View();
        }

        public ActionResult DeletePhoto()
        {
            return View();
        }

        [HttpPost]
        public JsonResult DeletePhoto(int id)
        {
            var result = photoService.Delete(id);
            return Json(id, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeletePhoto2(int id)
        {
            var result = fileLibraryService.Delete(id);
            return Json(id, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UploadFileDemo()
        {
            return View();
        }

        [HttpPost]
        public ContentResult UploadFile(HttpPostedFileBase FileData)
        {
            if (FileData != null && FileData.ContentLength > 0)
            {
                string fileSaveFolder = Server.MapPath("~/src/Images/UploadFiles/");
                string oldName = FileData.FileName;
                string extName = Path.GetExtension(oldName);
                string newName = Guid.NewGuid().ToString() + extName;

                string oImgUrl = "~/src/Images/UploadFiles/" + newName;
                string nImgUrl = "~/src/Images/Temp/" + newName;

                string fileType = FileData.ContentType;
                int size = FileData.ContentLength;
                FileData.SaveAs(Path.Combine(fileSaveFolder, newName));

                Thumbnail.GenerateThumbnail(Server.MapPath(oImgUrl), Server.MapPath(nImgUrl), 640, 480);//生成缩略图

                #region 此处可忽略
                FileLibrary fileLibrary = new FileLibrary();
                fileLibrary.OldFileName = oldName;
                fileLibrary.NewFileName = newName;
                fileLibrary.Extension = extName;
                fileLibrary.Size = size;
                fileLibrary.Url = fileSaveFolder;
                fileLibrary.CreateTime = DateTime.Now;
                fileLibraryService.Add(fileLibrary); 
                #endregion
            }
            return Content("");
        }

        public ActionResult PictureUpload()
        {
            List<SelectListItem> albumItems = new List<SelectListItem>();
            var result = albumService.FindList();
            foreach (var item in result)
            {
                albumItems.Add(new SelectListItem() { Value = item.ID.ToString(), Text = item.Name });
            }
            ViewData["AlbumID"] = albumItems;
            return View();
        }

        /// <summary>
        /// 上传到服务器文件夹
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PictureUpload(HttpPostedFileBase filename,FileLibraryViewModel model)
        {
            List<SelectListItem> albumItems = new List<SelectListItem>();
            var result = albumService.FindList();
            foreach (var item in result)
            {
                albumItems.Add(new SelectListItem() { Value = item.ID.ToString(), Text = item.Name });
            }
            ViewData["AlbumID"] = albumItems;

            HttpPostedFileBase file = Request.Files["filename"];
            if (file != null)
            {
                string oldName = file.FileName;
                string extName = Path.GetExtension(oldName);
                string newName = Guid.NewGuid().ToString() + extName;
                string fileType = file.ContentType;
                int size = file.ContentLength;

                string oImgUrl = "~/src/Images/UploadFiles/" + newName;
                string nImgUrl = "~/src/Images/Temp/" + newName;

                var fileName = file.FileName;//Path.GetExtension() 也许可以解决这个问题，先不管了。
                if (fileName.LastIndexOf("\\", System.StringComparison.Ordinal) > -1)//在不同浏览器下，filename有时候指的是文件名，有时候指的是全路径，所有这里要要统一。
                {
                    fileName = fileName.Substring(fileName.LastIndexOf("\\", System.StringComparison.Ordinal) + 1);//IndexOf 有时候会受到特殊字符的影响而判断错误。加上这个就纠正了。
                }
                var image = Path.GetExtension(fileName.ToLower());
                if (image != ".bmp" && image != ".png" && image != ".gif" && image != ".jpg" && image != ".jpeg")// 这里你自己加入其他图片格式，最好全部转化为大写再判断，我就偷懒了
                {
                    return View("PictureUpload"); //  
                }

                var filepath = Path.Combine(HttpContext.Server.MapPath("~/src/Images/UploadFiles/"), newName);

                file.SaveAs(filepath);

                Thumbnail.GenerateThumbnail(Server.MapPath(oImgUrl), Server.MapPath(nImgUrl), 640, 480);
                //var filepath1 = Path.Combine(HttpContext.Server.MapPath("~/src/Images/Temp/"));
                //file.SaveAs(filepath1);

                //string filename = file.FileName;
                var savePath = Server.MapPath("~/src/Images/UploadFiles/");
                             
                FileLibrary fileLibrary = new FileLibrary();
                fileLibrary.OldFileName = oldName;
                fileLibrary.NewFileName = newName;
                fileLibrary.Extension = extName;
                fileLibrary.Size = size;
                fileLibrary.Url = savePath;
                fileLibrary.Description = model.Description;
                fileLibrary.CreateTime = DateTime.Now;
                fileLibrary.AlbumID = model.AlbumID;
                fileLibraryService.Add(fileLibrary);

                var album = albumService.Find(model.AlbumID);
                album.Count = album.Count + 1;
                albumService.Update(album);
            }
            return RedirectToAction("/PictureUpload");
        }
    }
}