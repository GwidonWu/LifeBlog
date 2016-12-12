using BLL.Contract;
using DAL.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Service.Interface
{
    public interface IBlogService : IBaseService<Blog,int>
    {
        /// <summary>
        /// 分页 管理
        /// </summary>
        /// <param name="paging"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        IQueryable<Blog> GetList(Paging<Blog> paging, string where = "");

        /// <summary>
        /// Home展示
        /// </summary>
        /// <param name="paging"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        IQueryable<Blog> GetList(Paging<Blog> paging, int categoryId = -1);

        /// <summary>
        /// 添加文章
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        OperResult AddBlog(Blog blog);

    }
}
