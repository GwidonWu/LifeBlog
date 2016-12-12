using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Web.Utility
{
    /// <summary>
    /// 对象映射配置类
    /// </summary>
    public class Configuration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<Test>();
                cfg.AddProfile<Profiles.AddBlog_Blog>();
                cfg.AddProfile<Profiles.ModifyBlog_Blog>();
            });
        }
    }
}