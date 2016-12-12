using BLL.Contract;
using BLL.Service.Interface;
using DAL.Entity.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Infrastructures;
using UI.Web.Areas.Web.Models;

namespace UI.Web.Areas.Web.Controllers
{
    [Export]
    public class BlogController : Controller
    {
        [Import]
        private IBlogService blogService;
        [Import]
        private ICommentService commentService;
        [Import]
        private ICategoryService categoryService;
        [Import]
        private IBlogBrowseIPService blogBrowseIPService;

        // GET: Web/Blog
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
            string urlhead = "/Web/Blog/Index/" + id + ".html" + "?pageindex=";
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

        [HttpGet]
        public ActionResult BlogDetail(int id)
        {
            BlogBrowseIP blogBrowseIP = new BlogBrowseIP();
            var model = new ListModel();
            //Blog blog = blogService.Find(id);
            model.blog = blogService.Find(id);
            if (model.blog == null)
            {
                return View("Prompt", new Prompt() { Title = "错误", Message = "该文章不存在!" });
            }
            if (!model.blog.Publish)
            {
                return View("Prompt", new Prompt() { Title = "错误", Message = "该文章未发布!" });
            }

            ViewBag.PrevAndNext = GetBlogPrevAndNext(id);//文章上一篇和下一篇

            var result = blogBrowseIPService.FindList(t => t.BlogID == id).Where(t => t.BrowseIP == Request.UserHostAddress);
            if (!result.Any())
            {
                model.blog.BrowseNum = model.blog.BrowseNum + 1;
                blogBrowseIP.BrowseIP = Request.UserHostAddress;
                blogBrowseIP.BrowseTime = DateTime.Now;
                blogBrowseIP.BlogID = id;
                blogBrowseIPService.Add(blogBrowseIP);
            }
            else
            {
                foreach (var item in result)
                {
                    if (item.BrowseIP == Request.UserHostName)
                    {
                        break;
                    }
                    else
                    {
                        model.blog.BrowseNum = model.blog.BrowseNum + 1;
                        blogBrowseIP.BrowseIP = Request.UserHostAddress;
                        blogBrowseIP.BrowseTime = DateTime.Now;
                        blogBrowseIP.BlogID = id;
                        blogBrowseIPService.Add(blogBrowseIP);
                        break;
                    }
                }
            }

            //model.blog.BrowseNum = model.blog.BrowseNum + 1;
            model.blog.Comment = commentService.FindList(m => m.BlogID == id).Count();
            blogService.Update(model.blog);
            model.commentModel = commentService.FindList(m => m.BlogID == id);

            model.categoryModel = categoryService.FindList().ToList();
            model.commentModel2 = commentService.FindList().OrderByDescending(b => b.CommentTime);
            model.blogModel2 = blogService.FindList().OrderByDescending(t => t.BrowseNum).ToList();
            model.blogModel3 = blogService.FindList().OrderByDescending(t => t.Comment).ToList();
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult AddComment(CommentViewModel commentViewModel)
        {
            if (commentViewModel.Name == null || commentViewModel.Content == null)
            {
                return RedirectToAction("/BlogDetail/" + commentViewModel.BlogID);
            }
            else
            {
                Comment comment = new Comment();
                comment.BlogID = commentViewModel.BlogID;
                comment.Name = commentViewModel.Name;
                comment.Content = commentViewModel.Content;
                comment.CommentIP = Request.UserHostAddress;
                comment.CommentTime = DateTime.Now;
                var result = commentService.Add(comment);
                return RedirectToAction("/BlogDetail/" + commentViewModel.BlogID);
            }
        }

        [HttpGet]
        public ActionResult BlogCategory(int id)
        {
            Session["id"] = id;
            return RedirectToAction("/BlogCategory2/" + id);
        }

        public ActionResult BlogCategory2(int? pageindex, int id = -1)
        {
            var id2 = Convert.ToInt32(Session["id"]);
            var model = new ListModel();
            Paging<Blog> page = new Paging<Blog>();
            page.PageIndex = pageindex == null ? 1 : pageindex.Value;
            page.PageSize = 10;
            page.Items = blogService.GetList(page, id).Where(t => t.CategoryID == id2).ToList();

            #region 构造分页
            //构造标签
            int PageCount = page.TotalNumber;
            int PageSize = page.PageSize;
            int totalPage = (PageCount + PageSize - 1) / PageSize;
            string urlhead = "/Web/Blog/BlogCategory/" + id + ".html" + "?pageindex=";
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

            model.blogModel = page.Items;
            return View(model);
        }

        /// <summary>
        /// 获取当前文章上一篇和下一篇
        /// </summary>
        /// <param name="id">当前文章ID</param>
        /// <returns></returns>
        public List<Tuple<int, string>> GetBlogPrevAndNext(int id)
        {
            var all = blogService.FindList();
            var result = new List<Tuple<int, string>>();
            var curr = all.First(x => x.ID == id);
            if (all.Count() > 1)
            {
                var prev = (from p in all where id > p.ID && p.ID == all.Where(x => x.ID < id).Max(x => x.ID) select p).FirstOrDefault() ?? new Blog();
                var next = (from p in all where id < p.ID && p.ID == all.Where(x => x.ID > id).Min(x => x.ID) select p).FirstOrDefault() ?? new Blog();
                result.Add(new Tuple<int, string>(prev.ID, prev.Title));
                result.Add(new Tuple<int, string>(next.ID, next.Title));
            }
            return result;
        }
    }
}