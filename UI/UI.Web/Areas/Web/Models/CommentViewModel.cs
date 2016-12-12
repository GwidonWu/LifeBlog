using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UI.Web.Areas.Web.Models
{
    public class CommentViewModel
    {
        [Required(ErrorMessage ="{0}是必须的")]
        [Display(Name = "文章ID")]
        public int BlogID { get; set; }

        [Required(ErrorMessage = "{0}是必须的")]
        [Display(Name = "评论人")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0}是必须的")]
        [Display(Name = "评论内容")]
        public string Content { get; set; }
    }
}