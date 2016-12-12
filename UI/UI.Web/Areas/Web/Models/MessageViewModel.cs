using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UI.Web.Areas.Web.Models
{
    public class MessageViewModel
    {
        [Required(ErrorMessage = "{0}是必须的")]
        [Display(Name = "留言内容")]
        [StringLength(500, ErrorMessage = "长度必须少于{1}个字")]
        public string Content { get; set; }

        [Required(ErrorMessage = "{0}是必须的")]
        [Display(Name = "留言人")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0}是必须的")]
        [Display(Name = "留言时间")]
        public DateTime MessageTime { get; set; }
    }
}