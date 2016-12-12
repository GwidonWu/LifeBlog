using BLL.Contract;
using DAL.Entity.Entities;
using System.Linq;

namespace BLL.Service.Interface
{
    public interface IMessageService : IBaseService<Message,int>
    {
        /// <summary>
        /// 分页 管理
        /// </summary>
        /// <param name="paging"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        IQueryable<Message> GetList(Paging<Message> paging, string where = "");

        /// <summary>
        /// Home展示
        /// </summary>
        /// <param name="paging"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        IQueryable<Message> GetList(Paging<Message> paging, int categoryId = -1);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        OperResult AddBlog(Message message);

    }
}
