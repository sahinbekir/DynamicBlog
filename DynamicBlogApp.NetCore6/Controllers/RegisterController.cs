using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using DynamicBlogApp.NetCore6.Models;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DynamicBlogApp.NetCore6.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
	{
        private readonly UserManager<AppUser> _userManager;
        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        //WriterManager wm = new WriterManager(new EfWriterRepository());
		
		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}
        
        [HttpPost]
		public async Task<IActionResult> Register(UserSignUpViewModel p)
		{
            if (ModelState.IsValid)
            {
                Console.WriteLine("Hahaha");
                AppUser user = new AppUser()
                {
                    Email = p.Email,
                    UserName = p.UserName,
                    NameSurname = p.NameSurname,
                    PhoneNumber = p.PhoneNumber,
                    ImageUrl = p.ImageUrl,
                };
                var result = await _userManager.CreateAsync(user, p.Password);
                if (result.Succeeded)
                {
                    Console.WriteLine("Hahahas");
                    return RedirectToAction("Index", "Login");

                }
                else
                {
                    Console.WriteLine("Hahahae");
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }

            return View(p);
        }
	}
}
