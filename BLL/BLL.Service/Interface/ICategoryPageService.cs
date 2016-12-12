using BLL.Contract;
using DAL.Entity.Entities;

namespace BLL.Service.Interface
{
    public interface ICategoryPageService : IBaseService<CategoryPage,int>
    {
        /// <summary>
        /// 删除单页栏目-根据栏目ID
        /// </summary>
        /// <param name="categoryID">栏目ID</param>
        /// <returns></returns>
        OperResult DeleteByCategoryID(int categoryID);
    }
}
