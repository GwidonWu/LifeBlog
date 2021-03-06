﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity.Entities
{
    public class ContentType : EntityBase<int>
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Required()]
        [Display(Name = "名称")]
        public string Name { get; set; }

        /// <summary>
        /// 控制器名称
        /// </summary>
        [Required()]
        [Display(Name = "控制器名称")]
        public string Controller { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        [StringLength(1000, ErrorMessage = "必须少于{1}个字")]
        [Display(Name = "说明")]
        public string Description { get; set; }
    }
}
