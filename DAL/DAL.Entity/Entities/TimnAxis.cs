using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity.Entities
{
    public class TimnAxis : EntityBase<int>
    {
        [Required(ErrorMessage = "{0}是必须的")]
        [Display(Name = "时间")]
        public DateTime Time { get; set; }
        [Required(ErrorMessage = "{0}是必须的")]
        [Display(Name = "标题")]
        [StringLength(50, ErrorMessage = "长度必须少于{1}个字")]
        public string Title { get; set; }
        [Required(ErrorMessage = "{0}是必须的")]
        [Display(Name = "内容")]
        [StringLength(1000, ErrorMessage = "长度必须少于{1}个字")]
        public string Content { get; set; }
    }
}
