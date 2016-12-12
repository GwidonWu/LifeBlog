using DAL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service.Factory
{
    public class ContextFactory
    {
        /// <summary>
        /// 获取当前线程的数据上下文
        /// </summary>
        /// <returns>数据上下文</returns>
        public static LifeBlogDbContext CurrentContext()
        {
            LifeBlogDbContext dbContext = CallContext.GetData("LifeBlogDbContext") as LifeBlogDbContext;
            if (dbContext == null)
            {
                dbContext = new LifeBlogDbContext();
                CallContext.SetData("LifeBlogDbContext", dbContext);
            }
            return dbContext;
        }
    }
}
