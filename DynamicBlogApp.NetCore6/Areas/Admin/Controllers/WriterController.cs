using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DynamicBlogApp.NetCore6.Areas.Admin.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DynamicBlogApp.NetCore6.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class WriterController : Controller
    {
        UserManager _userManager = new UserManager(new EfUserRepository());
        public IActionResult AllWriters()
        {
            var values = _userManager.GetListAll();
            return View(values);
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetWriterById(int writerid)
        {
            var findWriter = writers.FirstOrDefault(x=>x.Id==writerid);
            var jsonWriters = JsonConvert.SerializeObject(findWriter);
            return Json(jsonWriters);
        }
        public IActionResult WriterList()
        {
            var jsonWriters = JsonConvert.SerializeObject(writers);
            return Json(jsonWriters);
        }
        [HttpPost]
        public IActionResult AddWriter(WriterClass w)
        {
            writers.Add(w);
            var jsonwriters = JsonConvert.SerializeObject(w);
            return Json(jsonwriters);
        }
        public IActionResult DeleteWriter(int id)
        {
            var writer = writers.FirstOrDefault(x=>x.Id==id);
            writers.Remove(writer);
            //var jsonwriters = JsonConvert.SerializeObject(w);
            return Json(writers);
        }
        public IActionResult UpdateWriter(WriterClass w)
        {
            var writer = writers.FirstOrDefault(x => x.Id == w.Id);
            writer.Name = w.Name;
            var jsonwriter = JsonConvert.SerializeObject(w);
            return Json(jsonwriter);
        }
        public static List<WriterClass> writers = new List<WriterClass>
        {
            new WriterClass()
            {
                Id=1,
                Name="Bekir"
            },
            new WriterClass()
            {
                Id =2,
                Name = "Şahin"
            }
        };
    }
}
