using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity.Entities
{
    public class Message : EntityBase<int>
    {
        [Required(ErrorMessage = "{0}是必须的")]
        [Display(Name = "留言内容")]
        [StringLength(500, ErrorMessage = "长度必须少于{1}个字")]
        public string Content { get; set; }

        [Required(ErrorMessage = "{0}是必须的")]
        [Display(Name = "留言时间")]
        public DateTime MessageTime { get; set; }

        [Required(ErrorMessage = "{0}是必须的")]
        [Display(Name = "留言人")]
        public string Name { get; set; }

        [Display(Name = "留言IP")]
        public string MessageIP { get; set; }

        //[Display(Name = "用户")]
        //[ForeignKey("User_Id")]
        //public virtual User User { get; set; }

        //public int User_Id { get; set; }
    }
}
