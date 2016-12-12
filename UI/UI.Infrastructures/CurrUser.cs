using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace UI.Infrastructures
{
    public class CurrUser
    {
        #region Public Properties
        /// <summary>
        /// 当然登陆的用户ID
        /// </summary>
        public static string UserID
        {
            get
            {
                return (HttpContext.Current.Session["UserID"] ?? string.Empty).ToString();
            }
        }
        /// <summary>
        /// 当前登陆的用户名
        /// </summary>
        public static string UserName
        {
            get
            {
                return (HttpContext.Current.Session["UserName"] ?? string.Empty).ToString();
            }
        }
        /// <summary>
        /// 用户角色
        /// </summary>
        public static string Role
        {
            get
            {
                return (HttpContext.Current.Session["Role"] ?? string.Empty).ToString();
            }
        }
        /// <summary>
        /// 用户权限
        /// 增，删，改，查
        /// </summary>
        public static string Authority
        {
            get
            {
                return (HttpContext.Current.Session["Authority"] ?? string.Empty).ToString();
            }
        }
        /// <summary>
        /// 当前登陆用户存储的扩展信息
        /// </summary>
        public static string ExtInfo
        {
            get
            {
                return (HttpContext.Current.Session["ExtInfo"] ?? string.Empty).ToString();
            }
        }
        /// <summary>
        /// 是否登陆
        /// </summary>
        public static bool IsLogin
        {
            get
            {
                return !string.IsNullOrWhiteSpace(UserID);
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// 退出登陆
        /// </summary>
        public static void Exit()
        {
            HttpContext.Current.Session.Abandon();//清除全部Session
        }
        /// <summary>
        /// 将用户信息持久化到Session
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="userName"></param>
        /// <param name="extInfo"></param>
        public static void Serialize(
            int userID,
            string userName,
            string extInfo = "",
            string role = "",
            string authority = "")
        {
            HttpContext.Current.Session["UserID"] = userID;
            HttpContext.Current.Session["UserName"] = userName;
            HttpContext.Current.Session["ExtInfo"] = extInfo;
            HttpContext.Current.Session["Role"] = role;
            HttpContext.Current.Session["Authority"] = authority;

        }
        #endregion
    }
}
