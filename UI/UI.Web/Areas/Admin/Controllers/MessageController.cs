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
    public class MessageController : Controller
    {
        [Import]
        private IMessageService messageService;
        
        public ActionResult Index()
        {
            ViewData["result"] = GetMessageList();
            return View();
        }

        [HttpGet]
        public IEnumerable<Message> GetMessageList()
        {
            var result = messageService.FindList();
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public ActionResult DeleteMessage()
        {
            return View();
        }

        [HttpPost]
        public JsonResult DeleteMessage(int id)
        {
            var result = messageService.Delete(id);
            return Json(id, JsonRequestBehavior.AllowGet);
        }
    }
}