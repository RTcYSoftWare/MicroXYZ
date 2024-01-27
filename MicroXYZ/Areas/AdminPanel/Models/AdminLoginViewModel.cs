using System.ComponentModel.DataAnnotations;

namespace MicroXYZ.Areas.AdminPanel.Models
{
    public class AdminLoginViewModel
    {
        [Required(ErrorMessage = "Email Boş Girilemez !")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre Boş Girilemez !")]
        [StringLength(256, ErrorMessage = "Şifreniz En Az 6 Karakter Olmalıdır !", MinimumLength = 6)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
