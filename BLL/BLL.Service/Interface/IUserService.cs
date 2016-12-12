using BLL.Contract;
using DAL.Entity.Entities;

namespace BLL.Service.Interface
{
    public interface IUserService : IBaseService<User,int>
    {
        /// <summary>
        /// 检测用户名是否重复
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        bool HasUserName(string UserName);
        /// <summary>
        /// 检测邮箱是否重复
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        bool HasEmail(string Email);

        /// <summary>
        /// 登录校验
        /// </summary>
        /// <param name="accounts"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        OperResult Login(string accounts, string password);
    }
}
