using DAL.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Web.Areas.Web.Models
{
    public class ListModel
    {
        public IList<Blog> blogModel { get; set; }

        public IList<Category> categoryModel { get; set; }

        public IQueryable<Comment> commentModel { get; set; }

        public CommentViewModel commentViewModel { get; set; }

        public Blog blog { get; set; }

        public MessageViewModel messageViewModel { get; set; }

        public IList<Message> messageModel { get; set; }

        public Category category { get; set; }

        /// <summary>
        /// 阅读排行榜
        /// </summary>
        public IList<Blog> blogModel2 { get; set; }

        /// <summary>
        /// 评论排行榜
        /// </summary>
        public IList<Blog> blogModel3 { get; set; }

        /// <summary>
        /// 最新评论
        /// </summary>
        public IQueryable<Comment> commentModel2 { get; set; }
    }
}