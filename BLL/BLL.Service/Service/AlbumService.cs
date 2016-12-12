using BLL.Service.Interface;
using DAL.Entity.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Contract;

namespace BLL.Service.Service
{
    [Export(typeof(IAlbumService))]
    public class AlbumService : BaseService<Album, int>, IAlbumService
    {

        public IQueryable<Album> GetList(Paging<Album> paging, string where = "")
        {
            IQueryable<Album> _list = Repository.FindList();
            if (!string.IsNullOrEmpty(where))
            {
                _list = _list.Where(b => b.Name.Contains(where));
            }
            _list = _list.OrderBy(b => b.CreateTime);
            paging.TotalNumber = _list.Count();
            return _list.Skip((paging.PageIndex - 1) * paging.PageSize).Take(paging.PageSize);
        }
    }
}
