using System.ComponentModel.DataAnnotations;

namespace NewBlogProject.Identity.Models.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Paraola")]
        public string Password { get; set; }

        [Display(Name = "Beni hatırla")]
        public bool RememberMe { get; set; }

        [Required]
        [Display(Name = "Doğrulma kodunu girin")]
        public string Captcha { get; set; }


    }
}
