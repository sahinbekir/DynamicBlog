using System.ComponentModel.DataAnnotations;

namespace DynamicBlogApp.NetCore6.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage ="Username write")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password write")]
        public string Password { get; set; }
    }
}
