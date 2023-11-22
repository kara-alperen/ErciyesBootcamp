using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TravelBlog.Models
{
    public class RegisterViewModel{

        [Required]
        [Display(Name ="UserName")]

        public string? UserName {get; set; } 
        [Display(Name ="Ad Soyad")]
        public string? Name {get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Eposta")]
        public string? Email {get; set; } 
        [Required]
        [StringLength(15, ErrorMessage ="Maks. 15 Karakter",MinimumLength =6)]
        [DataType(DataType.Password)]
        [Display(Name ="Parola")]
        public string? Password {get; set; } 
        [Required]
        [Compare(nameof(Password),ErrorMessage ="Parola Eşleşmiyor.")]
        [DataType(DataType.Password)]
        [Display(Name ="Parola Tekrar")]
        public string? ConfirmPassword {get; set; } 

        
    }
}