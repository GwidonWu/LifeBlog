using BLL.Contract;
using DAL.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service.Interface
{
    public interface IFileLibraryService : IBaseService<FileLibrary, int>
    {
        /// <summary>
        /// 分页 管理
        /// </summary>
        /// <param name="paging"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        IQueryable<FileLibrary> GetList(Paging<FileLibrary> paging, string where = "");

        IQueryable<FileLibrary> GetList(Paging<FileLibrary> paging, int albumID = -1);
    }
}
