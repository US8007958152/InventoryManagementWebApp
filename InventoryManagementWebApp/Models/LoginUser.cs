using System.ComponentModel.DataAnnotations;

namespace InventoryWebApp.Models
{
    public class LoginUser
    {
        [Required(ErrorMessage ="Please enter username")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please enter password")]
        public string Password { get; set; }
        public bool IsRemember { get; set; }
    }
}
