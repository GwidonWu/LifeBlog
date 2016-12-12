using BLL.Contract;
using BLL.Service.Interface;
using DAL.Entity.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service.Service
{
    [Export(typeof(IPhotoService))]
    public class PhotoService : BaseService<Photo, int>, IPhotoService
    {
        public IQueryable<Photo> GetList(Paging<Photo> paging, string where = "")
        {
            IQueryable<Photo> _list = Repository.FindList();
            if (!string.IsNullOrEmpty(where))
            {
                _list = _list.Where(b => b.Name.Contains(where));
            }
            _list = _list.OrderByDescending(b => b.CreateTime);
            paging.TotalNumber = _list.Count();
            return _list.Skip((paging.PageIndex - 1) * paging.PageSize).Take(paging.PageSize);
        }
    }
}
