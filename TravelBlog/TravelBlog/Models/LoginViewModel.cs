using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TravelBlog.Models
{
    public class LoginViewModel{

        [Required]
        [EmailAddress]
        [Display(Name = "Eposta")]        

        public string? Email {get; set;}

        [Required]
        [StringLength(15, ErrorMessage ="Maks. 15 Karakter",MinimumLength =6)]
        [DataType(DataType.Password)]
        [Display(Name ="Parola")]
        public string? Password {get; set;}
    }
}