using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity.Entities
{
    public enum CategoryType
    {
        /// <summary>
        /// 常规栏目
        /// </summary>
        [Display(Name = "常规栏目", Description = "可以添加内容，不能添加子栏目")]
        常规栏目,
        /// <summary>
        /// 单页栏目
        /// </summary>
        [Display(Name = "单页栏目", Description = "仅有一个页面的栏目")]
        单页栏目,
        /// <summary>
        /// 外部链接
        /// </summary>
        [Display(Name = "外部链接", Description = "点击跳转到指定链接")]
        外部链接
    }
}
