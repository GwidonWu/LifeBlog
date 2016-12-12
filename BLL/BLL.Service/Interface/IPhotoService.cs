using BLL.Contract;
using DAL.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service.Interface
{
    public interface IPhotoService : IBaseService<Photo, int>
    {
        /// <summary>
        /// 分页 管理
        /// </summary>
        /// <param name="paging"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        IQueryable<Photo> GetList(Paging<Photo> paging, string where = "");
    }
}
