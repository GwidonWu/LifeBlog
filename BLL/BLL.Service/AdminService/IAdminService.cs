using BLL.Contract;
using BLL.Service.Interface;
using DAL.Entity.Entities;

namespace BLL.Service.AdminService
{
    public interface IAdminService : IBaseService<Admin,int>
    {
        OperResult Login(string userName,string password);

        Admin Find(string userName);
    }
}
