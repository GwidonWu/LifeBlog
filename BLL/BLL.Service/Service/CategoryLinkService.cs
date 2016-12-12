using System.ComponentModel.Composition;
using BLL.Contract;
using BLL.Service.Service;
using DAL.Entity.Entities;
using BLL.Service.Interface;

namespace BLL.Service.Service
{
    [Export(typeof(ICategoryLinkService))]
    /// <summary>
    /// 链接栏目管理
    /// </summary>
    public class CategoryLinkService : BaseService<CategoryLink, int>, ICategoryLinkService
    {
        /// <summary>
        /// 删除链接栏目-根据栏目ID
        /// </summary>
        /// <param name="categoryID">栏目ID</param>
        /// <returns></returns>
        public OperResult DeleteByCategoryID(int categoryID)
        {
            return base.Delete(cl => cl.CategoryID == categoryID);
        }
    }
}
