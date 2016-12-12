using BLL.Contract;
using DAL.Entity.Entities;

namespace BLL.Service.Interface
{
    public interface ICategoryGeneralService : IBaseService<CategoryGeneral,int>
    {
        /// <summary>
        /// 删除常规栏目-根据栏目ID
        /// </summary>
        /// <param name="categoryID">栏目ID</param>
        /// <returns></returns>
        OperResult DeleteByCategoryID(int categoryID);
    }
}
