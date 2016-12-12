using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity.Entities
{
    public class Blog : EntityBase<int>
    {
        [Required(ErrorMessage = "{0}是必须的")]
        [Display(Name = "标题")]
        [StringLength(50, ErrorMessage = "长度必须少于{1}个字")]
        public string Title { get; set; }

        [Display(Name = "描述")]
        [StringLength(1000, ErrorMessage = "长度必须少于{1}个字")]
        public string Description { get; set; }

        [Required(ErrorMessage = "{0}是必须的")]
        [Display(Name = "内容")]
        public string Content { get; set; }

        [Required(ErrorMessage = "{0}是必须的")]
        [Display(Name = "作者")]
        public string Author { get; set; }

        [Required(ErrorMessage = "{0}是必须的")]
        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; }

        [Required(ErrorMessage = "{0}是必须的")]
        [Display(Name = "浏览数")]
        public int BrowseNum { get; set; }

        [Display(Name = "评论数")]
        public int Comment { get; set; }

        [Display(Name = "点赞数")]
        public int Fabulous { get; set; }

        [Display(Name = "是否发布")]
        public bool Publish { get; set; }

        public int CategoryID { get; set; }

        /// <summary>
        /// 栏目
        /// </summary>
        public virtual Category Category { get; set; }
    }
}
