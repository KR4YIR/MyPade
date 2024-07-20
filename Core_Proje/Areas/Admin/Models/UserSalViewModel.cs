using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Principal;

namespace Core_Proje.Areas.Admin.Models
{
    public class UserSalViewModel
    {
        public AdminUser kullanici { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile Image { get; set; }
        public string Category { get; set; }
        public string City { get; set; }
        //  public string Aciklama { get; set; }
        // public int LikeCount { get; set; }
        //  public int KategoriNo { get; set; }
    }
}