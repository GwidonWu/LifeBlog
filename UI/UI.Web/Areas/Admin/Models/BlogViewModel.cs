using System.ComponentModel.DataAnnotations;

namespace UI.Web.Areas.Admin.Models
{
    public class BlogViewModel
    {
        [Required(ErrorMessage = "{0}是必须的")]
        [Display(Name = "博客标题")]
        [StringLength(50, ErrorMessage = "长度必须少于{1}个字")]
        public string Title { get; set; }

        [Required(ErrorMessage = "{0}是必须的")]
        [Display(Name = "文章内容")]
        public string Content { get; set; }

        [Required(ErrorMessage = "{0}是必须的")]
        [Display(Name = "作者")]
        public string Author { get; set; }

        [Required(ErrorMessage = "{0}是必须的")]
        [Display(Name = "栏目ID")]
        public int CategoryID { get; set; }
    
        [Required(ErrorMessage = "{0}是必须的")]
        [Display(Name = "描述")]
        [StringLength(1000, ErrorMessage = "长度必须少于{1}个字")]
        public string Description { get; set; }

        [Display(Name = "浏览数")]
        public int BrowseNum { get; set; }

        [Display(Name = "评论数")]
        public int Comment { get; set; }

        [Display(Name = "点赞数")]
        public int Fabulous { get; set; }

        [Display(Name = "是否发布")]
        public bool Publish { get; set; }
    }
}