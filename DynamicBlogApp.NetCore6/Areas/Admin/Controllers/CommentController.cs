using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DynamicBlogApp.NetCore6.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : Controller
    {
        CommentManager _commentManager = new CommentManager(new EfCommentRepository());

        public IActionResult Index()
        {
            var values = _commentManager.GetCommentsForAdmin();
            return View(values);
        }
        /*
        public IActionResult DeleteComment(int id)
        {
            var commentvalue = _commentManager.GetById(id);
            _commentManager.TDelete(commentvalue)
            return RedirectToAction("/Admin/Comment/");
        }*/
    }
}
