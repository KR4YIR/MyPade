using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Post
{
    public class PostList : ViewComponent
    {
        private HomeManager postManager = new HomeManager(new EfHomeDal());

        public IViewComponentResult Invoke()
        {
            var values = postManager.TGetPostWithUser(null, null);
            return View(values);
        }
    }
}