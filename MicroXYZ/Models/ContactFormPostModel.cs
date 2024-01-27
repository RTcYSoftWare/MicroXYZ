using System.ComponentModel.DataAnnotations;

namespace MicroXYZ.Models
{
    public class ContactFormPostModel
    {
        [Required(ErrorMessage = "Ad Soyad Boş Girilemez !")]
        public string NameSurname { get; set; }

        [Required(ErrorMessage = "Email Boş Girilmez !")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mesaj Boş Girlemez !")]
        public string Message { get; set; }

        [Required(ErrorMessage = "Bir Konu Seçiniz !")]
        public int SubjectId { get; set; }
    }
}