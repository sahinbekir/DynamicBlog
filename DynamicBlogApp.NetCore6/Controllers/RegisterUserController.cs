using DynamicBlogApp.NetCore6.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DynamicBlogApp.NetCore6.Controllers
{
    [AllowAnonymous]
    public class RegisterUserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterUserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserSignUpViewModel p)
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
                var result = await _userManager.CreateAsync(user,p.Password);
                if (result.Succeeded)
                {
                    Console.WriteLine("Hahahas");
                    return RedirectToAction("Index","Login");

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
