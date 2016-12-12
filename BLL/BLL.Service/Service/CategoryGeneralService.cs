using System.ComponentModel.Composition;
using BLL.Service.Interface;
using DAL.Entity.Entities;
using BLL.Contract;
using BLL.Service.Service;

namespace BLL.Service.Service
{

    /// <summary>
    /// 常规栏目管理
    /// </summary>
    [Export(typeof(ICategoryGeneralService))]
    public class CategoryGeneralService : BaseService<CategoryGeneral,int>,ICategoryGeneralService
    {
        /// <summary>
        /// 删除常规栏目-根据栏目ID
        /// </summary>
        /// <param name="categoryID">栏目ID</param>
        /// <returns></returns>
        public OperResult DeleteByCategoryID(int categoryID)
        {
            return base.Delete(cg => cg.CategoryID == categoryID);
        }
    }
}
