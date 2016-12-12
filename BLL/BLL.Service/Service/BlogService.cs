using BLL.Service.Interface;
using DAL.Entity.Entities;
using System;
using System.Linq;
using BLL.Contract;
using System.ComponentModel.Composition;
using System.Collections.Generic;

namespace BLL.Service.Service
{
    [Export(typeof(IBlogService))]
    public class BlogService : BaseService<Blog, int>, IBlogService
    {
        public OperResult AddBlog(Blog blog)
        {
            blog.CreateTime = DateTime.Now;
            blog.BrowseNum = 0;
            blog.Comment = 0;
            blog.Fabulous = 0;
            blog.Publish = true;
            return base.Add(blog);
        }

        public IQueryable<Blog> GetList(Paging<Blog> paging, int categoryId = -1)
        {
            CategoryService categoryService = new CategoryService();
            Category category = categoryService.Find(categoryId);
            IQueryable<Blog> _list = Repository.FindList().Where(b => b.Publish);
            if (category != null)
            {
                _list = _list.Where(b => b.Category.ID == category.ID);
            }
            _list = _list.OrderByDescending(b => b.CreateTime);
            paging.TotalNumber = _list.Count();
            return _list.Skip((paging.PageIndex - 1) * paging.PageSize).Take(paging.PageSize);
        }

        public IQueryable<Blog> GetList(Paging<Blog> paging, string where = "")
        {
            IQueryable<Blog> _list = Repository.FindList();
            if (!string.IsNullOrEmpty(where))
            {
                _list = _list.Where(b => b.Title.Contains(where));
            }
            _list = _list.OrderByDescending(b => b.CreateTime);
            paging.TotalNumber = _list.Count();
            return _list.Skip((paging.PageIndex - 1) * paging.PageSize).Take(paging.PageSize);
        }
    }
}
