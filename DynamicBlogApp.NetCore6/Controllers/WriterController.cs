using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using DynamicBlogApp.NetCore6.Models;

namespace DynamicBlogApp.NetCore6.Controllers
{
	public class WriterController : Controller
	{

		WriterManager wm = new WriterManager(new EfWriterRepository());
		public IActionResult Index()
		{
			return View();
		}

		public PartialViewResult WriterNavbarPartial()
		{
			return PartialView();
		}
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }
		[HttpGet]
		public IActionResult WriterEditProfile()
		{
			var writervalues = wm.GetById(1);
			return View(writervalues);
		}
        [HttpPost]
        public IActionResult WriterEditProfile(Writer p)
        {
			WriterValidator wl = new WriterValidator();
			ValidationResult results = wl.Validate(p);
            //ValidationResult Error about that: Rendering DataAnnotations
            if (results.IsValid)
			{
				wm.TUpdate(p);
				return RedirectToAction("Index", "Dashboard");
			}
			else
			{
				foreach(var item in results.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View();
            
        }
		[HttpGet]
		public IActionResult WriterAdd()
		{
			return View();
		}
		[HttpPost]
        public IActionResult WriterAdd(AddProfileImage p)
        {
            Writer w = new Writer();
            if (p.WriterImage != null)
            {
                var extension = Path.GetExtension(p.WriterImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.WriterImage.CopyTo(stream);
                //p.WriterImage = newimagename;
            }
            w.WriterID = 0;
            w.WriterName = p.WriterName;
            w.WriterEmail = p.WriterEmail;
            w.WriterAbout = p.WriterAbout;
            w.WriterPassword = p.WriterPassword;
            w.WriterStatus = true;
            //wm.TAdd(p);
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
