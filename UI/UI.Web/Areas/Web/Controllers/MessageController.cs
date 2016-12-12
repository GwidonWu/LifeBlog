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
    public class MessageController : Controller
    {
        [Import]
        private IMessageService messageService;

        // GET: Web/Message
        public ActionResult Index(int? pageindex, int id = -1)
        {
            Paging<Message> page = new Paging<Message>();
            page.PageIndex = pageindex == null ? 1 : pageindex.Value;
            page.PageSize = 10;
            page.Items = messageService.GetList(page, "").ToList();

            #region 构造分页
            //构造标签
            int PageCount = page.TotalNumber;
            int PageSize = page.PageSize;
            int totalPage = (PageCount + PageSize - 1) / PageSize;
            string urlhead = "/Web/Message/Index/" + id + ".html" + "?pageindex=";
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
            model.messageModel = page.Items.ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult AddMessage(MessageViewModel messageViewModel)
        {
            if (messageViewModel.Name == null || messageViewModel.Content == null)
            {
                return RedirectToAction("/Index");
            }
            else
            {
                Message message = new Message();
                message.Content = messageViewModel.Content;
                message.MessageTime = DateTime.Now;
                message.Name = messageViewModel.Name;
                message.MessageIP = Request.UserHostAddress;
                messageService.Add(message);
                return RedirectToAction("/Index");
            }
        }
    }
}