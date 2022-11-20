using DataAccessLayer.Concrete;
using DynamicBlogApp.NetCore6.Areas.Admin.Models;
using DynamicBlogApp.NetCore6.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DynamicBlogApp.NetCore6.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        Context c = new Context();
        public AdminProfileController(UserManager<AppUser> userManager)
        {

            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> EditAdmin()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            AdminUpdateViewModel model = new AdminUpdateViewModel();
            model.namesurname = user.NameSurname;
            model.adminphone = user.PhoneNumber;
            model.adminemail = user.Email;
            model.adminusername = user.UserName;
            model.adminimg = user.ImageUrl;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditAdmin(AdminUpdateViewModel model)
        {
            //var values = _roleManager.Roles.Where(x => x.Id == model.id).FirstOrDefault();
            //var user =  _userManager.Users.Where(x => x.UserName == model.adminusername).FirstOrDefault();
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var danger = false;
            if (user.UserName != model.adminusername)
            {
                danger = true;
            }
            user.NameSurname = model.namesurname;
            user.PhoneNumber = model.adminphone;
            user.Email = model.adminemail;
            user.UserName = model.adminusername;


            if (model.adminpassword != null)
            {
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.adminpassword);
            }
            //user.PasswordHash = model.password;

            if (model.adminimg != null)
            {
                user.ImageUrl = model.adminimg;
            }
            var result = await _userManager.UpdateAsync(user);
            if (danger == true)
            {

                return RedirectToAction("LogOut", "AdminMessage");
            }
            else
            {
                return RedirectToAction("EditAdmin", "AdminProfile");
            }



        }
    }
}
