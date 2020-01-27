using System.ComponentModel.DataAnnotations;

namespace NewBlogProject.Identity.Models.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} en az {2} karakter uzunluğunda olmalıdır.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Parola")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Tekrar parola")]
        [Compare("Password", ErrorMessage = "Şifre ve onay şifresi uyuşmuyor.")]
        public string ConfirmPassword { get; set; }
    }
}
