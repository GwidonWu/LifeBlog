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
    [Export(typeof(IBlogBrowseIPService))]
    public class BlogBrowseIPService : BaseService<BlogBrowseIP,int>,IBlogBrowseIPService
    {
    }
}
