using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity.Entities
{
    public class Comment : EntityBase<int>
    {
        [Required(ErrorMessage = "{0}是必须的")]
        [Display(Name = "评论人")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0}是必须的")]
        [Display(Name = "内容")]
        public string Content { get; set; }
        [Display(Name = "评论时间")]
        public DateTime CommentTime { get; set; }
        [Display(Name = "IP")]
        public string CommentIP { get; set; }
        [Display(Name = "博客ID")]
        public int BlogID { get; set; }

        public virtual Blog Blog { get; set; }
    }
}
