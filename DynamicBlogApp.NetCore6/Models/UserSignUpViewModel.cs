using System.ComponentModel.DataAnnotations;

namespace DynamicBlogApp.NetCore6.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name ="Ad Soyad")]
        [Required(ErrorMessage ="Please valid Name and Surname")]
        public string NameSurname { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please valid Password")]
        public string Password { get; set; }

        [Display(Name = "ConfirmPassword")]
        [Compare("Password",ErrorMessage ="Not Same Password")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Mail")]
        [Required(ErrorMessage = "Please valid Mail")]
        public string Email { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Please valid Username")]
        public string UserName { get; set; }

        [Display(Name = "ImgUrl")]
        [Required(ErrorMessage = "Please valid ImgUrl")]
        public string ImageUrl { get; set; }

        [Display(Name = "PhoneNumber")]
        [Required(ErrorMessage = "Please valid PhoneNumber")]
        public string PhoneNumber { get; set; }
    }
    
}

