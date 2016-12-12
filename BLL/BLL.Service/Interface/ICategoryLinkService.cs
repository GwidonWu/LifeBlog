using DAL.Entity.Entities;
using BLL.Contract;

namespace BLL.Service.Interface
{
    public interface ICategoryLinkService : IBaseService<CategoryLink,int>
    {
        /// <summary>
        /// 删除链接栏目-根据栏目ID
        /// </summary>
        /// <param name="categoryID">栏目ID</param>
        /// <returns></returns>
        OperResult DeleteByCategoryID(int categoryID);
    }
}
