using System.ComponentModel.DataAnnotations;

namespace Core_Proje.Areas.Admin.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "isim bos birakilamaz")]
        public string Name { get; set; }
        [Required(ErrorMessage = "soyisim bos birakilamaz")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Kullanici adi bos birakilamaz")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Mail bos birakilamaz")]

        public string Email { get; set; }
        [Required(ErrorMessage = "Sifre bos birakilamaz")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Sifreyi tekrar girin")]
        [Compare("Password",ErrorMessage ="Sifreler uyumlu degil!")]
        public string ConfirmPassword { get; set; }
        

    }
}
