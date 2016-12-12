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
    [Export(typeof(IFileLibraryService))]
    public class FileLibraryService : BaseService<FileLibrary, int>, IFileLibraryService
    {
        public IQueryable<FileLibrary> GetList(Paging<FileLibrary> paging, int albumID = -1)
        {
            AlbumService albumService = new AlbumService();
            Album album = albumService.Find(albumID);
            IQueryable<FileLibrary> _list = Repository.FindList();
            if (album != null)
            {
                _list = _list.Where(b => b.Album.ID == album.ID);
            }
            _list = _list.OrderByDescending(b => b.CreateTime);
            paging.TotalNumber = _list.Count();
            return _list.Skip((paging.PageIndex - 1) * paging.PageSize).Take(paging.PageSize);
        }

        public IQueryable<FileLibrary> GetList(Paging<FileLibrary> paging, string where = "")
        {
            IQueryable<FileLibrary> _list = Repository.FindList();
            if (!string.IsNullOrEmpty(where))
            {
                _list = _list.Where(b => b.OldFileName.Contains(where));
            }
            _list = _list.OrderByDescending(b => b.CreateTime);
            paging.TotalNumber = _list.Count();
            return _list.Skip((paging.PageIndex - 1) * paging.PageSize).Take(paging.PageSize);
        }
    }
}
