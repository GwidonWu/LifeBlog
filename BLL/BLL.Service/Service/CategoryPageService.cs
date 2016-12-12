using System.ComponentModel.Composition;
using DAL.Entity.Entities;
using BLL.Service.Interface;
using BLL.Contract;

namespace BLL.Service.Service
{
    [Export(typeof(ICategoryPageService))]
    public class CategoryPageService : BaseService<CategoryPage, int>, ICategoryPageService
    {
        /// <summary>
        /// 删除单页栏目-根据栏目ID
        /// </summary>
        /// <param name="categoryID">栏目ID</param>
        /// <returns></returns>
        public OperResult DeleteByCategoryID(int categoryID)
        {
            return base.Delete(cp => cp.CategoryID == categoryID);
        }
    }
}
