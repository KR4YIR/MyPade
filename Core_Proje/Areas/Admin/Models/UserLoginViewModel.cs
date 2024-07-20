using System.ComponentModel.DataAnnotations;

namespace Core_Proje.Areas.Admin.Models
{
    public class UserLoginViewModel
    {
        [Display(Name ="Username")]
        [Required(ErrorMessage ="Enter Username...!")]
        public string Username { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Enter Password...!")]
        public string Password { get; set; }
    }
}
