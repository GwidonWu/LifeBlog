using BLL.Contract;
using System.ComponentModel.Composition;
using BLL.Service.Service;
using DAL.Entity.Entities;

namespace BLL.Service.AdminService
{
    [Export(typeof(IAdminService))]
    public class AdminService : BaseService<Admin,int>,IAdminService
    {
        public OperResult Login(string adminName, string password)
        {
            OperResult result = new OperResult();
            var admin = base.Repository.Find(a=> a.AdminName == adminName);           
            if (admin == null)
            {
                result.Code = 2;
                result.Message = "帐号为:【" + adminName + "】的管理员不存在";
            }
            else if (admin.Password == password)
            {
                result.Code = 1;
                result.Message = "验证通过";
            }
            else
            {
                result.Code = 3;
                result.Message = "密码错误";
            }
            return result;
        }

        public Admin Find(string adminName)
        {
            return Repository.Find(a=> a.AdminName == adminName);
        }
    }
}
