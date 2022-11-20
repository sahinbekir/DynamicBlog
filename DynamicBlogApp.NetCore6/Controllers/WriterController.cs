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
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using DocumentFormat.OpenXml.Spreadsheet;

namespace DynamicBlogApp.NetCore6.Controllers
{
    [Authorize(Roles = "Writer")]
    public class WriterController : Controller
    {

        
        private readonly UserManager<AppUser> _userManager;
        Context c = new Context();
        public WriterController(UserManager<AppUser> userManager)
        {

            _userManager = userManager;
        }
        

        public PartialViewResult WriterNavbarPartial()
        {
            var username = User.Identity.Name;
            ViewBag.v11 = username;

            var writername = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            ViewBag.v21 = writername;
            var writerimg = c.Users.Where(x => x.UserName == username).Select(y => y.ImageUrl).FirstOrDefault();
            ViewBag.v31 = writerimg;
            return PartialView();
        }
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }
        [HttpGet]
        public async Task<IActionResult> WriterEditProfile()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel model = new UserUpdateViewModel();
            model.ns = user.NameSurname;
            model.phone = user.PhoneNumber;
            model.email = user.Email;
            model.un = user.UserName;
            model.img = user.ImageUrl;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> WriterEditProfile(UserUpdateViewModel model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var danger = false;
            if (user.UserName != model.un)
            {
                danger = true;
            }
            user.NameSurname = model.ns;
            user.PhoneNumber = model.phone;
            user.Email = model.email;
            user.UserName = model.un;
            
            
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.pass);
            //user.PasswordHash = model.password;

            if (model.img!=null)
            {
                user.ImageUrl = model.img;
            }
            var result = await _userManager.UpdateAsync(user);
            if (danger == true)
            {
                return RedirectToAction("LogOut", "Login");
            }
            else
            {
                return RedirectToAction("Index", "Dashboard");
            }

           
            /*
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
			return View();*/

        }
        //WriterManager wm = new WriterManager(new EfWriterRepository());
        // SADECE PROTOTİP, FOTOGRAF EKLEME ÖRNEĞİ İÇİN.
        /*[HttpGet]
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
                w.WriterImage = newimagename;
            }
            w.WriterID = 0;
            w.WriterName = p.WriterName;
            w.WriterEmail = p.WriterEmail;
            w.WriterAbout = p.WriterAbout;
            w.WriterPassword = p.WriterPassword;
            w.WriterStatus = true;
            wm.TAdd(w);
            return RedirectToAction("Index", "Dashboard");
        }*/
    }
}
