using System.ComponentModel.DataAnnotations;

namespace DynamicBlogApp.NetCore6.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage ="Please Write to a Role Name")]
        public string name { get; set; }
    }
}
