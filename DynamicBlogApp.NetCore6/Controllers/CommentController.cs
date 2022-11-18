using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DynamicBlogApp.NetCore6.Controllers
{
    [AllowAnonymous]
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentRepository());
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult AddComment(Comment p)
        {
            p.CommentCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.CommentStatus = true;
            p.BlogID = 4;
            cm.CommentAdd(p);
            return PartialView();
        }
        public PartialViewResult CommentListByBlog(int id)
        {
            var values = cm.GetListAll(id);
            return PartialView();
        }
    
}
}
