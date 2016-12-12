using BLL.Contract;
using BLL.Service.Factory;
using BLL.Service.Interface;
using DAL.Entity.Entities;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service.Service
{
    [Export(typeof(ICommentService))]
    public class CommentService : BaseService<Comment,int>,ICommentService
    {
        public OperResult AddComment(Comment comment)
        {
            comment.CommentTime = DateTime.Now;
            return base.Add(comment);
        }
    }
}
