using BLL.Service.Interface;
using DAL.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Contract;
using System.ComponentModel.Composition;

namespace BLL.Service.Service
{
    [Export(typeof(IMessageService))]
    public class MessageService : BaseService<Message, int>, IMessageService
    {
        public OperResult AddBlog(Message message)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Message> GetList(Paging<Message> paging, int categoryId = -1)
        {
            CategoryService categoryService = new CategoryService();
            Category category = categoryService.Find(categoryId);
            IQueryable<Message> _list = Repository.FindList();
            _list = _list.OrderBy(b => b.MessageTime);
            paging.TotalNumber = _list.Count();
            return _list.Skip((paging.PageIndex - 1) * paging.PageSize).Take(paging.PageSize);
        }

        public IQueryable<Message> GetList(Paging<Message> paging, string where = "")
        {
            IQueryable<Message> _list = Repository.FindList();
            if (!string.IsNullOrEmpty(where))
            {
                _list = _list.Where(b => b.Content.Contains(where));
            }
            _list = _list.OrderBy(b => b.MessageTime);
            paging.TotalNumber = _list.Count();
            return _list.Skip((paging.PageIndex - 1) * paging.PageSize).Take(paging.PageSize);
        }
    }
}
