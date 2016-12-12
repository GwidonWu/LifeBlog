using System.ComponentModel.DataAnnotations;

namespace UI.Web.Areas.Admin.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "用户名")]
        public string AdminName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }
    }
}